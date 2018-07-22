using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draft_Assistant
{
    class Champion
    {

        public string Name { get; set; }
        #region Link Name -> ID
        public int Number {
            get
            {
                switch (this.Name)
                {
                    case "Aatrox": return 1;
                    case "Ahri": return 2;
                    case "Akali": return 3;
                    case "Alistar": return 4;
                    case "Amumu": return 5;
                    case "Anivia": return 6;
                    case "Annie": return 7;
                    case "Ashe": return 8;
                    case "Aurelion Sol": return 9;
                    case "Azir": return 10;
                    case "Bard": return 11;
                    case "Blitzcrank": return 12;
                    case "Brand": return 13;
                    case "Braum": return 14;
                    case "Caitlyn": return 15;
                    case "Camille": return 16;
                    case "Cassiopeia": return 17;
                    case "Cho'Gath": return 18;
                    case "Corki": return 19;
                    case "Darius": return 20;
                    case "Diana": return 21;
                    case "Dr. Mundo": return 22;
                    case "Draven": return 23;
                    case "Ekko": return 24;
                    case "Elise": return 25;
                    case "Evelynn": return 26;
                    case "Ezreal": return 27;
                    case "Fiddlesticks": return 28;
                    case "Fiora": return 29;
                    case "Fizz": return 30;
                    case "Galio": return 31;
                    case "Gangplank": return 32;
                    case "Garen": return 33;
                    case "Gnar": return 34;
                    case "Gragas": return 35;
                    case "Graves": return 36;
                    case "Hecarim": return 37;
                    case "Heimerdinger": return 38;
                    case "Illaoi": return 39;
                    case "Irelia": return 40;
                    case "Ivern": return 41;
                    case "Janna": return 42;
                    case "Jarvan IV": return 43;
                    case "Jax": return 44;
                    case "Jayce": return 45;
                    case "Jhin": return 46;
                    case "Jinx": return 47;
                    case "Kai'Sa": return 48;
                    case "Kalista": return 49;
                    case "Karma": return 50;
                    case "Karthus": return 51;
                    case "Kassadin": return 52;
                    case "Katarina": return 53;
                    case "Kayle": return 54;
                    case "Kayn": return 55;
                    case "Kennen": return 56;
                    case "Kha'Zix": return 57;
                    case "Kindred": return 58;
                    case "Kled": return 59;
                    case "Kog'Maw": return 60;
                    case "Leblanc": return 61;
                    case "Lee Sin": return 62;
                    case "Leona": return 63;
                    case "Lissandra": return 64;
                    case "Lucian": return 65;
                    case "Lulu": return 66;
                    case "Lux": return 67;
                    case "Malphite": return 68;
                    case "Malzahar": return 69;
                    case "Maokai": return 70;
                    case "Maître Yi": return 71;
                    case "Miss Fortune": return 72;
                    case "Mordekaiser": return 73;
                    case "Morganna": return 74;
                    case "Nami": return 75;
                    case "Nasus": return 76;
                    case "Nautilus": return 77;
                    case "Nidalee": return 78;
                    case "Nocturne": return 79;
                    case "Nunu": return 80;
                    case "Olaf": return 81;
                    case "Orianna": return 82;
                    case "Ornn": return 83;
                    case "Pantheon": return 84;
                    case "Poppy": return 85;
                    case "Pyke": return 86;
                    case "Quinn": return 87;
                    case "Rakan": return 88;
                    case "Rammus": return 89;
                    case "Rek'Sai": return 90;
                    case "Renekton": return 91;
                    case "Rengar": return 92;
                    case "Riven": return 93;
                    case "Rumble": return 94;
                    case "Ryze": return 95;
                    case "Sejuani": return 96;
                    case "Shaco": return 97;
                    case "Shen": return 98;
                    case "Shyvana": return 99;
                    case "Singed": return 100;
                    case "Sion": return 101;
                    case "Sivir": return 102;
                    case "Skarner": return 103;
                    case "Sona": return 104;
                    case "Soraka": return 105;
                    case "Swain": return 106;
                    case "Syndra": return 107;
                    case "Tahm Kench": return 108;
                    case "Taliyah": return 109;
                    case "Talon": return 110;
                    case "Taric": return 111;
                    case "Teemo": return 112;
                    case "Thresh": return 113;
                    case "Tristana": return 114;
                    case "Trundle": return 115;
                    case "Tryndamere": return 116;
                    case "Twisted Fate": return 117;
                    case "Twitch": return 118;
                    case "Udyr": return 119;
                    case "Urgot": return 120;
                    case "Varus": return 121;
                    case "Vayne": return 122;
                    case "Veigar": return 123;
                    case "Vel'Koz": return 124;
                    case "Vi": return 125;
                    case "Viktor": return 126;
                    case "Vladimir": return 127;
                    case "Volibear": return 128;
                    case "Warwick": return 129;
                    case "Wukong": return 130;
                    case "Xayah": return 131;
                    case "Xerath": return 132;
                    case "Xin Zhao": return 133;
                    case "Yasuo": return 134;
                    case "Yorick": return 135;
                    case "Zac": return 136;
                    case "Zed": return 137;
                    case "Ziggs": return 138;
                    case "Zilean": return 139;
                    case "Zoé": return 140;
                    case "Zyra": return 141;
                    default: return 999;
                }
            }
        }
        #endregion
        public int[,] AllyWinrate;
        public int[,] EnemyWinrate;

        public Champion(string n)
        {
            this.Name = n;
            AllyWinrate = new int[141,2];
            EnemyWinrate = new int[141,2];
            for (int i = 0; i<141; i++)
            {
                AllyWinrate[i,0] = 0;
                EnemyWinrate[i,0] = 0;
                AllyWinrate[i,1] = 0;
                EnemyWinrate[i,1] = 0;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        #region Methodes de calcul des winrates
        public double GetWinrate()
        {
            return AllyWinrate[this.Number - 1, 0] / (AllyWinrate[this.Number - 1, 0] + AllyWinrate[this.Number - 1, 1]);
        }

        public double GetWinrateWith(Champion[] compo)
        {
            int totalWins = 0;
            int totalLoss = 0;
            foreach (Champion champ in compo)
            {
                totalWins += AllyWinrate[champ.Number - 1, 0];
                totalLoss += AllyWinrate[champ.Number - 1, 1];
            }
            return totalWins / totalLoss; 
        }
        public double GetWinrateAgainst(Champion[] compo)
        {
            int totalWins = 0;
            int totalLoss = 0;
            foreach (Champion champ in compo)
            {
                totalWins += EnemyWinrate[champ.Number - 1, 0];
                totalLoss += EnemyWinrate[champ.Number - 1, 1];
            }
            return totalWins / totalLoss;
        }
        public double GetWinrate(Champion[] alliedComp, Champion[] enemyComp)
        {
            return (GetWinrateWith(alliedComp) + GetWinrateAgainst(enemyComp) + GetWinrate())/3;
        }
        #endregion

        #region Methodes de gestion des winrates
        public void WinWith(Champion[] compo)
        {
            foreach (Champion champ in compo)
            {
                this.AllyWinrate[champ.Number - 1, 0] += 1;
            }
        }
        public void WinAgainst(Champion[] compo)
        {
            foreach (Champion champ in compo)
            {
                this.EnemyWinrate[champ.Number - 1, 0] += 1;
            }
        }
        public void LoseWith(Champion[] compo)
        {
            foreach (Champion champ in compo)
            {
                this.AllyWinrate[champ.Number - 1, 1] += 1;
            }
        }
        public void LoseAgainst(Champion[] compo)
        {
            foreach (Champion champ in compo)
            {
                this.EnemyWinrate[champ.Number - 1, 1] += 1;
            }
        }
        #endregion

    }
}
