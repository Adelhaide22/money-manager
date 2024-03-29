﻿using Core;
using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class RegexCategoryEditorForm : Form
    {
        public RegexCategoryEditorForm()
        {
            InitializeComponent();
        }

        public void FillInformation(RegexCategory regexCategory)
        {
            textBox_rcapacity.Text = regexCategory.Capacity.ToString();
            textBox_rincrement.Text = regexCategory.Increment.ToString();
            textBox_rname.Text = regexCategory.Name.ToString();
            textBox_rules.Text = DisplayManager.ConvertRulesToTextBoxFormat(regexCategory.Rules);
            ShowDialog();
        }

        public RegexCategory ReadEditedCategory()
        {
            var name = textBox_rname.Text;
            var increment = int.TryParse(textBox_rincrement.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_rcapacity.Text, out int c) ? c : 0;
            var rules = DisplayManager.ConvertTextBoxTextToRules(textBox_rules.Text);

            return new RegexCategory(name, rules, increment, capacity);
        }

        private void btn_SaveRCategory_Click(object sender, EventArgs e)
        {
            var newCategory = ReadEditedCategory();
            StateManager.UpdateCategory(newCategory);
            Close();
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var newCategory = ReadEditedCategory();
                StateManager.UpdateCategory(newCategory);
                Close();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var newCategory = ReadEditedCategory();
            StateManager.DeleteCategory(newCategory);
        }
    }
}
