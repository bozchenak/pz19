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

namespace _18
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        b1kolychevaDemEntities db;
        public Authorization()
        {
            InitializeComponent();
        }
        private void btlog_Click(object sender, RoutedEventArgs e)
        {
            db = new b1kolychevaDemEntities();
            try
            {
                var user = db.Users.Where(d => (d.loginUser == tblog.Text && d.passwordUser == tbpas.Password)).FirstOrDefault();
                if (user != null)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно. Попробуйте снова !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btcan_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
