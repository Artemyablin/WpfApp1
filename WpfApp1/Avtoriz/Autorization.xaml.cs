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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        RestoranDataContext restoran = new RestoranDataContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (log.Text == "" || pas.Password == "")
            {
                MessageBox.Show("Введите данные во все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int us = restoran.Check_users(log.Text, pas.Password) ?? -1;

            if (us < 0) falseopen.Visibility = Visibility.Visible;
            else
            { 
                this.Hide(); 
                new MainWindow().ShowDialog(); 
                this.Close(); 
            } 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Registration().ShowDialog();
            this.Close();
        }
    }
}
