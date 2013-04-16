using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using itn0912_2DBLayer.ModelLayer;
using itn0912_2DBLayer.DBLayer;
using itn0912_2DBLayer.Debug;
/*
Done by Asbjørn Birch 
 */
namespace itn0912_2DBLayer.Controller
{
    public class ProductDB
    {
        //search Product by 'Beskrivelse'
        // SELECT * FROM Product WHERE beskrivelse LIKE '%string%';


        public List<Product> getProductByDesc(string str)
        {
            List<Product> products = new List<Product>();
            try
            {
                String sql = "SELECT product.varenummer, product.beskrivelse, Product.pris, Kategori.kategori FROM Product, Kategori WHERE beskrivelse LIKE '%" + str + "%' AND Product.katId = Kategori.id";
                Console.WriteLine("Output: " + sql);
                SqlCommand dbCmd = DBConnection.GetDbCommand("SELECT product.varenummer, product.beskrivelse, Product.pris, Kategori.kategori FROM Product, Kategori WHERE beskrivelse LIKE '%" + str + "%' AND Product.katId = Kategori.id");
                SqlDataReader reader = dbCmd.ExecuteReader();
                //List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product(Int32.Parse(reader["varenummer"].ToString()), reader["beskrivelse"].ToString(), Int32.Parse(reader["pris"].ToString()), reader["kategori"].ToString());
                    products.Add(product);

                }
               // DBConnection.Close();
                //return products;

            }
            catch (SqlException sqlE)
            {
                DebugToTxt.DebugMethod("Method: ProductDB.getProductByDesc\r\n" +
                "catch Exeption sqlE \r\n" +
                "Is SQL syntax OK?\r\n" +
                sqlE.ToString());
            }
            catch (Exception e)
            {
                DebugToTxt.DebugMethod("Method: ProductDB.getProductByDesc\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or connected to DB?\r\n" +
                    e.ToString());


            }
            finally
            {
                DBConnection.Close();
            }
            return products;
        }

        //search by varenummer

        public List<Product> getProductByVarenummer(int searchNo)
        {
            List<Product> products = new List<Product>();
            try
            {

                SqlCommand dbCmd = DBConnection.GetDbCommand("SELECT product.varenummer, product.beskrivelse, Product.pris, Kategori.kategori FROM Product, Kategori WHERE varenummer ='" + searchNo + "' AND Product.katId = Kategori.id");
                SqlDataReader reader = dbCmd.ExecuteReader();
                //List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product product = new Product(Int32.Parse(reader["varenummer"].ToString()), reader["beskrivelse"].ToString(), Int32.Parse(reader["pris"].ToString()), reader["kategori"].ToString());
                    products.Add(product);

                }
                //products.Clear();

                //DBConnection.Close();
            }
            catch (SqlException sqlE)
            {
                DebugToTxt.DebugMethod("Method: ProductDB.getProductByDesc\r\n" +
                "catch Exeption sqlE \r\n" +
                "Is SQL syntax OK?\r\n" +
                sqlE.ToString());
            }
            catch (Exception e)
            {
                DebugToTxt.DebugMethod("Method: ProductDB.getProductByDesc\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or connected to DB?\r\n" +
                    e.ToString());


            }
            finally
            { DBConnection.Close(); }
            return products;
            
        }

        // Done by Rasmus Overgaard - start
        public List<Product> getBeskrivelseByKategori(string name)
        {
            List<Product> products = new List<Product>();

            //SELECT Product.beskrivelse from Product, Kategori WHERE Kategori.kategori = 'Laptops' AND Kategori.id =  Product.katId
            string sql = "SELECT Product.beskrivelse from Product, Kategori WHERE Kategori.kategori = '" + name + "' AND Kategori.id =  Product.katId";
            SqlCommand dbCmd = DBConnection.GetDbCommand(sql);
            SqlDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product(reader["beskrivelse"].ToString());
                products.Add(product);

            }
            //products.Clear();

            DBConnection.Close();

           return products;
        }
        
    

    }
}
