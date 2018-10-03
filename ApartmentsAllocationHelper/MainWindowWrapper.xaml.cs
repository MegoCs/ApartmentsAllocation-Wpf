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
                    _dbContext.SaveChanges();
                    if (_dbContext.LoginDetails.Any(x => x.UserPassword == passTxt.Password && x.UserName==userNameTxt.Text))
                    {
                        
                        MainForm mainForm = new MainForm();
                        this.Hide();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("خطأ في كلمة المرور");
                        LoginBtn.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name);
                LoginBtn.IsEnabled = true;
            }
        }
    }
}
