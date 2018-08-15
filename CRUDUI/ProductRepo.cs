using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CRUDUI
{
	public class ProductRepo
	{

		public string ConnectionString { get; set; }


		public ProductRepo(string connectionString)
		{
			ConnectionString = connectionString;
		}



		public void Insert(Product product)
		{
			

			MySqlConnection conn = new MySqlConnection(ConnectionString);

			using (conn)
			{
				conn.Open();

				MySqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Insert Into products (Name, Price) Values (@Name, @Price);";
				cmd.Parameters.AddWithValue("name", product.Name);
				cmd.Parameters.AddWithValue("price", product.Price);

				cmd.ExecuteNonQuery();

			}

		}

		public List<Product> Select()
		{
			

			MySqlConnection conn = new MySqlConnection(ConnectionString);

			using (conn)
			{
				conn.Open();

				MySqlCommand cmd = conn.CreateCommand();

				cmd.CommandText = "Select ProductID, Name, Price" +
								  " From Products;";

				MySqlDataReader dr = cmd.ExecuteReader();

				List<Product> products = new List<Product>();

				while (dr.Read())
				{
					Product product = new Product();
					product.Id = Convert.ToInt32(dr["ProductID"]);
					product.Name = dr["Name"].ToString();
					product.Price = Convert.ToDecimal(dr["Price"]);

					products.Add(product);
				}
				return products;
			}


		}

		public void Update(Product product)
		{
			
			MySqlConnection conn = new MySqlConnection(ConnectionString);

			using (conn)
			{
				conn.Open();

				MySqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Update Products " +
					"Set Name = @name, Price = @price " +
					" Where ProductID = @id; ";
				cmd.Parameters.AddWithValue("name", product.Name);
				cmd.Parameters.AddWithValue("price", product.Price);
				cmd.Parameters.AddWithValue("id", product.Id);

				cmd.ExecuteNonQuery();
			}
		}

		public void Delete()
		{
			

			MySqlConnection conn = new MySqlConnection(ConnectionString);

			using (conn)
			{
				conn.Open();

				MySqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "Delete Name From Categories Where categoryID = 3;";

				cmd.ExecuteNonQuery();
			}
		}
	}
}
