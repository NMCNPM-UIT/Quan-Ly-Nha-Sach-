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
using MaterialDesignThemes.Wpf;

namespace BookStoreClone.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand TextChangedCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CloseApp { get; set; }
        public ICommand Minimize { get; set; }
        public ICommand Maximize { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }



        public PackIconKind Maximize_Icon { get => _maximize_Icon; set { _maximize_Icon = value; OnPropertyChanged(); } }
        public string TextTimKiem
        {
            get => _textTimKiem; set { _textTimKiem = value; OnPropertyChanged(); }
        }

        PackIconKind _maximize_Icon;
        string _textTimKiem;


        public MainViewModel()
        {

            Maximize_Icon = PackIconKind.WindowMaximize;


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




            TextChangedCommand = new RelayCommand<TreeView>((p) => { return true; }, (p) =>
            {

            }
             );

            CloseApp = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                    p.Close();
            }
            );

            Maximize = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {

                if (p.WindowState == WindowState.Normal)
                {
                    Maximize_Icon = PackIconKind.DockWindow;
                    p.WindowState = WindowState.Maximized;

                }
                else
                {
                    Maximize_Icon = PackIconKind.WindowMaximize;
                    p.WindowState = WindowState.Normal;
                    TextTimKiem = "adadasdas";
                }
            }
            );

            Minimize = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.WindowState = WindowState.Minimized;


                }
            }
            );
            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();


                }
            }
           );


        }
    }
}