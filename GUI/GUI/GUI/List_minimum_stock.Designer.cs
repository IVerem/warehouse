namespace GUI
{
    partial class List_minimum_stock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_form_list_minimum_stock_print = new System.Windows.Forms.Button();
            this.richTextBox_form_list_minimum_stock = new System.Windows.Forms.RichTextBox();
            this.button_form_list_minimum_stock_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_form_list_minimum_stock_print
            // 
            this.button_form_list_minimum_stock_print.Location = new System.Drawing.Point(59, 212);
            this.button_form_list_minimum_stock_print.Name = "button_form_list_minimum_stock_print";
            this.button_form_list_minimum_stock_print.Size = new System.Drawing.Size(75, 23);
            this.button_form_list_minimum_stock_print.TabIndex = 0;
            this.button_form_list_minimum_stock_print.Text = "Vis varer";
            this.button_form_list_minimum_stock_print.UseVisualStyleBackColor = true;
            this.button_form_list_minimum_stock_print.Click += new System.EventHandler(this.button_form_list_minimum_stock_print_Click);
            // 
            // richTextBox_form_list_minimum_stock
            // 
            this.richTextBox_form_list_minimum_stock.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_form_list_minimum_stock.Name = "richTextBox_form_list_minimum_stock";
            this.richTextBox_form_list_minimum_stock.Size = new System.Drawing.Size(260, 194);
            this.richTextBox_form_list_minimum_stock.TabIndex = 2;
            this.richTextBox_form_list_minimum_stock.Text = "";
            // 
            // button_form_list_minimum_stock_exit
            // 
            this.button_form_list_minimum_stock_exit.Location = new System.Drawing.Point(140, 212);
            this.button_form_list_minimum_stock_exit.Name = "button_form_list_minimum_stock_exit";
            this.button_form_list_minimum_stock_exit.Size = new System.Drawing.Size(75, 23);
            this.button_form_list_minimum_stock_exit.TabIndex = 3;
            this.button_form_list_minimum_stock_exit.Text = "Exit";
            this.button_form_list_minimum_stock_exit.UseVisualStyleBackColor = true;
            this.button_form_list_minimum_stock_exit.Click += new System.EventHandler(this.button_form_list_minimum_stock_exit_Click);
            // 
            // List_minimum_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button_form_list_minimum_stock_exit);
            this.Controls.Add(this.richTextBox_form_list_minimum_stock);
            this.Controls.Add(this.button_form_list_minimum_stock_print);
            this.Name = "List_minimum_stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Varer i minimum stock";
            this.Load += new System.EventHandler(this.List_minimum_stock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_form_list_minimum_stock_print;
        private System.Windows.Forms.RichTextBox richTextBox_form_list_minimum_stock;
        private System.Windows.Forms.Button button_form_list_minimum_stock_exit;
    }
}