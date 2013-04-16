using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itn0912_2DBLayer.ModelLayer;
using itn0912_2DBLayer.DBLayer;
/*
 * Done By Asbjørn
 */
namespace itn0912_2DBLayer.Controller
{
    public class ControllerStock
    {

        public List<Stock> getStockByMin()
        {
            StockDB stockObj = new StockDB();
            return stockObj.getStockByMin();
        }


        public bool setUpdateAntal(int antal, int bvarenr)
        {
            Stock antalUpdate = new Stock(antal, bvarenr); //opretter object af DB-klassen, da den ikke er static
            StockDB DBStockObj = new StockDB();
            bool updateOK = DBStockObj.updateAntal(antalUpdate);
           
            return updateOK;
        }
        
    }
}
