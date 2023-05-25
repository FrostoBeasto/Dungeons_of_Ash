using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_of_Ash
{
    internal class Player
    {
        public static List<string> inventory = new List<string>();

        
        public int playerHp = 100;
        public int lvl = 1;

        public int playerAttack = Items.physical_dmg;
        public int playerSpell = 200;
        public int playerheal = 20;
    }
}