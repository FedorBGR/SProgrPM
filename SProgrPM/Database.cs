using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

public class Database
{
    private string connectionString = "Host=localhost;Username=postgres;Password=Bogorodick200444;Database=PM";

    public DataTable GetPartners()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT id, company_type, name, director, phone, rating, discount FROM partners";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public void UpdateDiscounts()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = @"
           UPDATE partners p
            SET discount = CASE 
                WHEN COALESCE(s.total_sales, 0) >= 300000 THEN 15
                WHEN COALESCE(s.total_sales, 0) >= 50000 THEN 10
                WHEN COALESCE(s.total_sales, 0) >= 10000 THEN 5
                ELSE 0
            END
            FROM (
                SELECT partner_id, COALESCE(SUM(quantity), 0) AS total_sales
                FROM sales
                GROUP BY partner_id
            ) s
            WHERE p.id = s.partner_id OR s.partner_id IS NULL;";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.ExecuteNonQuery(); // Выполняем запрос
            }
        }
    }

    public void AddPartner(string name, string type, string legal_address, string director, string phone, string email, int rating)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO partners (name, company_type, legal_address, director, phone, email, rating) VALUES (@name, @type, @legal_address, @director, @phone, @email, @rating)";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@legal_address", legal_address);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdatePartner(int id, string name, string type, string legal_address, string director, string phone, string email, int rating)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE partners SET name = @name, company_type = @type, legal_address = @legal_address, director = @director, phone = @phone, email = @email, rating = @rating WHERE id = @id";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@legal_address", legal_address);
                cmd.Parameters.AddWithValue("@director", director);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.ExecuteNonQuery();
            }
        }

    }

    public List<string> GetPartnerTypes()
    {
        List<string> types = new List<string>();
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT DISTINCT company_type FROM partners";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(reader["company_type"].ToString());
                    }
                }
            }
        }
        return types;
    }
    public DataTable GetSalesHistory(int partnerId)
    {
        DataTable table = new DataTable();
        string query = @"SELECT s.id, p.name AS product_name, s.quantity, s.sale_date 
                     FROM sales s 
                     JOIN product p ON s.product_id = p.id 
                     WHERE s.partner_id = @partnerId 
                     ORDER BY s.sale_date DESC;";

        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@partnerId", partnerId);
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }
        }

        return table;
    }

    public (double?, double?) GetCoefficients(int productTypeId, int materialTypeId)
    {
        double? productCoeff = null;
        double? defectPercent = null;

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = @"
            SELECT pt.p_type_coeff, mt.procent
            FROM product_type pt
            JOIN material_type mt ON mt.id = @materialTypeId
            WHERE pt.id = @productTypeId;
        ";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@productTypeId", productTypeId);
                command.Parameters.AddWithValue("@materialTypeId", materialTypeId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        productCoeff = reader.IsDBNull(0) ? null : reader.GetDouble(0);
                        defectPercent = reader.IsDBNull(1) ? null : reader.GetDouble(1);
                    }
                }
            }
        }

        return (productCoeff, defectPercent);
    }

}

