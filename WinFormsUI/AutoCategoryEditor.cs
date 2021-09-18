 using Core;
using Core.Categories;
using System;
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

        public T? ReadEditedCategory<T>() where T : Category
        {
            var capacity = int.TryParse(textBox_acapacity.Text, out int c) ? c : 0;
            var category = textBox_acategory.Text;
            var name = textBox_aname.Text;
            var increment = int.TryParse(textBox_aincrement.Text, out int i) ? i : 0;

            return new AutoCategory(name, increment, capacity, category) as T;
        }

        private void btn_SaveACategory_Click(object sender, EventArgs e)
        {
            var newCategory = ReadEditedCategory<AutoCategory>();
            if (newCategory is not null)
            {
                StateManager.UpdateCategory(newCategory);
            }

            Close();
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var newCategory = ReadEditedCategory<AutoCategory>();
                if (newCategory is not null)
                {
                    StateManager.UpdateCategory(newCategory);
                }

                Close();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var newCategory = ReadEditedCategory<AutoCategory>();
            if (newCategory is not null)
            {
                StateManager.DeleteCategory(newCategory);
            }
        }
    }
}
