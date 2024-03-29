﻿using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    partial class EditTransactionForm
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
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtboxCardNumber = new System.Windows.Forms.TextBox();
            this.txtboxCategory = new System.Windows.Forms.TextBox();
            this.txtboxDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(20, 10);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(79, 15);
            this.lblCardNumber.TabIndex = 11;
            this.lblCardNumber.Text = "Card Number";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 80);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 205);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            // 
            // txtboxCardNumber
            // 
            this.txtboxCardNumber.Location = new System.Drawing.Point(20, 40);
            this.txtboxCardNumber.Name = "txtboxCardNumber";
            this.txtboxCardNumber.Size = new System.Drawing.Size(360, 23);
            this.txtboxCardNumber.TabIndex = 11;
            this.txtboxCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // txtboxCategory
            // 
            this.txtboxCategory.Location = new System.Drawing.Point(20, 110);
            this.txtboxCategory.Multiline = true;
            this.txtboxCategory.Name = "txtboxCategory";
            this.txtboxCategory.Size = new System.Drawing.Size(360, 70);
            this.txtboxCategory.TabIndex = 11;
            this.txtboxCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // txtboxDescription
            // 
            this.txtboxDescription.Location = new System.Drawing.Point(20, 235);
            this.txtboxDescription.Multiline = true;
            this.txtboxDescription.Name = "txtboxDescription";
            this.txtboxDescription.Size = new System.Drawing.Size(360, 85);
            this.txtboxDescription.TabIndex = 11;
            this.txtboxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Clicked);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(305, 350);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 13;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // EditTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtboxCardNumber);
            this.Controls.Add(this.txtboxCategory);
            this.Controls.Add(this.txtboxDescription);
            this.Controls.Add(this.btnSave);
            this.Name = "EditTransactionForm";
            this.Text = "TransactionEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.Label lblCardNumber;
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.TextBox txtboxCardNumber;
        public System.Windows.Forms.TextBox txtboxCategory;
        public System.Windows.Forms.TextBox txtboxDescription;
        public System.Windows.Forms.Button btnSave;
        #endregion

        private Button button_delete;
    }
}