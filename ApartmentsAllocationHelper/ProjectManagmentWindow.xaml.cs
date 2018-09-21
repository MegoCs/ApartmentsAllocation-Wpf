using ApartmentsAllocationHelper.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ProjectManagmentWindow.xaml
    /// </summary>
    public partial class ProjectManagmentWindow : Window
    {
        private ApartmentDeliveryDbContext _dbContext;
        Apartments curApart;
        Towers curTower;
        Floors curFloor;

        public ProjectManagmentWindow(List<Towers>  Tlist)
        {
            InitializeComponent();
            _dbContext = new ApartmentDeliveryDbContext();
            TowersList.ItemsSource = Tlist;
        }

        private void TowersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ApartmentsList.ItemsSource = null;
                ApartmentImg.Source = null;
                curTower = TowersList.SelectedItem as Towers;
                FloorsList.ItemsSource = curTower.Floors.OrderBy(x => x.FloorNo);
                if (curTower.TowerImage != null)
                {
                    var ms = new MemoryStream(curTower.TowerImage);
                    var bitmapImg = new BitmapImage();
                    bitmapImg.BeginInit();
                    bitmapImg.StreamSource = ms;
                    bitmapImg.EndInit();
                    TowerDesignImg.Source = bitmapImg;
                }
                else
                {
                    TowerDesignImg.Source = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FloorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ApartmentImg.Source = null;
                curFloor = FloorsList.SelectedItem as Floors;
                if (curFloor != null)
                {
                    var Alist = _dbContext.Apartments.Include(x => x.Type).Where(x => x.FloorId == curFloor.Id).OrderByDescending(x => x.ApartmentNumber);
                    ApartmentsList.ItemsSource = Alist.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                curApart = ApartmentsList.SelectedItem as Apartments;
                if (curApart != null)
                {
                    if (curApart.OccupationStatus == "DONE")
                        OccupayApartment.IsEnabled = false;
                    else OccupayApartment.IsEnabled = true;

                    if (curApart.Type.ApartmentImage != null)
                    {
                        var ms = new MemoryStream(curApart.Type.ApartmentImage);
                        var bitmapImg = new BitmapImage();
                        bitmapImg.BeginInit();
                        bitmapImg.StreamSource = ms;
                        bitmapImg.EndInit();
                        ApartmentImg.Source = bitmapImg;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OccupayApartment_Click(object sender, RoutedEventArgs e)
        {
            if (curApart != null && curFloor != null && curTower != null) {
                OccupationWindow occ = new OccupationWindow(curApart,curFloor,curTower);
                occ.ShowDialog();
            }
        }
    }
}
