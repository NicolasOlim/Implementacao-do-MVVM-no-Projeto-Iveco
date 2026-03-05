using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iveco_Green_Ledger.Viewmodels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {

    public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
