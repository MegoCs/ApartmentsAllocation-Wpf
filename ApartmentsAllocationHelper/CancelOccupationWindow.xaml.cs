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
using Microsoft.EntityFrameworkCore;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for CancelOccupationWindow.xaml
    /// </summary>
    public partial class CancelOccupationWindow : Window
    {
        ApartmentDeliveryDbContext _dbcontext;
        public CancelOccupationWindow()
        {
            InitializeComponent();
        }

        private void ConfirmDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(clientNationalTxt.Text))
                {
                    using (_dbcontext = new ApartmentDeliveryDbContext())
                    {
                        var client = _dbcontext.Clients.Where(C => C.NationalId == clientNationalTxt.Text).Include(x => x.Apartments).SingleOrDefault();

                        if (client != null)
                        {
                            if (client.Apartments.Count > 0)
                            {
                                var apart = client.Apartments.ToList()[0];
                                apart.ClientId = null;
                                apart.OccupationStatus = "NONE";
                                _dbcontext.Update(apart);
                                _dbcontext.SaveChanges();
                                MessageBox.Show("تم الغاء تخصيص الوحدة");
                                clientNationalTxt.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("لا توجد غرفة محجوزة لهذا الرقم");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("برجاء كتابة البيانات");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في البيانات"); Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException}", this.GetType().Name); 
            }
        }
    }
}
