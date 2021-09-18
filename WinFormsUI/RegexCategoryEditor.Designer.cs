
namespace WinFormsUI
{
    partial class RegexCategoryEditorForm
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
            this.label_rules = new System.Windows.Forms.Label();
            this.textBox_rules = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_rname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_rincrement = new System.Windows.Forms.TextBox();
            this.textBox_rcapacity = new System.Windows.Forms.TextBox();
            this.label_capacity = new System.Windows.Forms.Label();
            this.btn_SaveRCategory = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_rules
            // 
            this.label_rules.AutoSize = true;
            this.label_rules.Location = new System.Drawing.Point(24, 205);
            this.label_rules.Name = "label_rules";
            this.label_rules.Size = new System.Drawing.Size(35, 15);
            this.label_rules.TabIndex = 0;
            this.label_rules.Text = "Rules";
            // 
            // textBox_rules
            // 
            this.textBox_rules.Location = new System.Drawing.Point(24, 223);
            this.textBox_rules.Multiline = true;
            this.textBox_rules.Name = "textBox_rules";
            this.textBox_rules.Size = new System.Drawing.Size(254, 156);
            this.textBox_rules.TabIndex = 1;
            this.textBox_rules.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
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
            // textBox_rname
            // 
            this.textBox_rname.Location = new System.Drawing.Point(24, 40);
            this.textBox_rname.Name = "textBox_rname";
            this.textBox_rname.Size = new System.Drawing.Size(254, 23);
            this.textBox_rname.TabIndex = 3;
            this.textBox_rname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Increment";
            // 
            // textBox_rincrement
            // 
            this.textBox_rincrement.Location = new System.Drawing.Point(24, 96);
            this.textBox_rincrement.Name = "textBox_rincrement";
            this.textBox_rincrement.Size = new System.Drawing.Size(254, 23);
            this.textBox_rincrement.TabIndex = 5;
            this.textBox_rincrement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // textBox_rcapacity
            // 
            this.textBox_rcapacity.Location = new System.Drawing.Point(24, 158);
            this.textBox_rcapacity.Name = "textBox_rcapacity";
            this.textBox_rcapacity.Size = new System.Drawing.Size(254, 23);
            this.textBox_rcapacity.TabIndex = 7;
            this.textBox_rcapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
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
            // btn_SaveRCategory
            // 
            this.btn_SaveRCategory.Location = new System.Drawing.Point(172, 404);
            this.btn_SaveRCategory.Name = "btn_SaveRCategory";
            this.btn_SaveRCategory.Size = new System.Drawing.Size(106, 23);
            this.btn_SaveRCategory.TabIndex = 8;
            this.btn_SaveRCategory.Text = "Save changes";
            this.btn_SaveRCategory.UseVisualStyleBackColor = true;
            this.btn_SaveRCategory.Click += new System.EventHandler(this.btn_SaveRCategory_Click);
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
            // RegexCategoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.btn_SaveRCategory);
            this.Controls.Add(this.textBox_rcapacity);
            this.Controls.Add(this.label_capacity);
            this.Controls.Add(this.textBox_rincrement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_rname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_rules);
            this.Controls.Add(this.label_rules);
            this.Controls.Add(this.button_delete);
            this.Name = "RegexCategoryEditor";
            this.Text = "CategoryEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_rules;
        private System.Windows.Forms.TextBox textBox_rules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_rname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_rincrement;
        private System.Windows.Forms.TextBox textBox_rcapacity;
        private System.Windows.Forms.Label label_capacity;
        private System.Windows.Forms.Button btn_SaveRCategory;
        private System.Windows.Forms.Button button_delete;
    }
}