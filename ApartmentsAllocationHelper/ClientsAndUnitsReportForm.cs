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
    public partial class ClientsAndUnitsReportForm : Form
    {
        public ClientsAndUnitsReportForm(List<Projects> _proj)
        {
            InitializeComponent();
            try
            {
                projectsComboBox.DisplayMember = "ProjectName";
                projectsComboBox.ValueMember = "Id";
                projectsComboBox.DataSource = _proj;

                towersComboBox.DisplayMember = "TowerName";
                towersComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void ClientsAndUnitsReportForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadReportBtn_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ClientsAndUnits.ClientsAndTheirUnits' table. You can move, or remove it, as needed.
            try
            {
                if (!string.IsNullOrEmpty(towersComboBox.SelectedValue as string))
                {
                    this.ClientsAndTheirUnitsTableAdapter.Fill(this.ClientsAndUnits.ClientsAndTheirUnits, towersComboBox.SelectedValue as string);

                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void ProjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (projectsComboBox.SelectedItem != null)
                {
                    towersComboBox.DisplayMember = "TowerName";
                    towersComboBox.ValueMember = "Id";
                    List<Towers> tList = (projectsComboBox.SelectedItem as Projects).Towers.ToList();
                    towersComboBox.DataSource = tList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
                
        }

        private void TowersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
