using Core;
using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class EditTransactionForm : Form
    {
        private readonly Transaction transaction;

        public EditTransactionForm(Transaction transaction)
        {
            this.transaction = transaction;
            InitializeComponent();
        }

        public Transaction ReadEditedTransaction()
        {
            var cardNumber = txtboxCardNumber.Text;
            var category = txtboxCategory.Text;
            var description = txtboxDescription.Text;

            return new Transaction(cardNumber, transaction.Date, transaction.Amount, description, category, transaction.GetHashCode());
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var newTransaction = ReadEditedTransaction();
                StateManager.UpdateTransaction(newTransaction);
                Close();
            }
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            var newTransaction = ReadEditedTransaction();
            StateManager.UpdateTransaction(newTransaction);
            Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var newTransaction = ReadEditedTransaction();
            StateManager.DeleteTransaction(newTransaction);
        } 
    }
}
