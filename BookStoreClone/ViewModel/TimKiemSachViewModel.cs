using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class TimKiemSachViewModel:BaseViewModel
    {
        private string _tenSach;
        public string TenSach { get => _tenSach; set { _tenSach = value; } }



        #region commands
        public ICommand AnSachCommand { get; set; }

        #endregion
        public TimKiemSachViewModel()
        {
           
            AnSachCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
              
               
           
               
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
