namespace POSDemo.Screens
{
    partial class Firstpage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Firstpage));
            this.prograssbar1 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prograssbar1
            // 
            this.prograssbar1.animated = false;
            this.prograssbar1.animationIterval = 5;
            this.prograssbar1.animationSpeed = 300;
            this.prograssbar1.BackColor = System.Drawing.Color.White;
            this.prograssbar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prograssbar1.BackgroundImage")));
            this.prograssbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prograssbar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prograssbar1.ForeColor = System.Drawing.Color.SteelBlue;
            this.prograssbar1.LabelVisible = true;
            this.prograssbar1.LineProgressThickness = 8;
            this.prograssbar1.LineThickness = 5;
            this.prograssbar1.Location = new System.Drawing.Point(60, 91);
            this.prograssbar1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prograssbar1.MaxValue = 100;
            this.prograssbar1.Name = "prograssbar1";
            this.prograssbar1.ProgressBackColor = System.Drawing.Color.LightGray;
            this.prograssbar1.ProgressColor = System.Drawing.Color.SteelBlue;
            this.prograssbar1.Size = new System.Drawing.Size(201, 201);
            this.prograssbar1.TabIndex = 0;
            this.prograssbar1.Value = 0;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("MV Boli", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(91, 30);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(160, 41);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "MARKET";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.SteelBlue;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(104, 338);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(116, 25);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Loading....";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Firstpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 403);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.prograssbar1);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Name = "Firstpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firstpage";
            this.Load += new System.EventHandler(this.Firstpage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCircleProgressbar prograssbar1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Timer timer1;
    }
}