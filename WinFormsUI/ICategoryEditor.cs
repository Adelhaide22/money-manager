using Core.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsUI
{
    interface ICategoryEditor
    {
        void FillInformation<T>(T category) where T: Category;
        T? ReadEditedCategory<T>() where T : Category;
    }
}
