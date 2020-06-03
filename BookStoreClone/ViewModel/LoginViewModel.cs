using BookStoreClone.Model;
using BookStoreClone.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool  IsLogin { get; set; }
        

        private string _userName;
        public string UserName { get=>_userName; set { _userName = value ; OnPropertyChanged(); } }
        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand CloseWindow { get; set; }

        public LoginViewModel ()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

            CloseWindow = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            void Login (Window p)
            {
                
                if (p == null)
                    return;
                string pass = Password;
                string passEncode = MD5Hash(Base64Encode(Password));
                var account = DataProvider.Ins.DB.NguoiDungs.Where(x => x.TenDangNhap == UserName && x.MatKhau == passEncode).Count();
                if (account > 0)
                {
                    IsLogin = true;
                    p.Close();

                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu");
                }    
               
            }

            
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
