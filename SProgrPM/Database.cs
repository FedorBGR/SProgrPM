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
            string query = "SELECT company_type, name, director, phone, rating, discount FROM partners";
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

}

