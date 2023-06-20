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

        

        public int playerHp = 100 + Items.Hp;
        public int lvl = 1;

        public int playerAttack = 10 + Items.physical_dmg;
        public int playerSpell = 10 + Items.spell_dmg;
        public int playerheal = 10 + Items.Hp / 2;
    }
}