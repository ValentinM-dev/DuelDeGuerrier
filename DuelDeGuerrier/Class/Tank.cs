using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Class
{


    internal class Tank : Guerrier
    {
        private static int PointsDeVieInitial { get; set; } = 125;
        private static int PointsDeVieMax { get; set; } = 250;
        private static int PointsDeVieMin { get; set; } = 1;

        //Attribut
        private string _nom;
        private int _pointsVitaux;
        private int _nbDesAttaque;

        public Tank(string nom, int pointsVitaux, int nbDesAttaque) : base(nom, pointsVitaux, nbDesAttaque)
        {
            _nom = nom;
            _pointsVitaux = pointsVitaux;
            _nbDesAttaque = nbDesAttaque;
        }





    }
}
