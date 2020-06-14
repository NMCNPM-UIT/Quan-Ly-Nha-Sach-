using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MaterialDesignThemes;

namespace BookStoreClone.ViewModel
{
    class QuanLyDuLieuSachViewModel :BaseViewModel
    {
        private ObservableCollection<Sach> _listSach;
        private Sach _selectedSach;
        private string _theLoaiSach;
        private string _tacGiaSach;
        private BitmapImage _img;
        public ICommand SelectedChangeCommand { get; set; }
        public ICommand LuuSachCommand { get; set; }
        public ICommand ThemSachCommand { get; set; }
        public ObservableCollection<Sach> ListSach { get => _listSach; set { _listSach = value; OnPropertyChanged(); } }

        public Sach SelectedSach { get => _selectedSach; set { _selectedSach = value; OnPropertyChanged(); } }

        public string TheLoaiSach { get => _theLoaiSach; set { _theLoaiSach = value; OnPropertyChanged(); } }
        public string TacGiaSach { get => _tacGiaSach; set { _tacGiaSach = value; OnPropertyChanged(); } }

        public BitmapImage Img { get => _img; set { _img = value; OnPropertyChanged(); } }

        public QuanLyDuLieuSachViewModel()
        {
            ListSach = getSach();
            SelectedChangeCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
              {
                  string source = "";
                  TacGiaSach = "";
                  TheLoaiSach = "";
                  int i = 0;
                  SelectedSach = ((p as DataGrid).SelectedItem as Sach);
                  foreach ( TacGia a in SelectedSach.TacGias)
                  {
                      if (i < SelectedSach.TacGias.Count - 1)
                      {
                          
                          TacGiaSach += a.TenTG + ",";
                          i++;
                      }    
                      else
                      {
                          TacGiaSach += a.TenTG + ".";
                          i = 0;
                      }    
                          
                  }
                  foreach (TheLoai a in SelectedSach.TheLoais)
                  {
                      if (i < SelectedSach.TheLoais.Count - 1)
                      {
                          TheLoaiSach += a.TenTL + ",";
                          i++;
                      }
                      else
                      {
                          TheLoaiSach += a.TenTL + ".";
                          i = 0;
                      }

                  }
                 
                  if (String.IsNullOrEmpty(SelectedSach.AnhBia))
                      source = "no_image.png";
                  else
                      source = SelectedSach.AnhBia;
                  string resource = "/Resources/img/" + source;
                  Uri resourceUri = new Uri(resource, UriKind.Relative);
                  Img = new BitmapImage(resourceUri);
              });
            ThemSachCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
             {
                 SelectedSach = new Sach() ;
                 TacGiaSach = "";
                 TheLoaiSach = "";
                 (p as DataGrid).IsEnabled = false;

             });
            LuuSachCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
             {
                    
                 if((p as DataGrid).IsEnabled)
                 {
                     Sach a = DataProvider.Ins.DB.Saches.Find(SelectedSach.MaSach);


                 }
                 else
                 {
                     DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sach] ON");
                     DataProvider.Ins.DB.Saches.Add(SelectedSach);
                     DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sach] OFF");
                     DataProvider.Ins.DB.SaveChanges();
                 }
             });
        }
        private ObservableCollection<Sach> getSach()
        {
            return new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
        }    
    }

}
