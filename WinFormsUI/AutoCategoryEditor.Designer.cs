
namespace WinFormsUI
{
    partial class AutoCategoryEditor
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
            this.textBox_aname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_aincrement = new System.Windows.Forms.TextBox();
            this.textBox_acapacity = new System.Windows.Forms.TextBox();
            this.label_capacity = new System.Windows.Forms.Label();
            this.btn_SaveACategory = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            // textBox_aname
            // 
            this.textBox_aname.Location = new System.Drawing.Point(24, 40);
            this.textBox_aname.Name = "textBox_aname";
            this.textBox_aname.Size = new System.Drawing.Size(254, 23);
            this.textBox_aname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Increment";
            // 
            // textBox_aincrement
            // 
            this.textBox_aincrement.Location = new System.Drawing.Point(24, 225);
            this.textBox_aincrement.Name = "textBox_aincrement";
            this.textBox_aincrement.Size = new System.Drawing.Size(254, 23);
            this.textBox_aincrement.TabIndex = 5;
            // 
            // textBox_acapacity
            // 
            this.textBox_acapacity.Location = new System.Drawing.Point(24, 158);
            this.textBox_acapacity.Name = "textBox_acapacity";
            this.textBox_acapacity.Size = new System.Drawing.Size(254, 23);
            this.textBox_acapacity.TabIndex = 7;
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
            // btn_SaveACategory
            // 
            this.btn_SaveACategory.Location = new System.Drawing.Point(115, 402);
            this.btn_SaveACategory.Name = "btn_SaveACategory";
            this.btn_SaveACategory.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveACategory.TabIndex = 8;
            this.btn_SaveACategory.Text = "Save";
            this.btn_SaveACategory.UseVisualStyleBackColor = true;
            this.btn_SaveACategory.Click += new System.EventHandler(this.btn_SaveACategory_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 23);
            this.textBox1.TabIndex = 10;
            // 
            // label3_category
            // 
            this.label3_category.AutoSize = true;
            this.label3_category.Location = new System.Drawing.Point(24, 80);
            this.label3_category.Name = "label3_category";
            this.label3_category.Size = new System.Drawing.Size(55, 15);
            this.label3_category.TabIndex = 9;
            this.label3_category.Text = "Category";
            // 
            // AutoCategoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3_category);
            this.Controls.Add(this.btn_SaveACategory);
            this.Controls.Add(this.textBox_acapacity);
            this.Controls.Add(this.label_capacity);
            this.Controls.Add(this.textBox_aincrement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_aname);
            this.Controls.Add(this.label1);
            this.Name = "AutoCategoryEditor";
            this.Text = "CategoryEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_aname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_aincrement;
        private System.Windows.Forms.TextBox textBox_acapacity;
        private System.Windows.Forms.Label label_capacity;
        private System.Windows.Forms.Button btn_SaveACategory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3_category;
    }
}
