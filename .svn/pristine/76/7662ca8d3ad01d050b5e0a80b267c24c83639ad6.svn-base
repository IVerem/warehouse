using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * Dont by Asbjørn Birch
 */
namespace itn0912_2DBLayer.ModelLayer
{
   public class Stock
    {
        private int antal;
        private int minimum;
        private Kategori kategoriObj;
        private Product productObj;

        //Encapsulated Kategori
        internal Kategori KategoriObj
        {
            get { return kategoriObj; }
            set { kategoriObj = value; }
        }
       
        //Encapsulated Product 
        public Product ProductObj
        {
            get { return productObj; }
            set { productObj = value; }
        }

        //Constructor
        public Stock(int antal, int minimum, int bkatId, int bvarenr)
        {
            this.antal = antal;
            this.minimum = minimum;
            
            kategoriObj = new Kategori();
            kategoriObj.ID = bkatId;

            productObj = new Product();
            productObj.Varenummer = bvarenr;
        }

        //Custom constructor for antal < minimum
        //C# looks at the numbers of arguments and type - when getting the constructor from another class.method
        //Stock.bvarenr, Stock.antal, Stock.minimum, Stock.bkatId, Kategori.kategori
        public Stock(int bvarenr, int antal, int minimum, int bkatId, string kategori)
        {
            this.antal = antal;
            this.minimum = minimum;

            kategoriObj = new Kategori();
            kategoriObj.ID = bkatId;
            kategoriObj.FullKategori = kategori;

            productObj = new Product();
            productObj.Varenummer = bvarenr;
        }

        public Stock(int antal, int bvarenr) //constructor for setUpdateAntal 
        {
            this.antal = antal;
            productObj = new Product();
            productObj.Varenummer = bvarenr;
        }

        public Stock() //constructor for ViewSe_Sales 
        { }


        public int Antal
        {
            get { return antal; }
            set { antal = value; }
        
        }

        public int Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }

    }
}
