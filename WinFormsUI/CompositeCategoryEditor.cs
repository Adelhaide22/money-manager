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
    public partial class CompositeCategoryEditorForm : Form, ICategoryEditor
    {
        public CompositeCategoryEditorForm()
        {
            InitializeComponent();
        }

        public void FillInformation<T>(T category) where T : Category
        {
            if (category is not CompositeCategory compositeCategory)
            {
                throw new ArgumentNullException("Argument type is not CompositeCategory");
            }
            textBox_ccapacity.Text = compositeCategory.Capacity.ToString();
            textBox_cincrement.Text = compositeCategory.Increment.ToString();
            textBox_cname.Text = compositeCategory.Name.ToString();
            textBox_ccategories.Text = DisplayManager.DisplayList(compositeCategory.Categories);
            ShowDialog();
        }

        public void SaveEditedCategory()
        {
            var name = textBox_cname.Text;
            var increment = int.TryParse(textBox_cincrement.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_ccapacity.Text, out int c) ? c : 0;
            var categories = DisplayManager.ReadList(textBox_ccategories.Text);

            var newCategory = new CompositeCategory(name, increment, capacity, categories);

            StateManager.UpdateCategory(newCategory);
        }

        private void btn_SaveCCategory_Click(object sender, EventArgs e)
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
