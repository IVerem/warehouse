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
    public class Kategori
    {
        private int id;
        private string kategori;

        public Kategori(int id, string kategori)
        {
            this.id = id;
            this.kategori = kategori;
        }

        public Kategori() { } //empty for calling it at Product.cs

        public Kategori(string kategori)
        {
            this.kategori = kategori;
        }

        public string getIdAndKategori
        {
            get { return id + " " + kategori; }
        }
        public string FullKategori
        {
            get { return this.kategori; }
            set { kategori = value; }
        }

        public int ID
        {
            get { return this.id; }
            set { id = value; }
        }



    }
}
