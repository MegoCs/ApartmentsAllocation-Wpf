using ApartmentsAllocationHelper.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public ProjectManagmentWindow(List<Towers>  Tlist)
        {
            InitializeComponent();
            try
            {
                TowersList.ItemsSource = Tlist;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void TowersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    ApartmentImg.Source = null;
                    curTower = TowersList.SelectedItem as Towers;

                    ApartmentsWithDetailsList.ItemsSource = _dbContext.Apartments
                                         .Include(A => A.Floor)
                                         .Include(A => A.Client)
                                         .Include(A => A.Type)
                                         .ThenInclude(T => T.Tower)
                                         .Where(A => A.Type.TowerId == curTower.Id)
                                         .OrderBy(A => A.Floor.FloorNo)
                                         .ThenByDescending(A => A.ApartmentNumber)
                                         .ToList();
                    ApartmentsWithDetailsList.Height = (this.Height / 5) * 4;


                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ApartmentsWithDetailsList.ItemsSource);
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("Floor.FloorNo");
                    view.GroupDescriptions.Add(groupDescription); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void OccupayApartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curApart != null && curTower != null)
                {
                    OccupationWindow occ = new OccupationWindow(curApart);
                    occ.ShowDialog();
                    TowersList_SelectionChanged(null, null);
                    ApartmentsWithDetailsList_SelectionChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ApartmentsWithDetailsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ApartmentsWithDetailsList.SelectedItem != null)
                {
                    curApart = ApartmentsWithDetailsList.SelectedItem as Apartments;
                    curApartAreaTxt.Text = curApart.Type.ApartmentArea.ToString();
                    if (curApart.Client != null)
                        curApartClientTxt.Text = curApart.Client.ClientName;
                    else
                        curApartClientTxt.Text = "";
                }
                if (curApart.Type.ApartmentImage != null)
                {
                    var ms = new MemoryStream(curApart.Type.ApartmentImage);
                    var bitmapImg = new BitmapImage();
                    bitmapImg.BeginInit();
                    bitmapImg.StreamSource = ms;
                    bitmapImg.EndInit();
                    ApartmentImg.Source = bitmapImg;
                }
                else
                    ApartmentImg.Source = null;

                if (curApart.OccupationStatus == "NONE")
                    OccupayApartment.IsEnabled = true;
                else
                    OccupayApartment.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
    }
}
