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
    public partial class Add_kategori : Form
    {
        public Add_kategori()
        {
            InitializeComponent();
        }

        private void button_Form_Add_kategori_fortryd_Click(object sender, EventArgs e)
        {
            this.Close(); // Lukker formen
        }

        private void button_Form_Add_kategori_ok_Click(object sender, EventArgs e)
        {
           // itn0912_2DBLayer.Controller.ControllerKategori addKategori = new itn0912_2DBLayer.Controller.ControllerKategori();
            //addKategori.createKategori(textBox_Form_Add_kategori_input.Text);
            
            // Tager indholdet fra textboxen og sender det til metoden "createKategori". Herefter vises en bekræftelse og formen lukker.
            itn0912_2DBLayer.Controller.ControllerKategori okKat = new itn0912_2DBLayer.Controller.ControllerKategori();
            okKat.createKategori(textBox_Form_Add_kategori_input.Text);
            MessageBox.Show("Sendt " + textBox_Form_Add_kategori_input.Text + " til databasen");
            this.Close();
        }
    }
}
