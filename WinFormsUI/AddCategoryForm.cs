using Core;
using Core.Categories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void categoryTypesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = categoryTypesList.SelectedItem.ToString();

            var name = textBox_name.Text;
            var increment = int.TryParse(textBox_increment.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_capacity.Text, out int c) ? c : 0;

            if (selectedItem == nameof(AutoCategory))
            {
                textBox_category.Enabled = true;
                textBox_rules.Enabled = false;
                textBox_categories.Enabled = false;

                textBox_rules.PlaceholderText = string.Empty;
                textBox_categories.PlaceholderText = string.Empty;
            }
            if (selectedItem == nameof(RegexCategory))
            {
                textBox_rules.Enabled = true;
                textBox_category.Enabled = false;
                textBox_categories.Enabled = false;

                textBox_categories.PlaceholderText = string.Empty;

                textBox_rules.ScrollBars = ScrollBars.Vertical;
                textBox_rules.PlaceholderText = DisplayManager.ConvertRulesToTextBoxFormat(new List<Rule>() { new Rule("*.", "*", "*.", "*.")});
            }
            if (selectedItem == nameof(CompositeCategory))
            {
                textBox_categories.Enabled = true;
                textBox_rules.Enabled = false;
                textBox_category.Enabled = false;

                textBox_rules.PlaceholderText = string.Empty;

                textBox_categories.ScrollBars = ScrollBars.Vertical;
                textBox_categories.PlaceholderText = DisplayManager.ConvertListToTextBoxFormat(new List<string>() { "[Auto] CategoryName1", "[Auto] CategoryName2" });
            }
        }

        public void SaveAddedCategory()
        {
            var name = textBox_name.Text;
            var increment = int.TryParse(textBox_increment.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_capacity.Text, out int c) ? c : 0;

            if (textBox_category.Enabled)
            {
                var category = textBox_category.Text;
                var autoCategory = new AutoCategory(name, increment, capacity, category);

                StateManager.UpdateStateWithNewCategory(autoCategory);
            }
            if (textBox_rules.Enabled)
            {
                var rules = DisplayManager.ConvertTextBoxTextToRules(textBox_rules.Text);
                var regexCategory = new RegexCategory(name, rules, increment, capacity);

                StateManager.UpdateStateWithNewCategory(regexCategory);
            }
            if (textBox_categories.Enabled)
            {
                var categories = DisplayManager.ConvertTextBoxTextToList(textBox_categories.Text);
                var compositeCategory = new CompositeCategory(name, increment, capacity, categories);

                StateManager.UpdateStateWithNewCategory(compositeCategory);
            }           
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveAddedCategory();
                Close();
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveAddedCategory();
            Close();
        }
    }
}
