using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetWithPostgreSQLDemo
{
    public class ProductDal
    {
        NpgsqlConnection connection = new NpgsqlConnection("server=127.0.0.1;Username=postgres;Password=1234;Database=ETrade");

        public DataTable GetAll()
        {
            ConnectionControl(connection);

            NpgsqlCommand command = new NpgsqlCommand("Select * from products Order By product_id", connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();

            return dataTable;
        }
        public void Add(Product product)
        {
            ConnectionControl(connection);
            NpgsqlCommand command = new NpgsqlCommand("Insert into products values(@product_name, @unit_price, @stock_amount)", connection);
            command.Parameters.AddWithValue("@product_name", product.product_name);
            command.Parameters.AddWithValue("@unit_price", product.unit_price);
            command.Parameters.AddWithValue("@stock_amount", product.stock_amount);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl(connection);
            NpgsqlCommand command = new NpgsqlCommand(
                "Update products set product_name = @product_name, " +
                                     "unit_price = @unit_price, " +
                                     "stock_amount = @stock_amount " +
                                     "Where @product_id = product_id", connection);
            command.Parameters.AddWithValue("@product_id", product.product_id);
            command.Parameters.AddWithValue("@product_name", product.product_name);
            command.Parameters.AddWithValue("@unit_price", product.unit_price);
            command.Parameters.AddWithValue("@stock_amount", product.stock_amount);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(int product_id)
        {
            ConnectionControl(connection);
            NpgsqlCommand command = new NpgsqlCommand(
                "Delete From products Where @product_id = product_id", connection);
            command.Parameters.AddWithValue("@product_id",product_id);
            command.ExecuteNonQuery();

            connection.Close();
        }



        private static void ConnectionControl(NpgsqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
    }
}
