using Core;
using Core.Categories;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class CreateTransactionForm : Form
    {
        public CreateTransactionForm()
        {
            InitializeComponent();
        }

        public Transaction CreateTransaction()
        {
            var _orderedCategories = State.Instance.Categories
                .OrderBy(c => c, new CategoriesOrderer())
                .ToArray();

            var cardNumber = textBox_cardnumber.Text;
            var date = Date.TryParse(monthCalendar.Value.ToString(), out Date d) ? d : Date.Today;
            var amount = new Money(double.TryParse(textBox_amount.Text, out double a) ? a : 0, Currency.UAH);
            var description = textBox_description.Text;
            var category = _orderedCategories[categoriesList.SelectedIndex].Name;

            return new Transaction(cardNumber, date, amount, description, category);
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var newTransaction = CreateTransaction();
                StateManager.UpdateStateWithNewTransaction(newTransaction);
                Close();
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            var newTransaction = CreateTransaction();
            StateManager.UpdateStateWithNewTransaction(newTransaction);
            Close();
        }
    }
}
