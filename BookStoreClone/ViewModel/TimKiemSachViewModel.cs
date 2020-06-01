using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class TimKiemSachViewModel:BaseViewModel
    {
        #region commands
        public ICommand AnSachCommand { get; set; }

        #endregion
        public TimKiemSachViewModel()
        {
            AnSachCommand = new RelayCommand<Card>((p) => { return p == null ? false : true; }, (p) =>
            {
              
                (p as Card).Visibility = Visibility.Collapsed;
            }
            );

            //MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            //{
            //    FrameworkElement window = GetWindowParent(p);
            //    var w = window as Window;
            //    if (w != null)
            //    {
            //        w.DragMove();
            //    }
            //}
            //);
        }
    }
}
