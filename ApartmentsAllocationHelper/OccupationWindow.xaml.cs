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
        Clients _curClient;
        ApartmentDeliveryDbContext _dbContext;
        public OccupationWindow(Apartments curApart)
        {
            InitializeComponent();
            try
            {
                #region Load Data And Put on form
                _curApart = curApart;

                towerNameTxt.Text = _curApart.Type.Tower.TowerName;
                apartmentNameTxt.Text = _curApart.ApartmentName;
                apartmentAreaTxt.Text = curApart.Type.ApartmentArea.ToString();
                floorNumTxt.Text = _curApart.Floor.FloorNo.ToString();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void GetClientDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchClientNationalTxt.Text))
                {
                    _curClient = null;
                    UpdateClientDetailsControls("", "", "", "");
                    using (_dbContext = new ApartmentDeliveryDbContext())
                    {
                        _curClient = _dbContext.Clients.SingleOrDefault(x => x.NationalId == searchClientNationalTxt.Text);
                        if (!(_curClient is null))
                        {
                            UpdateClientDetailsControls(_curClient.ClientName, _curClient.PhoneNumber, _curClient.NationalId, _curClient.ClientAddress);
                            ConfirmOccupation.IsEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("لا توجد بيانات بهذا الرقم");
                            ConfirmOccupation.IsEnabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("برجاء كتابة الرقم القومي للعضو");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
        private void UpdateClientDetailsControls(string Name,string phone,string national,string add) {
            try
            {
                clientNameTxt.Text = Name;
                clientPhoneTxt.Text = phone;
                clientNationalIdTxt.Text = national;
                clientAddressTxt.Text = add;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ConfirmOccupation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(_curClient is null))
                {
                    using (_dbContext = new ApartmentDeliveryDbContext())
                    {
                        _curApart.OccupationStatus = "DONE";
                        _curApart.ClientId = _curClient.Id;
                        _curApart.OccupationDate = DateTime.Now;
                        _dbContext.Apartments.Update(_curApart);
                        _dbContext.SaveChangesAsync();
                        MessageBox.Show("تم تأكيد العملية");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }

        private void ShowClientsGrid_Click(object sender, RoutedEventArgs e)
        {
            ClientsViewGrid clients = new ClientsViewGrid(true);
            clients.ShowDialog();
            clientNationalIdTxt.Text = clients.SelectedClient.NationalId;
            _curClient = clients.SelectedClient;
            UpdateClientDetailsControls(_curClient.ClientName, _curClient.PhoneNumber, _curClient.NationalId,_curClient.ClientAddress);
            ConfirmOccupation.IsEnabled = true;
        }
    }
}
