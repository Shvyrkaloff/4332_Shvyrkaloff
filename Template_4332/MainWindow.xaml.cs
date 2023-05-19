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
using Template_4332.Application;

namespace Template_4332
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _context;

        public MainWindow()
        {
            _context = new ApplicationContext();

            InitializeComponent();
        }
        private void Khamitova_4332_Click(object sender, RoutedEventArgs e)
        {
            _4332_Khamitova elina= new _4332_Khamitova();
            elina.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Spiridonov_4332_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Shvyrkaloff_OnClick(object sender, RoutedEventArgs e)
        {
            _4332_Shvyrkaloff shvyrkaloff = new _4332_Shvyrkaloff(_context);
            shvyrkaloff.Show();
        }
    }
}
