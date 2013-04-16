using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itn0912_2DBLayer.Controller;
using itn0912_2DBLayer.DBLayer;
using itn0912_2DBLayer.ModelLayer;
using itn0912_2DBLayer.Debug;
using Auth;
/*
Done by Asbjørn Birch 
 * This is for testing methods of the controller..
 * It's not ment to be the real deal in view-terms
 */
namespace itn0912_2DBLayer
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Test of create Kategori 

            /*
            ControllerKategori addTest = new ControllerKategori();
            
             addTest.createKategori("Hairdryier");
            
            */
            
            //Test of remove Kategori
            /*
            ControllerKategori removeTest = new ControllerKategori();
            removeTest.removeKategori("Hairdryier");
            
            */


            
            //list for Kategories. And the list is called Items
            /*
            List<Kategori> item;

            ControllerKategori test1 = new ControllerKategori();
            item = test1.getAllKats();
            
            //foreach loop to run through the list and display them
            
            
            foreach (Kategori katObj in item)
            {
                Console.WriteLine(katObj.FullKategori);
            }
            */
             

            
            //Search by Description
            /*
            List<Product> proItem;

            ControllerProduct test5 = new ControllerProduct();

            proItem = test5.searchProductByDesc("Samsung");


            foreach (Product produktObj in proItem)
            {
                Console.WriteLine(produktObj.Varenummer.ToString() + " "  + produktObj.Beskrivelse + " " + produktObj.Pris + " " + produktObj.KategoriObj.FullKategori);

            }
            */
            
            

           // RASMUS TEST AF METODE. HJÆLP AB?
            /*
            List<itn0912_2DBLayer.ModelLayer.Product> productItems = new List<itn0912_2DBLayer.ModelLayer.Product>();
            itn0912_2DBLayer.Controller.ControllerProduct productCallMethod = new itn0912_2DBLayer.Controller.ControllerProduct();
            productItems = productCallMethod.getKategoriByKategori("Laptops");
          
            
            foreach (Product blah in productItems)
            {
                Console.WriteLine(blah.Beskrivelse.ToString());
            }
            */
            


            /*
            List<Kategori> katz;
            ControllerKategori soegKatz = new ControllerKategori();
            katz = soegKatz.getKategoriByKategori("TV");
            Console.WriteLine(katz);
            */

            //Search by varenummer
            /*
            List<Product> productItems;
            ControllerProduct searchVareNo = new ControllerProduct();
            productItems = searchVareNo.searchProductByVarenummer(12049);

            try
            {                    
                
                if (productItems.Count != 0)
               {
                foreach (Product prodObj in productItems)
                {

                        Console.WriteLine(prodObj.Varenummer.ToString() + " " + prodObj.Beskrivelse + " " + prodObj.Pris.ToString() + " " + prodObj.KategoriObj.FullKategori);
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine("nothing found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           */



            //get ID and Kategori 
            /*
            ControllerKategori c = new ControllerKategori();
            Kategori k1 = c.getKategoriByID(2);

            Console.WriteLine(k1.getIdAndKategori);
            */

            // Test if we can write to Debug.txt
            /*
            DebugToTxt.DebugMethod("Test number#4");
            */

            //Prints view dbo.Se_sales
            /*
            List<ViewSe_Sales> viewSeSales;
            ControllerViewSe_Sales showViewSe_sales = new ControllerViewSe_Sales();
            viewSeSales = showViewSe_sales.getViewSe_Sales();
            try
            {
                foreach (ViewSe_Sales viewObj in viewSeSales)
                {
                    Console.WriteLine("varenr: " + viewObj.ProdVareNr.Varenummer.ToString() + " beskrivelse: " + viewObj.ProdBeskriv.Beskrivelse.ToString() +
                        " Kategori: " + viewObj.Kategori.FullKategori.ToString() + " antal: " + viewObj.Antal.Antal.ToString() + " pris: " + viewObj.ProdPris.Pris.ToString());
                }
            }

            catch(Exception e)
            {
                //Console.WriteLine(e.ToString());
                DebugToTxt.DebugMethod(e.ToString());
            }
            */
            


            //Prints what in Minimum Stock
            
            /*
            List<Stock> stockItems;
            ControllerStock showMinStock = new ControllerStock();

            stockItems = showMinStock.getStockByMin();

         
          // How do we convert katId to the Name? Yet to be done 

            try
            {                    
                
                if (stockItems.Count != 0)
               {
                   foreach (Stock stockObj in stockItems)
                   {
                       //Stock.bvarenr, Stock.antal, Stock.minimum, Stock.bkatId, Kategori.kategori
                       Console.WriteLine("varnr: " + stockObj.ProductObj.Varenummer.ToString() + "\r\nAntal: " + stockObj.Antal.ToString()
                           + "\r\nMinimum: " + stockObj.Minimum.ToString() + "\r\nKategori: " + stockObj.KategoriObj.FullKategori.ToString());
                   }
                    
                }
                else
                {
                    Console.WriteLine("nothing found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
           */


            //Update Antal in Stock
            /*
            ControllerStock updateTest = new ControllerStock();
            updateTest.setUpdateAntal(5000, 12049); //antal, bvarenr
            */
            
            Console.ReadKey();
        }
    }
}
