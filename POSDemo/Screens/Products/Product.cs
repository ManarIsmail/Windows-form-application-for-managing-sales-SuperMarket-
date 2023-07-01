using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.Products
{
    public partial class Product : Form
    {
        POSTutEntities db = new POSTutEntities();
        string imagePath="";
        public Product()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txtName.Text==""||txtBarcode.Text==""||txtPrice.Text==""|| comboBox1.SelectedValue == null)
            {
                MessageBox.Show("برجاء اكمال البيانات المطلوبة اولا");
            }
            else
            {
                POSDemo.DB.Product prod = new POSDemo.DB.Product();
                prod.Name = txtName.Text;
                prod.Code =txtBarcode.Text;
                //prod.Price = decimal.Parse( txtPrice.Text);
                prod.Notes=txtNotes.Text;
                //prod.Quantity = int.Parse(txtQty.Text);
                prod.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
                int qty, price;
                int.TryParse(txtQty.Text, out qty);
                int.TryParse(txtPrice.Text, out price);
                prod.Price = price;
                prod.Quantity = qty;

                db.Products.Add(prod);
                db.SaveChanges();
                MessageBox.Show("تم حفظ المنتج");

                if (imagePath != "")
                {
                    string newPath = Environment.CurrentDirectory + "\\images\\Products\\" + prod.id + ".jpg";
                    File.Copy(imagePath, newPath);
                    prod.Image = newPath;
                    db.SaveChanges();
                }
                txtBarcode.Text = "";
                txtName.Text = "";
                txtNotes.Text = "";
                txtPrice.Text = "";
                txtQty.Text = "";
                pictureBox1.ImageLocation = "";
               
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialoge = new OpenFileDialog();
            if (dialoge.ShowDialog()== DialogResult.OK)
            {
                imagePath = dialoge.FileName;
                pictureBox1.ImageLocation = dialoge.FileName;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Product_list p = new Product_list();
            p.Show();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet1.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.pOSTutDataSet1.Category);

        }

        
    }
}
