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
    /// Interaction logic for SetTowerDetails.xaml
    /// </summary>
    public partial class SetTowerDetails : Window
    {
        ApartmentDeliveryDbContext _dbcontext;
        public SetTowerDetails(List<Towers> towersList)
        {
            InitializeComponent();
            towersCombo.ItemsSource = towersList;
        }

        private void ApartmentTypesListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DisplayTowerDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(towersCombo.SelectedValue is null))
            {
                //_dbcontext.ApartmentTypesPerTower.Select(x=>x.)
            }
        }

        private void SaveDetailsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectImg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
