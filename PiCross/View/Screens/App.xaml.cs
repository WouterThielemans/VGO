using System.Windows;
using ViewModel;

namespace View
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs s)
        {
            var mainWindow = new MainWindow();
            base.OnStartup(s);

            MainWindowVM MainWindowVM = new MainWindowVM();
            MainWindowVM.Close += Close;
            mainWindow.DataContext = MainWindowVM;
            mainWindow.Show();
        }
        //Quit application
        private void Close() => Shutdown();
    }
}
