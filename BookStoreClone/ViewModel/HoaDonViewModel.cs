using BookStoreClone.Model;
using BookStoreClone.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BookStoreClone.ViewModel
{
    class HoaDonViewModel : BaseViewModel
    {
        public ICommand LoadedKHCommand;
        public ICommand LoadedSachCommand;
        public ICommand SelectionChangedSachCommand;
        private ObservableCollection<CTHD> _listCTHD;
        public ObservableCollection<CTHD> ListCTHD { get => _listCTHD; set => _listCTHD = value; }
        public HoaDonViewModel()
        {

            LoadedKHCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                p.ItemsSource = getKH();
            });
            LoadedSachCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                p.ItemsSource = getSach();
            });
            SelectionChangedSachCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                p.ItemsSource = getSach();
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
