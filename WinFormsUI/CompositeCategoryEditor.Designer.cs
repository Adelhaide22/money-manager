﻿
namespace WinFormsUI
{
    partial class CompositeCategoryEditorForm
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_cname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_cincrement = new System.Windows.Forms.TextBox();
            this.textBox_ccapacity = new System.Windows.Forms.TextBox();
            this.label_capacity = new System.Windows.Forms.Label();
            this.btn_SaveCCategory = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.textBox_ccategories = new System.Windows.Forms.TextBox();
            this.label3_category = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBox_cname
            // 
            this.textBox_cname.Enabled = false;
            this.textBox_cname.Location = new System.Drawing.Point(24, 40);
            this.textBox_cname.Name = "textBox_cname";
            this.textBox_cname.Size = new System.Drawing.Size(254, 23);
            this.textBox_cname.TabIndex = 3;
            this.textBox_cname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Increment";
            // 
            // textBox_cincrement
            // 
            this.textBox_cincrement.Location = new System.Drawing.Point(24, 98);
            this.textBox_cincrement.Name = "textBox_cincrement";
            this.textBox_cincrement.Size = new System.Drawing.Size(254, 23);
            this.textBox_cincrement.TabIndex = 5;
            this.textBox_cincrement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // textBox_ccapacity
            // 
            this.textBox_ccapacity.Location = new System.Drawing.Point(24, 158);
            this.textBox_ccapacity.Name = "textBox_ccapacity";
            this.textBox_ccapacity.Size = new System.Drawing.Size(254, 23);
            this.textBox_ccapacity.TabIndex = 7;
            this.textBox_ccapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // label_capacity
            // 
            this.label_capacity.AutoSize = true;
            this.label_capacity.Location = new System.Drawing.Point(24, 140);
            this.label_capacity.Name = "label_capacity";
            this.label_capacity.Size = new System.Drawing.Size(53, 15);
            this.label_capacity.TabIndex = 6;
            this.label_capacity.Text = "Capacity";
            // 
            // btn_SaveCCategory
            // 
            this.btn_SaveCCategory.Location = new System.Drawing.Point(172, 404);
            this.btn_SaveCCategory.Name = "btn_SaveCCategory";
            this.btn_SaveCCategory.Size = new System.Drawing.Size(106, 23);
            this.btn_SaveCCategory.TabIndex = 8;
            this.btn_SaveCCategory.Text = "Save changes";
            this.btn_SaveCCategory.UseVisualStyleBackColor = true;
            this.btn_SaveCCategory.Click += new System.EventHandler(this.btn_SaveCCategory_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(24, 404);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(106, 23);
            this.button_delete.TabIndex = 11;
            this.button_delete.Text = "Delete category";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // textBox_ccategories
            // 
            this.textBox_ccategories.AcceptsReturn = true;
            this.textBox_ccategories.AcceptsTab = true;
            this.textBox_ccategories.Location = new System.Drawing.Point(24, 222);
            this.textBox_ccategories.Multiline = true;
            this.textBox_ccategories.Name = "textBox_ccategories";
            this.textBox_ccategories.Size = new System.Drawing.Size(254, 157);
            this.textBox_ccategories.TabIndex = 10;
            this.textBox_ccategories.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // label3_category
            // 
            this.label3_category.AutoSize = true;
            this.label3_category.Location = new System.Drawing.Point(24, 204);
            this.label3_category.Name = "label3_category";
            this.label3_category.Size = new System.Drawing.Size(63, 15);
            this.label3_category.TabIndex = 9;
            this.label3_category.Text = "Categories";
            // 
            // CompositeCategoryEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.textBox_ccategories);
            this.Controls.Add(this.label3_category);
            this.Controls.Add(this.btn_SaveCCategory);
            this.Controls.Add(this.textBox_ccapacity);
            this.Controls.Add(this.label_capacity);
            this.Controls.Add(this.textBox_cincrement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_cname);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label1);
            this.Name = "CompositeCategoryEditorForm";
            this.Text = "CategoryEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_cname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_cincrement;
        private System.Windows.Forms.TextBox textBox_ccapacity;
        private System.Windows.Forms.Label label_capacity;
        private System.Windows.Forms.Button btn_SaveCCategory;
        private System.Windows.Forms.TextBox textBox_ccategories;
        private System.Windows.Forms.Label label3_category;
        private System.Windows.Forms.Button button_delete;
    }
}