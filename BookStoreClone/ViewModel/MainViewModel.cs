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

        public ICommand QLNDCommand { get; set; }
        public ICommand TTTKCommand { get; set; }
        public ICommand SachCommand { get; set; }
        public ICommand DLSachCommand { get; set; }
        public ICommand KhachHangCommand { get; set; }
        public ICommand NhapSachCommand { get; set; }
        public ICommand HoaDonCommand { get; set; }
        public ICommand ThuTienCommand { get; set; }
        public ICommand TKKhachHangCommand { get; set; }
        public ICommand TkSachCommand { get; set; }
        public ICommand BCCongNoCommand { get; set; }
        public ICommand BCTonKhoCommand { get; set; }

        public PackIconKind Maximize_Icon { get => _maximize_Icon; set { _maximize_Icon = value; OnPropertyChanged(); } }
        public string TextTimKiem
        {
            get => _textTimKiem; 
            set { _textTimKiem = value; OnPropertyChanged(TextTimKiem); }
        }

        PackIconKind _maximize_Icon;
        string _textTimKiem;


        public MainViewModel()
        {

            Maximize_Icon = PackIconKind.WindowMaximize;
            TextTimKiem = "";

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




            TextChangedCommand = new RelayCommand<TreeView>((p) => { if (p != null) return true; return false; }, (p) =>
            {

                for (int i = 0; i < p.Items.Count; i++)
                {
                    StackPanel stackPanel = p.Items[i] as StackPanel;
                    for (int j = 0; j < stackPanel.Children.Count; j++)
                    {
                        if (stackPanel.Children[j] is TreeViewItem)
                        {
                            TreeViewItem treeViewItem = stackPanel.Children[j] as TreeViewItem;
                            if (TextTimKiem == "")
                                for (int k = 0; k < treeViewItem.Items.Count; k++)
                                {
                                    treeViewItem.IsExpanded = false;
                                }

                            else if (treeViewItem.Header.ToString().ToLower().Contains(TextTimKiem.ToLower()))

                                for (int k = 0; k < treeViewItem.Items.Count; k++)
                                {
                                    TreeViewItem treeViewItem1 = treeViewItem.Items[k] as TreeViewItem;
                                    treeViewItem1.Visibility = Visibility.Visible;
                                    treeViewItem.IsExpanded = true;
                                }
                            else
                            {
                                int count1 = 0;
                                for (int k = 0; k < treeViewItem.Items.Count; k++)
                                {
                                    TreeViewItem treeViewItem1 = treeViewItem.Items[k] as TreeViewItem;
                                    if (treeViewItem1.Header.ToString().ToLower().Contains(TextTimKiem.ToLower()))
                                    {
                                        count1++;
                                        treeViewItem1.Visibility = Visibility.Visible;
                                    }
                                    else treeViewItem1.Visibility = Visibility.Collapsed;

                                }
                                if (count1 > 0)
                                    treeViewItem.IsExpanded = true;
                                else treeViewItem.IsExpanded = false;
                            }
                        }
                    }
                }

            }
             ) ;

            CloseApp = new RelayCommand<Window>((p) => { if (p != null) return true; return false; }, (p) =>
             {

                 p.Close();
             }
            );

            Maximize = new RelayCommand<Window>((p) => { if (p != null) return true; return false; }, (p) =>
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

            Minimize = new RelayCommand<Window>((p) => { if (p != null) return true; return false; }, (p) =>
            {

                p.WindowState = WindowState.Minimized;
            }
            );
            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { if (p != null) return true; return false; }, (p) =>
            {
                p.DragMove();
            }
           );


        }
    }
}