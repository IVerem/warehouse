using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Done by Rasmus Overgaard
namespace GUI
{
    public partial class Fjern_kategori : Form
    {
        public Fjern_kategori()
        {
            InitializeComponent();
            List<itn0912_2DBLayer.ModelLayer.Kategori> KatListe;
            itn0912_2DBLayer.Controller.ControllerKategori KateCtr = new itn0912_2DBLayer.Controller.ControllerKategori();
            KatListe = KateCtr.getAllKats();

            foreach (itn0912_2DBLayer.ModelLayer.Kategori KatObj in KatListe)
            {
                comboBox_Form_Add_kategori.Items.Add(KatObj.FullKategori);
            }
        }

        private void button_Form_remove_kategori_fortryd_Click(object sender, EventArgs e)
        {
            this.Close(); // Lukker formen
        }

        private void button_Form_Fjern_kategori_ok_Click(object sender, EventArgs e)
        {
            string valgt = comboBox_Form_Add_kategori.SelectedItem.ToString();
            itn0912_2DBLayer.Controller.ControllerKategori FjernKategori = new itn0912_2DBLayer.Controller.ControllerKategori();
            FjernKategori.removeKategori(valgt);
            MessageBox.Show("Dette fjerner kategorien " + valgt + " fra databasen");
            this.Close();
        }
    }
}
