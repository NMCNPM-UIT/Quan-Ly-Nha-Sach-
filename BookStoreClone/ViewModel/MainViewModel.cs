using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStoreClone.Model;
using BookStoreClone.View;
namespace BookStoreClone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand TextChangedCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
             {
                 Isloaded = true;
                 p.Show();
                 //if (p == null)
                 //    return;
                 //p.Hide();

                 //Login loginWindow = new Login();
                 //loginWindow.ShowDialog();
                 //if (loginWindow.DataContext == null)
                 //    return;

                 //var loginVM = loginWindow.DataContext as LoginViewModel;
                 //if(loginVM.IsLogin)
                 //{
                 //    p.Show();
                 //}
                 //else
                 //{
                 //    p.Close();
                 //}
             });

            TextChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MessageBox.Show((p as TextBox).ToString());
            }
            );
          
          

        }
    }
}
