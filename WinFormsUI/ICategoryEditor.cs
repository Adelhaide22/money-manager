﻿using Core.Categories;
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
        void SaveEditedCategory(); // todo thibk about better signature and reusability
    }
}
