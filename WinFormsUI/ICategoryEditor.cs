using Core.Categories;

namespace WinFormsUI
{
    interface ICategoryEditor
    {
        void FillInformation<T>(T category) where T: Category;
        T? ReadEditedCategory<T>() where T : Category;
    }
}
