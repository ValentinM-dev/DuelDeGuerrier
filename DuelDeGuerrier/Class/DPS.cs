using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Class
{
    internal class DPS : Guerrier
    {
                // Attributs
        private string _nom;
        private int _pointsVitaux;
        private int _nbDesAttaque;

        public DPS(string nom, int pointsVitaux, int nbDesAttaque) : base(nom, pointsVitaux, nbDesAttaque)
        {
            _nom = nom;
            _pointsVitaux = pointsVitaux;
            _nbDesAttaque = nbDesAttaque;
        }

        //Modification de la méthode "Attaquer" permettant à la classe DPS d'attaquer plus fort
        public override int Attaquer()
        {
            Random attaque = new Random();
            int valeurAttaque;
            int degatsTotal = 0;

            for (int i = 0; i < _nbDesAttaque; i++)
            {
                valeurAttaque = attaque.Next(3, 11);
                degatsTotal += valeurAttaque;
                Console.WriteLine($"Voici les valeurs des attaques effectuée par {_nom} : {valeurAttaque}");


            }
            return base.Attaquer();
        }
    }
}
