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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Exception: {ex.Message} InnerException: {ex.InnerException.Message}", this.Name);
            }
        }
    }
}
