namespace SProgrPM
{
    partial class SalesForm
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
            dataGridViewSales = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSales.BackgroundColor = SystemColors.Control;
            dataGridViewSales.BorderStyle = BorderStyle.None;
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Location = new Point(118, 110);
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.Size = new Size(582, 211);
            dataGridViewSales.TabIndex = 0;
            dataGridViewSales.CellContentClick += dataGridViewSales_CellContentClick;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewSales);
            Name = "SalesForm";
            Text = "SalesForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSales;
    }
}