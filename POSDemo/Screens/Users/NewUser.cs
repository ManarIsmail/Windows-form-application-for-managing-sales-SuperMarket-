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

namespace POSDemo.Screens.Users
{
    public partial class NewUser : Form
    {
        POSTutEntities db = new POSTutEntities();
        public NewUser()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //db.Users.Add(new User
            //{
            //    UserName = txtUser.Text, Password=txtPassword.Text
            //});
            //db.SaveChanges();
            //MessageBox.Show("تم الحفظ");

            User obj = new User();
            obj.UserName=txtUser.Text;
            obj.Password = txtPassword.Text;
            db.Users.Add(obj);
            db.SaveChanges();
            MessageBox.Show("تم الحفظ");
        }

        
    }
}
