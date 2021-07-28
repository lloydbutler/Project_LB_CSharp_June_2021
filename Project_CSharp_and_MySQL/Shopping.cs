using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Project_CSharp_and_MySQL
{
    
    class Shopping
    {
        MySqlConnection con;
        MySqlCommand cmd;
        
        

        public Shopping()
        {
            string connectionstring = "server=localhost;user=root;password=root;database=nbs4";
            con = new MySqlConnection(connectionstring);
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            
        }
        public void addSale(string ProductName, int Quantity, float price)
        {
            cmd.CommandText = $"insert into shop (productname, quantity, price, saledate) values('{ProductName}', {Quantity}, {price}, now())";
            cmd.ExecuteNonQuery();
            Console.ReadLine();
            
        }
        public void SaleReport(int mchoice, int ychoice, int select)
        {

            string row = "";
            if (select == 1)
            {
                
                cmd.CommandText = $"select * from shop where year(saledate)={ychoice}";
                cmd.ExecuteNonQuery();
                MySqlDataReader myReader = cmd.ExecuteReader();
                
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        row += myReader.GetName(i) + "\t";
                    }
                    Console.WriteLine(row);
                    row = "";

                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        row += myReader.GetString(i) +"\t";
                    }
                    Console.WriteLine(row);
                    row = "";       
                }

                myReader.Close();
                Console.ReadLine();
            }
            if (select == 2)
            {
                cmd.CommandText = $"select * from shop where year(saledate)={ychoice} and month(saledate)={mchoice}";
                cmd.ExecuteNonQuery();
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        row += myReader.GetString(i) + " ";
                    }
                    Console.WriteLine(row);
                    row = "";
                }

                myReader.Close();
                Console.ReadLine();
            }
            if (select == 3)
            {
                cmd.CommandText = $"select productname, sum(quantity * price) as Total from shop where year(saledate)={ychoice} group by productname";
                cmd.ExecuteNonQuery();
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        row += myReader.GetString(i) + " ";
                    }
                    Console.WriteLine(row);
                    row = " ";

                }

                myReader.Close();
                Console.ReadLine();
            }
            if (select == 4)
            {
                cmd.CommandText = $"select productname, sum(quantity * price) as Total from shop where year(saledate)={ychoice} and month(saledate)={mchoice} group by productname";
                cmd.ExecuteNonQuery();
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        row += myReader.GetString(i) + " ";
                    }
                    Console.WriteLine(row);
                    row = "";
                }

                myReader.Close();
                Console.ReadLine();
            }


        }



    }
}
