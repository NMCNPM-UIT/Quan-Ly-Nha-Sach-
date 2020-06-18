using BookStoreClone.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class PhieuThuTienViewModel:BaseViewModel
    {
        private ObservableCollection<PhieuThuTien> _listPT;
        private ObservableCollection<KhachHang> _listKH;
        private ObservableCollection<NguoiDung> _listNV;
        private PhieuThuTien _selectedPT;
        private bool _setDataPT;
        private bool _setbtnThem;
        private bool _setbtnLuu;
        private bool _setbtnXoa;
        private bool _setbtnHuy;
        private string _textTimKiem;
        private ComboBoxItem _timKiemTheo;
        public ObservableCollection<PhieuThuTien> ListPT { get => _listPT; set { _listPT = value; OnPropertyChanged(); } }
        public ObservableCollection<KhachHang> ListKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public ObservableCollection<NguoiDung> ListNV { get => _listNV; set { _listNV = value; OnPropertyChanged(); } }
        public ICommand SelectedChangeCommand { get; set; }
        public ICommand XoaPTCommand { get; set; }
        public ICommand HuyPTCommand { get; set; }
        public ICommand ThemPTCommand { get; set; }
        public ICommand LuuPTCommand { get; set; }
        public PhieuThuTien SelectedPT { get => _selectedPT; set { _selectedPT = value; OnPropertyChanged(); } }

        public bool SetDataPT { get => _setDataPT; set { _setDataPT = value; OnPropertyChanged(); } }

        public bool SetbtnThem { get => _setbtnThem; set { _setbtnThem = value; OnPropertyChanged(); } }
        public bool SetbtnLuu { get => _setbtnLuu; set { _setbtnLuu = value; OnPropertyChanged(); } }

        public bool SetbtnXoa { get => _setbtnXoa; set { _setbtnXoa = value; OnPropertyChanged(); } }

        public bool SetbtnHuy { get => _setbtnHuy; set {_setbtnHuy = value; OnPropertyChanged(); } }

        public string TextTimKiem
        {
            get => _textTimKiem; set
            {
                if (!String.IsNullOrEmpty(TimKiemTheo.Content.ToString()))
                {
                    if (TimKiemTheo.Content.ToString() == "Tên Khách Hàng")
                    {
                        _textTimKiem = value; OnPropertyChanged();
                        ListPT = new ObservableCollection<PhieuThuTien>(DataProvider.Ins.DB.PhieuThuTiens.Where(x => x.KhachHang.TenKH.ToLower().Contains(TextTimKiem.ToLower())));
                    }
                    else
                        ListPT = new ObservableCollection<PhieuThuTien>(DataProvider.Ins.DB.PhieuThuTiens.Where(x => x.KhachHang.SDT.Contains(TextTimKiem)));
                }
                else
                    ListPT = getPT();
            }
        }

        public ComboBoxItem TimKiemTheo { get => _timKiemTheo; set { _timKiemTheo = value; OnPropertyChanged("TimKiemTheo"); } }

    

        public PhieuThuTienViewModel()
        {
            ListPT = getPT();
            ListKH = new ObservableCollection<KhachHang> (DataProvider.Ins.DB.KhachHangs);
            ListNV = new ObservableCollection<NguoiDung>(DataProvider.Ins.DB.NguoiDungs);
            SetDataPT = true;
            SetbtnHuy = false;
            SetbtnXoa = true;
            SetbtnLuu = false;
            SetbtnThem = true;
            SelectedChangeCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
             {
                 SelectedPT = ((p).SelectedItem as PhieuThuTien);
             });
          
            ThemPTCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                (p as Card).IsEnabled = true;
                setMuteable();
                SelectedPT = new PhieuThuTien();
            });
            LuuPTCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
             {
                 if(SelectedPT.KhachHang != null || SelectedPT.NguoiDung !=null || SelectedPT.NgayThuTien != null||SelectedPT.SoTienThu ==null)
                 {
                     if(SelectedPT.SoTienThu <= SelectedPT.KhachHang.SoTienNo)
                     {
                        
                             MessageBoxResult ans = MessageBox.Show("Bạn có chắc muốn thêm phiếu thu này với Khách Hàng " + SelectedPT.KhachHang.TenKH + " không ?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                             if(ans == MessageBoxResult.Yes)
                             {
                                int soTienNo = (int)SelectedPT.KhachHang.SoTienNo - (int)SelectedPT.SoTienThu;
                                SelectedPT.KhachHang.SoTienNo = soTienNo;
                                 DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhieuThuTien] ON");
                                 DataProvider.Ins.DB.PhieuThuTiens.Add(SelectedPT);
                                 DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhieuThuTien] OFF");
                                 DataProvider.Ins.DB.SaveChanges();
                                 DataProvider.Ins.DB.SaveChangesAsync();
                                 ListPT = getPT();
                             }
                              p.IsEnabled = false;
                            setEnable();
                            SelectedPT = null;
                     }
                     else
                     {
                         MessageBox.Show("Số tiền thu không được vượt quá số tiền nợ !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                     }
                 }
                 else
                 {
                     MessageBox.Show("Yêu cầu nhập đủ thông tin!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                 }
                 
             });
            HuyPTCommand = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                SelectedPT = null;
                (p as Card).IsEnabled = false;
                setEnable();
            });
            XoaPTCommand = new RelayCommand<Card>((p)=> { return true; },(p)=>
            {
                if(SelectedPT != null)
                {
                    MessageBoxResult ans = MessageBox.Show("Bạn có chắc muốn xóa phiếu này không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if(ans == MessageBoxResult.Yes)
                    {
                        int soTienNo = (int)SelectedPT.KhachHang.SoTienNo + (int)SelectedPT.SoTienThu;
                        SelectedPT.KhachHang.SoTienNo = soTienNo;
                        DataProvider.Ins.DB.PhieuThuTiens.Remove(SelectedPT);
                        DataProvider.Ins.DB.SaveChanges();
                        SelectedPT = null;
                        ListPT = getPT();
                    }    
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu muốn xóa!","Thông báo",MessageBoxButton.OK,MessageBoxImage.Information);

                }
            });

        }

        private ObservableCollection<PhieuThuTien> getPT()
        {
            return new ObservableCollection<PhieuThuTien>(DataProvider.Ins.DB.PhieuThuTiens);
        }
        void setMuteable()
        {
            SetDataPT = false;
            SetbtnThem = false;
            SetbtnLuu = true;
            SetbtnXoa = false;
            SetbtnHuy = true;
       
        }
        void setEnable()
        {
            SetDataPT = true ;
            SetbtnThem = true;
            SetbtnLuu = false;
            SetbtnXoa = true;
            SetbtnHuy = false;
        }
       

    }
}
