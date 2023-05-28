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

        public int playerAttack = Items.physical_dmg;
        public int playerSpell = Items.spell_dmg;
        public int playerheal = Items.Hp / 2;
    }
}