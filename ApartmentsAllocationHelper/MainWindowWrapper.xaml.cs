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

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApartmentDeliveryDbContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginBtn.IsEnabled = false;
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    if (_dbContext.LoginDetails.Any(x => x.UserPassword == passTxt.Text))
                    {
                        MainForm mainForm = new MainForm();
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("خطأ في البيانات");
                        LoginBtn.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException.Message}", this.Name);
            }
        }
    }
}
