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
    /// Interaction logic for OccupationWindow.xaml
    /// </summary>
    public partial class OccupationWindow : Window
    {
        Apartments _curApart;
        Floors _curFloor;
        Towers _curTower;
        Clients _curClient;
        ApartmentDeliveryDbContext _dbContext;
        public OccupationWindow(Apartments curApart,Floors curFloor,Towers curTower)
        {
            InitializeComponent();
            #region Load Data And Put on form
            _curApart = curApart;
            _curFloor = curFloor;
            _curTower = curTower;

            towerNameTxt.Text = _curTower.TowerName;
            floorNumTxt.Text = _curFloor.FloorNo.ToString();
            apartmentNameTxt.Text = _curApart.ApartmentName;
            apartmentAreaTxt.Text = curApart.Type.ApartmentArea.ToString();
            #endregion
        }

        private void GetClientDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchClientNationalTxt.Text))
            {
                _curClient = null;
                UpdateClientDetailsControls("", "", "", "");
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    _curClient = _dbContext.Clients.SingleOrDefault(x => x.NationalId == searchClientNationalTxt.Text);
                    if (!(_curClient is null))
                        UpdateClientDetailsControls(_curClient.ClientName, _curClient.PhoneNumber, _curClient.NationalId, "Address");
                    else
                        MessageBox.Show("لا توجد بيانات بهذا الرقم");
                }
            }
            else
            {
                MessageBox.Show("برجاء كتابة الرقم القومي للعضو");
            }
        }
        private void UpdateClientDetailsControls(string Name,string phone,string national,string add) {
            clientNameTxt.Text = Name;
            clientPhoneTxt.Text = phone;
            clientNationalIdTxt.Text = national;
            clientAddressTxt.Text = add;
        }
    }
}
