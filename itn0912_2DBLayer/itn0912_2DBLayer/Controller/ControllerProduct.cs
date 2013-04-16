using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itn0912_2DBLayer.ModelLayer;
using itn0912_2DBLayer.DBLayer;
/*
Done by Asbjørn Birch 
 */
namespace itn0912_2DBLayer.Controller
{
   public class ControllerProduct
    {

        //creates a list with products. search by string str
        public List<Product> searchProductByDesc(string str)
        {
            ProductDB ProdObj = new ProductDB();
            return ProdObj.getProductByDesc(str);
        }

        public List<Product> searchProductByVarenummer(int vareNo)
        {
            ProductDB prodObj = new ProductDB();
            return prodObj.getProductByVarenummer(vareNo);
        }


        // Done by Rasmus Overgaard - start
        public List<Product> getBeskrivelseByKategori(string name)
        {
            ProductDB dbKatObj = new ProductDB();
            return dbKatObj.getBeskrivelseByKategori(name);
            
        }
        // Done by Rasmus Overgaard - slut
    }
}
