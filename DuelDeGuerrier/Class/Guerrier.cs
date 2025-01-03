using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Class
{
    internal class Guerrier
    {
        private int PointsDeVieInitial { get; set; } = 50;
        private int PointsDeVieMax { get; set; } = 100;
        private int PointsDeVieMin { get; set; } = 1;

        // Attributs
        private string _nom;
        private int _pointsVitaux;
        private int _nbDesAttaque;

        //Constructeur
        public Guerrier(string nom, int pointsVitaux, int nbDesAttaque)
        {
            _nom = nom;
            _pointsVitaux = pointsVitaux;
            _nbDesAttaque = nbDesAttaque;
        }

        // Méthodes publiques
        // Méthode "GetNom" permettant de récuperer le futur nom du guerrier
        public string GetNom()
        {
            return _nom;
        }

        //Méthode "GetPointDeVie" afin de pouvoir récuperer les PV du futur guerrier
        public int GetPointDeVie()
        {
            return _pointsVitaux;
        }

        //Méthode "SetPointsDeVie" afin de pouvoir affiler des points de vie au futur Guerrier avec un if-else pour verifier si le guerrier respecte bien les limites de PV et qu'il n'es pas de PV négatif
        public void SetPointsDeVie(int pointsVitaux)
        {
            this._pointsVitaux = pointsVitaux;

            if (_pointsVitaux < PointsDeVieMin || _pointsVitaux > PointsDeVieMax)
            {
                if (_pointsVitaux < PointsDeVieMin)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{_nom} ne peut pas ce battre il n'a pas de Point De Vie");
                }

                else if (_pointsVitaux > PointsDeVieMax)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{_nom} ne respecte pas la limite de Points De Vie ({PointsDeVieMax} étant ces PV Max");
                }

            }

        }


        public int GetNbDesAttaque()
        {
            return _nbDesAttaque;
        }

        public void AfficherInfos()
        {
            Console.ResetColor();
            Console.WriteLine($"Voici les informations de {_nom} : {_nom}, {_pointsVitaux}, {_nbDesAttaque}");
        }
        
        public virtual int Attaquer()
        {
            Random attaque = new Random();
            int valeurAttaque;
            int degatsTotal = 0;

            for (int i = 0; i < _nbDesAttaque; i++)
            {
                valeurAttaque = attaque.Next(0, 7);
                degatsTotal += valeurAttaque ;
                Console.WriteLine($"Voici les valeurs des attaques effectuée par {_nom} : {valeurAttaque}");
                

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_nom} effectue une attaque de : {degatsTotal} PV");
            Console.ResetColor();
            return degatsTotal;
        }

        public virtual void SubirDegats(int degats)
        {
            if(_pointsVitaux < 0)
            {
                degats = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dégats impossible {_nom} est à {_pointsVitaux} PV");
                Console.ResetColor();
            }

            else
            {
                int pointsDeVieRestant = _pointsVitaux - degats;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{_nom} a subis {degats} damage.\n");
                Console.ResetColor();
                if(_pointsVitaux <= 0)
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{_nom} est mort. Il a {_pointsVitaux} PV");
                    Console.ResetColor();

                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{_nom} à {pointsDeVieRestant} PV restant.");
                    Console.ResetColor();
                }

                _pointsVitaux = pointsDeVieRestant;
            }
        }
    }
}