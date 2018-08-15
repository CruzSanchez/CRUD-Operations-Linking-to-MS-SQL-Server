using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CRUDUI
{
    class Program
    {
        static void Main(string[] args)
		{

			ProductRepo repo = new ProductRepo("Server=127.0.0.1;Database=bestbuy;Uid=root;Pwd=***********;SslMode=None;");

			//List<Product> products = repo.Select();
			//foreach(Product product in products)
			//{
			//	Console.WriteLine(product);
			//}

			//Console.ReadLine();

			//Product prodtoinsert = new Product();
			//prodtoinsert.Name = "Cruz Product";
			//prodtoinsert.Price = 1000;

			//repo.Insert(prodtoinsert);

			//Console.WriteLine("Updated!");


			Product productToUpdate = new Product();
			productToUpdate.Id = 26;
			productToUpdate.Name = "Cruz update";
			productToUpdate.Price = 20000;

			repo.Update(productToUpdate);

			Console.WriteLine("UD");



			Product prodDelete = new Product();
			prodDelete.Name = "Cruz product";
			prodDelete.Id = 26;

			repo.Delete(prodDelete);

			Console.ReadLine();

        }

    }
}
