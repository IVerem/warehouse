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
 * By Asbjørn Birch
 */
namespace itn0912_2DBLayer.Controller
{
    class ViewSe_SalesDB
    {

        //Method for teh view dbo.Se_sales in the Database... 
        //Output are the following: 
        //Kategori, Varenummer, beskrivelse, antal, pris 

        public List<ViewSe_Sales> getViewSe_Sales()
        {
            try
            {

            string sqlString = "SELECT * FROM dbo.Se_sales";
            SqlCommand dbCmd = DBConnection.GetDbCommand(sqlString);
            SqlDataReader reader = dbCmd.ExecuteReader();
            List<ViewSe_Sales> viewSe_Sales = new List<ViewSe_Sales>();
            while (reader.Read())
            {
                ViewSe_Sales viewSe_Sale = new ViewSe_Sales(reader["kategori"].ToString(), Int32.Parse(reader["varenummer"].ToString()), reader["beskrivelse"].ToString(), Int32.Parse(reader["antal"].ToString()), Int32.Parse(reader["pris"].ToString()));
                viewSe_Sales.Add(viewSe_Sale);
            }
            return viewSe_Sales;
            }

            catch (SqlException sqlE)
            {
                DebugToTxt.DebugMethod("Method: ViewSe_Sales.getViewSe_Sales\r\n" +
                "catch Exeption sqlE \r\n" +
                "Is SQL syntax OK?\r\n" +
                sqlE.ToString());
            }
            catch (Exception e)
            {
                DebugToTxt.DebugMethod("Method: ViewSe_Sales.getViewSe_Sales\r\n" +
                    "catch Exeption e\r\n" +
                    "Is user logged in to DB or connected to DB?\r\n" +
                    e.ToString());
            }
            finally
            {
                DBConnection.Close();
            }
            return null;
        }

    }
        
}

