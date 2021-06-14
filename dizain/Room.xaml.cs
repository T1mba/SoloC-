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

namespace dizain
{
    /// <summary>
    /// Логика взаимодействия для Room.xaml
    /// </summary>
    public partial class Room : Window
    {
        public Room()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList();
            listofUsers.ItemsSource = users;
        }
    }
}
