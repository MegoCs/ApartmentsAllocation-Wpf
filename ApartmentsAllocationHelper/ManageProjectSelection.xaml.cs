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
            projectsComboBox.ItemsSource = pList;

            #region Config BackGroundWorker To Load Data
            projectDetailsLoaderAgent = new BackgroundWorker();
            projectDetailsLoaderAgent.DoWork += ProjectDetailsLoaderAgent_DoWork;
            projectDetailsLoaderAgent.RunWorkerCompleted += ProjectDetailsLoaderAgent_RunWorkerCompleted;
            #endregion


        }

        private void ProjectDetailsLoaderAgent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            showBtn.IsEnabled = true;
            progressBar.Value = 100;
        }

        private void ProjectDetailsLoaderAgent_DoWork(object sender, DoWorkEventArgs e)
        {
            _dbContext = new ApartmentDeliveryDbContext();
            Tlist = _dbContext.Towers.Where(x=>x.ProjectId== curId).Include(x => x.Floors).OrderByDescending(x => x.TowerName).ToList();
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            ProjectManagmentWindow pWindow = new ProjectManagmentWindow(Tlist);
            pWindow.Show();
        }

        private void ProjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (projectsComboBox.SelectedValue != null) {
                showBtn.IsEnabled = false;
                projectDetailsLoaderAgent.RunWorkerAsync();
                curId = projectsComboBox.SelectedValue.ToString();
            }
        }
    }
}
