using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BookStoreClone.Model;

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for QuanLyKhachHangUC.xaml
    /// </summary>
    public partial class QuanLyKhachHangUC : UserControl
    {
        private ObservableCollection<KhachHang> getCustomers()
        {
            return new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        }
        public QuanLyKhachHangUC()
        {
            InitializeComponent();
        }
        private void KhachHang_Loaded(object sender, RoutedEventArgs e)
        {
            dataKhachHang.ItemsSource = getCustomers();
        }
        private void btnXoaKH(object sender, RoutedEventArgs e)
        {
            Button seleted = (Button)sender;
            var item = seleted.DataContext as KhachHang;
            var DeleteRecord = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng " + item.TenKH + " không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DeleteRecord == MessageBoxResult.Yes)
            {
                DataProvider.Ins.DB.KhachHangs.Remove(item);
                DataProvider.Ins.DB.SaveChanges();
                dataKhachHang.ItemsSource = getCustomers();
            }
        }
        private void btnThemKH_Click(object sender, RoutedEventArgs e)
        {
            dataKhachHang.SelectedItem = null;
           
            
              
        }
        void XoaTrang()
        {
            txbTienNo.Clear();
        }
    }
}
