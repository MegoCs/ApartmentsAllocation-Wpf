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

        public ClientsViewGrid()
        {
            InitializeComponent();
            using (_dbContext = new ApartmentDeliveryDbContext())
            {
                clientsList = _dbContext.Clients.ToList();
                clientsDataView.ItemsSource = clientsList;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(clientNationalTxt.Text))&& (!string.IsNullOrEmpty(clientNameTxt.Text)))
            {
                clientsDataView.ItemsSource = clientsList.Where(x => x.NationalId.Contains(clientNationalTxt.Text)&& x.ClientName.Contains(clientNameTxt.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(clientNationalTxt.Text)) {
                clientsDataView.ItemsSource  = clientsList.Where(x => x.NationalId.Contains(clientNationalTxt.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(clientNameTxt.Text))
            {
                clientsDataView.ItemsSource = clientsList.Where(x => x.ClientName.Contains(clientNameTxt.Text)).ToList();
            }
            else {
                clientsDataView.ItemsSource = clientsList;
            }
        }
    }
}
