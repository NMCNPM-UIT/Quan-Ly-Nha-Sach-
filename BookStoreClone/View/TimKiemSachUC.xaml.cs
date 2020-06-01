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
    /// Interaction logic for TimKiemSachUC.xaml
    /// </summary>
    public partial class TimKiemSachUC : UserControl
    {

        List<SachUC> listSach = new List<SachUC>();
        public TimKiemSachUC()
        {
            InitializeComponent();

        }

        private void txtSoTrangHienTai_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSoTrangtxtChanged(object sender, TextChangedEventArgs e)
        {
            HienThiTrang(int.Parse((sender as TextBox).Text.ToString()));
        }
        void HienThiTrang(int n)
        {
            this.pnlHienThiSach.Children.Clear();
            for (int i=n*25;i<(n+1)*25;i++)
            {
                SachUC sachUC = new SachUC(i.ToString());
                
                sachUC.Height = 320;
                sachUC.Width = 200;
                listSach.Add(sachUC);
                this.pnlHienThiSach.Children.Add(sachUC);
            }
        }
    }
    
}
