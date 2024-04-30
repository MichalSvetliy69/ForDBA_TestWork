using ForDBA.ViewModels;
using ForDBA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Data
{
    /// <summary>
    /// Хранит в себе все экземпляры актуальных ViewModels для внешнего обращения
    /// </summary>
    static class ViewModelsContainer
    {
        private static MainWindowVM _mainWindowVM;
        public static MainWindowVM mainWindowVM
        {
            get { return _mainWindowVM; }
            set { _mainWindowVM = value; }
        }

        private static SearchByPhoneNumberVM _searchByPhoneNumberVM;
        public static SearchByPhoneNumberVM searchByPhoneNumberVMWindowVM
        {
            get { return _searchByPhoneNumberVM; }
            set { _searchByPhoneNumberVM = value; }
        }


        private static StreetsInfoListVM _streetsInfoListVM;
        public static StreetsInfoListVM StreetsInfoListVM
        {
            get { return _streetsInfoListVM; }
            set { _streetsInfoListVM = value; }
        }

    }
}
