
using System;

namespace WinFormsUI
{
    partial class CreateTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_cardnumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.categoriesList = new System.Windows.Forms.ComboBox();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card number";
            // 
            // textBox_cardnumber
            // 
            this.textBox_cardnumber.Location = new System.Drawing.Point(13, 32);
            this.textBox_cardnumber.Name = "textBox_cardnumber";
            this.textBox_cardnumber.Size = new System.Drawing.Size(259, 23);
            this.textBox_cardnumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // monthCalendar
            // 
            this.monthCalendar.CustomFormat = "yyyy.MM.dd";
            this.monthCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthCalendar.Location = new System.Drawing.Point(13, 90);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.Size = new System.Drawing.Size(259, 23);
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount";
            // 
            // textBox_amount
            // 
            this.textBox_amount.Location = new System.Drawing.Point(15, 313);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(259, 23);
            this.textBox_amount.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(15, 376);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_description.Size = new System.Drawing.Size(259, 87);
            this.textBox_description.TabIndex = 7;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(15, 483);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(55, 15);
            this.label.TabIndex = 8;
            this.label.Text = "Category";
            // 
            // categoriesList
            // 
            this.categoriesList.FormattingEnabled = true;
            this.categoriesList.Location = new System.Drawing.Point(15, 503);
            this.categoriesList.Name = "categoriesList";
            this.categoriesList.Size = new System.Drawing.Size(259, 23);
            this.categoriesList.TabIndex = 9;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(106, 542);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // CreateTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 577);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.categoriesList);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_amount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_cardnumber);
            this.Controls.Add(this.label1);
            this.Name = "CreateTransactionForm";
            this.Text = "CreateTransactionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_cardnumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker monthCalendar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label;
        public System.Windows.Forms.ComboBox categoriesList;
        private System.Windows.Forms.Button button_save;
    }
}