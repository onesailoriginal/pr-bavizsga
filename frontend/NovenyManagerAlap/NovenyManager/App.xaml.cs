using NovenyManager.Model;
using NovenyManager.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NovenyManager
{
    public partial class App : Application
    {
        private NovenyModel _model;
        private NovenyViewModel _viewModel;
        private MainWindow _window;

        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _model = new NovenyModel();
            _viewModel = new NovenyViewModel(_model);
            _window = new MainWindow();
            _window.DataContext = _viewModel;
            _window.Show();
        }
    }
}
