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

namespace POSDemo.Screens.Suppliers
{
    public partial class Suppliers : Form
    {
        POSTutEntities db = new POSTutEntities();
        int id;
        POSDemo.DB.Supplier result;
        public Suppliers()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            bunifuCustomDataGrid1.DataSource = db.Suppliers.ToList();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = db.Suppliers.ToList();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                bunifuCustomDataGrid1.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();
            }
            else
            {
                bunifuCustomDataGrid1.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text) ||
                                                                 x.Name.Contains(txtName.Text)).ToList();
            }
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                result = db.Suppliers.SingleOrDefault(x => x.id == id);
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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("اضافة عميل جديد", "هل انت متاكد من اضافة هذا العميل كعميل جديد؟", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {


                if (txtFormName.Text == "" || txtFormPhone.Text == "")
                {
                    MessageBox.Show("برجاء اكمال البيانات المطلوبة اولا");
                }
                else if (db.Suppliers.Where(x=>x.Phone == txtFormPhone.Text).Count()>0)
                {
                    MessageBox.Show("هذا المورد موجود مسبقا");
                }
                else
                {
                    Supplier s = new Supplier();
                    s.Name = txtFormName.Text;
                    s.Phone = txtFormPhone.Text;
                    s.Notes = txtNotes.Text;
                    s.Email = txtMail.Text;
                    s.address = txtAddress.Text;
                    s.Company = txtCompany.Text;
                    s.isActive = checkBox1.Checked;

                    db.Suppliers.Add(s);
                    db.SaveChanges();
                    MessageBox.Show("تم حفظ  العميل");


                    txtFormName.Text = "";
                    txtFormPhone.Text = "";
                    txtNotes.Text = "";
                    txtMail.Text = "";
                    txtAddress.Text = "";
                    txtCompany.Text = "";
                    checkBox1.Checked = false;
                    bunifuCustomDataGrid1.DataSource = db.Suppliers.ToList();
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد حفظ التعديل", "تاكيد التعديل", MessageBoxButtons.YesNo);
            if (db.Suppliers.Where(x => x.Phone == txtFormPhone.Text && x.id != id).Count() > 0)
            {
                MessageBox.Show(" رقم التليفوون لهذا المورد موجود في مورد اخر");
                return;
            }
            if (r == DialogResult.Yes)
            {
                id = int.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                result = db.Suppliers.SingleOrDefault(x => x.id == id);
                result.Name = txtFormName.Text;
                result.Phone = txtFormPhone.Text;
                result.Notes = txtNotes.Text;
                result.Email = txtMail.Text;
                result.address = txtAddress.Text;
                result.Company = txtCompany.Text;
                result.isActive = checkBox1.Checked;
                db.SaveChanges();
                MessageBox.Show("تم التعديل بنجاح");
                bunifuCustomDataGrid1.DataSource = db.Suppliers.ToList();
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف", "تاكيد الحذف", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Suppliers.Find(id);
                db.Suppliers.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم الحذف بنجاح");
                bunifuCustomDataGrid1.DataSource = db.Suppliers.ToList();

            }
        }
    }
}
