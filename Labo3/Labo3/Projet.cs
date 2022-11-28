using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    internal class Projet : INotifyPropertyChanged
    {
        string numero;
        DateTime debut;
        int budget;
        string description;
        string employe;

        public string Numero { get => numero; set => numero = value; }
        public DateTime Debut { get => debut; set => debut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }

        public override string ToString()
        {
            return numero + " " + debut + " " + budget + " " + description + " " + employe;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
