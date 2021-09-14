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
            throw new NotImplementedException();
        }

        public void SaveEditedCategory()
        {
            throw new NotImplementedException();
        }

        private void btn_SaveRCategory_Click(object sender, EventArgs e)
        {

        }
    }
}
