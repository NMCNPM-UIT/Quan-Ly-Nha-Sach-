using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStoreClone
{
    
    class Program
    {
        public static MainWindow mainWindow = null;

        private Program()
        {
           
        }
        void Creater()
        {
            MessageBox.Show("");
            mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
