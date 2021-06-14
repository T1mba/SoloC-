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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
           
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass2 = PassBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен состоять как минимум из пяти букв";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Пароль должен состоять как минимум из пяти букв";
                PassBox.Background = Brushes.Red;
            }
            else if (pass != pass2)
            {
                PassBox2.ToolTip = "Пароли не совпадают";
                PassBox2.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Не верный формат почты";
                textBoxEmail.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = " ";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = " ";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = " ";
                PassBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = " ";
                textBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Регистрация прошла успешна");
                AusWindow ausWindow = new AusWindow();
                ausWindow.Show();
                this.Hide();
                User user = new User(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();
            }
            
        }

        private void Button_Window_AusClick(object sender, RoutedEventArgs e)
        {
            AusWindow ausWindow = new AusWindow();
            ausWindow.Show();
            this.Hide();
        }
    }
}
