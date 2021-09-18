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
    public partial class AutoCategoryEditorForm : Form, ICategoryEditor
    {
        public AutoCategoryEditorForm()
        {
            InitializeComponent();
        }

        public void FillInformation<T>(T category) where T : Category
        {
            if (category is not AutoCategory autoCategory)
            {
                throw new ArgumentNullException("Argument type is not AutoCategory");
            }
            textBox_acapacity.Text = autoCategory.Capacity.ToString();
            textBox_aincrement.Text = autoCategory.Increment.ToString();
            textBox_aname.Text = autoCategory.Name.ToString();
            textBox_acategory.Text = autoCategory.Category.ToString();
            ShowDialog();
        }

        public void SaveEditedCategory()
        {
            var capacity = int.TryParse(textBox_acapacity.Text, out int c) ? c : 0;
            var category = textBox_acategory.Text;
            var name = textBox_aname.Text;
            var increment = int.TryParse(textBox_aincrement.Text, out int i) ? i : 0;

            var newCategory = new AutoCategory(name, increment, capacity, category);

            StateManager.UpdateCategory(newCategory);
        }

        private void btn_SaveACategory_Click(object sender, EventArgs e)
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
