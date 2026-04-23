using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovenyManager.Model
{
    public class NovenyModel
    {
        private List<Noveny> _novenyek;
        public List<Noveny> Novenyek => _novenyek;
        public event EventHandler<NovenyEventArgs>? NovenyHozzaadva ;
        private void AdatokBetoltese()
        {
            string url = "Model/novenyei.txt";
            string[] tomb = File.ReadAllLines(url);
            foreach (string item in tomb)
            {
                string[] parts =  item.Split(";");
                string nev = parts[0];
                string faj = parts[1];
                int locsolas = Convert.ToInt32( parts[2]);
                DateTime utolso = DateTime.Parse( parts[3]);
                Noveny noveny = new Noveny(nev, faj, locsolas, utolso);
                _novenyek.Add(noveny);
            }

        }
        public NovenyModel()
        {
            _novenyek = new List<Noveny>();
            AdatokBetoltese();
        }

        public void Locsol(Noveny noveny)
        {
            noveny.UtolsoLocsolas = DateTime.Today;
        }
        public void NovenyHozzaad(Noveny noveny)
        {
            _novenyek.Add(noveny);
            NovenyHozzaadva.Invoke(this, new NovenyEventArgs(noveny));
        }
    }
}
