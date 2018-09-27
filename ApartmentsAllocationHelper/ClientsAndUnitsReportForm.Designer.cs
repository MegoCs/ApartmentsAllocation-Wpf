namespace ApartmentsAllocationHelper
{
    partial class ClientsAndUnitsReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClientsAndTheirUnitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientsAndUnits = new ApartmentsAllocationHelper.ClientsAndUnits();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClientsAndTheirUnitsTableAdapter = new ApartmentsAllocationHelper.ClientsAndUnitsTableAdapters.ClientsAndTheirUnitsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.towersComboBox = new System.Windows.Forms.ComboBox();
            this.LoadReportBtn = new System.Windows.Forms.Button();
            this.projectsComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsAndTheirUnitsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsAndUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientsAndTheirUnitsBindingSource
            // 
            this.ClientsAndTheirUnitsBindingSource.DataMember = "ClientsAndTheirUnits";
            this.ClientsAndTheirUnitsBindingSource.DataSource = this.ClientsAndUnits;
            // 
            // ClientsAndUnits
            // 
            this.ClientsAndUnits.DataSetName = "ClientsAndUnits";
            this.ClientsAndUnits.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ClientsAndTheirUnitsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ApartmentsAllocationHelper.ClientsOccupation.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 44);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Size = new System.Drawing.Size(666, 540);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ClientsAndTheirUnitsTableAdapter
            // 
            this.ClientsAndTheirUnitsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "مشروع التخصيص";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "البرج";
            // 
            // towersComboBox
            // 
            this.towersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.towersComboBox.FormattingEnabled = true;
            this.towersComboBox.Location = new System.Drawing.Point(172, 16);
            this.towersComboBox.Name = "towersComboBox";
            this.towersComboBox.Size = new System.Drawing.Size(121, 21);
            this.towersComboBox.TabIndex = 2;
            this.towersComboBox.SelectedIndexChanged += new System.EventHandler(this.TowersComboBox_SelectedIndexChanged);
            // 
            // LoadReportBtn
            // 
            this.LoadReportBtn.Location = new System.Drawing.Point(12, 15);
            this.LoadReportBtn.Name = "LoadReportBtn";
            this.LoadReportBtn.Size = new System.Drawing.Size(120, 23);
            this.LoadReportBtn.TabIndex = 3;
            this.LoadReportBtn.Text = "عرض التقرير";
            this.LoadReportBtn.UseVisualStyleBackColor = true;
            this.LoadReportBtn.Click += new System.EventHandler(this.LoadReportBtn_Click);
            // 
            // projectsComboBox
            // 
            this.projectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectsComboBox.FormattingEnabled = true;
            this.projectsComboBox.Location = new System.Drawing.Point(402, 16);
            this.projectsComboBox.Name = "projectsComboBox";
            this.projectsComboBox.Size = new System.Drawing.Size(121, 21);
            this.projectsComboBox.TabIndex = 4;
            this.projectsComboBox.SelectedIndexChanged += new System.EventHandler(this.ProjectsComboBox_SelectedIndexChanged);
            // 
            // ClientsAndUnitsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 596);
            this.Controls.Add(this.projectsComboBox);
            this.Controls.Add(this.LoadReportBtn);
            this.Controls.Add(this.towersComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsAndUnitsReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير العملاء الذي تم لهم تخصيص";
            this.Load += new System.EventHandler(this.ClientsAndUnitsReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientsAndTheirUnitsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsAndUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClientsAndTheirUnitsBindingSource;
        private ClientsAndUnits ClientsAndUnits;
        private ClientsAndUnitsTableAdapters.ClientsAndTheirUnitsTableAdapter ClientsAndTheirUnitsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox towersComboBox;
        private System.Windows.Forms.Button LoadReportBtn;
        private System.Windows.Forms.ComboBox projectsComboBox;
    }
}