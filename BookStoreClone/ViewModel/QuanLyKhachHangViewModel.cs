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
    public class QuanLyKhachHangViewModel :BaseViewModel
    {
        private ObservableCollection<KhachHang> _listKH;
        private bool _setDataKH;
        private bool _setbtnThem;
        private bool _setbtnLuu;
        private bool _setbtnXoa;
        private bool _setbtnSua;
        private bool _setbtnHuy;
        public bool _isSua;
        public bool _isThem;
        private string _textTimKiem;
        private KhachHang _selectedKH;
        private ComboBoxItem _timKiemTheo;
        public ObservableCollection<KhachHang> ListKH { get=> _listKH; set { _listKH = value;OnPropertyChanged(); } }
        public ICommand SelectedChangeCommand { get; set; }
        public ICommand SuaKHCommand { get; set; }
        public ICommand XoaKHCommand { get; set; }
        public ICommand HuyKHCommand { get; set; }
        public ICommand ThemKHCommand { get; set; }
        public ICommand LuuKHCommand { get; set; }
       
        public KhachHang SelectedKH { get => _selectedKH; set { _selectedKH = value; OnPropertyChanged(); } }

        public bool SetDataKH { get => _setDataKH; set { _setDataKH = value; OnPropertyChanged(); } }

        public bool SetbtnThem { get => _setbtnThem; set { _setbtnThem = value; OnPropertyChanged(); } }
        public bool SetbtnLuu { get => _setbtnLuu; set { _setbtnLuu = value; OnPropertyChanged(); } }

        public bool SetbtnXoa { get => _setbtnXoa; set { _setbtnXoa = value; OnPropertyChanged(); } }

        public bool SetbtnHuy { get => _setbtnHuy; set { _setbtnHuy = value; OnPropertyChanged(); } }

        public bool SetbtnSua { get => _setbtnSua; set { _setbtnSua = value; OnPropertyChanged(); } }
        public string TextTimKiem
        {
            get => _textTimKiem; set
            {
                if (!String.IsNullOrEmpty(TimKiemTheo.Content.ToString()))
                {
                    if (TimKiemTheo.Content.ToString() == "Tên Khách Hàng")
                    {
                        _textTimKiem = value; OnPropertyChanged();
                        ListKH = new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs.Where(x => x.TenKH.ToLower().Contains(TextTimKiem.ToLower())));
                    }
                    else
                        ListKH = new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs.Where(x => x.SDT.Contains(TextTimKiem)));
                }
                else
                    ListKH = getKH();
            }
        }

        public ComboBoxItem TimKiemTheo { get => _timKiemTheo; set { _timKiemTheo = value; OnPropertyChanged("TimKiemTheo"); } }

        public QuanLyKhachHangViewModel()
        {
            ListKH = getKH();
            SetDataKH = true;
            SetbtnHuy = false;
            SetbtnXoa = true;
            SetbtnLuu = false;
            SetbtnThem = true;
            SetbtnSua = true;
            SelectedChangeCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                try
                {
                    SelectedKH = ((p).SelectedItem as KhachHang);
                }
                catch
                {
                    SelectedKH = ListKH.First();
                }
              

            });

            ThemKHCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                _isThem = true;
                _isSua = false;
                (p as Card).IsEnabled = true;
                setMuteable();
                SelectedKH = new KhachHang();
            });
            LuuKHCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                if (SelectedKH.TenKH != null || SelectedKH.SDT != null )
                {
                    int a = DataProvider.Ins.DB.KhachHangs.Where(x => x.SDT == SelectedKH.SDT).Count();
                    if (a <= 1)
                    {
                        if(_isSua ==true && _isThem ==false)
                        {
                            MessageBoxResult ans = MessageBox.Show("Bạn có chắc muốn thêm Khách Hàng " + SelectedKH.TenKH + " không ?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                            if (ans == MessageBoxResult.Yes)
                            {
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        }   
                        else if (_isSua == false && _isThem == true)
                        {
                            MessageBoxResult ans = MessageBox.Show("Bạn có chắc muốn thêm Khách Hàng " + SelectedKH.TenKH + " không ?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                            if (ans == MessageBoxResult.Yes)
                            {

                                DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[KhachHang] ON");
                                DataProvider.Ins.DB.KhachHangs.Add(SelectedKH);
  
                                DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[KhachHang] OFF");
                                DataProvider.Ins.DB.SaveChanges();
                                
                            }
                        }
                        ListKH = getKH();
                        p.IsEnabled = false;
                        setEnable();
                        SelectedKH = null;
                    }
                    else 
                    {
                        MessageBox.Show("Đã có khách hàng đăng kí số điện thoại này !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Yêu cầu nhập đủ thông tin!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            });
            HuyKHCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                SelectedKH = null;
                (p as Card).IsEnabled = false;
                setEnable();
            });
            XoaKHCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                if (SelectedKH != null)
                {
                    MessageBoxResult ans = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (ans == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.KhachHangs.Remove(SelectedKH);
                        DataProvider.Ins.DB.SaveChanges();
                        SelectedKH = null;
                        ListKH = getKH();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng muốn xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            });
            SuaKHCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
              {
                  if(SelectedKH !=null)
                  {
                      (p as Card).IsEnabled = true;
                      setMuteable();
                      _isSua = true;
                      _isThem = false;
                  }   
                  else
                  {
                      MessageBox.Show("Chọn khách hàng muốn sửa! ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                  }   
              });
        }
        ObservableCollection<KhachHang> getKH()
        {
            return new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        }
        void setMuteable()
        {
            SetDataKH = false;
            SetbtnThem = false;
            SetbtnLuu = true;
            SetbtnXoa = false;
            SetbtnHuy = true;
            SetbtnSua = false;
        } 
        void setEnable()
        {
            SetDataKH = true;
            SetbtnThem = true;
            SetbtnLuu = false;
            SetbtnXoa = true;
            SetbtnHuy = false;
            SetbtnSua = true;
        }

    }
}
