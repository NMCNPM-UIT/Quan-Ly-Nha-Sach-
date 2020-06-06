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
            setMutable();
        }
        private void btnXoaKH_Click(object sender, RoutedEventArgs e)
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
            dataKhachHang.IsEnabled = false;
            XoaTrang();
            setEnable();

        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dataKhachHang.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn khách hàng bạn muốn sửa!", "Sửa Khách Hàng", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                setEnable();
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            if (!IsNull())
            {

                if (string.IsNullOrEmpty(txbMaKH.Text))
                {
                    var ans = MessageBox.Show("Bạn có chắc muốn thêm khách hàng mới không?", "Xác Nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (ans == MessageBoxResult.Yes)
                    {
                        string soDT = txbSDT.Text;
                        var a = DataProvider.Ins.DB.KhachHangs.Where(x => x.SDT == soDT);
                        if (a.Count() <= 0)
                        {
                            khachHang.TenKH = txbTenKH.Text;
                            khachHang.Email = txbEmail.Text;
                            khachHang.DiaChi = txbDiaChi.Text;
                            khachHang.SDT = soDT;
                            khachHang.SoTienNo = Int32.Parse(txbTienNo.Text);
                            DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[KhachHang] ON");
                            DataProvider.Ins.DB.KhachHangs.Add(khachHang);
                            DataProvider.Ins.DB.SaveChanges();
                            DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[KhachHang] OFF");

                        }
                        else
                        {
                            MessageBox.Show("Đã có tài khoản sử dụng Số Điện Thoại này!", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                       
                    }


                }
            }
            else
            {
                var an1 = MessageBox.Show("Bạn có chắc muốn sửa thông tin khách hàng" + txbTenKH.Text + "không? ", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (an1 == MessageBoxResult.Yes)
                {
                    khachHang = DataProvider.Ins.DB.KhachHangs.Find(Int32.Parse(txbMaKH.Text));
                    string soDT = txbSDT.Text;
                    var a = DataProvider.Ins.DB.KhachHangs.Where(x => x.SDT == x.SDT);
                    if (a.Count() <= 0)
                    {
                        khachHang.TenKH = txbTenKH.Text;
                        khachHang.Email = txbEmail.Text;
                        khachHang.DiaChi = txbDiaChi.Text;
                        khachHang.SDT = soDT;
                        khachHang.SoTienNo = Int32.Parse(txbTienNo.Text);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Đã có tài khoản sử dụng Số Điện Thoại này!", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }    
                }
            }
            dataKhachHang.ItemsSource = getCustomers();
            XoaTrang();
            setMutable();
        }
        void XoaTrang()
        {
            txbTienNo.Clear();
            txbDiaChi.Clear();
            txbEmail.Clear();
            txbMaKH.Clear();
            txbSDT.Clear();
            txbTenKH.Clear();

        }
        bool IsNull()
        {
            if (String.IsNullOrEmpty(txbTenKH.Text) || String.IsNullOrEmpty(txbSDT.Text) || String.IsNullOrEmpty(txbTienNo.Text))
                return true;
            return false;
        }
        void setEnable()
        {
            btnSua.IsEnabled = false;
            btnThemKH.IsEnabled = false;
            btnLuu.IsEnabled = true;
            txbDiaChi.IsEnabled = true;
            txbEmail.IsEnabled = true;

            txbSDT.IsEnabled = true;
            txbTenKH.IsEnabled = true;
            txbTienNo.IsEnabled = true;
        }
        void setMutable()
        {
            dataKhachHang.IsEnabled = true;
            txbDiaChi.IsEnabled = false;
            txbEmail.IsEnabled = false;
            txbMaKH.IsEnabled = false;
            txbSDT.IsEnabled = false;
            txbTenKH.IsEnabled = false;
            txbTienNo.IsEnabled = false;
            btnLuu.IsEnabled = false;
            btnSua.IsEnabled = true;
            btnThemKH.IsEnabled = true;
        }
    }
}
 





