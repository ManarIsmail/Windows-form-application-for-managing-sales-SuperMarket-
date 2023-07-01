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
    public partial class Product_list : Form
    {
        POSTutEntities db = new POSTutEntities();
        int id=0;
        POSDemo.DB.Product result;
        string imagePath="";

        public Product_list()
        {
            InitializeComponent();
            comboBox1.DataSource = db.Categories.ToList();
            comboBox2.DataSource = db.Categories.ToList();

            bunifuCustomDataGrid1.DataSource = db.Products.OrderBy(x => x.Name).ToList();

            //MessageBox.Show(db.Products.Min(x => x.Price).ToString());
            //var xx = db.Products.Sum(x => x.Price);
            //MessageBox.Show(xx.ToString());
        }
        private void Product_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet3.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.pOSTutDataSet3.Product);
            // TODO: This line of code loads data into the 'pOSTutDataSet2.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.pOSTutDataSet2.Category);
            // TODO: This line of code loads data into the 'pOSTutDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.pOSTutDataSet.Product);

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txtName.Text=="")
            {
                bunifuCustomDataGrid1.DataSource = db.Products.Where(x => x.Code == txtBarcode.Text).ToList();
            }
            else
            {
                bunifuCustomDataGrid1.DataSource = db.Products.Where(x => x.Code == txtBarcode.Text ||
                                                                 x.Name.Contains(txtName.Text)).ToList();
            }
            

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = db.Products.ToList();

        }
        
        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                result = db.Products.SingleOrDefault(x => x.id == id);

                
                txtFormBarcode.Text = result.Code;
                txtFormnName.Text = result.Name;
                txtFormPrice.Text = result.Price.ToString();
                txtFormQty.Text = result.Quantity.ToString();
                txtFormNotes.Text = result.Notes;
                pictureBox1.ImageLocation = result.Image;
                comboBox1.SelectedValue = result.CategoryId;
            }
            catch { }
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
            id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            result = db.Products.SingleOrDefault(x => x.id == id);
            result.Name = txtFormnName.Text;
            result.Code = txtFormBarcode.Text;
            result.Price = decimal.Parse( txtFormPrice.Text);
            result.Quantity = int.Parse(txtFormQty.Text);
            result.Notes=txtFormNotes.Text;
            result.CategoryId =int.Parse( comboBox1.SelectedValue.ToString());    
            if (imagePath != "")
            {
                string newPath = Environment.CurrentDirectory + "\\images\\Products\\" + result.id + ".jpg";
                File.Copy(imagePath, newPath, true);
                result.Image = newPath;
                db.SaveChanges();
            }
            db.SaveChanges();
            MessageBox.Show("تم التعديل بنجاح");
            bunifuCustomDataGrid1.DataSource = db.Products.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialoge = new OpenFileDialog();
            if (dialoge.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialoge.FileName;
                pictureBox1.ImageLocation = dialoge.FileName;
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
           var r= MessageBox.Show("هل تريد الحذف","تاكيد الحذف",MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Products.Find(id);
                db.Products.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم الحذف بنجاح");
                bunifuCustomDataGrid1.DataSource = db.Products.ToList();
                MessageBox.Show("تم الحذف بنجاح");
            }
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Product p=new Product();
            p.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
              int catid = int.Parse(comboBox2.SelectedValue.ToString());
            bunifuCustomDataGrid1.DataSource = db.Products.Where(x => x.CategoryId == catid).ToList();

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
