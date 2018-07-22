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

        public static void HomeMenu()
        {
            Console.Clear();
            Console.WriteLine("\t Bienvenue dans League Draft Assistant !");
            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("0. Reinitialiser toutes les donnees !");
            Console.WriteLine("1. Saisir les résultats des derniers matchs LCS !");
            Console.WriteLine("2. Faire une draft !");
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
                for (int i = 0; i<winComp.Length; i++)
                {
                    winComp[i].WinWith(winComp);
                    winComp[i].WinAgainst(loseComp);
                    loseComp[i].LoseAgainst(winComp);
                    loseComp[i].LoseWith(loseComp);
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
            List<Champion> unplayableChamps = new List<Champion>();
            for (int i = 0; i < banList.Length; i++)
            {
                unplayableChamps.Add(champions.SingleOrDefault(item => item.Name == banList[i])); 
            }
            #endregion
            switch (input)
            {
                case 1:
                    
                    break;
                case 2:

                    break;
                case 0:
                    HomeMenu();
                    break;
            }
        }

    }
}
