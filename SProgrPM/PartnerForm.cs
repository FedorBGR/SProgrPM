using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SProgrPM
{
    public partial class PartnerForm : Form

    {
        private Database db = new Database();
        private int? partnerId = null; // Если NULL, значит форма открыта для добавления
        private string connectionString = "Host=localhost;Username=postgres;Password=Bogorodick200444;Database=PM";

        public PartnerForm()
        {
            InitializeComponent();
            LoadPartnerTypes();
            button_save.BackColor = ColorTranslator.FromHtml("#F4E8D3 ");
        }

        public PartnerForm(int partnerId)
        {
            InitializeComponent();
            this.partnerId = partnerId;
            LoadPartnerData(); // Загружаем данные
            LoadPartnerTypes();
            button_save.BackColor = ColorTranslator.FromHtml("#F4E8D3 ");
        }

        private void LoadPartnerData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT name, company_type, rating, legal_address, director, phone, email FROM partners WHERE id = @id";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", partnerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader.GetString(0);
                            cmbCompanyType.Text = reader.GetString(1);
                            numRating.Value = reader.GetInt32(2);
                            txtAddress.Text = reader.GetString(3);
                            txtDirector.Text = reader.GetString(4);
                            txtPhone.Text = reader.GetString(5).Replace(" ", "");
                            txtEmail.Text = reader.GetString(6);
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public Action OnPartnerUpdated;
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка заполнения полей
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(cmbCompanyType.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtDirector.Text)||
                    string.IsNullOrWhiteSpace(txtPhone.Text)||
                    string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Данные из формы
                string name = txtName.Text.Trim();
                string type = cmbCompanyType.Text.ToString();
                string address = txtAddress.Text.Trim();
                string director = txtDirector.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                int rating = (int)numRating.Value;

                if (partnerId.HasValue) // Редактирование партнера
                {
                    db.UpdatePartner(partnerId.Value, name, type, address, director, phone, email, rating);
                }
                else // Добавление нового партнера
                {
                    db.AddPartner(name, type, address,  director, phone, email, rating);
                }
                OnPartnerUpdated?.Invoke();
                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close(); // Закрываем форму после сохранения
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPartnerTypes()
        {
            List<string> types = db.GetPartnerTypes();
            cmbCompanyType.Items.Clear(); // Очистка предыдущих значений
            cmbCompanyType.Items.AddRange(types.ToArray()); // Добавляем новые типы в ComboBox
        }
    }
}
