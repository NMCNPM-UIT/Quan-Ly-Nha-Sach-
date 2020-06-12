
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SachUC.xaml
    /// </summary>
    public partial class SachUC : UserControl
    {
        public ICommand HienThoThongTinSachCommand { get; set; }
        public SachUC(string name, string DonGia,string img)
        {
            InitializeComponent();
            DataContext = this;
            tbTenSach.Text = name;
            tbDonGia.Text = DonGia;
            string source = "/Resources/img/" + img;
            Uri resourceUri = new Uri(source, UriKind.Relative);
            imgAnhSach.Source = new BitmapImage(resourceUri);
            

            HienThoThongTinSachCommand = new ViewModel.RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                MessageBox.Show(p.Text);
                DockPanel dockPanel = (((((((((p.Parent as Canvas).Parent as Button).Parent as Grid).Parent as SachUC).Parent as WrapPanel).Parent as ScrollViewer).Parent as Card).Parent as DockPanel).Parent as DockPanel);
                (dockPanel.Parent as TimKiemSachUC).IDSach = p.Text;
                for (int i = 0; i < dockPanel.Children.Count; i++)
                    if (dockPanel.Children[i] is Card)
                    {

                        dockPanel.Children[i].Visibility = Visibility.Visible;

                    }

            }
            );
        }
   
    }
}
