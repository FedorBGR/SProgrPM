using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SProgrPM
{
    public partial class SalesForm : Form
    {
        private int partnerId;
        private Database db;
        public SalesForm(int partnerId, Database db)
        {
            InitializeComponent();
            this.partnerId = partnerId;
            this.db = db;
            LoadSalesHistory();
            dataGridViewSales.BackgroundColor = ColorTranslator.FromHtml("#F4E8D3 ");
            this.BackColor = ColorTranslator.FromHtml("#F4E8D3 ");
        }

        private void LoadSalesHistory()
        {
            DataTable salesHistory = db.GetSalesHistory(partnerId);

            if (salesHistory.Rows.Count == 0)
            {
                Label noDataLabel = new Label
                {
                    Text = "Нет данных о продажах",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 20, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Location = new Point(30, 30)
                };
                this.Controls.Add(noDataLabel);
            }
            else
            {
                dataGridViewSales.DataSource = salesHistory;
            }
        }

        private void dataGridViewSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
