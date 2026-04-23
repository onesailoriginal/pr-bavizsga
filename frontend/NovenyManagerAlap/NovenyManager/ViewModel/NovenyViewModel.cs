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

        public NovenyViewModel(NovenyModel model)
        {
            _model = model;
        }
    }
}
