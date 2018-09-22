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
    /// Interaction logic for NewProjectCreation.xaml
    /// </summary>
    public partial class NewProjectCreation : Window
    {
        private ApartmentDeliveryDbContext _dbContext;
        public NewProjectCreation()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(projNameTxt.Text))
            {
                using (_dbContext = new ApartmentDeliveryDbContext())
                {
                    _dbContext.Projects.Add(new Projects()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProjectName = projNameTxt.Text,
                    });
                    _dbContext.SaveChanges();
                    MessageBox.Show("تم حفظ المشروع");
                    this.Close();
                }
            }
            else {
                MessageBox.Show("برجاء اختيار اسم للمشروع");
            }
        }
    }
}
