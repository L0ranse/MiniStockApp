using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStockApp
{
    public partial class Form1 : Form
    {
        // SQL'e geçene kadar verileri tutacağımız geçici liste
        public static List<Product> ProductList = new List<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        // Tabloyu güncelleyecek metodumuz
        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ProductList;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult cevap = MessageBox.Show("Are you sure you want to delete the selected product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (cevap == DialogResult.Yes)
                {
                    Product secilenUrun = (Product)dataGridView1.CurrentRow.DataBoundItem;
                    ProductList.Remove(secilenUrun);
                    RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //// DİKKAT: Bunun çalışması için Form1 tasarımına 'searchTextBox' adında bir TextBox eklemelisin!
            //if (searchTextBox != null && !string.IsNullOrWhiteSpace(searchTextBox.Text))
            //{
            //    string aranan = searchTextBox.Text.ToLower();
            //    var filtreliListe = ProductList.Where(urun => urun.Name.ToLower().Contains(aranan)).ToList();

            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = filtreliListe;
            //}
            //else
            //{
            //    RefreshGrid(); // Arama kutusu boşsa tüm listeyi geri yükle
            //}
        }

        private void newProductBtn_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            RefreshGrid();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Tablodan seçili ürünü al ve Form2'ye gönder
                Product secilen = (Product)dataGridView1.CurrentRow.DataBoundItem;

                Form2 frm = new Form2();
                frm.DuzenlenecekUrun = secilen;
                frm.ShowDialog();

                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Please select a product to edit from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lowStockItemsBtn_Click(object sender, EventArgs e)
        {
            // Stoğu 10'dan az olanları listeler. Sayıyı ihtiyacına göre değiştirebilirsin.
            var azalanStoklar = ProductList.Where(urun => urun.Stock < 10).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = azalanStoklar;

            if (azalanStoklar.Count == 0)
            {
                MessageBox.Show("There are no low stock items.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}