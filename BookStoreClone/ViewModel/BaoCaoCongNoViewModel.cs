using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreClone.ViewModel
{
    public class BaoCaoCongNoViewModel :BaseViewModel
    {
        private BaoCaoCongNo _baoCaoNo;
        private ObservableCollection<CTBaoCaoCongNo> _listCTBCNo;
        public ObservableCollection<CTBaoCaoCongNo> ListCTBCNo { get=> _listCTBCNo; set { _listCTBCNo = value; OnPropertyChanged(); } }
        public BaoCaoCongNoViewModel()
        {
            ListCTBCNo = getCTBC();
        }
        private ObservableCollection<CTBaoCaoCongNo> getCTBC()
        {
            return new ObservableCollection<CTBaoCaoCongNo>(DataProvider.Ins.DB.CTBaoCaoCongNoes);
        }
    }
}
