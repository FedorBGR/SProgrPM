using System.Data;

namespace SProgrPM
{
    public partial class Form1 : Form
    {
        private Database db = new Database();
        public Form1()
        {
            InitializeComponent();
            LoadPartners();
        }
        private void PartnerCard_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Panel clickedCard && clickedCard.Tag is int partnerId)
            {
                using (var form = new PartnerForm(partnerId)) // ✅ Передаём ID партнёра в форму
                {
                    form.OnPartnerUpdated = LoadPartners;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadPartners(); // 🔄 Обновляем список после редактирования
                    }
                }
            }
        }

            public void LoadPartners()
        {
            flowLayoutPanel1.Controls.Clear();
            db.UpdateDiscounts();
            DataTable partners = db.GetPartners();

            foreach (DataRow row in partners.Rows)
            {
                int partnerId = Convert.ToInt32(row["id"]);
                // Карточка (Panel)
                Panel card = new Panel
                {
                    Width = 840,
                    Height = 200, // Увеличил высоту для лучшего размещения
                    BackColor = ColorTranslator.FromHtml("#F4E8D3 "),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Tag = partnerId,
                };


                Label TypeLabel = new Label
                {
                    Text = row["company_type"].ToString(),
                    Font = new Font("Segoe UI", 16),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 70,
                    Height = 25,
                    Location = new Point(30, 30)
                };

                Label nameLabel = new Label
                {
                    Text = row["name"].ToString(),
                    Font = new Font("Segoe UI", 16),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 280,
                    Height = 30,
                    Location = new Point(100, 30)
                };


                Label DirectorLabel = new Label
                {
                    Text = row["director"].ToString(),
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 320,
                    Height = 25,
                    Location = new Point(30, 65)
                };

                Label PhoneLabel = new Label
                {
                    Text = row["phone"].ToString(),
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 280,
                    Height = 20,
                    Location = new Point(30, 90)
                };

                Label ratingLabel = new Label
                {
                    Text = "Рейтинг: " + row["rating"].ToString(),
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 280,
                    Height = 20,
                    Location = new Point(30, 115)
                };

                // Рейтинг - справа, под адресом
                Label DiscountLabel = new Label
                {
                    Text = row["discount"].ToString() + "%",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Width = 280,
                    Height = 20,
                    Location = new Point(770, 30)
                };

                Button historyButton = new Button
                {
                    Text = "История продаж",
                    Font = new Font("Segoe UI", 14), 
                    ForeColor = Color.Black,
                    Location = new Point(630, 115),
                    Width = 200,
                    Height = 30
                };

                card.DoubleClick += PartnerCard_DoubleClick;
                historyButton.Click += (sender, e) => ShowSalesHistory(partnerId);

                // Добавляем элементы в карточку
                card.Controls.Add(historyButton);
                card.Controls.Add(TypeLabel);
                card.Controls.Add(nameLabel);
                card.Controls.Add(DirectorLabel);
                card.Controls.Add(PhoneLabel);
                card.Controls.Add(ratingLabel);
                card.Controls.Add(DiscountLabel);

                // Добавляем карточку в FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(card);
                
            }
        }

        private void Add_partner_button_Click(object sender, EventArgs e)
        {
            using (var form = new PartnerForm())
            {
                form.OnPartnerUpdated = LoadPartners;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPartners(); // Обновляем список партнеров
                }
            }
        }

        private void ShowSalesHistory(int partnerId)
        {
            using (var form = new SalesForm(partnerId, db))
            {
                form.ShowDialog();
            }
        }
    }
}
