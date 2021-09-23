
namespace WinFormsUI
{
    partial class AddCategoryForm
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
            this.lbl_categoryType = new System.Windows.Forms.Label();
            this.categoryTypesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_increment = new System.Windows.Forms.TextBox();
            this.label_increment = new System.Windows.Forms.Label();
            this.textBox_capacity = new System.Windows.Forms.TextBox();
            this.label_capacity = new System.Windows.Forms.Label();
            this.label_category = new System.Windows.Forms.Label();
            this.textBox_category = new System.Windows.Forms.TextBox();
            this.textBox_categories = new System.Windows.Forms.TextBox();
            this.label_categories = new System.Windows.Forms.Label();
            this.textBox_rules = new System.Windows.Forms.TextBox();
            this.label_rules = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_categoryType
            // 
            this.lbl_categoryType.AutoSize = true;
            this.lbl_categoryType.Location = new System.Drawing.Point(13, 13);
            this.lbl_categoryType.Name = "lbl_categoryType";
            this.lbl_categoryType.Size = new System.Drawing.Size(113, 15);
            this.lbl_categoryType.TabIndex = 0;
            this.lbl_categoryType.Text = "Select category type";
            // 
            // comboBox1
            // 
            this.categoryTypesList.FormattingEnabled = true;
            this.categoryTypesList.Location = new System.Drawing.Point(13, 35);
            this.categoryTypesList.Name = "categoryTypesList";
            this.categoryTypesList.Size = new System.Drawing.Size(266, 23);
            this.categoryTypesList.TabIndex = 1;
            this.categoryTypesList.SelectedIndexChanged += new System.EventHandler(this.categoryTypesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(12, 92);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(122, 23);
            this.textBox_name.TabIndex = 3;
            // 
            // textBox_increment
            // 
            this.textBox_increment.Location = new System.Drawing.Point(13, 151);
            this.textBox_increment.Name = "textBox_increment";
            this.textBox_increment.Size = new System.Drawing.Size(122, 23);
            this.textBox_increment.TabIndex = 5;
            // 
            // label_increment
            // 
            this.label_increment.AutoSize = true;
            this.label_increment.Location = new System.Drawing.Point(13, 131);
            this.label_increment.Name = "label_increment";
            this.label_increment.Size = new System.Drawing.Size(61, 15);
            this.label_increment.TabIndex = 4;
            this.label_increment.Text = "Increment";
            // 
            // textBox_capacity
            // 
            this.textBox_capacity.Location = new System.Drawing.Point(157, 151);
            this.textBox_capacity.Name = "textBox_capacity";
            this.textBox_capacity.Size = new System.Drawing.Size(122, 23);
            this.textBox_capacity.TabIndex = 7;
            // 
            // label_capacity
            // 
            this.label_capacity.AutoSize = true;
            this.label_capacity.Location = new System.Drawing.Point(157, 131);
            this.label_capacity.Name = "label_capacity";
            this.label_capacity.Size = new System.Drawing.Size(53, 15);
            this.label_capacity.TabIndex = 6;
            this.label_capacity.Text = "Capacity";
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Location = new System.Drawing.Point(13, 215);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(55, 15);
            this.label_category.TabIndex = 8;
            this.label_category.Text = "Category";
            // 
            // textBox_category
            // 
            this.textBox_category.Enabled = false;
            this.textBox_category.Location = new System.Drawing.Point(13, 238);
            this.textBox_category.Name = "textBox_category";
            this.textBox_category.Size = new System.Drawing.Size(266, 23);
            this.textBox_category.TabIndex = 9;
            // 
            // textBox_categories
            // 
            this.textBox_categories.Enabled = false;
            this.textBox_categories.Location = new System.Drawing.Point(13, 300);
            this.textBox_categories.Multiline = true;
            this.textBox_categories.Name = "textBox_categories";
            this.textBox_categories.Size = new System.Drawing.Size(266, 86);
            this.textBox_categories.TabIndex = 11;
            // 
            // label_categories
            // 
            this.label_categories.AutoSize = true;
            this.label_categories.Location = new System.Drawing.Point(13, 277);
            this.label_categories.Name = "label_categories";
            this.label_categories.Size = new System.Drawing.Size(63, 15);
            this.label_categories.TabIndex = 10;
            this.label_categories.Text = "Categories";
            // 
            // textBox_rules
            // 
            this.textBox_rules.Enabled = false;
            this.textBox_rules.Location = new System.Drawing.Point(13, 428);
            this.textBox_rules.Multiline = true;
            this.textBox_rules.Name = "textBox_rules";
            this.textBox_rules.Size = new System.Drawing.Size(266, 127);
            this.textBox_rules.TabIndex = 13;
            // 
            // label_rules
            // 
            this.label_rules.AutoSize = true;
            this.label_rules.Location = new System.Drawing.Point(13, 405);
            this.label_rules.Name = "label_rules";
            this.label_rules.Size = new System.Drawing.Size(35, 15);
            this.label_rules.TabIndex = 12;
            this.label_rules.Text = "Rules";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(108, 573);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 14;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 610);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_rules);
            this.Controls.Add(this.label_rules);
            this.Controls.Add(this.textBox_categories);
            this.Controls.Add(this.label_categories);
            this.Controls.Add(this.textBox_category);
            this.Controls.Add(this.label_category);
            this.Controls.Add(this.textBox_capacity);
            this.Controls.Add(this.label_capacity);
            this.Controls.Add(this.textBox_increment);
            this.Controls.Add(this.label_increment);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryTypesList);
            this.Controls.Add(this.lbl_categoryType);
            this.Name = "AddCategoryForm";
            this.Text = "AddCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_categoryType;
        internal System.Windows.Forms.ComboBox categoryTypesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_increment;
        private System.Windows.Forms.Label label_increment;
        private System.Windows.Forms.TextBox textBox_capacity;
        private System.Windows.Forms.Label label_capacity;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.TextBox textBox_category;
        private System.Windows.Forms.TextBox textBox_categories;
        private System.Windows.Forms.Label label_categories;
        private System.Windows.Forms.TextBox textBox_rules;
        private System.Windows.Forms.Label label_rules;
        private System.Windows.Forms.Button button_save;
    }
}