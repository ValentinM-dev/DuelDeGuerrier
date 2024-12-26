using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Class
{
    internal class Elfe : Guerrier
    {
                // Attributs
        private string _nom;
        private int _pointsVitaux;
        private int _nbDesAttaque;

        public Elfe(string nom, int pointsVitaux, int nbDesAttaque) : base(nom, pointsVitaux, nbDesAttaque)
        {
        }

        public override int Attaquer()
        {
            Random attaque = new Random();
            int valeurAttaque = 0;
            int degatsTotal = 0;

            for (int i = 0; i <= _nbDesAttaque; i++)
            {
                valeurAttaque = attaque.Next(0, 7);
                if (valeurAttaque == 0)
                {
                    valeurAttaque = 1;
                    degatsTotal += valeurAttaque;

                }
                else
                {
                    degatsTotal += valeurAttaque;
                    Console.WriteLine($"Voici les valeurs des attaques effectuée par {_nom} : {valeurAttaque}");


                }
            }
            return base.Attaquer();
        }
    }
}
