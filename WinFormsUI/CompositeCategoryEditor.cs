using Core;
using Core.Categories;
using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class CompositeCategoryEditorForm : Form
    {
        public CompositeCategoryEditorForm()
        {
            InitializeComponent();
        }

        public void FillInformation(CompositeCategory compositeCategory)
        {
            textBox_ccapacity.Text = compositeCategory.Capacity.ToString();
            textBox_cincrement.Text = compositeCategory.Increment.ToString();
            textBox_cname.Text = compositeCategory.Name.ToString();
            textBox_ccategories.Text = DisplayManager.ConvertListToTextBoxFormat(compositeCategory.Categories);
            ShowDialog();
        }

        public CompositeCategory ReadEditedCategory()
        {
            var name = textBox_cname.Text;
            var increment = int.TryParse(textBox_cincrement.Text, out int i) ? i : 0;
            var capacity = int.TryParse(textBox_ccapacity.Text, out int c) ? c : 0;
            var categories = DisplayManager.ConvertTextBoxTextToList(textBox_ccategories.Text);

            return new CompositeCategory(name, increment, capacity, categories);
        }

        private void btn_SaveCCategory_Click(object sender, EventArgs e)
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
