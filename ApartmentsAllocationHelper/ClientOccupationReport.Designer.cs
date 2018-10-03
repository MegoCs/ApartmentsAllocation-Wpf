namespace ApartmentsAllocationHelper
{
    partial class ClientOccupationReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.nationalIDTxt = new System.Windows.Forms.TextBox();
            this.showReportBtn = new System.Windows.Forms.Button();
            this.showClientsDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "الرقم القومي";
            // 
            // nationalIDTxt
            // 
            this.nationalIDTxt.Location = new System.Drawing.Point(330, 18);
            this.nationalIDTxt.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.nationalIDTxt.Name = "nationalIDTxt";
            this.nationalIDTxt.Size = new System.Drawing.Size(291, 26);
            this.nationalIDTxt.TabIndex = 1;
            this.nationalIDTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // showReportBtn
            // 
            this.showReportBtn.Location = new System.Drawing.Point(14, 14);
            this.showReportBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.showReportBtn.Name = "showReportBtn";
            this.showReportBtn.Size = new System.Drawing.Size(125, 35);
            this.showReportBtn.TabIndex = 2;
            this.showReportBtn.Text = "عرض التقرير";
            this.showReportBtn.UseVisualStyleBackColor = true;
            this.showReportBtn.Click += new System.EventHandler(this.ShowReportBtn_Click);
            // 
            // showClientsDataBtn
            // 
            this.showClientsDataBtn.Location = new System.Drawing.Point(149, 14);
            this.showClientsDataBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.showClientsDataBtn.Name = "showClientsDataBtn";
            this.showClientsDataBtn.Size = new System.Drawing.Size(171, 35);
            this.showClientsDataBtn.TabIndex = 3;
            this.showClientsDataBtn.Text = "عرض بيانات العملاء";
            this.showClientsDataBtn.UseVisualStyleBackColor = true;
            this.showClientsDataBtn.Click += new System.EventHandler(this.ShowClientsDataBtn_Click);
            // 
            // ClientOccupationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 633);
            this.Controls.Add(this.showClientsDataBtn);
            this.Controls.Add(this.showReportBtn);
            this.Controls.Add(this.nationalIDTxt);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ClientOccupationReport";
            this.Text = "تقارير العميل";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nationalIDTxt;
        private System.Windows.Forms.Button showReportBtn;
        private System.Windows.Forms.Button showClientsDataBtn;
    }
}