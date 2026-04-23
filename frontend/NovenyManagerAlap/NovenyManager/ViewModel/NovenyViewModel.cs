using NovenyManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace NovenyManager.ViewModel
{
    public class NovenyViewModel : ViewModelBase
    {
        private NovenyModel _model;
        private string _ujNev;
        private string _ujFaj;
        private int _ujLocsolasiIdoKoz;
        public string UjNev { get { return _ujNev; } set { _ujNev = value; OnPropertyChanged(nameof(UjNev)); } }
        public string UjFaj { get { return _ujFaj; } set { _ujFaj = value; OnPropertyChanged(nameof(UjFaj)); } }
        public int UjLocsolasiIdoKoz { get { return _ujLocsolasiIdoKoz; } set { _ujLocsolasiIdoKoz = value; OnPropertyChanged(nameof(UjFaj)); } }

        public ObservableCollection<Noveny> Novenyek { get; set; }
        public RelayCommand<Noveny> LocsolCommand { get; set; }
        public RelayCommand NovenyHozzaadCommand { get; set; }

        public NovenyViewModel(NovenyModel model)
        {
            UjLocsolasiIdoKoz = 7;
            UjNev = String.Empty;
            UjFaj = String.Empty;
            _model = model;
            Novenyek = new ObservableCollection<Noveny>(_model.Novenyek);
            LocsolCommand = new RelayCommand<Noveny>((noveny) => {
                _model.Locsol(noveny);
                OnPropertyChanged(nameof(Novenyek));
                }
            );
            NovenyHozzaadCommand = new RelayCommand(() =>
            {
                if(UjNev.Length != 0 && UjFaj.Length != 0 && UjLocsolasiIdoKoz >0)
                {
                    _model.NovenyHozzaad(new Noveny(UjNev, UjFaj, UjLocsolasiIdoKoz, DateTime.Today));
                    UjNev = String.Empty;
                    UjFaj = String.Empty;
                    UjLocsolasiIdoKoz = 7;
                }
            });
            _model.NovenyHozzaadva += _model_NovenyHozzaadva; ;
        }

        private void _model_NovenyHozzaadva(object? sender, NovenyEventArgs e)
        {
            Novenyek.Add(e.Noveny);
        }
    }
}
