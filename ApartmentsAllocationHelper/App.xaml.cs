using ApartmentsAllocationHelper.Models;
using System.Windows;

namespace ApartmentsAllocationHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseInitializer.InitializeDatabase();
        }
    }
}