using System;
using System.Collections.Generic;
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
    class SachViewModel
    {
        public ICommand HienThoThongTinSachCommand { get; set; }
        
        public SachViewModel()
        {
            HienThoThongTinSachCommand = new RelayCommand<TextBlock>((p) => { return true; }, (p) => {
                
                DockPanel dockPanel = (((((((((p.Parent as Canvas).Parent as Button).Parent as Grid).Parent as SachUC).Parent as WrapPanel).Parent as ScrollViewer).Parent as Card).Parent as DockPanel).Parent as DockPanel);
                for (int i = 0; i < dockPanel.Children.Count; i++)
                    if (dockPanel.Children[i] is Card)
                        (dockPanel.Children[i] as Card).Visibility = Visibility.Visible;
            }
             );
        }
        Control GetWindowParent(Control p)
        {
            Control parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as Control;
            }

            return parent;
        }
    }
}
