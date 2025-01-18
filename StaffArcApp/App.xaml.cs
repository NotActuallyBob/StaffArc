using System.Configuration;
using System.Data;
using System.Windows;
using Ninject;
using StaffArcApp.Ninject;
using StaffArcApp.ViewModels;

namespace StaffArcApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel? kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            kernel = new StandardKernel(new AppModule());
            var mainViewModel = kernel.Get<MainViewModel>();
            var mainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            kernel?.Dispose();
            base.OnExit(e);
        }
    }

}
