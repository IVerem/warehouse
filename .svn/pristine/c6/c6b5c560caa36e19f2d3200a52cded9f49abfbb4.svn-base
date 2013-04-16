using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Done by Rasmus Overgaard
namespace GUI
{
    public partial class List_minimum_stock : Form
    {
        public List_minimum_stock()
        {
            InitializeComponent();
        }

        private void button_form_list_minimum_stock_print_Click(object sender, EventArgs e)
        {
            List<itn0912_2DBLayer.ModelLayer.Stock> stockItems;
            itn0912_2DBLayer.Controller.ControllerStock ShowMinStock = new itn0912_2DBLayer.Controller.ControllerStock();
            stockItems = ShowMinStock.getStockByMin();
            richTextBox_form_list_minimum_stock.Clear();            
            if (stockItems.Count != 0)
            {
                foreach (itn0912_2DBLayer.ModelLayer.Stock stockObj in stockItems)
                {
                    int sum = stockObj.Minimum - stockObj.Antal; 
                    richTextBox_form_list_minimum_stock.Text += "Der mangler " + sum + " stk af varenr: " + stockObj.ProductObj.Varenummer + "\n";
                }
            }
            else
            {
                string err = "Det er ikke nødvendigt at bestille flere varer hjem!";
                richTextBox_form_list_minimum_stock.Text = err;
            }
        }

        private void button_form_list_minimum_stock_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void List_minimum_stock_Load(object sender, EventArgs e)
        {
            richTextBox_form_list_minimum_stock.Clear();
        }
    }
}
