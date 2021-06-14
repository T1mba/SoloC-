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
            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
                str += "Password: " + user.Password + " | ";
            exampleText.Text = str;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string Login = textBoxLogin.Text.Trim();
            string Pass = PassBox.Password.Trim();
            string Pass2 = PassBox2.Password.Trim();
            string Email = textBoxEmail.Text.ToLower().Trim();

            if (Login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен состоять как минимум из пяти букв";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (Pass.Length < 5)
            {
                PassBox.ToolTip = "Пароль должен состоять как минимум из пяти букв";
                PassBox.Background = Brushes.Red;
            }
            else if (Pass != Pass2)
            {
                PassBox2.ToolTip = "Пароли не совпадают";
                PassBox2.Background = Brushes.Red;
            }
            else if (Email.Length < 5 || !Email.Contains("@") || !Email.Contains("."))
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
                User user = new User(Login, Pass, Email);

                db.Users.Add(user);
                db.SaveChanges();
            }
            
        }
        
    }
}
