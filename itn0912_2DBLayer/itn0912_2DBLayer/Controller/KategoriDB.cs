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
    class KategoriDB
    {
   
      
      
        public Kategori getKategoriByID(int id)
        {

            try
            {
                SqlCommand dbCmd = DBConnection.GetDbCommand("SELECT * FROM [kategori] WHERE kategori.id = " + id);

                SqlDataReader reader = dbCmd.ExecuteReader();
                reader.Read();

                Kategori kat = new Kategori(Int32.Parse(reader["id"].ToString()), reader["kategori"].ToString());
                //DBConnection.Close();
                return kat;
            }
            catch (SqlException sqlE)
            {
                //write SQL-debug to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.getKategoriByID\r\n" + 
                    "catch SqlExeption sqlE\r\n" +
                    "Is SQL Syntax OK?\r\n" + 
                    sqlE.ToString());
              
                
            }
 

            catch (Exception e)
            {
                //wrtite to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.getKategoriByID\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or has connection to SQL?\r\n" + 
                    e.ToString());
            }
            finally
            {
                DBConnection.Close();
            }
            return null;
        }


        public List<Kategori> getAllKats()
        {

            try
            {
                SqlCommand dbCmd = DBConnection.GetDbCommand("SELECT * FROM [kategori] ORDER BY id");

                SqlDataReader reader = dbCmd.ExecuteReader();
                List<Kategori> kate1 = new List<Kategori>();
                while (reader.Read())
                {
                    Kategori kate2 = new Kategori(Int32.Parse(reader["id"].ToString()), reader["Kategori"].ToString());
                    kate1.Add(kate2);
                }
                DBConnection.Close();
                return kate1;
            }
            catch (SqlException sqlE)
            {
                //write SQL-debugging to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.getAllKats\r\n" +
                    "catch Exeption sqlE \r\n" +
                    "Is SQL syntax OK?\r\n" + 
                    sqlE.ToString());
            }

            catch (Exception e)
            {
                //write to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.getAllKats\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to the DB or has connection to SQL?\r\n" + 
                    e.ToString());
            }
            finally
            {
                DBConnection.Close();
            }
            return null;
        }

        public bool addKategori(Kategori kategori)
        {
            //TODO: 
            //try catch 

            try
            {

                // UNIQUE in table kategories 
                SqlCommand dbCmd = DBConnection.GetDbCommand("INSERT INTO [kategori] VALUES ('" + kategori.FullKategori + "')");
                int rows = dbCmd.ExecuteNonQuery();

                bool returnResult = false;
                if (rows == 1)
                {
                    returnResult = true;

                }

                return returnResult;

            }
            catch (SqlException sqlE)
            {
                //write to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.addKategori\r\n" +
                    "catch Exeption sqlE\r\n" +
                    "Is SQL Syntax OK?\r\n" + 
                    sqlE.ToString());
            }

            catch (Exception e)
            {
                //Write to debug.txt
                DebugToTxt.DebugMethod("Metod: KategoriDB.addKategori\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or has connection to SQL?\r\n" + 
                    e.ToString());
            }
            finally
            {
                DBConnection.Close();
            }
            return false;
        }

        public bool deleteKategori(Kategori kategori)
        {
            //TODO: Try catch - Done 
            //TODO : Write to debug.txt
            try
            {

                SqlCommand dbCmd = DBConnection.GetDbCommand("DELETE FROM [kategori] WHERE kategori = '" + kategori.FullKategori + "'");
                int rows = dbCmd.ExecuteNonQuery();

                bool returnResult = false;
                if (rows == 1)
                {
                    returnResult = true;
                }
                else
                {
                    throw new Exception("No rows affected");
                }
                return returnResult;
            }


            catch (SqlException sqlE)
            {
                // Write to debug.txt
                DebugToTxt.DebugMethod("Method: KategoriDB.deleteKategori\r\n" +
                "catch Exeption sqlE\r\n" +
                "Is SQL Syntax OK?\r\n" + 
                sqlE.ToString());
            }

            catch (Exception e)
            {
                DebugToTxt.DebugMethod("Metod: KategoriDB.addKategori\r\n" +
                "catch Exeption e\r\n" +
                "Is user logged in to DB or has connection to SQL?\r\n" +
                e.ToString());

            }
            finally
            {
                DBConnection.Close();
            }

            return false;
        }

    }
}
