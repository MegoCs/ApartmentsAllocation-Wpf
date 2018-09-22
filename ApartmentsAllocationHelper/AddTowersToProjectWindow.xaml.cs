using ApartmentsAllocationHelper.Models.EntityModels;
using Microsoft.Win32;
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
    /// Interaction logic for AddTowersToProjectWindow.xaml
    /// </summary>
    public partial class AddTowersToProjectWindow : Window
    {
        private ApartmentDeliveryDbContext _dbContext;
        private List<Projects> pList;
        private Towers towerToBeAdd;
        public AddTowersToProjectWindow()
        {
            InitializeComponent();
            towerToBeAdd = new Towers();
            using (_dbContext = new ApartmentDeliveryDbContext()) {
                pList=_dbContext.Projects.ToList();
                projNamesCombo.ItemsSource = pList;
            }
        }

        private void TowerImgSelect_Click(object sender, RoutedEventArgs e)
        {
            //towerToBeAdd.TowerImage =;
            OpenFileDialog Img = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                Multiselect = false
            };
            if (Img.ShowDialog() == true)
            {
                towerToBeAdd.TowerImage= File.ReadAllBytes(Img.FileName);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            towerToBeAdd.FloorsNumber = decimal.Parse(FloorsNumTxt.Text);
            towerToBeAdd.ApartmentsPerFloor = decimal.Parse(ApartmentPerFloorNumTxt.Text);
            towerToBeAdd.TowerName = towerNameTxt.Text;
            towerToBeAdd.ProjectId = projNamesCombo.SelectedValue as string;
            towerToBeAdd.Id = Guid.NewGuid().ToString();

            if (towerToBeAdd.FloorsNumber != 0 && towerToBeAdd.ApartmentsPerFloor != 0 && !string.IsNullOrEmpty(towerToBeAdd.TowerName)) {
                using (_dbContext = new ApartmentDeliveryDbContext()) {
                    _dbContext.Towers.Add(towerToBeAdd);
                    _dbContext.SaveChanges();
                    MessageBox.Show("تم اضافة البرج");
                }
            }
        }
    }
}
