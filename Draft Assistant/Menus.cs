using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Draft_Assistant
{
    static class Menus
    {

        //Menu principal
        public static void HomeMenu()
        {
            Console.Clear();
            Console.WriteLine("\t Bienvenue dans League Draft Assistant !");
            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("0. Reinitialiser toutes les donnees !");
            Console.WriteLine("1. Saisir les résultats des derniers matchs LCS !");
            Console.WriteLine("2. Faire une draft !");
            Console.WriteLine("3. DEBUG MODE");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 0:
                    Initializer.Initialize();
                    HomeMenu();
                    break;
                case 1: InputData();
                    break;
                case 2: Draft();
                    break;
                case 3: Debug();
                    break;
                default: HomeMenu();
                    break;
            }
        }

        //Saisie massive de stats
        public static void InputData()
        {
            Console.Clear();
            Champion[] champions = JsonConvert.DeserializeObject<Champion[]>(File.ReadAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON"));
            Console.WriteLine("Saisissez les dernieres compos de matchs LCS, en commencant par l'equipe qui a gagné !");
            Console.WriteLine("Synthaxe : Ecrivez le nom francais des champions, et séparez par une virgule, sans espace");
            Console.WriteLine("Une fois que vous aurez fini, appuyez sur x pour retourner au menu principal");
            string input = Console.ReadLine();

            while (input != "x")
            {
                string[] splitChampions = input.Split(',');
                Team winComp = new Team();
                Team loseComp = new Team();
                
                //Remplissage des équipes
                for (int i = 0; i < 5; i++)
                {
                    winComp.Add(champions.SingleOrDefault(item => item.Name == splitChampions[i]));
                    loseComp.Add(champions.SingleOrDefault(item => item.Name == splitChampions[i+5]));
                }

                //Modification des stats
                //Equipe gagnante
                foreach (Champion c in winComp)
                {
                    c.WinWith(winComp);
                    c.WinAgainst(loseComp);
                }

                //Equipe perdante
                foreach (Champion c in loseComp)
                {
                    c.LoseAgainst(winComp);
                    c.LoseWith(loseComp);
                }
                input = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enregistrement des modifications en cours");
            File.WriteAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON",
    JsonConvert.SerializeObject(champions));
            Console.Clear();
            Console.WriteLine("Enregistrement terminé !");
            Thread.Sleep(2000);
            HomeMenu();
        }

        //Simulation de draft
        public static void Draft()
        {
            Console.Clear();
            Champion[] champions = JsonConvert.DeserializeObject<Champion[]>(File.ReadAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON"));
            Console.WriteLine("Draftez-vous en 1er ou en 2eme ?");
            Console.WriteLine("Sélectionnez 0 pour retourner au menu principal");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                HomeMenu();
            }
            Console.WriteLine("Quels sont les bans ? (séparez chaque ban par une virgule, sans espace)");
            #region Gestion des bans
            string bans = Console.ReadLine();
            string[] banList = bans.Split(',');
            List<Champion> playableChamps = champions.ToList();
            for (int i = 0; i < banList.Length; i++)
            {
                playableChamps.Remove(champions.SingleOrDefault(item => item.Name == banList[i])); 
            }
            #endregion
            Team compoAlliee = new Team();
            Team compoEnnemie = new Team();
            switch (input)
            {
                case 1:
                    //Pick allié 1
                    playableChamps.Sort((a, b) => -a.GetWinrate().CompareTo(b.GetWinrate()));
                    Console.WriteLine("Pour l'instant, le meilleur pick serait : " + playableChamps[0]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    string pick = Console.ReadLine();
                    Champion allie1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == pick.ToLower());
                    compoAlliee.Add(allie1);
                    playableChamps.Remove(allie1);

                    //Picks adverses 1/2
                    Console.WriteLine("Quels sont les picks adverses ?");
                    string[] picks = Console.ReadLine().Split(',');
                    Champion ennemi1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi2 = playableChamps.SingleOrDefault(item => item.Name == picks[1]);
                    compoEnnemie.Add(ennemi1);
                    compoEnnemie.Add(ennemi2);
                    playableChamps.Remove(ennemi1);
                    playableChamps.Remove(ennemi2);

                    //Picks alliés 2/3
                    playableChamps.Sort((a, b) => -a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    Champion allie2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion allie3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie2);
                    compoAlliee.Add(allie3);
                    playableChamps.Remove(allie2);
                    playableChamps.Remove(allie3);

                    //Pick adverses 3/4
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    Champion ennemi3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi4 = playableChamps.SingleOrDefault(item => item.Name == picks[1]);
                    compoEnnemie.Add(ennemi3);
                    compoEnnemie.Add(ennemi4);
                    playableChamps.Remove(ennemi3);
                    playableChamps.Remove(ennemi4);

                    //Picks alliés 4/5
                    playableChamps.Sort((a, b) => -a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    Console.WriteLine("Pour finir, je pense que vous devriez pick " + playableChamps[0] + " et " + playableChamps[1]);

                    //Retour au menu principal
                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    HomeMenu();
                    break;

                case 2:
                    //Pick adverse 1
                    Console.WriteLine("Quel est le premier pick adverse ?");
                    pick = Console.ReadLine();
                    ennemi1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == pick.ToLower());
                    compoEnnemie.Add(ennemi1);
                    playableChamps.Remove(ennemi1);

                    //Pick allié 1/2
                    playableChamps.Sort((a, b) => a.GetWinrateAgainst(compoEnnemie).CompareTo(b.GetWinrateAgainst(compoEnnemie)));
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    allie1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    allie2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie1);
                    compoAlliee.Add(allie2);
                    playableChamps.Remove(allie1);
                    playableChamps.Remove(allie2);

                    //Picks adverses 2/3
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    ennemi2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    ennemi3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoEnnemie.Add(ennemi2);
                    compoEnnemie.Add(ennemi3);
                    playableChamps.Remove(ennemi2);
                    playableChamps.Remove(ennemi3);

                    //Picks alliés 3/4
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    allie3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion allie4 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie3);
                    compoAlliee.Add(allie4);
                    playableChamps.Remove(allie3);
                    playableChamps.Remove(allie4);

                    //Picks adverses 4/5
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    ennemi4 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi5 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoEnnemie.Add(ennemi4);
                    compoEnnemie.Add(ennemi5);
                    playableChamps.Remove(ennemi4);
                    playableChamps.Remove(ennemi5);

                    //Pick allié 5
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0]);

                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    HomeMenu();
                    break;
            }
        }

        //Saisie des games une par une
        public static void Debug()
        {
            Console.Clear();
            string input = Console.ReadLine();
            while (input != "x")
            {
                Champion[] champions = JsonConvert.DeserializeObject<Champion[]>(File.ReadAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON"));
                string[] splitChampions = input.Split(',');
                Team winComp = new Team ();
                Team loseComp = new Team ();
                //Remplissage des equipes gagnantes et perdantes
                for (int i = 0; i < 5; i++)
                {
                    winComp.Add(champions.SingleOrDefault(item => item.Name == splitChampions[i]));
                    loseComp.Add(champions.SingleOrDefault(item => item.Name == splitChampions[i+5]));
                }

                //Modifications des stats en fonction des compos gagnantes et perdantes
                for (int i = 0; i < winComp.Length; i++)
                {
                    winComp[i].WinWith(winComp);
                    winComp[i].WinAgainst(loseComp);
                    loseComp[i].LoseAgainst(winComp);
                    loseComp[i].LoseWith(loseComp);
                }

                Console.WriteLine("Enregistrement des modifications en cours");
                File.WriteAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON",
        JsonConvert.SerializeObject(champions));
                Console.Clear();
                Console.WriteLine("Enregistrement OK !");
                input = Console.ReadLine();
            }

            HomeMenu();

        }

    }
}
