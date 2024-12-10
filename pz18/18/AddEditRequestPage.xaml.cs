using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AddEditRequestPage.xaml
    /// </summary>
    public partial class AddEditRequestPage : Page
    {
        //private Request _requests = new Request();
        //public AddEditRequestPage(Request requests)
        //{
        //    InitializeComponent();
        //    if (_requests != null)
        //    {
        //        _requests = requests;
        //    }
        //    DataContext = _requests;
        //}

        //public void SaveButtons(object sender, RoutedEventArgs e)
        //{
        //    b1kolychevaDemEntities.GetContext().Requests.AddOrUpdate(_requests);
        //    b1kolychevaDemEntities.GetContext().SaveChanges();
        //    Manager.MainFrame.GoBack();
        //}

        //private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (Visibility == Visibility.Visible)
        //    {
        //        b1kolychevaDemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
        //    }
        //}
    }
}
