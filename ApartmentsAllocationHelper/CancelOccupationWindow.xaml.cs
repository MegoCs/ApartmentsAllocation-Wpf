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
            if (!string.IsNullOrEmpty(clientNationalTxt.Text))
            {
                using (_dbcontext = new ApartmentDeliveryDbContext())
                {
                    var apart = _dbcontext.Apartments.Where(x => x.ClientId == clientNationalTxt.Text && x.OccupationStatus == "DONE").SingleOrDefault();
                    apart.ClientId = null;
                    apart.OccupationStatus = "NONE";
                    _dbcontext.Update(apart);
                    _dbcontext.SaveChanges();
                    MessageBox.Show("تم الغاء تخصيص الوحدة");
                    clientNationalTxt.Text = "";
                }
            }
            else {
                MessageBox.Show("برجاء كتابة البيانات");
            }
        }
    }
}
