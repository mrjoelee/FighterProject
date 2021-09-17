using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterProject.Enum;
using System.Threading;

namespace FighterProject
{
    class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Fighter goodGuy = new Fighter("Ryu", Faction.GoodGuy);
            Fighter badGuy = new Fighter("Bison", Faction.GoodGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rng.Next(0,10) < 5)
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }
                Thread.Sleep(200);
            }
        }
    }
}
