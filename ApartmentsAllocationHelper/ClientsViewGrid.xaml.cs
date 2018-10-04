using ApartmentsAllocationHelper.Models.EntityModels;
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
using System.Windows.Shapes;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for ClientsViewGrid.xaml
    /// </summary>
    public partial class ClientsViewGrid : Window
    {
        List<Clients> clientsList;
        ApartmentDeliveryDbContext _dbContext;
        public Clients SelectedClient { get; set; }
        public ClientsViewGrid(bool returnValueBtnVisibility)
        {
            InitializeComponent();
            returnSelectedBtn.Visibility = (returnValueBtnVisibility == true)?Visibility.Visible:Visibility.Collapsed;
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    clientsList = _dbContext.Clients.ToList();
                    clientsDataView.ItemsSource = clientsList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(clientNationalTxt.Text)) && (!string.IsNullOrEmpty(clientNameTxt.Text)))
                {
                    clientsDataView.ItemsSource = clientsList.Where(x => x.NationalId.Contains(clientNationalTxt.Text) && x.ClientName.Contains(clientNameTxt.Text)).ToList();
                }
                else if (!string.IsNullOrEmpty(clientNationalTxt.Text))
                {
                    clientsDataView.ItemsSource = clientsList.Where(x => x.NationalId.Contains(clientNationalTxt.Text)).ToList();
                }
                else if (!string.IsNullOrEmpty(clientNameTxt.Text))
                {
                    clientsDataView.ItemsSource = clientsList.Where(x => x.ClientName.Contains(clientNameTxt.Text)).ToList();
                }
                else
                {
                    clientsDataView.ItemsSource = clientsList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ReturnSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedClient = (Clients)clientsDataView.SelectedItem;
            if (SelectedClient != null)
                this.Close();
            else
                MessageBox.Show("لم يتم اختيار عميل");
        }
    }
}
