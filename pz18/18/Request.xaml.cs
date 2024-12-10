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

namespace _18
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Page
    {
        b1kolychevaDemEntities db = new b1kolychevaDemEntities();
        public Request()
        {
            InitializeComponent();
            RequestGrid.ItemsSource = db.Requests.ToList();
        }
        private void DeleteButtons(object sender, RoutedEventArgs e)
        {
            var propDel = RequestGrid.SelectedItems.Cast<Requests>().ToList();
            try
            {
                if (MessageBox.Show("Хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.Requests.RemoveRange(propDel);
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    RequestGrid.ItemsSource = b1kolychevaDemEntities.GetContext().Requests.ToList();
                }
                RequestGrid.ItemsSource = db.Requests.ToList();
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка! \nОбратитесь в Тех Поддержку");
            }

        }

        private void B_EDIT(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRequestPage((sender as Button).DataContext as Request));
            RequestGrid.ItemsSource = db.Requests.ToList();
        }

        private void AddButtons(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRequestPage(null));
            RequestGrid.ItemsSource = db.Requests.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                b1kolychevaDemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
                RequestGrid.ItemsSource = b1kolychevaDemEntities.GetContext().Requests.ToList();
            }
        }
    }
}
