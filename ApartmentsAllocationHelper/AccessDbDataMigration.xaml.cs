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
        BackgroundWorker MigrationSilentWorker;

        public string DbLocation { get; private set; }

        public AccessDbDataMigration()
        {
            InitializeComponent();
            try
            {
                MigrationSilentWorker = new BackgroundWorker();
                MigrationSilentWorker.DoWork += MigrationSilentWorker_DoWork;
                MigrationSilentWorker.RunWorkerCompleted += MigrationSilentWorker_RunWorkerCompleted;
                MigrationSilentWorker.WorkerReportsProgress = true;
                MigrationSilentWorker.ProgressChanged += MigrationSilentWorker_ProgressChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
        private void MigrationSilentWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progress.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void MigrationSilentWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                System.Windows.MessageBox.Show("تم نقل البيانات الجديدة");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void MigrationSilentWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
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
                                ClientAddress = dbHandler.myReader["address"].ToString()
                            });
                        }
                        float progress = ((currentChecked + 1) * 100) / clientsNum;
                        MigrationSilentWorker.ReportProgress(Convert.ToInt32(progress));
                    }
                    dbHandler.myConnection.Close();
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
        private void SelectDbFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    MigrationSilentWorker.RunWorkerAsync();
                    DescriptionDetailsTxt.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
    }
}
