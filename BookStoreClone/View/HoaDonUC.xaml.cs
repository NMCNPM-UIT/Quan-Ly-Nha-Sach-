using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting;
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

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for HoaDonUC.xaml
    /// </summary>
    public partial class HoaDonUC : UserControl
    {

        //private string _donGiaBan;

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string newName)
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(newName));
        //    }    
        //}    

        //public string DonGiaBan { get => _donGiaBan; set { _donGiaBan = value; OnPropertyChanged("DonGiaBan"); } }
        //private ObservableCollection<CTHD> _listCTHD;

        //public ObservableCollection<CTHD> ListCTHD { get => _listCTHD; set => _listCTHD = value; }

        ////public hoadonuc()
        ////{
        ////    initializecomponent();
        ////    this.datacontext = this;
        ////    listcthd = new observablecollection<cthd>();
        ////}
        public HoaDonUC()
        {
            
            InitializeComponent();
        }

        //private ObservableCollection<KhachHang> getKH()
        //{
        //    return new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        //}
        //private ObservableCollection<Sach> getSach()
        //{
        //    return new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
        //}
        //private ObservableCollection<CTHD> getCTHD()
        //{

        //    return ListCTHD;
        //}


        //private void  Load_HD (object sender, RoutedEventArgs e)
        //{
        //    cbKH.ItemsSource = getKH();
        //    cbChonSach.ItemsSource = getSach();
        //    dataCTHD.ItemsSource = getCTHD();

        //}    
        //private void btnXoa_Click(object sender, RoutedEventArgs e)
        //{
        //    Button seleted = (Button)sender;
        //    var item = seleted.DataContext as CTHD;
        //    var DeleteRecord = MessageBox.Show("Bạn có xóa " + item.Sach.TenSach + "ra khỏi hóa đơn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //    if (DeleteRecord == MessageBoxResult.Yes)
        //    {
        //        ListCTHD.Remove(item);
        //        dataCTHD.ItemsSource = getCTHD();
        //    }

        //}
        //private void btnThem_Click(Object sender, RoutedEventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(txbSoLuongMua.Text))
        //    {
        //        int _soLuongMua = Convert.ToInt32(txbSoLuongMua.Text);
        //        if ( (Convert.ToInt32(txbSoLuongTon.Text) - _soLuongMua ) >= 20) 
        //        {
        //            Sach a = cbChonSach.SelectedItem as Sach;
        //            CTHD sach = new CTHD();
        //            sach.Sach = a;
        //            sach.SoLuong = _soLuongMua;
        //            sach.DonGiaBan = Convert.ToInt32(txbDonGiaBan.Text);
        //            sach.MaSach = a.MaSach;
        //            ListCTHD.Add(sach);
        //            dataCTHD.ItemsSource = getCTHD();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể đáp ứng số lượng trên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        }
        //    }
        //    else
        //        MessageBox.Show("Bạn chưa nhập số lượng cần mua!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        //}    

        //private void cbChonSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Sach a = cbChonSach.SelectedItem as Sach;
        //    double _giaBan = (double)a.DonGia * 1.15;
        //    txbDonGiaBan.Text = _giaBan.ToString();
        //    string _tacGia = "";
        //    string _theLoai = "";
        //    foreach (var b in a.TacGias)
        //    {
        //        _tacGia += b.TenTG + ", ";
        //    }

        //    foreach ( var b in a.TheLoais)
        //    {
        //        _theLoai += b.TenTL + ", ";
        //    }
        //    txbTheLoai.Text = _theLoai;
        //    txbTacGia.Text = _tacGia;
        //}
    }
}
