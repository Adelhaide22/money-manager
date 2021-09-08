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

        public void SaveEditedTransaction()
        {
            var cardNumber = txtboxCardNumber.Text;
            var category = txtboxCategory.Text;
            var description = txtboxDescription.Text;

            var newTransaction = new Transaction(cardNumber, transaction.Date, transaction.Amount, description, category, transaction.GetHashCode());

            StateManager.UpdateTransaction(newTransaction);
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveEditedTransaction();
                Close();
            }
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            SaveEditedTransaction();
            Close();
        }
    }
}
