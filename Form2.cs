using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniStockApp
{
    public partial class Form2 : Form
    {
        public Product DuzenlenecekUrun = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (DuzenlenecekUrun == null)
            {
                
                Product newProduct = new Product();

                newProduct.Name = productNameText.Text;
                newProduct.Category = productCategoryComboBox.Text;
                newProduct.Stock = Convert.ToInt32(stockNumericUpDown.Value);
                newProduct.Price = Convert.ToDecimal(priceMaskedTextBox.Text);

                Form1.ProductList.Add(newProduct);
                MessageBox.Show("Product added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                DuzenlenecekUrun.Name = productNameText.Text;
                DuzenlenecekUrun.Category = productCategoryComboBox.Text;
                DuzenlenecekUrun.Stock = Convert.ToInt32(stockNumericUpDown.Value);
                DuzenlenecekUrun.Price = Convert.ToDecimal(priceMaskedTextBox.Text);

                MessageBox.Show("Product updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (DuzenlenecekUrun != null)
            {
                productNameText.Text = DuzenlenecekUrun.Name;
                productCategoryComboBox.Text = DuzenlenecekUrun.Category;
                stockNumericUpDown.Value = DuzenlenecekUrun.Stock;
                priceMaskedTextBox.Text = DuzenlenecekUrun.Price.ToString();
            }
        }
    }
}