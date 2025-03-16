using System;
using MySql.Data.MySqlClient;

namespace OOP.ManageProduct
{
    public class InsertNewProduct
    {
        private string server = "localhost";
        private string database = "csharpapp";
        private string username = "root";
        private string password = "";
        private string connString;

        public InsertNewProduct()
        {
            connString = $"Server={server};Database={database};User ID={username};Password={password};";
        }

        public void InsertData(string productName, decimal productPrice, string description, string category, int stock)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL");

                    // Corrected Query: Do NOT insert 'id'
                    string query = "INSERT INTO products (`productName`, `productPrice`, `description`, `category`, `stock`) VALUES (@name, @price, @description, @category, @stock)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@price", productPrice);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@stock", stock);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ?
                            "\n        /$$           /$$                    /$$                                      /$$                   /$$\n" +
                            "\n       | $$          | $$                   |__/                                     | $$                  | $$\r" +
                            "\n    /$$$$$$$ /$$$$$$ /$$$$$$   /$$$$$$        /$$/$$$$$$$  /$$$$$$$ /$$$$$$  /$$$$$$ /$$$$$$   /$$$$$$  /$$$$$$$\r" +
                            "\n   /$$__  $$|____  $|_  $$_/  |____  $$      | $| $$__  $$/$$_____//$$__  $$/$$__  $|_  $$_/  /$$__  $$/$$__  $$\r" +
                            "\n  | $$  | $$ /$$$$$$$ | $$     /$$$$$$$      | $| $$  \\ $|  $$$$$$| $$$$$$$| $$  \\__/ | $$   | $$$$$$$| $$  | $$ \r" +
                            "\n  | $$  | $$/$$__  $$ | $$ /$$/$$__  $$      | $| $$  | $$\\____  $| $$_____| $$       | $$ /$| $$_____| $$  | $$\r" +
                            "\n  |  $$$$$$|  $$$$$$$ |  $$$$|  $$$$$$$      | $| $$  | $$/$$$$$$$|  $$$$$$| $$       |  $$$$|  $$$$$$|  $$$$$$$\r" +
                            "\n   \\____  $$\\_______/  \\___/  \\_______/      |__|__/  |__/|_______/\\_______|__/        \\___/  \\_______/\\_______/\r"

                                            : "Failed to insert data.");
                       
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

