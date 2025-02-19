namespace SProgrPM
{
    partial class PartnerForm
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
            txtName = new TextBox();
            cmbCompanyType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            numRating = new NumericUpDown();
            label3 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtDirector = new TextBox();
            label5 = new Label();
            txtPhone = new MaskedTextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            button_save = new Button();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(202, 42);
            txtName.Name = "txtName";
            txtName.Size = new Size(335, 32);
            txtName.TabIndex = 0;
            // 
            // cmbCompanyType
            // 
            cmbCompanyType.Font = new Font("Segoe UI", 14F);
            cmbCompanyType.FormattingEnabled = true;
            cmbCompanyType.Location = new Point(202, 92);
            cmbCompanyType.Name = "cmbCompanyType";
            cmbCompanyType.Size = new Size(185, 33);
            cmbCompanyType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(53, 49);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 2;
            label1.Text = "Наименовение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(152, 100);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 3;
            label2.Text = "Тип";
            label2.Click += label2_Click;
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 14F);
            numRating.Location = new Point(202, 140);
            numRating.Name = "numRating";
            numRating.Size = new Size(185, 32);
            numRating.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(115, 147);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 5;
            label3.Text = "Рейтинг";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 14F);
            txtAddress.Location = new Point(202, 193);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(335, 32);
            txtAddress.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(132, 200);
            label4.Name = "label4";
            label4.Size = new Size(64, 25);
            label4.TabIndex = 7;
            label4.Text = "Адрес";
            // 
            // txtDirector
            // 
            txtDirector.Font = new Font("Segoe UI", 14F);
            txtDirector.Location = new Point(202, 246);
            txtDirector.Name = "txtDirector";
            txtDirector.Size = new Size(335, 32);
            txtDirector.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(100, 253);
            label5.Name = "label5";
            label5.Size = new Size(96, 25);
            label5.TabIndex = 9;
            label5.Text = "Директор";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 14F);
            txtPhone.Location = new Point(202, 297);
            txtPhone.Mask = "(999) 000-0000";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(164, 32);
            txtPhone.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(100, 304);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 11;
            label6.Text = "Телефон";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 14F);
            txtEmail.Location = new Point(202, 349);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(335, 32);
            txtEmail.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(100, 356);
            label7.Name = "label7";
            label7.Size = new Size(94, 25);
            label7.TabIndex = 13;
            label7.Text = "Эл. почта";
            // 
            // button_save
            // 
            button_save.BackColor = Color.White;
            button_save.Font = new Font("Segoe UI", 14F);
            button_save.Location = new Point(642, 337);
            button_save.Name = "button_save";
            button_save.Size = new Size(146, 44);
            button_save.TabIndex = 14;
            button_save.Text = "Сохранить";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // PartnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_save);
            Controls.Add(label7);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(txtPhone);
            Controls.Add(label5);
            Controls.Add(txtDirector);
            Controls.Add(label4);
            Controls.Add(txtAddress);
            Controls.Add(label3);
            Controls.Add(numRating);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCompanyType);
            Controls.Add(txtName);
            Name = "PartnerForm";
            Text = "PartnerForm";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private ComboBox cmbCompanyType;
        private Label label1;
        private Label label2;
        private NumericUpDown numRating;
        private Label label3;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtDirector;
        private Label label5;
        private MaskedTextBox txtPhone;
        private Label label6;
        private TextBox txtEmail;
        private Label label7;
        private Button button_save;
    }
}