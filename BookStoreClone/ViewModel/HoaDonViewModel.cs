using BookStoreClone.Model;
using BookStoreClone.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BookStoreClone.ViewModel
{
    class HoaDonViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand SelectionChangedSachCommand;
        private ObservableCollection<CTHD> _listCTHD;
        private int _soLuongConLai;
        private string _tacGiaSach;
        private string _theLoaiSach;
        private double _donGiaBan;
        private ObservableCollection<KhachHang> _listKH;
        private ObservableCollection<Sach> _listSach;
        public ObservableCollection<CTHD> ListCTHD { get => _listCTHD; set { _listCTHD = value; OnPropertyChanged(); } }
        public int SoLuongConLai { get => _soLuongConLai; set{ _soLuongConLai = value; OnPropertyChanged(); } }
        public string TheLoaiSach { get => _theLoaiSach; set { _theLoaiSach = value; OnPropertyChanged(); } }
        public string TacGiaSach { get => _tacGiaSach; set {_tacGiaSach = value; OnPropertyChanged(); } }
        public double DonGiaBan { get => _donGiaBan; set { _donGiaBan = value; OnPropertyChanged(); } }
        public ObservableCollection<KhachHang> ListKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public ObservableCollection<Sach> ListSach { get => _listSach; set {_listSach = value; OnPropertyChanged(); } }

        public HoaDonViewModel()
        {
            ListCTHD = new ObservableCollection<CTHD>();
            ListSach = getSach();
            ListKH = getKH();
            SelectionChangedSachCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                Sach a = (p as ComboBox).SelectedItem as Sach;
                SoLuongConLai = (int)a.SoLuongTon;
                DonGiaBan = (double)a.DonGia *(double) 1.15;
                int i = 0;
                foreach (var b in a.TacGias)
                {
                    if(i != a.TacGias.Count)
                    {
                        TacGiaSach += b.TenTG + ", ";
                        i++;
                    }    
                    else
                    {
                        i = 0;
                        TacGiaSach += b.TenTG;
                    }    
                    
                }
                foreach (var b in a.TheLoais)
                {
                    if (i != a.TheLoais.Count)
                    {
                        TheLoaiSach += b.TenTL + ", ";
                        i++;
                    }
                    else
                    {
                        i = 0;
                        TheLoaiSach += b.TenTL;
                    }
                }
            });


        }
        private ObservableCollection<KhachHang> getKH()
        {
            return new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        }
        private ObservableCollection<Sach> getSach()
        {
            return new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
        }
        private ObservableCollection<CTHD> getCTHD()
        {

            return ListCTHD;
        }

    }
}
