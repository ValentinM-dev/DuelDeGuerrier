using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Class
{
    internal class Nain : Guerrier
    {
        //Attribut armureLourde
        private bool _armureLourde;

        public bool GetArmureLourde()
        {
            return _armureLourde;
        }
        public Nain(string nom, int pointsVitaux, int nbDesAttaque, bool armureLourde) : base(nom, pointsVitaux, nbDesAttaque)
        {
            _armureLourde = armureLourde;
        }
    }
}
