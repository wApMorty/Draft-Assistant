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
                    case "Bard": return 1;
                    case "Blitzcrank": return 2;
                    case "Brand": return 3;
                    case "Braum": return 4;
                    case "Caitlyn": return 5;
                    case "Camille": return 6;
                    case "Cassiopeia": return 7;
                    case "Cho'Gath": return 8;
                    case "Corki": return 9;
                    case "Darius": return 10;
                    case "Diana": return 1;
                    case "Dr. Mundo": return 2;
                    case "Draven": return 3;
                    case "Ekko": return 4;
                    case "Elise": return 5;
                    case "Evelynn": return 6;
                    case "Ezreal": return 7;
                    case "Fiddlesticks": return 8;
                    case "Fiora": return 9;
                    case "Fizz": return 10;
                    case "Galio": return 1;
                    case "Gangplank": return 2;
                    case "Garen": return 3;
                    case "Gnar": return 4;
                    case "Gragas": return 5;
                    case "Graves": return 6;
                    case "Hecarim": return 7;
                    case "Heimerdinger": return 8;
                    case "Illaoi": return 9;
                    case "Irelia": return 10;
                    case "Ivern": return 1;
                    case "Janna": return 2;
                    case "Jarvan IV": return 3;
                    case "Jax": return 4;
                    case "Jayce": return 5;
                    case "Jhin": return 6;
                    case "Jinx": return 7;
                    case "Kai'Sa": return 8;
                    case "Kalista": return 9;
                    case "Karma": return 10;
                    case "Karthus": return 1;
                    case "Kassadin": return 2;
                    case "Katarina": return 3;
                    case "Kayle": return 4;
                    case "Kayn": return 5;
                    case "Kennen": return 6;
                    case "Kha'Zix": return 7;
                    case "Kindred": return 8;
                    case "Kled": return 9;
                    case "Kog'Maw": return 10;
                    case "Leblanc": return 1;
                    case "Lee Sin": return 2;
                    case "Leona": return 3;
                    case "Lissandra": return 4;
                    case "Lucian": return 5;
                    case "Lulu": return 6;
                    case "Lux": return 7;
                    case "Malphite": return 8;
                    case "Malzahar": return 9;
                    case "Maokai": return 10;
                    case "Maître Yi": return 1;
                    case "Miss Fortune": return 2;
                    case "Mordekaiser": return 3;
                    case "Morganna": return 4;
                    case "Nami": return 5;
                    case "Nasus": return 6;
                    case "Nautilus": return 7;
                    case "Nidalee": return 8;
                    case "Nocturne": return 9;
                    case "Nunu": return 10;
                    case "Olaf": return 1;
                    case "Orianna": return 2;
                    case "Ornn": return 3;
                    case "Pantheon": return 4;
                    case "Poppy": return 5;
                    case "Pyke": return 6;
                    case "Quinn": return 7;
                    case "Rakan": return 8;
                    case "Rammus": return 9;
                    case "Rek'Sai": return 10;
                    case "Renekton": return 1;
                    case "Rengar": return 2;
                    case "Riven": return 3;
                    case "Rumble": return 4;
                    case "Ryze": return 5;
                    case "Sejuani": return 6;
                    case "Shaco": return 7;
                    case "Shen": return 8;
                    case "Shyvana": return 9;
                    case "Singed": return 10;
                    case "Sion": return 1;
                    case "Sivir": return 2;
                    case "Skarner": return 3;
                    case "Sona": return 4;
                    case "Soraka": return 5;
                    case "Swain": return 6;
                    case "Syndra": return 7;
                    case "Tahm Kench": return 8;
                    case "Taliyah": return 9;
                    case "Talon": return 10;
                    case "Taric": return 1;
                    case "Teemo": return 2;
                    case "Thresh": return 3;
                    case "Tristana": return 4;
                    case "Trundle": return 5;
                    case "Tryndamere": return 6;
                    case "Twisted Fate": return 7;
                    case "Twitch": return 8;
                    case "Udyr": return 9;
                    case "Urgot": return 10;
                    case "Varus": return 1;
                    case "Vayne": return 2;
                    case "Veigar": return 3;
                    case "Vel'Koz": return 4;
                    case "Vi": return 5;
                    case "Viktor": return 6;
                    case "Vladimir": return 7;
                    case "Volibear": return 8;
                    case "Warwick": return 9;
                    case "Wukong": return 10;
                    case "Xayah": return 1;
                    case "Xerath": return 2;
                    case "Xin Zhao": return 3;
                    case "Yasuo": return 4;
                    case "Yorick": return 5;
                    case "Zac": return 6;
                    case "Zed": return 7;
                    case "Ziggs": return 8;
                    case "Zilean": return 9;
                    case "Zoé": return 10;
                    case "Zyra": return 1;
                    default: return 999;
                }
            }
        }

    }
}
