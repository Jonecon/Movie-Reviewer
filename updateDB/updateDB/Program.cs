using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace updateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> movieList;
            movieList = populateList();

            try
            {
                StreamWriter sw = File.CreateText("C:\\Users\\Connor\\Desktop\\updateDB.sql");
                Random rand = new Random();
                for (int i = 21; i < 200021; i++)
                {
                    sw.WriteLine("UPDATE movie SET movieimg = '" + movieList[rand.Next(20)] + "' WHERE movie_id = " + i + ";");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static List<string> populateList()
        {
            List<string> x = new List<string>();
            x.Add("Imgs\\AsheLOL.jpg");
            x.Add("Imgs\\BridgetoTerabithia.jpg");
            x.Add("Imgs\\Ciri.jpg");
            x.Add("Imgs\\CiriAndGeralt.jpg");
            x.Add("Imgs\\CiriSit.jpg");
            x.Add("Imgs\\DravenLOL.jpg");
            x.Add("Imgs\\InfinityWars.jpg");
            x.Add("Imgs\\Jumanji1995.jpg");
            x.Add("Imgs\\MissFortuneLOL.jpg");
            x.Add("Imgs\\SpiritedAway.jpg");
            x.Add("Imgs\\SylvanasWOW.jpg");
            x.Add("Imgs\\ThejungleBook1967.jpg");
            x.Add("Imgs\\TheLastNaruto.jpg");
            x.Add("Imgs\\TheLionKing1994.jpg");
            x.Add("Imgs\\TyrandeWOW.jpg");
            x.Add("Imgs\\UzumakiFamily.jpg");
            x.Add("Imgs\\Weatherwithyou.jpg");
            x.Add("Imgs\\WolfChildren.jpg");
            x.Add("Imgs\\XayahLOL.jpg");
            x.Add("Imgs\\YourName.jpg");

            return x;
        }
    }
}
