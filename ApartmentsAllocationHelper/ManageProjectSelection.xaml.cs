using ApartmentsAllocationHelper.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for ManageProjectSelection.xaml
    /// </summary>
    public partial class ManageProjectSelection : Window
    {
        BackgroundWorker projectDetailsLoaderAgent;
        private ApartmentDeliveryDbContext _dbContext;

        private List<Towers> Tlist ;
        private string curId;

        public ManageProjectSelection(List<Projects> pList)
        {
            InitializeComponent();
            try
            {
                projectsComboBox.ItemsSource = pList;

                #region Config BackGroundWorker To Load Data
                projectDetailsLoaderAgent = new BackgroundWorker();
                projectDetailsLoaderAgent.DoWork += ProjectDetailsLoaderAgent_DoWork;
                projectDetailsLoaderAgent.RunWorkerCompleted += ProjectDetailsLoaderAgent_RunWorkerCompleted;
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }

        }

        private void ProjectDetailsLoaderAgent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                showBtn.IsEnabled = true;
                projectDetailsBtn.IsEnabled = true;
                progressBar.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ProjectDetailsLoaderAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using(_dbContext = new ApartmentDeliveryDbContext())
                {
                    Tlist = _dbContext.Towers.Where(x => x.ProjectId == curId).Include(x => x.Floors).OrderByDescending(x => x.TowerName).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectManagmentWindow pWindow = new ProjectManagmentWindow(Tlist);
                pWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ProjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (projectsComboBox.SelectedValue != null)
                {
                    showBtn.IsEnabled = false;
                    projectDetailsBtn.IsEnabled = false;
                    projectDetailsLoaderAgent.RunWorkerAsync();
                    curId = projectsComboBox.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ProjectDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (projectsComboBox.SelectedItem != null)
                {
                    SetTowerDetails tDetails = new SetTowerDetails(Tlist, projectsComboBox.SelectedItem as Projects);
                    tDetails.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
            }
        }
    }
}
