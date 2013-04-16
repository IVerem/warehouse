using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itn0912_2DBLayer.ModelLayer
{
   public class ViewSe_Sales
    {

        private Kategori katKategori;
        private Product prodVareNr; 
        private Product prodBeskriv; 
        private Product  prodPris;
        private Stock stockAntal;

       // HAR ÆNDRET FRA INTERAL KATEGORI KATEGORI TIL PUBLIC!!!
        //encapsulate Kategori 
        public Kategori Kategori
        {
            get { return katKategori; }
            set { katKategori = value; }
        }

        //encapsulate Product.prodpris
        public Product ProdPris
        {
            get { return prodPris; }
            set { prodPris = value; }
        }

        //encapsulate Product prodVareNr
        public Product ProdVareNr
        {
            get { return prodVareNr; }
            set { prodVareNr = value; }
        }

        //encapsulate Product prodBeskriv
        public Product ProdBeskriv
        {
            get { return prodBeskriv; }
            set { prodBeskriv = value; }
        }

        //encapsulate Stock antal
        public Stock Antal
        {
            get { return stockAntal; }
            set { stockAntal = value; }
        }
    

        //lé constructor 
        public ViewSe_Sales(string kategori, int varenummer, string beskrivelse, int antal, int pris)
        {
            katKategori = new Kategori();
            katKategori.FullKategori = kategori;

            prodVareNr = new Product();
            prodVareNr.Varenummer = varenummer;

            prodBeskriv = new Product();
            prodBeskriv.Beskrivelse = beskrivelse;

            stockAntal = new Stock();
            stockAntal.Antal = antal;

            prodPris = new Product();
            prodPris.Pris = pris;
        }
    
    }
}

