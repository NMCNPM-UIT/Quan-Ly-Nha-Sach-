using BookStoreClone.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class QuanLyHoaDonViewModel :BaseViewModel
    {

        private ObservableCollection<KhachHang> _listKH;
        private ObservableCollection<HoaDon> _listHD;
        public ICommand SelectHDCommand { get; set; }
        public ICommand XoaHDCommand { get; set; } 
        public ICommand SuaHDCommand { get; set; }
        public ICommand TimKiemKHCommand { get; set; }
        private string _timKH;
        private DateTime _ngayLapHD;
        private int _tongHD;
        private HoaDon _selectedHD;
        public ObservableCollection<KhachHang> ListKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public string TimKH { get => _timKH; set { _timKH = value; OnPropertyChanged(); } }

        public ObservableCollection<HoaDon> ListHD { get => _listHD; set { _listHD = value; OnPropertyChanged(); } }

        public DateTime NgayLapHD { get => _ngayLapHD; set { _ngayLapHD = value; OnPropertyChanged(); } }
        public int TongHD { get => _tongHD; set { _tongHD = value; OnPropertyChanged(); } }
        public HoaDon SelectedHD { get => _selectedHD; set { _selectedHD = value; OnPropertyChanged(); } }

        public QuanLyHoaDonViewModel()
        {
            ListKH = getKH();
            ListHD = getHD();
            SelectHDCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
          {
              SelectedHD = p.SelectedItem as HoaDon;
              TongHD = (int)SelectedHD.TongTien;
              NgayLapHD = (DateTime)SelectedHD.NgayBan;

          });
            XoaHDCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("Fuck!");
            });
            SuaHDCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("Fuck!");
            });
            TimKiemKHCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    ListHD = (ObservableCollection<HoaDon>)ListHD.Where(x => x.KhachHang.TenKH.Contains(p.Text));

                }
                catch(Exception e)
                {
                   
                }



            });
            }
        private ObservableCollection<KhachHang> getKH()
        {
            return new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        }
        private ObservableCollection<HoaDon> getHD()
        {
            return new ObservableCollection<HoaDon>(DataProvider.Ins.DB.HoaDons);
        }   
    }
}
