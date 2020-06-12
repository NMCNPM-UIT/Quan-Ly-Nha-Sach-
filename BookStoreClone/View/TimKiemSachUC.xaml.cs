using BookStoreClone.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BookStoreClone.View
{
    /// <summary>
    /// Interaction logic for TimKiemSachUC.xaml
    /// </summary>


    public partial class TimKiemSachUC : UserControl, INotifyPropertyChanged
    {



        #region Thuộc tính
        List<Sach> a;
        private string _maxTrang;
        private string _iDSach;
        private string _tenSach;
        private string _giaSach;
        private string _moTaSach;
        private string _soLuongTon;
        private string _tacGia;
        private string _theLoai;
        private string _nhaXB;
        public string TenSach { get => _tenSach; set { _tenSach = value; OnPropertyChanged("TenSach"); } }
        public string GiaSach { get => _giaSach; set { _giaSach = value; OnPropertyChanged("GiaSach"); } }
        public string MoTaSach { get => _moTaSach; set { _moTaSach = value; OnPropertyChanged("MoTaSach"); } }
        public string SoLuongTon { get => _soLuongTon; set { _soLuongTon = value; OnPropertyChanged("SoLuongTon"); } }
        public string TacGia { get => _tacGia; set { _tacGia = value; OnPropertyChanged("TacGia"); } }
        public string TheLoai { get => _theLoai; set { _theLoai = value; OnPropertyChanged("TheLoai"); } }
        public string NhaXB { get => _nhaXB; set { _nhaXB = value; OnPropertyChanged("NhaXB"); } }
        public string IDSach { get => _iDSach; set { _iDSach = value; OnPropertyChanged("IDSach"); } }
        public string MaxTrang
        {
            get => _maxTrang; set { _maxTrang = value; OnPropertyChanged("MaxTrang"); }
        }
        #endregion

        #region event
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {

            if (PropertyChanged != null && newName != "IDSach")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
            else if (PropertyChanged != null)
            {
                ThongTinChiTiet(IDSach);
            }
           

        }
        #endregion

        // Cập nhật dữ liệu ở đây
        void ThongTinChiTiet(string idSach)
        {
            
                var query = from st in DataProvider.Ins.DB.Saches
                            where st.TenSach == idSach
                            select st;

            TenSach = query.First().TenSach;
            GiaSach = query.First().DonGia.ToString();
            MoTaSach = query.First().MoTa;
       
                    



            
        }

        public TimKiemSachUC()
        {
            InitializeComponent();
            DataContext = this;

            a = DataProvider.Ins.DB.Saches.ToList();
            

            if (a.Count % 25 > 0)
                txbMaxTrang.Text = a.Count / 25 + 1 + "";
            

            HienThiTrang(0);
        }

        private void txtSoTrangHienTai_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSoTrangtxtChanged(object sender, TextChangedEventArgs e)
        {

            if ((sender as TextBox).Text == "")
            { 
                HienThiTrang(0);
                (sender as TextBox).Text = "1";
            }
            else
            {

                if (int.Parse((sender as TextBox).Text) > a.Count / 25-1)

                    HienThiTrang(a.Count / 25 - 1);


                else if (int.Parse((sender as TextBox).Text) < 1)
                    HienThiTrang(0);
                else HienThiTrang(int.Parse((sender as TextBox).Text) - 1);
            }
          
        }
        void HienThiTrang(int n)
        {
            this.pnlHienThiSach.Children.Clear();
            if (a.Count == 0)
            {
                this.pnlHienThiSach.Children.Add(new TextBlock() { Text="không có giá trị phù hợp"});
            }
            else
            {
                for (int i = n * 25; i < n * 25 + 25 && i < a.Count; i++)
                {
                    string source = "";
                   if(a[i].AnhBia==null || a[i].AnhBia == "")
                     source = "no_image.png";
                    else
                      source = a[i].AnhBia;
                    SachUC sachUC = new SachUC(a[i].TenSach, a[i].DonGia.ToString(),source);
                    sachUC.Height = 320;
                    sachUC.Width = 200;
                    this.pnlHienThiSach.Children.Add(sachUC);
                }
            }
        }

        //Sự kiện ẩn show full thông tin sách;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((((sender as Button).Parent as Canvas).Parent as StackPanel).Parent as Card).Visibility = Visibility.Collapsed;
        }

        
    }

}
