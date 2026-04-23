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

        public string Nev { get { return _nev; } set { _nev = value; OnPropertyChanged(nameof(Nev)); } }
        public string Faj { get { return _faj; } set { _faj = value; OnPropertyChanged(nameof(Faj)); } }
        public int LocsolasiIdoKoz { get { return _locsolasiIdoKoz; } set { _locsolasiIdoKoz = value;  OnPropertyChanged(nameof(LocsolasiIdoKoz)); } }
        public DateTime UtolsoLocsolas { get { return _utolsoLocsolas; } set { _utolsoLocsolas = value; OnPropertyChanged(nameof(UtolsoLocsolas)); } }

        public bool LocsolasraVar { get { return (DateTime.Today - _utolsoLocsolas).Days >= _locsolasiIdoKoz; } }
        public Noveny(string Nev, string Faj, int LocsolasiIdoKoz, DateTime UtolsoLocsolas)
        {
            this.Nev = Nev;
            this.Faj = Faj;
            this.LocsolasiIdoKoz = LocsolasiIdoKoz;
            this.UtolsoLocsolas = UtolsoLocsolas;
        }
    }
}
