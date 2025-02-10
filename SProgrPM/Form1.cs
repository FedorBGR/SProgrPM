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
        
        private void LoadPartners()
        {
            db.UpdateDiscounts();
            DataTable partners = db.GetPartners();

            foreach (DataRow row in partners.Rows)
            {
                // Карточка (Panel)
                Panel card = new Panel
                {
                    Width = 840,
                    Height = 200, // Увеличил высоту для лучшего размещения
                    BackColor= ColorTranslator.FromHtml("#F4E8D3 "),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
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
                    Text =  row["director"].ToString(),
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

                // Добавляем элементы в карточку
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

    }
}
