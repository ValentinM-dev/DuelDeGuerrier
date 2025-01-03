using DuelDeGuerrier.Class;

Console.WriteLine("Bienvenue dans le 'Duel de Guerrier'! ");

Console.WriteLine("Appuyez sur n'importe quel touche afin d'accèder au Menu Principal...");

//Ajout de la liste pour stocker tout les guerriers
List<Guerrier> personnages = new List<Guerrier>();

// Permet avec l'appuis d'une touche d'afficher le Menu Principal
Console.ReadKey(true);

bool quitter = false;
while (!quitter)
{


    AfficherMenuPrincipal();

    ConsoleKeyInfo choix = Console.ReadKey(true);

    switch (choix.Key)
    {
        //Touche Numpad1 permettant d'ajouter un guerrier
        case ConsoleKey.NumPad1:
            Console.Clear();
            AjouterGuerrier();

            break;

        //Touche Numpad2 permettant d'afficher la liste des guerriers
        case ConsoleKey.NumPad2:
            Console.Clear();
            AfficherListeGuerrier(personnages);

            break;

        //Touche Numpad3 permettant de lancer une tournois jusqu'à ce que le dernier survivant gagne
        case ConsoleKey.NumPad3:
            Console.Clear();
            LancerTournoi();

            break;


        //Touche Numpad0 permettant de quitter le programme
        case ConsoleKey.NumPad0:
            Console.Clear();
            quitter = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Selectionner une option parmis celle visible");
            break;

    }

    if (!quitter)
    {
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu");
        Console.ReadKey(true);
    }



    //Méthode "AfficherMenuPrincipal permettant d'afficher le menu avec les différentes option
    static void AfficherMenuPrincipal()
    {
        Console.Clear(); // Efface l'écran pour un affichage propre
        Console.WriteLine("=== MENU PRINCIPAL ===");
        Console.WriteLine("1. Création des guerriers");
        Console.WriteLine("2. Affichage de la liste des guerriers");
        Console.WriteLine("3. Lancer un tournois");
        Console.WriteLine("0. Quitter");
        Console.WriteLine("======================");
        Console.Write("Selectionnez votre Option (Utiliser les touche Numpad)");
    }
}

void AjouterGuerrier()
{

    //Demande du nombre de Guerrier souhaité avant de faire le tournois.
    Console.WriteLine("Combien de Guerrier souhaitez vous ajouter ?");
    int nombreDePersonnages = int.Parse(Console.ReadLine());
    bool choixClasse = false;

    for (int i = 0; i < nombreDePersonnages; i++)
    {
        Console.WriteLine("=== Quel est sa classe ? ===");
        Console.WriteLine("1. Tank");
        Console.WriteLine("2. DPS");
        Console.WriteLine("3. Support");

        Console.Write("Effectuez votre choix avec le pavé numérique");
        ConsoleKeyInfo classChoix = Console.ReadKey(true);

        //Choix de la classe du guerrier en utiliant ConsoleKey
        switch (classChoix.Key)
        {
            //Insertion des valeurs pour un Tank
            case ConsoleKey.NumPad1:
                Console.Clear();
                Console.WriteLine("Entrez les informations pour votre Tank (nom, points de vie (Max 250), Lancer de dès)");
                personnages.Add(new Tank(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                break;

            //Insertion des valeurs pour un DPS
            case ConsoleKey.NumPad2:
                Console.Clear();
                Console.WriteLine("Entrez les informations pour votre DPS (nom, points de vie (Max 150), Lancer de dès)");
                personnages.Add(new DPS(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                break;

            //Insertion des valeurs pour un Support
            case ConsoleKey.NumPad3:
                Console.Clear();
                Console.WriteLine("Entrez les informations pour votre Support (nom, points de vie (Max 125), Lancer de dès)");
                //personnages = new Support(Console.ReadLine(), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                break;

            default:
                Console.WriteLine("Veuillez selectionnez une classe valide !");
                Console.ReadKey(true);

                break;
        }

        if (!choixClasse)
        {
            Console.WriteLine("\nAppuyez sur une touche pour revenir sur le choix de la classe");
            Console.ReadKey();
            Console.Clear();
        }
    }

}

static void AfficherListeGuerrier(List<Guerrier> personnages)
{
    Console.Clear();
    Console.WriteLine("=== Liste de Guerriers ===\n");
    for (int i = 0; i < personnages.Count; i++)
    {
        if (personnages.Count == 0)
        {
            Console.WriteLine("Il n'a aucun Guerrier pret a ce battre pour le tournoi.");
        }

        else
        {
            Console.WriteLine($"Guerrier {i + 1} :");
            personnages[i].AfficherInfos();
            Console.WriteLine("===\n");
        }
    }

    Console.WriteLine("Appuyez sur une touche pour revenir au menu");
    Console.ReadKey();
}

void LancerTournoi()
{
    Console.Clear();
    Random combattant = new Random();
    int nombreCombattant;
    bool combatActif = false;

    while (!combatActif)
    {
        List<Guerrier> combat = new List<Guerrier>();
        Console.WriteLine("Voulez-vous lancer le tournois ?\n");
        Console.WriteLine("===\n");
        Console.WriteLine("Numpad1 = Oui / Numpad2 = Non");
        Console.ReadKey(true);

        bool lancerTournois;

        if (Console.ReadKey(true).Key == ConsoleKey.NumPad1)
        {
            for (int i = 0; i < 2; i++)
            {
                if (combat.Count > 2 || personnages.Count > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Il faut au minimum 2 Combattant afin de pouvoir lancer le tournois");

                }

                else
                {
                    Console.Clear();
                    int tirage = combattant.Next(0, personnages.Count);
                    combat.Add(personnages[tirage]);
                    personnages.RemoveAt(tirage);

                    Console.WriteLine($"Le combattant selectionné est {i + 1}\n");
                    combat[i].AfficherInfos();
                    Console.WriteLine("===");

                }

            }
        }

        else if (Console.ReadKey(true).Key == ConsoleKey.NumPad2)
        {
            Console.Clear();
            Console.WriteLine("Appuyez sur n'importe quel touche pour revenir au menu");

        }

        else if (Console.ReadKey(true).Key != ConsoleKey.NumPad1 && Console.ReadKey(true).Key != ConsoleKey.NumPad2)
        {
            Console.Clear();
            Console.WriteLine("Veuillez selectionner les touches indiquer uniquement");

        }
    }

}