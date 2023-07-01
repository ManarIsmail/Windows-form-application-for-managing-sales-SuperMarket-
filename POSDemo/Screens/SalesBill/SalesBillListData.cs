using POSDemo.DB;
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
    public partial class SalesBillListData : Form
    {
        POSTutEntities db = new POSTutEntities();
        public SalesBillListData()
        {
            InitializeComponent();
            bunifuCustomDataGrid2.DataSource=db.SalesBills.Select(x=> new { x.Id, x.Total,x.User.UserName, x.Customer.Name,x.Date,x.Notes}).ToList();
        }

        private void bunifuCustomDataGrid2_SelectionChanged(object sender, EventArgs e)
        {
            int id = int.Parse(bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString());
           var bill = db.SalesBills.FirstOrDefault(x => x.Id == id);
            txtNumber.Text = bill.Id.ToString();
            txtNotes.Text=bill.Notes;
            lblDiscount.Text = bill.TotalAfterDiscount.ToString();
            lblTotal.Text=bill.Total.ToString();
            bunifuDatepicker1.Value =(DateTime)bill.Date;
            txtDiscount.Text = bill.discount.ToString();
            
            bunifuCustomDataGrid1.Rows.Clear();

            foreach (var item in bill.SalesBillDetails)
            {
                bunifuCustomDataGrid1.Rows.Add(item.ProductId,item.Product.Name,item.Price,item.quantity,item.totalPrice, item.Product.Image== null? new Bitmap(20,20):Image.FromFile(item.Product.Image));
            }
            


        }

        private void SalesBillListData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet5.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.pOSTutDataSet5.Customer);

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تم الحفظ");
        }
    }
}
