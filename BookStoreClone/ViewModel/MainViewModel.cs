using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStoreClone.View;
namespace BookStoreClone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        
        
        public MainViewModel()
        {

            TextChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MessageBox.Show((p as TextBox).ToString());
            }
            );
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Isloaded = true;
               
            }
              );           
        }
    }
}
