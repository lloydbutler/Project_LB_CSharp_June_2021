using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Project_CSharp_and_MySQL
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            Shopping shop = new Shopping();

            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1. Data Entry");
            Console.WriteLine("2. Reports");
            Console.WriteLine("3. Close");
            string opt = Console.ReadLine();

            if (Convert.ToInt32(opt) == 1)
            {
                Console.WriteLine("Please enter product name");
                string proName = Console.ReadLine();
                Console.WriteLine("Please enter quantity sold");
                string qtySold = Console.ReadLine();
                Console.WriteLine("Please enter the price");
                string price = Console.ReadLine();
                
                shop.addSale(proName, Convert.ToInt32(qtySold), float.Parse(price));
            }

            if (Convert.ToInt32(opt) == 2)
            {
                Console.WriteLine("1. list products sold in a specific year");
                Console.WriteLine("2. list of products sold in a specific month within a specific year");
                Console.WriteLine("3. total sales in a specific year");
                Console.WriteLine("4. total sales in a specific month");
                
                string select = Console.ReadLine();

                if (Convert.ToInt32(select) == 1)
                {
                    Console.WriteLine("please type year to view");
                    int ytv = Convert.ToInt32(Console.ReadLine());
                    shop.SaleReport(0,ytv, Convert.ToInt32(select));
                }
                if (Convert.ToInt32(select) == 2)
                {
                    Console.WriteLine("please type year to view");
                    int ytv = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("please type month to view");
                    int mtv = Convert.ToInt32(Console.ReadLine());
                    shop.SaleReport(mtv,ytv, Convert.ToInt32(select));
                }
                if (Convert.ToInt32(select) == 3)
                {
                    Console.WriteLine("please type year to view");
                    int ytv = Convert.ToInt32(Console.ReadLine());
                    shop.SaleReport(0,ytv, Convert.ToInt32(select));
                }
                if (Convert.ToInt32(select) == 4)
                {
                    Console.WriteLine("please type year to view");
                    int ytv = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("please type month to view");
                    int mtv = Convert.ToInt32(Console.ReadLine());
                    shop.SaleReport(mtv, ytv, Convert.ToInt32(select));
                }
                

            }
            if (Convert.ToInt32(opt) == 3)
            {
                Environment.Exit(0);
            }


        }
    }
}
