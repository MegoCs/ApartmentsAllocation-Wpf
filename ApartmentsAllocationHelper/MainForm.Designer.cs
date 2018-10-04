namespace ApartmentsAllocationHelper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.اضافةمشروعجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTowersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsWithDoneOccupationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.apartsWithNoneOccupationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.clientReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientDataViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addClientDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelOccupationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مساعدةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.clientsDataToolStripMenuItem,
            this.مساعدةToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.اضافةمشروعجديدToolStripMenuItem});
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(85, 25);
            this.projectsToolStripMenuItem.Text = "مشروعات";
            // 
            // manageProjectToolStripMenuItem
            // 
            this.manageProjectToolStripMenuItem.Enabled = false;
            this.manageProjectToolStripMenuItem.Name = "manageProjectToolStripMenuItem";
            this.manageProjectToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.manageProjectToolStripMenuItem.Text = "ادارة مشروع";
            this.manageProjectToolStripMenuItem.Click += new System.EventHandler(this.ManageProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // اضافةمشروعجديدToolStripMenuItem
            // 
            this.اضافةمشروعجديدToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectToolStripMenuItem,
            this.addTowersToolStripMenuItem});
            this.اضافةمشروعجديدToolStripMenuItem.Name = "اضافةمشروعجديدToolStripMenuItem";
            this.اضافةمشروعجديدToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.اضافةمشروعجديدToolStripMenuItem.Text = "مشروع جديد";
            // 
            // addProjectToolStripMenuItem
            // 
            this.addProjectToolStripMenuItem.Name = "addProjectToolStripMenuItem";
            this.addProjectToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.addProjectToolStripMenuItem.Text = "اضافة اسم المشروع";
            this.addProjectToolStripMenuItem.Click += new System.EventHandler(this.AddProjectToolStripMenuItem_Click);
            // 
            // addTowersToolStripMenuItem
            // 
            this.addTowersToolStripMenuItem.Name = "addTowersToolStripMenuItem";
            this.addTowersToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.addTowersToolStripMenuItem.Text = "اضافة برج جديد الى مشروع";
            this.addTowersToolStripMenuItem.Click += new System.EventHandler(this.AddTowersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsWithDoneOccupationToolStripMenuItem,
            this.toolStripSeparator1,
            this.apartsWithNoneOccupationToolStripMenuItem,
            this.toolStripSeparator3,
            this.clientReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.reportsToolStripMenuItem.Text = "تقارير";
            // 
            // clientsWithDoneOccupationToolStripMenuItem
            // 
            this.clientsWithDoneOccupationToolStripMenuItem.Enabled = false;
            this.clientsWithDoneOccupationToolStripMenuItem.Name = "clientsWithDoneOccupationToolStripMenuItem";
            this.clientsWithDoneOccupationToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.clientsWithDoneOccupationToolStripMenuItem.Text = "العملاء المخصص لهم وحدات";
            this.clientsWithDoneOccupationToolStripMenuItem.Click += new System.EventHandler(this.ClientsWithDoneOccupationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(262, 6);
            // 
            // apartsWithNoneOccupationToolStripMenuItem
            // 
            this.apartsWithNoneOccupationToolStripMenuItem.Name = "apartsWithNoneOccupationToolStripMenuItem";
            this.apartsWithNoneOccupationToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.apartsWithNoneOccupationToolStripMenuItem.Text = "الوحدات الغير مخصصة";
            this.apartsWithNoneOccupationToolStripMenuItem.Click += new System.EventHandler(this.ApartsWithNoneOccupationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(262, 6);
            // 
            // clientReportToolStripMenuItem
            // 
            this.clientReportToolStripMenuItem.Name = "clientReportToolStripMenuItem";
            this.clientReportToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.clientReportToolStripMenuItem.Text = "تقرير تخصيص وحدة لعميل";
            this.clientReportToolStripMenuItem.Click += new System.EventHandler(this.ClientReportToolStripMenuItem_Click);
            // 
            // clientsDataToolStripMenuItem
            // 
            this.clientsDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientDataViewToolStripMenuItem1,
            this.toolStripSeparator4,
            this.addClientDataToolStripMenuItem,
            this.toolStripSeparator5,
            this.cancelOccupationToolStripMenuItem});
            this.clientsDataToolStripMenuItem.Name = "clientsDataToolStripMenuItem";
            this.clientsDataToolStripMenuItem.Size = new System.Drawing.Size(107, 25);
            this.clientsDataToolStripMenuItem.Text = "بيانات العملاء";
            // 
            // clientDataViewToolStripMenuItem1
            // 
            this.clientDataViewToolStripMenuItem1.Name = "clientDataViewToolStripMenuItem1";
            this.clientDataViewToolStripMenuItem1.Size = new System.Drawing.Size(252, 26);
            this.clientDataViewToolStripMenuItem1.Text = "بيانات العملاء";
            this.clientDataViewToolStripMenuItem1.Click += new System.EventHandler(this.ClientDataViewToolStripMenuItem1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(249, 6);
            // 
            // addClientDataToolStripMenuItem
            // 
            this.addClientDataToolStripMenuItem.Name = "addClientDataToolStripMenuItem";
            this.addClientDataToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.addClientDataToolStripMenuItem.Text = "ادراج بيانات العملاء الجدد";
            this.addClientDataToolStripMenuItem.Click += new System.EventHandler(this.AddClientDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(249, 6);
            // 
            // cancelOccupationToolStripMenuItem
            // 
            this.cancelOccupationToolStripMenuItem.Name = "cancelOccupationToolStripMenuItem";
            this.cancelOccupationToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.cancelOccupationToolStripMenuItem.Text = "الغاء حجز او تخصيص عميل";
            this.cancelOccupationToolStripMenuItem.Click += new System.EventHandler(this.CancelOccupationToolStripMenuItem_Click);
            // 
            // مساعدةToolStripMenuItem
            // 
            this.مساعدةToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManualToolStripMenuItem});
            this.مساعدةToolStripMenuItem.Name = "مساعدةToolStripMenuItem";
            this.مساعدةToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.مساعدةToolStripMenuItem.Text = "مساعدة";
            // 
            // ManualToolStripMenuItem
            // 
            this.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem";
            this.ManualToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.ManualToolStripMenuItem.Text = "طريقة الاستخدام";
            this.ManualToolStripMenuItem.Click += new System.EventHandler(this.ManualToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الصفحة الرئيسية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsWithDoneOccupationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apartsWithNoneOccupationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem اضافةمشروعجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTowersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelOccupationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientDataViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem مساعدةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualToolStripMenuItem;
    }
}