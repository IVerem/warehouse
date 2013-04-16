using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth;
using itn0912_2DBLayer;
using itn0912_2DBLayer.ModelLayer;
// Done by Rasmus Overgaard
namespace GUI
{
    public partial class MainForm : Form
    {
        // Listen skal være her for at vi kan kalde den både fra søge funktion og fra combobox.
        //private List<itn0912_2DBLayer.Controller.ControllerProduct> productItems = new List<itn0912_2DBLayer.Controller.ControllerProduct>();
        private List<itn0912_2DBLayer.ModelLayer.Product> productItems = new List<itn0912_2DBLayer.ModelLayer.Product>();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_soeg_Click(object sender, EventArgs e)
        {
            panel_kategori.Visible = false;
            panel_aendre.Visible = false;
            panel_lager.Visible = false;
            panel_salg.Visible = false;
            panel_soeg.Visible = true;
        }

        private void button_kategori_Click(object sender, EventArgs e)
        {
            panel_aendre.Visible = false;
            panel_soeg.Visible = false;
            panel_lager.Visible = false;
            panel_salg.Visible = false;
            panel_kategori.Visible = true;

            // Fylder indhold i vores combobox med det samme at panel'et "åbnes". 
            List<itn0912_2DBLayer.ModelLayer.Kategori> KategoriListe;
            itn0912_2DBLayer.Controller.ControllerKategori KategoriCtr = new itn0912_2DBLayer.Controller.ControllerKategori();
            KategoriListe = KategoriCtr.getAllKats();
            comboBox_kategori.Items.Clear();
            foreach (itn0912_2DBLayer.ModelLayer.Kategori KategoriObj in KategoriListe)
            {
                comboBox_kategori.Items.Add(KategoriObj.FullKategori);
            }
        }

        private void button_aendre_Click(object sender, EventArgs e)
        {
            panel_kategori.Visible = false;
            panel_soeg.Visible = false;
            panel_lager.Visible = false;
            panel_salg.Visible = false;
            panel_aendre.Visible = true;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_lager_Click(object sender, EventArgs e)
        {
            // Tjekker om brugeren er medlem af den rigtige gruppe på DomainControlleren. Hvis ja, viser program data, hvis nej, giv en fejl besked.
            if (Auth.Auth.UserCheck(Environment.UserName, "Lager"))
            {
                panel_soeg.Visible = false;
                panel_kategori.Visible = false;
                panel_aendre.Visible = false;
                panel_salg.Visible = false;
                panel_lager.Visible = true;
            }
            else
            {
                MessageBox.Show("Kontroller rettigheder. Du skal være medlem af gruppen 'Lager' på Domain Controlleren", "Adgang nægtet", MessageBoxButtons.OK);
            }
        }


        private void button_lager_soeg_varenr_Click(object sender, EventArgs e)
        {
            itn0912_2DBLayer.Controller.ControllerProduct SearchVareNr = new itn0912_2DBLayer.Controller.ControllerProduct();
            int varenr = Convert.ToInt32(textBox_lager_varenr.Text.ToString()); // Konvetere vores string fra textboxen til en int, så den kan benyttes i metoden på linjen herunder.
            productItems = SearchVareNr.searchProductByVarenummer(varenr);
            try
            {
                if (productItems != null)
                {   // Fylder data i vores textboxe
                    comboBox_lager_vaelg.Items.Clear(); // Tømmer combobox'en der bruges til seachByDesc i tilfælde af at vi har søgt på beskrivlese før varenr.
                    textBox_lager_pris.Text = productItems.ElementAt(0).Pris.ToString();
                    textBox_lager_beskriv.Text = productItems.ElementAt(0).Beskrivelse;
                    textBox_lager_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                    textBox_lager_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;  
                }
                else
                {
                    MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }

        private void button_lager_soeg_beskriv_Click(object sender, EventArgs e)
        { 
           itn0912_2DBLayer.Controller.ControllerProduct searchDecb = new itn0912_2DBLayer.Controller.ControllerProduct();
           productItems = searchDecb.searchProductByDesc(textBox_lager_beskriv.Text.Trim()); // Trim gør at feltet tømmes inden vi fylder det igen.
           try
            {
                  if (productItems != null)
                { // Fylder data i vores textboxe
                  textBox_lager_pris.Text = productItems.ElementAt(0).Pris.ToString();
                  textBox_lager_beskriv.Text = productItems.ElementAt(0).Beskrivelse;
                  textBox_lager_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                  textBox_lager_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;

                    comboBox_lager_vaelg.Items.Clear(); // Sikre at combobox'en er tom inden foreach loopet køres.
                    foreach (itn0912_2DBLayer.ModelLayer.Product prodObj in productItems)
                    {
                        comboBox_lager_vaelg.Items.Add(prodObj.Beskrivelse); // Tilføjer varernes beskrivelser til combobox'en.
                    }
                    
                  }
                 else
                {
                     MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                 }
          }
          catch (Exception)
           {
               MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }    
         

        private void button_aendre_add_kategori_Click(object sender, EventArgs e)
        {
            // Åbner formen "Add_kategori.cs"
            Add_kategori add_kategori = new Add_kategori();
            add_kategori.Show();    
        }

        private void button_aendre_fjern_kategori_Click(object sender, EventArgs e)
        {
            // Åbner formen "Fjern_kategori.cs"
            Fjern_kategori fjern_kategori = new Fjern_kategori();
            fjern_kategori.Show();
        }

        private void comboBox_kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valgt_kategori = comboBox_kategori.SelectedItem.ToString();

            List<itn0912_2DBLayer.ModelLayer.Product> productItems = new List<itn0912_2DBLayer.ModelLayer.Product>();
            itn0912_2DBLayer.Controller.ControllerProduct productCallMethod = new itn0912_2DBLayer.Controller.ControllerProduct();
            productItems = productCallMethod.getBeskrivelseByKategori(valgt_kategori);
            richTextBox_lager_beskrivelse.Clear();
           
            if (productItems != null)
            {
                foreach (Product blah in productItems)
                {
                    richTextBox_lager_beskrivelse.Text += blah.Beskrivelse.ToString() + "\n";
                }
            }
            else
            {
                MessageBox.Show("Den valgte kategori indeholder ingen varer", "Fejl!");
            }

        }

        private void comboBox_lager_vaelg_SelectedIndexChanged(object sender, EventArgs e)
        {     
            // Fylder vores søgeresultater ind i comboboxen. 
            // Der kan i comboboxen vælges et produkt som vises med pris osv i textbox.
            int index = comboBox_lager_vaelg.SelectedIndex;
            textBox_lager_pris.Text = productItems.ElementAt(index).Pris.ToString();
            textBox_lager_beskriv.Text = productItems.ElementAt(index).Beskrivelse;
            textBox_lager_varenr.Text = productItems.ElementAt(index).Varenummer.ToString();
            textBox_lager_kategori.Text = productItems.ElementAt(index).KategoriObj.FullKategori;
        }

        private void button_soeg_soeg_varenr_Click(object sender, EventArgs e)
        {
            itn0912_2DBLayer.Controller.ControllerProduct SearchVareNr = new itn0912_2DBLayer.Controller.ControllerProduct();
            int varenr = Convert.ToInt32(textBox_soeg_varenr.Text.ToString()); // Konvetere vores string fra textboxen til en int, så den kan benyttes i metoden på linjen herunder.
            productItems = SearchVareNr.searchProductByVarenummer(varenr);
            try
            {
                if (productItems != null)
                {   // Fylder data i vores textboxe
                    textBox_soeg_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                    textBox_soeg_beskrivelse.Text = productItems.ElementAt(0).Beskrivelse;
                    textBox_soeg_pris.Text = productItems.ElementAt(0).Pris.ToString();
                    textBox_soeg_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;
                }
                else
                {
                    MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }

        private void button_soeg_soeg_beskrivelse_Click(object sender, EventArgs e)
        {
            itn0912_2DBLayer.Controller.ControllerProduct searchDecb = new itn0912_2DBLayer.Controller.ControllerProduct();
            productItems = searchDecb.searchProductByDesc(textBox_soeg_beskrivelse.Text.Trim()); // Trim gør at feltet tømmes inden vi fylder det igen.
            try
            {
                if (productItems != null)
                { // Fylder data i vores textboxe
                    textBox_soeg_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                    textBox_soeg_beskrivelse.Text = productItems.ElementAt(0).Beskrivelse;
                    textBox_soeg_pris.Text = productItems.ElementAt(0).Pris.ToString();
                    textBox_soeg_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;
                    
                    comboBox_soeg_vaelg.Items.Clear();
                    foreach (itn0912_2DBLayer.ModelLayer.Product prodObj in productItems)
                    {
                        comboBox_soeg_vaelg.Items.Add(prodObj.Beskrivelse); // Tilføjer varernes beskrivelser til combobox'en.
                    }
                }
                else
                {
                    MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }

        private void button_aendre_soeg_varenr_Click(object sender, EventArgs e)
        {
            itn0912_2DBLayer.Controller.ControllerProduct SearchVareNr = new itn0912_2DBLayer.Controller.ControllerProduct();
            int varenr = Convert.ToInt32(textBox_aendre_varenr.Text.ToString()); // Konvetere vores string fra textboxen til en int, så den kan benyttes i metoden på linjen herunder.
            productItems = SearchVareNr.searchProductByVarenummer(varenr);
            try
            {
                if (productItems != null)
                {   // Fylder data i vores textboxe
                    textBox_aendre_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                    textBox_aendre_beskriv.Text = productItems.ElementAt(0).Beskrivelse;
                    textBox_aendre_pris.Text = productItems.ElementAt(0).Pris.ToString();
                    textBox_aendre_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;
                }
                else
                {
                    MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }

        private void button_aendre_soeg_beskrivelse_Click(object sender, EventArgs e)
        {
            itn0912_2DBLayer.Controller.ControllerProduct searchDecb = new itn0912_2DBLayer.Controller.ControllerProduct();
            productItems = searchDecb.searchProductByDesc(textBox_aendre_beskriv.Text.Trim()); // Trim gør at feltet tømmes inden vi fylder det igen.
            try
            {
                if (productItems != null)
                { // Fylder data i vores textboxe
                    textBox_aendre_varenr.Text = productItems.ElementAt(0).Varenummer.ToString();
                    textBox_aendre_beskriv.Text = productItems.ElementAt(0).Beskrivelse;
                    textBox_aendre_pris.Text = productItems.ElementAt(0).Pris.ToString();
                    textBox_aendre_kategori.Text = productItems.ElementAt(0).KategoriObj.FullKategori;

                    comboBox_aendre_vaelg.Items.Clear();
                    foreach (itn0912_2DBLayer.ModelLayer.Product prodObj in productItems)
                    {
                        comboBox_aendre_vaelg.Items.Add(prodObj.Beskrivelse); // Tilføjer varernes beskrivelser til combobox'en.
                    }
                }
                else
                {
                    MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke finde det du søger", "Error", MessageBoxButtons.OK);
            }
        }

        private void button_aendre_antal_lager_Click(object sender, EventArgs e)
        {
            // Tjekker om man klikker OK til denne messagebox. Hvis vi gør det, udføres koden. Ellers gør programmet intet.
            if (MessageBox.Show("Har du indtastet data i varenummer og antal", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { 
                itn0912_2DBLayer.Controller.ControllerStock updateStock = new itn0912_2DBLayer.Controller.ControllerStock();
                int varenr = Convert.ToInt32(textBox_aendre_varenr.Text.ToString()); // Konveterer vores string (textboxe) til int's
                int antal = Convert.ToInt32(textBox_aendre_antal.Text.ToString());
                updateStock.setUpdateAntal(antal, varenr);
            }
        }

        private void button_lager_varer_min_Click(object sender, EventArgs e)
        {
            // Åbner formen "List_minimum_stock.cs"
            List_minimum_stock list_minimum_stock = new List_minimum_stock();
            list_minimum_stock.Show();
        }

        private void comboBox_aendre_vaelg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fylder vores søgeresultater ind i comboboxen. 
            // Der kan i comboboxen vælges et produkt som vises med pris osv i textbox.
            int index = comboBox_aendre_vaelg.SelectedIndex;
            textBox_aendre_pris.Text = productItems.ElementAt(index).Pris.ToString();
            textBox_aendre_beskriv.Text = productItems.ElementAt(index).Beskrivelse;
            textBox_aendre_varenr.Text = productItems.ElementAt(index).Varenummer.ToString();
            textBox_aendre_kategori.Text = productItems.ElementAt(index).KategoriObj.FullKategori;
        }

        private void comboBox_soeg_vaelg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fylder vores søgeresultater ind i comboboxen. 
            // Der kan i comboboxen vælges et produkt som vises med pris osv i textbox.
            int index = comboBox_soeg_vaelg.SelectedIndex;
            textBox_soeg_pris.Text = productItems.ElementAt(index).Pris.ToString();
            textBox_soeg_beskrivelse.Text = productItems.ElementAt(index).Beskrivelse;
            textBox_soeg_varenr.Text = productItems.ElementAt(index).Varenummer.ToString();
            textBox_soeg_kategori.Text = productItems.ElementAt(index).KategoriObj.FullKategori;
        }

        private void button_salg_Click(object sender, EventArgs e)
        {
            // Tjekker om brugeren er medlem af den rigtige gruppe på DomainControlleren. Hvis ja, viser program data, hvis nej, giv en fejl besked.
            if (Auth.Auth.UserCheck(Environment.UserName, "Sales"))
            {
                panel_kategori.Visible = false;
                panel_soeg.Visible = false;
                panel_lager.Visible = false;
                panel_salg.Visible = true;
                panel_aendre.Visible = false;

                List<itn0912_2DBLayer.ModelLayer.ViewSe_Sales> ViewSeSales;
                itn0912_2DBLayer.Controller.ControllerViewSe_Sales ShowViewSe_sales = new itn0912_2DBLayer.Controller.ControllerViewSe_Sales();
                ViewSeSales = ShowViewSe_sales.getViewSe_Sales();
                richTextBox_salg.Clear();
                // Fylder indhold i vores combobox med det samme at panel'et "åbnes".
                foreach (itn0912_2DBLayer.ModelLayer.ViewSe_Sales SalgObj in ViewSeSales)
                {
                    richTextBox_salg.Text += "Varenr: " + SalgObj.ProdVareNr.Varenummer.ToString() + " Beskrivelse: " + SalgObj.ProdBeskriv.Beskrivelse + " Pris: " + SalgObj.ProdPris.Pris.ToString()
                        + " Kategori: " + SalgObj.Kategori.FullKategori + " Antal: " + SalgObj.Antal.Antal.ToString() + "\n\n";
                }
            }
            else
            {
                MessageBox.Show("Kontroller rettigheder. Du skal være medlem af gruppen 'Sales' på Domain Controlleren", "Adgang nægtet", MessageBoxButtons.OK);
            }
        }
        }
        }