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

namespace dizain
{
    /// <summary>
    /// Логика взаимодействия для AusWindow.xaml
    /// </summary>
    public partial class AusWindow : Window
    {
        public AusWindow()
        {
            InitializeComponent();
        }

        private void Button_Aus_Click(object sender, RoutedEventArgs e)
        {
            string Login = textBoxLogin.Text.Trim();
            string Pass = PassBox.Password.Trim();
            if (Login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен состоять как минимум из пяти букв";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (Pass.Length < 5)
            {
                PassBox.ToolTip = "Пароль должен состоять как минимум из пяти букв";
                textBoxLogin.Background = Brushes.Red;
            }
            else
            {

                textBoxLogin.ToolTip = " ";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = " ";
                PassBox.Background = Brushes.Transparent;

                User AusUser = null;
                using (ApplicationContext db = new ApplicationContext())
                { 
                    AusUser = db.Users.Where(b => b.Login == Login && b.Pass == Pass ).FirstOrDefault();
                }
                if (AusUser != null)
                {
                    MessageBox.Show("Успешно!");
                    Room room = new Room();
                    room.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Неккоректные данные!");
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
