using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using NovenyManager.ViewModel;

namespace NovenyManager.Model
{
    public class Noveny : ViewModelBase
    {
        private string _nev;
        private string _faj;
        private int _locsolasiIdoKoz;
        private DateTime _utolsoLocsolas;

        public string Nev { get; set { OnPropertyChanged(nameof(_nev)); } }

    }
}
