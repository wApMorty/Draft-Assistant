﻿using Newtonsoft.Json;
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
                try
                {
                    string[] splitChampions = input.Split(',');
                    string[] winningComp = { splitChampions[0], splitChampions[1], splitChampions[2], splitChampions[3], splitChampions[4] };
                    string[] losingComp = { splitChampions[5], splitChampions[6], splitChampions[7], splitChampions[8], splitChampions[9] };
                    Champion champion1 = champions.SingleOrDefault(item => item.Name == winningComp[0]);
                    Champion champion2 = champions.SingleOrDefault(item => item.Name == winningComp[1]);
                    Champion champion3 = champions.SingleOrDefault(item => item.Name == winningComp[2]);
                    Champion champion4 = champions.SingleOrDefault(item => item.Name == winningComp[3]);
                    Champion champion5 = champions.SingleOrDefault(item => item.Name == winningComp[4]);
                    Champion champion6 = champions.SingleOrDefault(item => item.Name == losingComp[0]);
                    Champion champion7 = champions.SingleOrDefault(item => item.Name == losingComp[1]);
                    Champion champion8 = champions.SingleOrDefault(item => item.Name == losingComp[2]);
                    Champion champion9 = champions.SingleOrDefault(item => item.Name == losingComp[3]);
                    Champion champion10 = champions.SingleOrDefault(item => item.Name == losingComp[4]);
                    Champion[] winComp = { champion1, champion2, champion3, champion4, champion5 };
                    Champion[] loseComp = { champion6, champion7, champion8, champion9, champion10 };
                    for (int i = 0; i < winComp.Length; i++)
                    {
                        winComp[i].WinWith(winComp);
                        winComp[i].WinAgainst(loseComp);
                        loseComp[i].LoseAgainst(winComp);
                        loseComp[i].LoseWith(loseComp);
                    }
                    input = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Je n'ai pas très bien compris ...");
                    input = Console.ReadLine();
                    throw;
                }
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

        public static void Draft()
        {
            Console.Clear();
            Champion[] champions = JsonConvert.DeserializeObject<Champion[]>(File.ReadAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON"));
            Console.WriteLine("Draftez-vous en 1er ou en 2eme ?");
            Console.WriteLine("Sélectionnez 0 pour retourner au menu principal");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("Quels sont les bans ? (séparez chaque ban par une virgule, sans espace)");
            #region Gestion des bans
            string bans = Console.ReadLine();
            string[] banList = bans.Split(',');
            List<Champion> playableChamps = champions.ToList();
            for (int i = 0; i < banList.Length; i++)
            {
                playableChamps.Remove(champions.SingleOrDefault(item => item.Name == banList[i])); 
            }
            List<Champion> compoAlliee = new List<Champion>();
            List<Champion> compoEnnemie = new List<Champion>();
            #endregion
            switch (input)
            {
                case 1:
                    playableChamps.Sort((a, b) => a.GetWinrate().CompareTo(b.GetWinrate()));
                    playableChamps.Reverse();
                    Console.WriteLine("Pour l'instant, le meilleur pick serait : " + playableChamps[0]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    string pick = Console.ReadLine();
                    Champion allie1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == pick.ToLower());
                    compoAlliee.Add(allie1);
                    playableChamps.Remove(allie1);
                    Console.WriteLine("Quels sont les picks adverses ?");
                    string[] picks = Console.ReadLine().Split(',');
                    Champion ennemi1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi2 = playableChamps.SingleOrDefault(item => item.Name == picks[1]);
                    compoEnnemie.Add(ennemi1);
                    compoEnnemie.Add(ennemi2);
                    playableChamps.Remove(ennemi1);
                    playableChamps.Remove(ennemi2);
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    playableChamps.Reverse();
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    Champion allie2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion allie3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie2);
                    compoAlliee.Add(allie3);
                    playableChamps.Remove(allie2);
                    playableChamps.Remove(allie3);
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    Champion ennemi3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi4 = playableChamps.SingleOrDefault(item => item.Name == picks[1]);
                    compoEnnemie.Add(ennemi3);
                    compoEnnemie.Add(ennemi4);
                    playableChamps.Remove(ennemi3);
                    playableChamps.Remove(ennemi4);
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    playableChamps.Reverse();
                    Console.WriteLine("Pour finir, je pense que vous devriez pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    HomeMenu();
                    break;
                case 2:
                    Console.WriteLine("Quel est le premier pick adverse ?");
                    pick = Console.ReadLine();
                    ennemi1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == pick.ToLower());
                    compoEnnemie.Add(ennemi1);
                    playableChamps.Remove(ennemi1);
                    playableChamps.Sort((a, b) => a.GetWinrateAgainst(compoEnnemie).CompareTo(b.GetWinrateAgainst(compoEnnemie)));
                    playableChamps.Reverse();
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    allie1 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    allie2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie1);
                    compoAlliee.Add(allie2);
                    playableChamps.Remove(allie1);
                    playableChamps.Remove(allie2);
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    ennemi2 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    ennemi3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoEnnemie.Add(ennemi2);
                    compoEnnemie.Add(ennemi3);
                    playableChamps.Remove(ennemi2);
                    playableChamps.Remove(ennemi3);
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    playableChamps.Reverse();
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0] + " et " + playableChamps[1]);
                    Console.WriteLine("Qu'avez-vous pick ?");
                    picks = Console.ReadLine().Split(',');
                    allie3 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion allie4 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoAlliee.Add(allie3);
                    compoAlliee.Add(allie4);
                    playableChamps.Remove(allie3);
                    playableChamps.Remove(allie4);
                    Console.WriteLine("Quels sont les picks adverses ?");
                    picks = Console.ReadLine().Split(',');
                    ennemi4 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[0].ToLower());
                    Champion ennemi5 = playableChamps.SingleOrDefault(item => item.Name.ToLower() == picks[1].ToLower());
                    compoEnnemie.Add(ennemi4);
                    compoEnnemie.Add(ennemi5);
                    playableChamps.Remove(ennemi4);
                    playableChamps.Remove(ennemi5);
                    playableChamps.Sort((a, b) => a.GetWinrate(compoAlliee, compoEnnemie).CompareTo(b.GetWinrate(compoAlliee, compoEnnemie)));
                    playableChamps.Reverse();
                    Console.WriteLine("Dans ces conditions, je vous conseille de pick " + playableChamps[0]);
                    Thread.Sleep(TimeSpan.FromSeconds(20));
                    HomeMenu();
                    break;
                case 0:
                    HomeMenu();
                    break;
            }
        }

        public static void Debug()
        {
            Console.Clear();
            string input = Console.ReadLine();
            while (input != "x")
            {
                Champion[] champions = JsonConvert.DeserializeObject<Champion[]>(File.ReadAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON"));
                string[] splitChampions = input.Split(',');
                string[] winningComp = { splitChampions[0], splitChampions[1], splitChampions[2], splitChampions[3], splitChampions[4] };
                string[] losingComp = { splitChampions[5], splitChampions[6], splitChampions[7], splitChampions[8], splitChampions[9] };
                Champion champion1 = champions.SingleOrDefault(item => item.Name == winningComp[0]);
                Champion champion2 = champions.SingleOrDefault(item => item.Name == winningComp[1]);
                Champion champion3 = champions.SingleOrDefault(item => item.Name == winningComp[2]);
                Champion champion4 = champions.SingleOrDefault(item => item.Name == winningComp[3]);
                Champion champion5 = champions.SingleOrDefault(item => item.Name == winningComp[4]);
                Champion champion6 = champions.SingleOrDefault(item => item.Name == losingComp[0]);
                Champion champion7 = champions.SingleOrDefault(item => item.Name == losingComp[1]);
                Champion champion8 = champions.SingleOrDefault(item => item.Name == losingComp[2]);
                Champion champion9 = champions.SingleOrDefault(item => item.Name == losingComp[3]);
                Champion champion10 = champions.SingleOrDefault(item => item.Name == losingComp[4]);
                Champion[] winComp = { champion1, champion2, champion3, champion4, champion5 };
                Champion[] loseComp = { champion6, champion7, champion8, champion9, champion10 };
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
