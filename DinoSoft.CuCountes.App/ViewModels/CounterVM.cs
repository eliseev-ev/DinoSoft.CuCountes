using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCountes.App.ViewModels
{
    public class CounterVM : INotifyPropertyChanged
    {
        public Model.Counter Model { private set; get; }

        public CounterVM(Model.Counter counter)
        {
            Model = counter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
