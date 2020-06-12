using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStoreClone.View;
using MaterialDesignThemes.Wpf;

namespace BookStoreClone.ViewModel
{
    class SachViewModel:BaseViewModel
    {
        public ICommand HienThoThongTinSachCommand { get; set; }
        
        public SachViewModel()
        {
            HienThoThongTinSachCommand = new ViewModel.RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                FrameworkElement frameworkElement = p;
                while (frameworkElement.Parent as TimKiemSachUC == null)
                    frameworkElement = frameworkElement.Parent as FrameworkElement;
                DockPanel dockPanel = frameworkElement as DockPanel;
                for (int i = 0; i < dockPanel.Children.Count; i++)
                    if (dockPanel.Children[i] is Card)
                    {
                        TimKiemSachViewModel timKiemSachViewModel = (TimKiemSachViewModel)(dockPanel.Parent as TimKiemSachUC).DataContext;
                        timKiemSachViewModel.IDSach = p.Text;
                        dockPanel.Children[i].Visibility = Visibility.Visible;
                    }
            }
            );
        }
       
    }
}
