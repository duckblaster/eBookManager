using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace eBookManager {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //public Library Library = new Library();

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //Library.Books.LoadAsync();

            CollectionViewSource bookViewSource = ((CollectionViewSource) (FindResource("BookViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            bookViewSource.Source = Library.Books;//.Local;
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e) {
            Book book = new Book();
            Library.Books.Add(book);
            Library.SaveChanges();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void BookDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
            Book book = e.Row.Item as Book;
            book.MetadataManualUpdate = DateTime.Now;
            Library.SaveChanges();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            //Library.Dispose();
        }
    }
}
