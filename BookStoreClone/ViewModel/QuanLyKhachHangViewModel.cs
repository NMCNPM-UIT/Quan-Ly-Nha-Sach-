using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreClone.ViewModel
{
    public class QuanLyKhachHangViewModel :BaseViewModel
    {
        //private ObservableCollection<KhachHang> _listKH;
        //public ObservableCollection<KhachHang> ListKH { get=> _listKH; set { _listKH = value;OnPropertyChanged(); } }
        public QuanLyKhachHangViewModel()
        {
           
        }    
        //public void LoadKhachHangData()
        //{
        //    ListKH = new ObservableCollection<KhachHang>(DataProvider.Ins.DB.KhachHangs);
        //}
    }
}
