using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draft_Assistant
{
    class Initializer
    {

        public static void Initialize()
        {
            #region Instanciation de tous les champions du jeu
            Champion aatrox = new Champion("Aatrox");
            Champion ahri = new Champion("Ahri");
            Champion akali = new Champion("Akali");
            Champion alistar = new Champion("Alistar");
            Champion amumu = new Champion("Amumu");
            Champion anivia = new Champion("Anivia");
            Champion annie = new Champion("Annie");
            Champion ashe = new Champion("Ashe");
            Champion aurelion_sol = new Champion("AurelionSol");
            Champion azir = new Champion("Azir");
            Champion bard = new Champion("Bard");
            Champion blitzcrank = new Champion("Blitzcrank");
            Champion brand = new Champion("Brand");
            Champion braum = new Champion("Braum");
            Champion caitlyn = new Champion("Caitlyn");
            Champion camille = new Champion("Camille");
            Champion cassiopeia = new Champion("Cassiopeia");
            Champion cho_gath = new Champion("ChoGath");
            Champion corki = new Champion("Corki");
            Champion darius = new Champion("Darius");
            Champion diana = new Champion("Diana");
            Champion dr_mundo = new Champion("DrMundo");
            Champion draven = new Champion("Draven");
            Champion ekko = new Champion("Ekko");
            Champion elise = new Champion("Elise");
            Champion evelynn = new Champion("Evelynn");
            Champion ezreal = new Champion("Ezreal");
            Champion fiddlesticks = new Champion("Fiddlesticks");
            Champion fiora = new Champion("Fiora");
            Champion fizz = new Champion("Fizz");
            Champion galio = new Champion("Galio");
            Champion gangplank = new Champion("Gangplank");
            Champion garen = new Champion("Garen");
            Champion gnar = new Champion("Gnar");
            Champion gragas = new Champion("Gragas");
            Champion graves = new Champion("Graves");
            Champion hecarim = new Champion("Hecarim");
            Champion heimerdinger = new Champion("Heimerdinger");
            Champion illaoi = new Champion("Illaoi");
            Champion irelia = new Champion("Irelia");
            Champion ivern = new Champion("Ivern");
            Champion janna = new Champion("Janna");
            Champion jarvan_iv = new Champion("JarvanIV");
            Champion jax = new Champion("Jax");
            Champion jayce = new Champion("Jayce");
            Champion jhin = new Champion("Jhin");
            Champion jinx = new Champion("Jinx");
            Champion kai_sa = new Champion("KaiSa");
            Champion kalista = new Champion("Kalista");
            Champion karma = new Champion("Karma");
            Champion karthus = new Champion("Karthus");
            Champion kassadin = new Champion("Kassadin");
            Champion katarina = new Champion("Katarina");
            Champion kayle = new Champion("Kayle");
            Champion kayn = new Champion("Kayn");
            Champion kennen = new Champion("Kennen");
            Champion kha_zix = new Champion("KhaZix");
            Champion kindred = new Champion("Kindred");
            Champion kled = new Champion("Kled");
            Champion kog_maw = new Champion("KogMaw");
            Champion leblanc = new Champion("Leblanc");
            Champion lee_sin = new Champion("LeeSin");
            Champion leona = new Champion("Leona");
            Champion lissandra = new Champion("Lissandra");
            Champion lucian = new Champion("Lucian");
            Champion lulu = new Champion("Lulu");
            Champion lux = new Champion("Lux");
            Champion malphite = new Champion("Malphite");
            Champion malzahar = new Champion("Malzahar");
            Champion maokai = new Champion("Maokai");
            Champion maitre_yi = new Champion("MaitreYi");
            Champion miss_fortune = new Champion("MissFortune");
            Champion mordekaiser = new Champion("Mordekaiser");
            Champion morganna = new Champion("Morganna");
            Champion nami = new Champion("Nami");
            Champion nasus = new Champion("Nasus");
            Champion nautilus = new Champion("Nautilus");
            Champion nidalee = new Champion("Nidalee");
            Champion nocturne = new Champion("Nocturne");
            Champion nunu = new Champion("Nunu");
            Champion olaf = new Champion("Olaf");
            Champion orianna = new Champion("Orianna");
            Champion ornn = new Champion("Ornn");
            Champion pantheon = new Champion("Pantheon");
            Champion poppy = new Champion("Poppy");
            Champion pyke = new Champion("Pyke");
            Champion quinn = new Champion("Quinn");
            Champion rakan = new Champion("Rakan");
            Champion rammus = new Champion("Rammus");
            Champion rek_sai = new Champion("RekSai");
            Champion renekton = new Champion("Renekton");
            Champion rengar = new Champion("Rengar");
            Champion riven = new Champion("Riven");
            Champion rumble = new Champion("Rumble");
            Champion ryze = new Champion("Ryze");
            Champion sejuani = new Champion("Sejuani");
            Champion shaco = new Champion("Shaco");
            Champion shen = new Champion("Shen");
            Champion shyvana = new Champion("Shyvana");
            Champion singed = new Champion("Singed");
            Champion sion = new Champion("Sion");
            Champion sivir = new Champion("Sivir");
            Champion skarner = new Champion("Skarner");
            Champion sona = new Champion("Sona");
            Champion soraka = new Champion("Soraka");
            Champion swain = new Champion("Swain");
            Champion syndra = new Champion("Syndra");
            Champion tahm_kench = new Champion("TahmKench");
            Champion taliyah = new Champion("Taliyah");
            Champion talon = new Champion("Talon");
            Champion taric = new Champion("Taric");
            Champion teemo = new Champion("Teemo");
            Champion thresh = new Champion("Thresh");
            Champion tristana = new Champion("Tristana");
            Champion trundle = new Champion("Trundle");
            Champion tryndamere = new Champion("Tryndamere");
            Champion twisted_fate = new Champion("TwistedFate");
            Champion twitch = new Champion("Twitch");
            Champion udyr = new Champion("Udyr");
            Champion urgot = new Champion("Urgot");
            Champion varus = new Champion("Varus");
            Champion vayne = new Champion("Vayne");
            Champion veigar = new Champion("Veigar");
            Champion vel_koz = new Champion("VelKoz");
            Champion vi = new Champion("Vi");
            Champion viktor = new Champion("Viktor");
            Champion vladimir = new Champion("Vladimir");
            Champion volibear = new Champion("Volibear");
            Champion warwick = new Champion("Warwick");
            Champion wukong = new Champion("Wukong");
            Champion xayah = new Champion("Xayah");
            Champion xerath = new Champion("Xerath");
            Champion xin_zhao = new Champion("XinZhao");
            Champion yasuo = new Champion("Yasuo");
            Champion yorick = new Champion("Yorick");
            Champion zac = new Champion("Zac");
            Champion zed = new Champion("Zed");
            Champion ziggs = new Champion("Ziggs");
            Champion zilean = new Champion("Zilean");
            Champion zoe = new Champion("Zoe");
            Champion zyra = new Champion("Zyra");
            #endregion

            #region Stockage dans un tableau
            Champion[] champions = { aatrox, ahri, akali, alistar, amumu,
            anivia, annie, ashe, aurelion_sol, azir, bard, blitzcrank,
            brand, braum, caitlyn, camille, cassiopeia, cho_gath, corki,
            darius, diana, dr_mundo, draven, ekko, elise, evelynn, ezreal,
            fiddlesticks, fiora, fizz, galio, gangplank, garen, gnar, gragas,
            hecarim, heimerdinger, illaoi, irelia, ivern, janna, jarvan_iv,
            jax, jayce, jhin, jinx, kai_sa, kalista, karma, karthus, kassadin,
            katarina, kayle, kayn, kennen, kha_zix, kindred, kled, kog_maw,
            leblanc, lee_sin, leona, lissandra, lucian, lulu, lux, malphite,
            malzahar, maokai, maitre_yi, miss_fortune, mordekaiser, morganna,
            nami, nasus, nautilus, nidalee, nocturne, nunu, olaf, orianna,
            ornn, pantheon, poppy, pyke, quinn, rakan, rammus, rek_sai,
            renekton, rengar, riven, rumble, ryze, sejuani, shaco, shen,
            shyvana, singed, sion, sivir, skarner, sona, soraka, swain,
            syndra, tahm_kench, taliyah, talon, taric, teemo, thresh,
            tristana, trundle, tryndamere, twisted_fate, twitch, udyr,
            urgot, varus, vayne, veigar, vel_koz, vi, viktor, vladimir,
            volibear, warwick, wukong, xayah, xerath, xin_zhao, yasuo,
            yorick, zac, zed, ziggs, zilean, zoe, zyra};
            #endregion

            #region Serialization dans un JSON
            File.WriteAllText(@"D:\Paul\Documents\Visual Studio workspace\Draft Assistant 3rd try\Draft Assistant\Draft Assistant\Database.JSON",
                JsonConvert.SerializeObject(champions));
            #endregion
        }

    }
}
