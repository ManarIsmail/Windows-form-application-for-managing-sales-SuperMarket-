using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace POSDemo.Screens
{
    public partial class Firstpage : Form
    {

        [DllImport("Gdi32.dll", EntryPoint ="CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
            
        public Firstpage()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            prograssbar1.Value= 0;
        }

        private void Firstpage_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prograssbar1.Value += 1;
            prograssbar1.Text = prograssbar1.Value.ToString() + "%";
            if (prograssbar1.Value==100)
            {
                timer1.Enabled = false;
                Form1 f1_form = new Form1();
                f1_form.Show();
                
            }
        }
    }
}
