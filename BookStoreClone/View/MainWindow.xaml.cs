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

namespace BookStoreClone
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TxtTimmKiem_Tab_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show((e.Source as TextBox).Text);
        }

        private void TimKiemSachUC_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as TreeViewItem).Header.ToString());
        }
    }
}
