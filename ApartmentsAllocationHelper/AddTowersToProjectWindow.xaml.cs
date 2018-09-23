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

                    for (int i = 1  ; i < towerToBeAdd.FloorsNumber+1; i++)
                    {
                        Floors newFloor = new Floors()
                        {
                            ApartmentsNumber = towerToBeAdd.ApartmentsPerFloor,
                            FloorNo = i,
                            TowerId = towerToBeAdd.Id,
                            Id = Guid.NewGuid().ToString()
                        };

                        _dbContext.Floors.Add(newFloor);

                        for (int j = 1; j < towerToBeAdd.ApartmentsPerFloor +1; j++)
                        {

                            ApartmentTypesPerTower apartType = new ApartmentTypesPerTower() {
                                ApartmentArea=j*10,
                                Id=Guid.NewGuid().ToString(),
                                TowerId=towerToBeAdd.Id,
                            };
                            _dbContext.ApartmentTypesPerTower.Add(apartType);
                            Apartments newApart = new Apartments() {
                                ApartmentNumber = (i * 10) + j,
                                ApartmentName = $"{((i * 10) + j)} شقة",
                                OccupationStatus="NONE",
                                FloorId=newFloor.Id,
                                Id=Guid.NewGuid().ToString(),
                                TypeId = apartType.Id,
                            };
                            _dbContext.Apartments.Add(newApart);
                        }

                    }

                    _dbContext.SaveChanges();
                    MessageBox.Show("تم اضافة البرج");
                }
            }
        }
    }
}
