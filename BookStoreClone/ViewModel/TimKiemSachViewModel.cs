﻿namespace BookStoreClone.ViewModel
{
    using BookStoreClone.Model;
    using BookStoreClone.View;
    using MaterialDesignThemes.Wpf;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    internal class TimKiemSachViewModel : BaseViewModel
    {
        internal List<Sach> a;

        internal WrapPanel wrapPanel;

        private string _textTimKiem;

        private int _maxTrang;

        private string _iDSach;

        private string _tenSach;

        private string _giaSach;

        private string _moTaSach;

        private string _soLuongTon;

        private string _tacGia;

        private string _theLoai;

        private string _nhaXB;

        private string _anhBia;

        private int _soLuongHienThi;

        private int _soTrangHienTai;

        private string _trangThaiSoTrang;

        public string TenSach
        {
            get => _tenSach; set { _tenSach = value; OnPropertyChanged("TenSach"); }
        }

        public string GiaSach
        {
            get => _giaSach; set { _giaSach = value; OnPropertyChanged("GiaSach"); }
        }

        public string MoTaSach
        {
            get => _moTaSach; set { _moTaSach = value; OnPropertyChanged("MoTaSach"); }
        }

        public string SoLuongTon
        {
            get => _soLuongTon; set { _soLuongTon = value; OnPropertyChanged("SoLuongTon"); }
        }

        public string TacGia
        {
            get => _tacGia; set { _tacGia = value; OnPropertyChanged("TacGia"); }
        }

        public string TheLoai
        {
            get => _theLoai; set { _theLoai = value; OnPropertyChanged("TheLoai"); }
        }

        public string NhaXB
        {
            get => _nhaXB; set { _nhaXB = value; OnPropertyChanged("NhaXB"); }
        }

        public string IDSach
        {
            get => _iDSach; set { _iDSach = value; OnPropertyChanged("IDSach"); ThongTinChiTiet(IDSach); }
        }

        public string TextTimKiem
        {
            get => _textTimKiem; set { _textTimKiem = value; OnPropertyChanged("TextTimKiem"); }
        }

        public string AnhBia
        {
            get => _anhBia; set { _anhBia = value; OnPropertyChanged("AnhBia"); }
        }

        public int SoLuongHienThi
        {
            get => _soLuongHienThi; set { _soLuongHienThi = value; OnPropertyChanged("AnhBia"); }
        }

        public int SoTrangHienTai
        {
            get => _soTrangHienTai;
            set
            {
                _soTrangHienTai = value;
                OnPropertyChanged("SoTrangHienTai");
                TrangThaiSoTrang = "Trang: " + SoTrangHienTai + "/" + MaxTrang + "";
                LoadSachTu((SoTrangHienTai - 1) * SoLuongHienThi, SoTrangHienTai * SoLuongHienThi - 1 < a.Count - 1 ? SoTrangHienTai * SoLuongHienThi - 1 : a.Count - 1, wrapPanel);
            }
        }

        public string TrangThaiSoTrang
        {
            get => _trangThaiSoTrang; set { _trangThaiSoTrang = value; OnPropertyChanged("TrangThaiSoTrang"); }
        }

        public int MaxTrang
        {
            get => _maxTrang;
            set
            {
                _maxTrang = value;
                OnPropertyChanged("MaxTrang");
                TrangThaiSoTrang = "Trang: " + SoTrangHienTai + "/" + MaxTrang + "";
            }
        }

        public ICommand AnSachCommand { get; set; }

        public ICommand TimKiemCommand { get; set; }

        public ICommand LoadSach { get; set; }

        public ICommand TrangDauCommand { get; set; }

        public ICommand TrangCuoiCommand { get; set; }

        public ICommand TrangTiepTheoCommand { get; set; }

        public ICommand TrangTruocDoCommand { get; set; }

        public ICommand ThayDoiSoLuongHienThiCommand { get; set; }

        public TimKiemSachViewModel()
        {
            //Load Database
            a = DataProvider.Ins.DB.Saches.ToList();

            SoLuongHienThi = 16;
            SoTrangHienTai = 1;


            //Tìm kiếm sách
            TimKiemCommand = new RelayCommand<WrapPanel>((p) => { return p == null ? false : true; }, (p) =>
            {

            }
           );

            //Ẩn sách
            AnSachCommand = new RelayCommand<Card>((p) => { return p == null ? false : true; }, (p) =>
            {
                p.Visibility = Visibility.Collapsed;
            }
           );

            //Load lúc mới vào
            LoadSach = new RelayCommand<WrapPanel>((p) => { return p == null ? false : true; }, (p) =>
             {


                 wrapPanel = p;
                 MaxTrang = a.Count % SoLuongHienThi == 0 ? a.Count / SoLuongHienThi : a.Count / SoLuongHienThi + 1;
                 LoadSachTu(0, SoLuongHienThi - 1 < a.Count ? SoLuongHienThi - 1 : a.Count - 1, wrapPanel);
             }
           );

            //Thay đổi số lượng hiển thị
            ThayDoiSoLuongHienThiCommand = new RelayCommand<ComboBox>((p) => { return p == null ? false : true; }, (p) =>
            {
                SoLuongHienThi = int.Parse((p.SelectedItem as ComboBoxItem).Content.ToString());
                MaxTrang = a.Count % SoLuongHienThi == 0 ? a.Count / SoLuongHienThi : a.Count / SoLuongHienThi + 1;
                LoadSachTu(0, SoLuongHienThi - 1 < a.Count ? SoLuongHienThi - 1 : a.Count - 1, wrapPanel);
            }
         );
            TrangCuoiCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SoTrangHienTai = MaxTrang;
            }
         );
            TrangDauCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SoTrangHienTai = 1;
            }
         );
            TrangTiepTheoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>

            {
                SoTrangHienTai = SoTrangHienTai < MaxTrang ? SoTrangHienTai + 1 : SoTrangHienTai;
            }
         );
            TrangTruocDoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SoTrangHienTai = SoTrangHienTai - 1 > 1 ? SoTrangHienTai - 1 : 1;
            }
         );
        }

        internal void LoadSachTu(int n, int m, WrapPanel p)
        {
            if (p != null)
            {
                p.Children.Clear();
                for (int i = n; i <= m; i++)
                {
                    string source = "";
                    if (a[i].AnhBia == null || a[i].AnhBia == "")
                        source = "no_image.png";
                    else
                        source = a[i].AnhBia;
                    SachUC sachUC = new SachUC(a[i].TenSach, a[i].DonGia.ToString(), source);
                    sachUC.Height = 320;
                    sachUC.Width = 200;

                    p.Children.Add(sachUC);
                }
            }
        }

        internal void ThongTinChiTiet(string idSach)
        {
            var query = from st in DataProvider.Ins.DB.Saches
                        where st.TenSach == idSach
                        select st;

            TenSach = query.First().TenSach;
            GiaSach = query.First().DonGia.ToString();
            MoTaSach = query.First().MoTa;
            AnhBia = "/Resources/img/" + query.First().AnhBia;
        }
    }
}
