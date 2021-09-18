using Core;
using Core.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class RegexCategoryEditorForm : Form, ICategoryEditor
    {
        public RegexCategoryEditorForm()
        {
            InitializeComponent();
        }

        public void FillInformation<T>(T category) where T : Category
        {
            if (category is not RegexCategory regexCategory)
            {
                throw new ArgumentNullException("Argument type is not RegexCategory");
            }
            textBox_rcapacity.Text = regexCategory.Capacity.ToString();
            textBox_rincrement.Text = regexCategory.Increment.ToString();
            textBox_rname.Text = regexCategory.Name.ToString();
            textBox_rules.Text = DisplayManager.DisplayRules(regexCategory.Rules);
            ShowDialog();
        }

        public void SaveEditedCategory()
        {
            var name = textBox_rname.Text;
            var increment = int.TryParse(textBox_rincrement.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_rcapacity.Text, out int c) ? c : 0;
            var rules = DisplayManager.ReadRules(textBox_rules.Text);

            var newCategory = new RegexCategory(name, rules, increment, capacity);

            StateManager.UpdateCategory(newCategory);
        }

        private void btn_SaveRCategory_Click(object sender, EventArgs e)
        {
            SaveEditedCategory();
            Close();
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveEditedCategory();
                Close();
            }
        }
    }
}
