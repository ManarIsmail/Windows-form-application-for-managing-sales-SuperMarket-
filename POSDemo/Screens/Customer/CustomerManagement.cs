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

namespace POSDemo.Screens.Customer
{
    public partial class CustomerManagement : Form
    {
        POSTutEntities db = new POSTutEntities();
        int id;
        POSDemo.DB.Customer result;

        public CustomerManagement()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            bunifuCustomDataGrid1.DataSource = db.Customers.ToList();
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                bunifuCustomDataGrid1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();
            }
            else
            {
                bunifuCustomDataGrid1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text) ||
                                                                 x.Name.Contains(txtName.Text)).ToList();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = db.Customers.ToList();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("اضافة عميل جديد", "هل انت متاكد من اضافة هذا العميل كعميل جديد؟", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {


                if (txtFormName.Text == "" || txtFormPhone.Text == "")
                {
                    MessageBox.Show("برجاء اكمال البيانات المطلوبة اولا");
                }
                else
                {
                    POSDemo.DB.Customer c = new POSDemo.DB.Customer();
                    c.Name = txtFormName.Text;
                    c.Phone = txtFormPhone.Text;
                    c.Notes = txtNotes.Text;
                    c.Email = txtMail.Text;
                    c.address = txtAddress.Text;
                    c.Company = txtCompany.Text;
                    c.isActive = checkBox1.Checked;

                    db.Customers.Add(c);
                    db.SaveChanges();
                    MessageBox.Show("تم حفظ  العميل");


                    txtFormName.Text = "";
                    txtFormPhone.Text = "";
                    txtNotes.Text = "";
                    txtMail.Text = "";
                    txtAddress.Text = "";
                    txtCompany.Text = "";
                    checkBox1.Checked = false;
                    bunifuCustomDataGrid1.DataSource = db.Customers.ToList();
                }
            }
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                result = db.Customers.SingleOrDefault(x => x.id == id);
                txtFormName.Text = result.Name;
                txtFormPhone.Text = result.Phone;
                txtNotes.Text = result.Notes;
                txtMail.Text = result.Email;
                txtAddress.Text = result.address;
                txtCompany.Text = result.Company;
                if (result.isActive == null)
                {
                    result.isActive = false;
                }
                checkBox1.Checked = (bool)result.isActive;
            }
            catch { }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف", "تاكيد الحذف", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Customers.Find(id);
                db.Customers.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم الحذف بنجاح");
                bunifuCustomDataGrid1.DataSource = db.Customers.ToList();

            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد حفظ التعديل", "تاكيد التعديل", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                result = db.Customers.SingleOrDefault(x => x.id == id);
                result.Name = txtFormName.Text;
                result.Phone = txtFormPhone.Text;
                result.Notes = txtNotes.Text;
                result.Email = txtMail.Text;
                result.address = txtAddress.Text;
                result.Company = txtCompany.Text;
                result.isActive = checkBox1.Checked;
                db.SaveChanges();
                MessageBox.Show("تم التعديل بنجاح");
                bunifuCustomDataGrid1.DataSource = db.Customers.ToList();
            }
        }

        
    }
}
