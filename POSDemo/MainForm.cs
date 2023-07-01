using POSDemo.Screens.Customer;
using POSDemo.Screens.Products;
using POSDemo.Screens.SalesBill;
using POSDemo.Screens.Suppliers;
using POSDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblUser.Text=Users.Name;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser frm = new NewUser();
            frm.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_list frm=new Product_list();
            frm.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Product_list frm = new Product_list();
            frm.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            CustomerManagement c = new CustomerManagement();
            c.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.Show();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagement c = new CustomerManagement();
            c.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers s = new Suppliers();
            s.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            SalesBillForm FRM=new SalesBillForm();
            FRM.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

            SalesBillListData Report = new SalesBillListData();
            Report.Show();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            LogOut log=new LogOut();
            log.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            SalesBillListData P = new SalesBillListData();
            P.Show();
        }
    }
}
