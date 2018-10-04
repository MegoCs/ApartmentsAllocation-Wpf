using ApartmentsAllocationHelper.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmentsAllocationHelper
{
    public partial class EmptyApartsReportForm : Form
    {
        public EmptyApartsReportForm(List<Projects> projs)
        {
            InitializeComponent();

            try
            {
                projectsComboBox.DisplayMember = "ProjectName";
                projectsComboBox.ValueMember = "Id";
                projectsComboBox.DataSource = projs;

            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }

        private void EmptyApartsReportForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowReportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(projectsComboBox.SelectedItem is null))

                    // TODO: This line of code loads data into the 'EmptyApartmentsDataSet.DataTable1' table. You can move, or remove it, as needed.
                    this.DataTable1TableAdapter.Fill(this.EmptyApartmentsDataSet.DataTable1, projectsComboBox.SelectedValue as string);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }
    }
}
