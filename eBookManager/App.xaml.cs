using System.Data.Entity;
using System.Threading;
using System.Windows;

//using eBookManager.Migrations;

namespace eBookManager {
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        //public Library Library;

        public App() {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Library, Configuration>());
            //Library = new Library();
            //Library.Books.LoadAsync();
        }

        private void App_Startup(object sender, StartupEventArgs e) {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
