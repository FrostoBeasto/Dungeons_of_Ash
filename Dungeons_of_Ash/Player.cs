using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_of_Ash
{
    internal class Player
    {
        public List<string> inventory = new List<string>();

        
        public int playerHp = 100;

        public int playerAttack = 5;
        public int playerSpell = 10;
        public int playerheal = 20;
    }
}
