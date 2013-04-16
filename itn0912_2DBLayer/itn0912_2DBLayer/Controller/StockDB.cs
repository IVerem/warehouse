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
 * Done by Asbjørn Birch
 */

namespace itn0912_2DBLayer.Controller
{
    public class StockDB
    {


        //Print out what's in minimum-stock 
        public List<Stock> getStockByMin()
        {
            try
            {
                string sqlString = "SELECT Stock.bvarenr, Stock.antal, Stock.minimum, Stock.bkatId, Kategori.kategori FROM Stock, Kategori WHERE Stock.antal < Stock.minimum and kategori.id = Stock.bkatId";
                SqlCommand dbCmd = DBConnection.GetDbCommand(sqlString);
                SqlDataReader reader = dbCmd.ExecuteReader();
                List<Stock> stocks = new List<Stock>();
                //Console.WriteLine("Rigt before the while-loop - Debug");
                while (reader.Read())
                {
                    Stock stock = new Stock(Int32.Parse(reader["bvarenr"].ToString()), Int32.Parse(reader["antal"].ToString()), Int32.Parse(reader["minimum"].ToString()), Int32.Parse(reader["bkatId"].ToString()), reader["kategori"].ToString());

                    //Stock stock = new Stock(Int32.Parse(reader["antal"].ToString()), Int32.Parse(reader["minimum"].ToString()), Int32.Parse(reader["bvarenr"].ToString()), Int32.Parse(reader["bkatId"].ToString()));
                    stocks.Add(stock);

                }

                return stocks;
            }

            catch (SqlException sqlE)
            {
                DebugToTxt.DebugMethod("Method: StockDB.getStockByMin\r\n" +
                "catch Exeption sqlE \r\n" +
                "Is SQL syntax OK?\r\n" +
                sqlE.ToString());
            }
            catch (Exception e)
            {
                DebugToTxt.DebugMethod("Method: StockDB.getStockByMin\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or connected to DB?\r\n" +
                    e.ToString());


            }
            finally
            {
                DBConnection.Close();
            }

            return null;
        } // end of getStockByMin

        //Update antal in stock
        //Syntax:
        //UPDATE Stock SET antal=10 WHERE bvarenr=12049
        public bool updateAntal(Stock stock)
        {
            try
            {

                SqlCommand dbCmd = DBConnection.GetDbCommand("UPDATE [Stock] SET antal='" + stock.Antal + "' WHERE bvarenr='" + stock.ProductObj.Varenummer + "'");
                int rows = dbCmd.ExecuteNonQuery();
                //Console.WriteLine(dbCmd.ToString()); //debugging
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
                DebugToTxt.DebugMethod("Method: StockDB.updateAntal\r\n" +
                    "catch Exeption sqlE\r\n" +
                    "Is SQL Syntax OK?\r\n" +
                    sqlE.ToString());
            }

            catch (Exception e)
            {
                //Write to debug.txt
                DebugToTxt.DebugMethod("Metod: StockDB.updateAntal\r\n" +
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