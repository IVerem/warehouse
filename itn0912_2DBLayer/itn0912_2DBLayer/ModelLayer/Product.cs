using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Done by Asbjørn Birch 
 */
namespace itn0912_2DBLayer.ModelLayer
{
    public class Product
    {
        private int varenummer;
        private string beskrivelse;
        private int pris;
        //private int katId; // skal være objekt af Kategori (?) 
        private Kategori kategoriObj;

        public Kategori KategoriObj
        {
            get { return kategoriObj; }
            set { kategoriObj = value; }
        }


        // Constructor that fits getProductByDesc
        public Product(int varenummer, string beskrivelse, int pris, string kategori)
        {
            this.varenummer = varenummer;
            this.beskrivelse = beskrivelse;
            this.pris = pris;
            kategoriObj = new Kategori();
            kategoriObj.FullKategori = kategori;

        }

        //Constructor that takes 0 arguments, in order to create varenummer as object in stock-class
        public Product()
        {
        }

        // Constructor der bruges til GetBeskrivelseByKategori
        public Product(string beskrivelse)
        {
            this.beskrivelse = beskrivelse;
        }
 /*
        public Product(int varenummer, string beskrivelse, int pris, int katId)
        {
            this.varenummer = varenummer;
            this.beskrivelse = beskrivelse;
            this.pris = pris;
            kategoriObj = new Kategori();
            kategoriObj.ID = katId;
            
        }

       
        public Product(int varenummer, string beskrivelse, int pris)
        {
            this.varenummer = varenummer;
            this.beskrivelse = beskrivelse;
            this.pris = pris;
        }
        

        public Product(int varenummer, string beskrivelse, int pris)
        {
            this.varenummer = varenummer;
            this.beskrivelse = beskrivelse;
            this.pris = pris;
        }
*/
        public int Varenummer
        {
            get { return varenummer; }
            set { varenummer = value; }
        }

        public string Beskrivelse
        {
            get { return beskrivelse; }
            set { beskrivelse = value; }
        }

        public int Pris
        {
            get { return pris; }
            set { pris = value; }
        }


    }
}
