using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApartmentsAllocationHelper.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel;
using ApartmentsAllocationHelper.Models;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for AccessDbDataMigration.xaml
    /// </summary>
    public partial class AccessDbDataMigration : Window
    {
        ApartmentDeliveryDbContext _dbContext = null;
        BackgroundWorker MigrationSlientWorker;

        public string DbLocation { get; private set; }

        public AccessDbDataMigration()
        {
            InitializeComponent();
            _dbContext = new ApartmentDeliveryDbContext();
            MigrationSlientWorker = new BackgroundWorker();
            MigrationSlientWorker.DoWork += MigrationSlientWorker_DoWork;
            MigrationSlientWorker.RunWorkerCompleted += MigrationSlientWorker_RunWorkerCompleted;
            MigrationSlientWorker.WorkerReportsProgress = true;
            MigrationSlientWorker.ProgressChanged += MigrationSlientWorker_ProgressChanged;
        }
        private void MigrationSlientWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void MigrationSlientWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Windows.MessageBox.Show("تم نقل البيانات الجديدة");
            this.Close();
        }

        private void MigrationSlientWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int clientsNum = 0, currentChecked = 0;
            ConnectionHandler dbHandler = new ConnectionHandler(DbLocation);
            dbHandler.StartConnection();
            dbHandler.SQLCODE("select count(*) from Clients", false);
            if (dbHandler.myReader.Read())
            {
                int.TryParse(dbHandler.myReader[0].ToString(), out clientsNum);
            }
            dbHandler.SQLCODE("select * from Clients", false);
            while (dbHandler.myReader.Read())
            {
                currentChecked++;
                string nationalId = dbHandler.myReader["national_id"].ToString();
                if (!_dbContext.Clients.Any(x => x.NationalId == nationalId))
                {
                    _dbContext.Clients.Add(new Clients()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClientName = dbHandler.myReader["client_name"].ToString(),
                        NationalId = dbHandler.myReader["national_id"].ToString(),
                        PhoneNumber = dbHandler.myReader["phone_number"].ToString(),
                        ClientAddress= dbHandler.myReader["address"].ToString()
                    });
                }
                float progress = ((currentChecked + 1) * 100) / clientsNum;
                MigrationSlientWorker.ReportProgress(Convert.ToInt32(progress));
            }
            dbHandler.myConnection.Close();
            _dbContext.SaveChanges();
        }
        private void SelectDbFileBtn_Click(object sender, RoutedEventArgs e)
        {
            selectDbFileBtn.IsEnabled = false;
            OpenFileDialog AccessDbFile = new OpenFileDialog
            {
                Filter = "AccessFiles (*.accdb)|*.accdb",
                Multiselect = false
            };
            if (AccessDbFile.ShowDialog() == true)
            {
                DbLocation = AccessDbFile.FileName;
                MigrationSlientWorker.RunWorkerAsync();
                DescriptionDetailsTxt.Visibility = Visibility.Visible;
            }
        }
    }
}
