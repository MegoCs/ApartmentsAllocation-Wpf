﻿using ApartmentsAllocationHelper.Models.EntityModels;
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
    /// Interaction logic for SetTowerDetails.xaml
    /// </summary>
    public partial class SetTowerDetails : Window
    {
        private ApartmentDeliveryDbContext _dbcontext;
        private Towers curTower;
        private List<ApartmentTypesPerTower> apartsList;
        private ApartmentTypesPerTower curType;

        public SetTowerDetails(List<Towers> towersList)
        {
            InitializeComponent();

            try
            {
                towersCombo.ItemsSource = towersList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void ApartmentTypesListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                curType = apartmentTypesListview.SelectedItem as ApartmentTypesPerTower;
                typeAreaTxt.Text = curType.ApartmentArea.ToString();
                if (curType != null)
                {
                    if (curType.ApartmentImage != null)
                    {
                        var ms = new MemoryStream(curType.ApartmentImage);
                        var bitmapImg = new BitmapImage();
                        bitmapImg.BeginInit();
                        bitmapImg.StreamSource = ms;
                        bitmapImg.EndInit();
                        curTypeImg.Source = bitmapImg;
                    }
                    else
                    {
                        curTypeImg.Source = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void SaveDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curType != null && curTower != null && !string.IsNullOrEmpty(typeAreaTxt.Text))
                {
                    curTower.TowerName = towerNameTxt.Text;
                    curType.ApartmentArea = int.Parse(typeAreaTxt.Text);
                    curTower.TowerMessage = towerMessage.Text;
                    using (_dbcontext = new ApartmentDeliveryDbContext())
                    {
                        _dbcontext.ApartmentTypesPerTower.Update(curType);
                        _dbcontext.Towers.Update(curTower);
                        _dbcontext.SaveChanges();
                        MessageBox.Show("تم حفظ البيانات");
                    }
                }
                else
                    MessageBox.Show("برجاء اختيار البرج و الوحدات");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }

        }

        private void SelectImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curType != null)
                {
                    OpenFileDialog Img = new OpenFileDialog
                    {
                        Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                        Multiselect = false
                    };
                    if (Img.ShowDialog() == true)
                    {
                        curType.ApartmentImage = File.ReadAllBytes(Img.FileName);
                        curTypeImg.Source = new BitmapImage(new Uri(Img.FileName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void SelectTowerImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curTower != null)
                {
                    OpenFileDialog Img = new OpenFileDialog
                    {
                        Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                        Multiselect = false
                    };
                    if (Img.ShowDialog() == true)
                    {
                        curTower.TowerImage = File.ReadAllBytes(Img.FileName);
                        towerImg.Source = new BitmapImage(new Uri(Img.FileName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void TowersCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!(towersCombo.SelectedValue is null))
                {
                    curTower = towersCombo.SelectedItem as Towers;
                    towerNameTxt.Text = curTower.TowerName;
                    if (!string.IsNullOrEmpty(curTower.TowerMessage))
                        towerMessage.Text = curTower.TowerMessage;
                    else
                        towerMessage.Text = "";

                    if (curTower.TowerImage != null)
                    {
                        var ms = new MemoryStream(curTower.TowerImage);
                        var bitmapImg = new BitmapImage();
                        bitmapImg.BeginInit();
                        bitmapImg.StreamSource = ms;
                        bitmapImg.EndInit();
                        towerImg.Source = bitmapImg;
                    }
                    using (_dbcontext = new ApartmentDeliveryDbContext())
                    {
                        apartsList = _dbcontext.ApartmentTypesPerTower.Where(x => x.TowerId == towersCombo.SelectedValue.ToString()).OrderBy(x => x.TagNumber).ToList();
                    }
                    apartmentTypesListview.ItemsSource = apartsList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }

        private void DeleteTowerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curTower != null)
                {
                    using (_dbcontext = new ApartmentDeliveryDbContext())
                    {
                        _dbcontext.Towers.Remove(curTower);
                        _dbcontext.Floors.RemoveRange(_dbcontext.Floors.Where(x => x.TowerId == curTower.Id));
                        _dbcontext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.Name); 
            }
        }
    }
}
