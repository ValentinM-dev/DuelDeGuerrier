using DuelDeGuerrier.Class;

Guerrier lancelot = new Guerrier("Lancelot", 35, 3);
Guerrier galahad = new Guerrier("Galahad", 30, 4);
Elfe test = new Elfe("test", 12, 11);

galahad.AfficherInfos();
galahad.SubirDegats(test.Attaquer());
galahad.AfficherInfos();