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
using WpfApp1.DataBase;

namespace WpfApp1.Avtoriz
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        RestoranDataContext restoran = new RestoranDataContext();
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tx1.Text == "" || tx2.Text == "" || tx3.Text == "" || tx4.Text == "" || tx5.Text == "" || tx6.Text == "" || tx7.Text == "")
            {
                MessageBox.Show("Заполни все поля, сука!", "Ты пидорас", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            restoran.Add_User(tx6.Text, tx3.Text, tx4.Text, tx5.Text, tx7.Text, tx1.Text, tx2.Text);
        }
    }
}
