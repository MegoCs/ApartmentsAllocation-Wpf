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
        private List<ApartmentTypesPerTower> apartType;

        public AddTowersToProjectWindow()
        {
            InitializeComponent();
            try
            {
                towerToBeAdd = new Towers();
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    pList = _dbContext.Projects.ToList();
                    projNamesCombo.ItemsSource = pList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                towerToBeAdd.FloorsNumber = decimal.Parse(FloorsNumTxt.Text);
                towerToBeAdd.ApartmentsPerFloor = decimal.Parse(ApartmentPerFloorNumTxt.Text);
                towerToBeAdd.TowerName = towerNameTxt.Text;
                towerToBeAdd.ProjectId = projNamesCombo.SelectedValue as string;
                towerToBeAdd.Id = Guid.NewGuid().ToString();
                apartType = new List<ApartmentTypesPerTower>();

                if (towerToBeAdd.FloorsNumber != 0 && towerToBeAdd.ApartmentsPerFloor != 0 && !string.IsNullOrEmpty(towerToBeAdd.TowerName))
                {
                    using (_dbContext = new ApartmentDeliveryDbContext())
                    {
                        _dbContext.Towers.Add(towerToBeAdd);

                        for (int i = 1; i <= towerToBeAdd.ApartmentsPerFloor; i++)
                        {
                            apartType.Add(new ApartmentTypesPerTower()
                            {
                                ApartmentArea = 100,
                                Id = Guid.NewGuid().ToString(),
                                TagNumber = i,
                                TagName = $"{10 + i} شقة",
                                TowerId = towerToBeAdd.Id,
                            });
                            _dbContext.ApartmentTypesPerTower.Add(apartType[i - 1]);
                        }

                        for (int i = 1; i < towerToBeAdd.FloorsNumber + 1; i++)
                        {
                            Floors newFloor = new Floors()
                            {
                                ApartmentsNumber = towerToBeAdd.ApartmentsPerFloor,
                                FloorNo = i,
                                TowerId = towerToBeAdd.Id,
                                Id = Guid.NewGuid().ToString()
                            };

                            _dbContext.Floors.Add(newFloor);
                            for (int j = 1; j < towerToBeAdd.ApartmentsPerFloor + 1; j++)
                            {
                                Apartments newApart = new Apartments()
                                {
                                    ApartmentNumber = (i * 10) + j,
                                    ApartmentName = $"{((i * 10) + j)} شقة",
                                    OccupationStatus = "NONE",
                                    FloorId = newFloor.Id,
                                    Id = Guid.NewGuid().ToString(),
                                    TypeId = apartType[j - 1].Id,
                                };
                                _dbContext.Apartments.Add(newApart);
                            }
                        }

                        _dbContext.SaveChanges();
                        MessageBox.Show("تم اضافة البرج");
                        ClearValues();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ClearValues()
        {
            try
            {
                towerToBeAdd = new Towers();
                towerNameTxt.Text = "";
                FloorsNumTxt.Text = "";
                ApartmentPerFloorNumTxt.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
    }
}
