using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabSmoothedTrends = new System.Windows.Forms.TabPage();
            this.chartSeriesSmoothed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabCumulativeTrends = new System.Windows.Forms.TabPage();
            this.chartSeriesCumulative = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabLedger = new System.Windows.Forms.TabPage();
            this.lbTransactions = new System.Windows.Forms.ListBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.chboxAllCategories = new System.Windows.Forms.CheckBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblSmoothingRatio = new System.Windows.Forms.Label();
            this.txtboxSmoothingRatio = new System.Windows.Forms.TextBox();
            this.clbCategories = new System.Windows.Forms.CheckedListBox();
            this.button_addCategory = new System.Windows.Forms.Button();
            this.button_editSelectedCategory = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabSmoothedTrends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeriesSmoothed)).BeginInit();
            this.tabCumulativeTrends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeriesCumulative)).BeginInit();
            this.tabLedger.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabSmoothedTrends);
            this.tabs.Controls.Add(this.tabCumulativeTrends);
            this.tabs.Controls.Add(this.tabLedger);
            this.tabs.Location = new System.Drawing.Point(272, 14);
            this.tabs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1189, 758);
            this.tabs.TabIndex = 3;
            // 
            // tabSmoothedTrends
            // 
            this.tabSmoothedTrends.Controls.Add(this.chartSeriesSmoothed);
            this.tabSmoothedTrends.Location = new System.Drawing.Point(4, 24);
            this.tabSmoothedTrends.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabSmoothedTrends.Name = "tabSmoothedTrends";
            this.tabSmoothedTrends.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabSmoothedTrends.Size = new System.Drawing.Size(1181, 730);
            this.tabSmoothedTrends.TabIndex = 1;
            this.tabSmoothedTrends.Text = "Smoothed Trends";
            this.tabSmoothedTrends.UseVisualStyleBackColor = true;
            // 
            // chartSeriesSmoothed
            // 
            chartArea1.Name = "Main Chart Area";
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.LabelStyle.Format = "yyyy.MM.dd";
            this.chartSeriesSmoothed.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend";
            this.chartSeriesSmoothed.Legends.Add(legend1);
            this.chartSeriesSmoothed.Location = new System.Drawing.Point(6, 6);
            this.chartSeriesSmoothed.Name = "chartSeriesSmoothed";
            this.chartSeriesSmoothed.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartSeriesSmoothed.Size = new System.Drawing.Size(999, 619);
            this.chartSeriesSmoothed.TabIndex = 1;
            this.chartSeriesSmoothed.Text = "chartTrends";
            // 
            // tabCumulativeTrends
            // 
            this.tabCumulativeTrends.Controls.Add(this.chartSeriesCumulative);
            this.tabCumulativeTrends.Location = new System.Drawing.Point(4, 24);
            this.tabCumulativeTrends.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCumulativeTrends.Name = "tabCumulativeTrends";
            this.tabCumulativeTrends.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCumulativeTrends.Size = new System.Drawing.Size(1181, 730);
            this.tabCumulativeTrends.TabIndex = 1;
            this.tabCumulativeTrends.Text = "Cumulative Trends";
            this.tabCumulativeTrends.UseVisualStyleBackColor = true;
            // 
            // chartSeriesCumulative
            // 
            chartArea2.Name = "Main Chart Area";
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea2.AxisX.Interval = 1;
            chartArea2.AxisX.LabelStyle.Format = "yyyy.MM.dd";
            this.chartSeriesCumulative.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend";
            this.chartSeriesCumulative.Legends.Add(legend2);
            this.chartSeriesCumulative.Location = new System.Drawing.Point(6, 6);
            this.chartSeriesCumulative.Name = "chartSeriesCumulative";
            this.chartSeriesCumulative.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartSeriesCumulative.Size = new System.Drawing.Size(999, 619);
            this.chartSeriesCumulative.TabIndex = 1;
            this.chartSeriesCumulative.Text = "chartTrends";
            // 
            // tabLedger
            // 
            this.tabLedger.Controls.Add(this.lbTransactions);
            this.tabLedger.Location = new System.Drawing.Point(4, 24);
            this.tabLedger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabLedger.Name = "tabLedger";
            this.tabLedger.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabLedger.Size = new System.Drawing.Size(1181, 730);
            this.tabLedger.TabIndex = 0;
            this.tabLedger.Text = "Ledger";
            this.tabLedger.UseVisualStyleBackColor = true;
            // 
            // lbTransactions
            // 
            this.lbTransactions.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTransactions.FormattingEnabled = true;
            this.lbTransactions.HorizontalScrollbar = true;
            this.lbTransactions.ItemHeight = 22;
            this.lbTransactions.Location = new System.Drawing.Point(7, 7);
            this.lbTransactions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbTransactions.Name = "lbTransactions";
            this.lbTransactions.Size = new System.Drawing.Size(1165, 708);
            this.lbTransactions.TabIndex = 1;
            this.lbTransactions.DoubleClick += new System.EventHandler(this.lb_DoubleClick);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "yyyy.MM.dd";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(14, 99);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(233, 23);
            this.dateTimePickerEnd.TabIndex = 14;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Checked = false;
            this.dateTimePickerStart.CustomFormat = "yyyy.MM.dd";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(14, 40);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(233, 23);
            this.dateTimePickerStart.TabIndex = 13;
            this.dateTimePickerStart.Value = new System.DateTime(2020, 1, 19, 15, 10, 57, 0);
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // chboxAllCategories
            // 
            this.chboxAllCategories.AutoSize = true;
            this.chboxAllCategories.Location = new System.Drawing.Point(13, 546);
            this.chboxAllCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chboxAllCategories.Name = "chboxAllCategories";
            this.chboxAllCategories.Size = new System.Drawing.Size(131, 19);
            this.chboxAllCategories.TabIndex = 12;
            this.chboxAllCategories.Text = "Show All Categories";
            this.chboxAllCategories.CheckedChanged += new System.EventHandler(this.chboxAllCategories_CheckedChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(14, 75);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 15);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "End date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(14, 16);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(57, 15);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Start date";
            //
            // cbxIsOnlyCustom
            //
            this.chboxAllCategories.AutoSize = true;
            this.chboxAllCategories.Location = new System.Drawing.Point(12, 425);
            this.chboxAllCategories.Name = "cbxAllCategories";
            this.chboxAllCategories.Size = new System.Drawing.Size(50, 13);
            this.chboxAllCategories.TabIndex = 12;
            this.chboxAllCategories.Text = "Show All Categories";
            this.chboxAllCategories.Checked = false;
            this.chboxAllCategories.CheckedChanged += new System.EventHandler(this.chboxAllCategories_CheckedChanged);
            // 
            // lblSmoothingRatio
            // 
            this.lblSmoothingRatio.AutoSize = true;
            this.lblSmoothingRatio.Location = new System.Drawing.Point(14, 589);
            this.lblSmoothingRatio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSmoothingRatio.Name = "lblSmoothingRatio";
            this.lblSmoothingRatio.Size = new System.Drawing.Size(96, 15);
            this.lblSmoothingRatio.TabIndex = 11;
            this.lblSmoothingRatio.Text = "Smoothing Ratio";
            // 
            // txtboxSmoothingRatio
            // 
            this.txtboxSmoothingRatio.Location = new System.Drawing.Point(14, 607);
            this.txtboxSmoothingRatio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtboxSmoothingRatio.Name = "txtboxSmoothingRatio";
            this.txtboxSmoothingRatio.Size = new System.Drawing.Size(108, 23);
            this.txtboxSmoothingRatio.TabIndex = 11;
            this.txtboxSmoothingRatio.Text = "0.99";
            this.txtboxSmoothingRatio.TextChanged += new System.EventHandler(this.txtboxSmoothingRatio_TextChanged);
            // 
            // clbCategories
            // 
            this.clbCategories.CheckOnClick = true;
            this.clbCategories.FormattingEnabled = true;
            this.clbCategories.Location = new System.Drawing.Point(14, 162);
            this.clbCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clbCategories.Name = "clbCategories";
            this.clbCategories.Size = new System.Drawing.Size(233, 310);
            this.clbCategories.TabIndex = 15;
            // 
            // button_addCategory
            // 
            this.button_addCategory.Location = new System.Drawing.Point(14, 479);
            this.button_addCategory.Name = "button_addCategory";
            this.button_addCategory.Size = new System.Drawing.Size(233, 23);
            this.button_addCategory.TabIndex = 16;
            this.button_addCategory.Text = "Add category";
            this.button_addCategory.UseVisualStyleBackColor = true;
            this.button_addCategory.Click += new System.EventHandler(this.button_addCategory_Click);
            // 
            // button_editSelectedCategory
            // 
            this.button_editSelectedCategory.Location = new System.Drawing.Point(14, 508);
            this.button_editSelectedCategory.Name = "button_editSelectedCategory";
            this.button_editSelectedCategory.Size = new System.Drawing.Size(233, 23);
            this.button_editSelectedCategory.TabIndex = 17;
            this.button_editSelectedCategory.Text = "Edit selected category";
            this.button_editSelectedCategory.UseVisualStyleBackColor = true;
            this.button_editSelectedCategory.Click += new System.EventHandler(this.button_editSelectedCategory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 786);
            this.Controls.Add(this.button_editSelectedCategory);
            this.Controls.Add(this.button_addCategory);
            this.Controls.Add(this.clbCategories);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblSmoothingRatio);
            this.Controls.Add(this.txtboxSmoothingRatio);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.chboxAllCategories);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Money Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabSmoothedTrends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSeriesSmoothed)).EndInit();
            this.tabCumulativeTrends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSeriesCumulative)).EndInit();

            this.tabLedger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeriesCumulative;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeriesSmoothed;
        private System.Windows.Forms.CheckedListBox clbCategories;
        private System.Windows.Forms.CheckBox chboxAllCategories;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblSmoothingRatio;
        private System.Windows.Forms.TextBox txtboxSmoothingRatio;
        private System.Windows.Forms.ListBox lbTransactions;
        private System.Windows.Forms.TabPage tabCumulativeTrends;
        private System.Windows.Forms.TabPage tabLedger;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabSmoothedTrends;
        private Button button_addCategory;
        private Button button_editSelectedCategory;

        #endregion
    }
}