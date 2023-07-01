using POSDemo.DB;
using POSDemo.Screens.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.SalesBill
{
    public partial class SalesBillForm : Form
    {
        POSTutEntities db = new POSTutEntities();
        List<POSDemo.DB.Product> products;
        public SalesBillForm()
        {
            InitializeComponent();
            //comboBox1.DataSource = db.Customers.Where(x => x.isActive == true).ToList();
            //comboBox1.ValueMember = "id";
            //comboBox1.DisplayMember = "Name";
            products = db.Products.ToList();
            imageList1.ImageSize = new Size(83, 83);
            lblUser.Text = POSDemo.Users.Name;


        }

        private void SalesBillForm_Load(object sender, EventArgs e)
        {
            this.customerTableAdapter.FillBy(this.pOSTutDataSet4.Customer);
            for (int i = 0; i < products.Count(); i++)
            {
                if (products[i].Image != null)
                {
                    imageList1.Images.Add(Image.FromFile(products[i].Image));
                }
                else
                {
                    Bitmap btm = new Bitmap(70, 70);
                    imageList1.Images.Add(btm);
                }

                ListViewItem item = new ListViewItem();
                item.Text = products[i].Name;
                item.ImageIndex = i;
                item.Tag = products[i];
                listView1.Items.Add(item);
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {


        }

        void CalculateTotal()
        {
            try
            {
                decimal total = 0;
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount; i++)
                {
                    total += decimal.Parse(bunifuCustomDataGrid1.Rows[i].Cells["totalprice"].Value.ToString());
                }
                lblTotal.Text = total.ToString();
                decimal disc = decimal.Parse(txtDiscount.Text);
                lblDiscount.Text = (total - disc).ToString();
            }
            catch
            {

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var product = (POSDemo.DB.Product)listView1.SelectedItems[0].Tag;
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount; i++)
                {
                    if (bunifuCustomDataGrid1.Rows[i].Cells["id"].Value.ToString() == product.id.ToString())
                    {
                        bunifuCustomDataGrid1.Rows[i].Cells["quantity"].Value = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells["quantity"].Value.ToString()) + 1;
                        bunifuCustomDataGrid1.Rows[i].Cells["totalprice"].Value = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells["quantity"].Value.ToString()) * decimal.Parse(bunifuCustomDataGrid1.Rows[i].Cells["price"].Value.ToString());
                        CalculateTotal();
                        return;
                    }
                }
                bunifuCustomDataGrid1.Rows.Add(product.id, product.Name, product.Price, 1, product.Price * 1, product.Image == null ? new Bitmap(40, 40) : Image.FromFile(product.Image));
                CalculateTotal();
            }
        }

        private void txtDiscount_OnValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            POSDemo.DB.SalesBill result = new POSDemo.DB.SalesBill()
            {
                Date = bunifuDatepicker1.Value.Date,
                discount = decimal.Parse(txtDiscount.Text),
                Total = decimal.Parse(lblTotal.Text),
                TotalAfterDiscount = decimal.Parse(lblDiscount.Text),
                Notes = txtNotes.Text,
                CustomerId = int.Parse(comboBox1.SelectedValue.ToString()),
                UserId= POSDemo.Users.id,
            };
            List<SalesBillDetail> list = new List<SalesBillDetail>();
            for (int i = 0; i < bunifuCustomDataGrid1.RowCount; i++)
            {
                list.Add(new SalesBillDetail {
                    ProductId =  int.Parse( bunifuCustomDataGrid1.Rows[i].Cells["id"].Value.ToString()),
                    quantity  = int.Parse(bunifuCustomDataGrid1.Rows[i].Cells["quantity"].Value.ToString()),
                    Price= decimal.Parse(bunifuCustomDataGrid1.Rows[i].Cells["price"].Value.ToString()),
                    totalPrice= int.Parse(bunifuCustomDataGrid1.Rows[i].Cells["quantity"].Value.ToString())* decimal.Parse(bunifuCustomDataGrid1.Rows[i].Cells["price"].Value.ToString()),
                });
            }

            result.SalesBillDetails = list;
            db.SalesBills.Add(result);
            db.SaveChanges();

            MessageBox.Show("تم الحفظ رقم الفاتورة=" + result.Id) ;
        }

        private void bunifuCustomDataGrid1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SalesBillListData bills = new SalesBillListData();
            bills.Show();
        }
    }
}
