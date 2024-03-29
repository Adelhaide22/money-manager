﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Core;
using Core.Categories;
using Core.Helpers;

namespace WinFormsUI
{
    public partial class MainForm : Form
    {
        private Date startDate, endDate;
        private double smoothingRatio;
        private Category[] _orderedCategories = Array.Empty<Category>();
        private int _listPosition;

        public MainForm() => InitializeComponent();
        private event Action OnFilteringUpdated = () => { };
        private IRepository repository = new FileRepository();

        private void MainForm_Load(object sender, EventArgs e)
        {
            var cts = new CancellationTokenSource();
            clbCategories.ItemCheck += async (o, e) =>
            {
                // No lock here because this code only executes in
                // UI thread, which means critical section cannot
                // be executed in different threads simultaneously
                cts.Cancel();
                cts = new CancellationTokenSource();
                var ct = cts.Token;

                const int debounceDelayMs = 100;
                await Task.Delay(debounceDelayMs);
                if (ct.IsCancellationRequested)
                {
                    return;
                }

                OnFilteringUpdated();
            };

            dateTimePickerStart.Value = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            dateTimePickerEnd.Value = DateTime.Now.Date;
            txtboxSmoothingRatio_TextChanged(sender, e);

            repository = new FileRepository();

            LoadCategories();
            LoadTransactions();

            OnFilteringUpdated += RefreshList;
            OnFilteringUpdated += RefreshChart;
            OnFilteringUpdated += RestoreScrollPosition;
            State.OnStateChanged += repository.SaveUpdatedTransactions;
            State.OnStateChanged += RefreshCategories;
            State.OnStateChanged += RefreshList;
            State.OnStateChanged += RefreshChart;

            repository.SaveUpdatedTransactions();
            repository.SaveAutoCategories(State.Instance.Categories.Where(c => c is AutoCategory).Cast<AutoCategory>().AsEnumerable());
            
            RefreshCategories();
            RefreshList();
            RefreshChart();
        }

        private void MainForm_Closing(object sender, EventArgs e)
        {
            repository.SaveAutoCategories(State.Instance.Categories.Where(c => c is AutoCategory).Cast<AutoCategory>().AsEnumerable());
            repository.SaveCompositeCategories(State.Instance.Categories.Where(c => c is CompositeCategory).Cast<CompositeCategory>().AsEnumerable());
            repository.SaveRegexCategories(State.Instance.Categories.Where(c => c is RegexCategory).Cast<RegexCategory>().AsEnumerable());
        }

        private void RestoreScrollPosition()
        {
            lbTransactions.SelectedIndex = _listPosition < lbTransactions.Items.Count ? _listPosition : -1;
        }

        private void LoadCategories()
        {
            var regexCategories = repository.GetRegexCategories();
            var autoCategories = repository.GetAutoCategories();
            var compositeCategories = repository.GetCompositeCategories();

            StateManager.LoadCategories(regexCategories, autoCategories, compositeCategories);
        }
        
        private void LoadTransactions()
        {
            var filesUsb = repository.GetUsbFiles();
            var filesPb = repository.GetPbFiles();
            var filesKb = repository.GetKbFiles();

            var modifiedTransactions = repository.GetTransactions();

            StateManager.LoadTransactions(filesUsb.Concat(filesPb).Concat(filesKb), modifiedTransactions); // todo to repository
        }

        private void RefreshCategories()
        {
            var isFirstLoad = clbCategories.Items.Count == 0;

            var selectedCategories = clbCategories.CheckedIndices
                .Cast<int>()
                .Select(i => _orderedCategories[i].Name)
                .ToList();

            clbCategories.Items.Clear();

            _orderedCategories = State.Instance.Categories
                .OrderBy(c => c, new CategoriesOrderer())
                .ToArray();
            
            string categoryWithPrefix = string.Empty;
            var indicesToCheck = new List<int>();

            for (int i = 0; i < _orderedCategories.Length; i++)
            {
                var c = _orderedCategories[i];
                var timeSeries = TimeSeriesHelper.GetCumulativeTimeSeries(c.Name, c.Increment, c.Capacity);
                var todayData = timeSeries[Date.Today];
                var todayRelative = todayData / c.Capacity;

                var level = LevelsHelper.GetLevel(todayRelative);
                categoryWithPrefix = DisplayManager.GetPrefix(level) + c.Name;

                clbCategories.Items.Add(categoryWithPrefix);

                if (selectedCategories.FirstOrDefault(sc => sc == _orderedCategories[i].Name) != null)
                {
                    indicesToCheck.Add(i);
                }
            }

            foreach (var i in indicesToCheck)
            {
                clbCategories.SetItemChecked(i, true);
            }

            if (isFirstLoad)
            {
                clbCategories.SetItemChecked(0, true);
            }
        }

        private void RefreshList()
        {
            lbTransactions.Items.Clear();

            var displayedTransactions = GetTransactionsToDisplay();

            lbTransactions.Items.AddRange(displayedTransactions
                .Select(t =>
                {
                    var categories = chboxAllCategories.Checked
                        ? State.Instance.GetAllMatchingCategories(t)
                        : State.Instance.GetAllMatchingCategoriesOfType<CompositeCategory>(t);
                    return DisplayManager.FormatLedgerRecord(t, categories);
                })
                .ToArray());
        }

        private Transaction[] GetTransactionsToDisplay()
        {
            var categoriesNames = clbCategories.CheckedIndices
                .Cast<int>()
                .Select(i => _orderedCategories[i].Name);          

            return TransactionsHelper.GetTransactionsUnion(
                          categoriesNames,
                          startDate,
                          endDate).Reverse().ToArray();
        }

        private void RefreshChart()
        {
            chartSeriesSmoothed.Series.Clear();
            chartSeriesCumulative.Series.Clear();
            
            var selectedCategories = clbCategories.CheckedIndices
                .Cast<int>()
                .Select(i => _orderedCategories[i].Name);

            var smoothedSeriesToRemove = chartSeriesSmoothed.Series.Where(s => selectedCategories.All(c => c != s.Name));
            var cumulativeSeriesToRemove = chartSeriesCumulative.Series.Where(s => selectedCategories.All(c => c != s.Name));

            foreach (var s in smoothedSeriesToRemove)
            {
                chartSeriesSmoothed.Series.Remove(s);
            }

            foreach (var s in cumulativeSeriesToRemove)
            {
                chartSeriesCumulative.Series.Remove(s);
            }

            foreach (var c in selectedCategories)
            {
                if (chartSeriesSmoothed.Series.FindByName(c) is null)
                {
                    var newSeries = new Series
                    {
                        Name = c,
                        ChartType = SeriesChartType.Line
                    };
                    chartSeriesSmoothed.Series.Add(newSeries);
                }

                if (chartSeriesCumulative.Series.FindByName(c) is null)
                {
                    var newSeries = new Series
                    {
                        Name = c,
                        ChartType = SeriesChartType.Line
                    };
                    chartSeriesCumulative.Series.Add(newSeries);
                }

                var smoothedSeries = chartSeriesSmoothed.Series.FindByName(c);
                smoothedSeries.Points.Clear();

                var cumulativeSeries = chartSeriesCumulative.Series.FindByName(c);
                cumulativeSeries.Points.Clear();

                var name = c.Replace($"({Levels.Empty}) ", "")
                    .Replace($"({Levels.Low}) ", "")
                    .Replace($"({Levels.Full}) ", "");
                
                var category = State.Instance.Categories.First(category => category.Name == name);
                var smoothedTimeSeries = TimeSeriesHelper.GetSmoothedTimeSeries(name, smoothingRatio);
                var cumulativeTimeSeries = TimeSeriesHelper.GetCumulativeTimeSeries(name, category.Increment, category.Capacity);

                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    _ = smoothedSeries.Points.AddXY(date.ToString(), smoothedTimeSeries[date]);
                }

                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    _ = cumulativeSeries.Points.AddXY(date.ToString(), cumulativeTimeSeries[date]);
                }
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            startDate = dateTimePickerStart.Value.ToDate();
            OnFilteringUpdated();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            endDate = dateTimePickerEnd.Value.ToDate();
            OnFilteringUpdated();
        }

        private void txtboxSmoothingRatio_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtboxSmoothingRatio.Text, out var newSmoothingRatio)
                && newSmoothingRatio <= 1 && newSmoothingRatio >= 0)
            {
                smoothingRatio = newSmoothingRatio;
                OnFilteringUpdated();
            }
        }

        private void chboxAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button_addCategory_Click(object sender, EventArgs e)
        {
            var form = new AddCategoryForm();
            form.categoryTypesList.Items.AddRange(new string[] { nameof(AutoCategory), nameof(RegexCategory), nameof(CompositeCategory)});
            form.ShowDialog();

            RefreshCategories();
        }

        private void button_editSelectedCategory_Click(object sender, EventArgs e)
        {
            var categoriesToEdit = clbCategories.CheckedIndices
                .Cast<int>()
                .Select(i => _orderedCategories[i])
                .ToList();

            foreach (var category in categoriesToEdit)
            {
                switch (category)
                {
                    case AutoCategory autoCategory:
                        var autoEditor = new AutoCategoryEditorForm();                        
                        autoEditor.FillInformation(autoCategory);
                        break;
                    case RegexCategory regexCategory:
                        var regexEditor = new RegexCategoryEditorForm();                        
                        regexEditor.FillInformation(regexCategory);
                        break;
                    case CompositeCategory compositeCategory:
                        var compositeEditor = new CompositeCategoryEditorForm();
                        compositeEditor.FillInformation(compositeCategory);
                        break;
                    default:
                        break;
                }
            }

            RefreshCategories();
        }

        private void button_addTransaction_Click(object sender, EventArgs e)
        {
            var form = new CreateTransactionForm();
            form.categoriesList.Items.AddRange(_orderedCategories.OfType<CompositeCategory>().Select(c => c.Name).ToArray());
            form.ShowDialog();
        }

        private void lb_DoubleClick(object sender, EventArgs e)
        {
            _listPosition = lbTransactions.SelectedIndex;

            var transactionRecordIndex = lbTransactions.SelectedIndex;
            var transaction = GetTransactionsToDisplay()[transactionRecordIndex];

            var transactionEditor = new EditTransactionForm(transaction);
            transactionEditor.txtboxCardNumber.Text = transaction.CardNumber;
            transactionEditor.txtboxCategory.Text = transaction.Category;
            transactionEditor.txtboxDescription.Text = transaction.Description;
            transactionEditor.ShowDialog();
        }

        private void lb_Select(object sender, EventArgs e)
        {
            _listPosition = lbTransactions.SelectedIndex;
        }
    }
}
