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
    public class ControllerKategori
    {
        /*
        public Controller()
        {
        }*/

        public Kategori getKategoriByID(int id)
        {
            KategoriDB DBKatObj = new KategoriDB();

            return DBKatObj.getKategoriByID(id);
        }



        public List<Kategori> getAllKats()
        {
            //KategoriDB DBKatObj = new KategoriDB();
            itn0912_2DBLayer.Controller.KategoriDB DBKatObj = new itn0912_2DBLayer.Controller.KategoriDB();
            return DBKatObj.getAllKats();
        }


        //Creates a Kategori 
        public bool createKategori(string kategori)
        {
            Kategori katAdd = new Kategori(kategori); // opretter objekt af DB-klassen, fordi den ikke er static
            KategoriDB DBKatObj = new KategoriDB();
            bool kategoriOk = DBKatObj.addKategori(katAdd);
            
            return kategoriOk;
        }

        //Removes a kategori 

        public bool removeKategori(string kategori)
        {
            Kategori katRemo = new Kategori(kategori);
            KategoriDB katDBObj = new KategoriDB();

            bool kategoriOk = katDBObj.deleteKategori(katRemo);

            return kategoriOk;
        }

        
        
    }
}
