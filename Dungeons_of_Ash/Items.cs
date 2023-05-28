using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_of_Ash
{
    internal class Items
    {
        public static string[] easy_weapons = {"Hellstone Greataxe","Lava Shard Staff"};

        public static string[] easy_armors = {"Molten Forged Warrior Helmet", "Molten Forged Warrior Armor", "Molten Forged Mage Helmet"
                , "Molten Forged Mage Armor"};

        public static string[] normal_weapons = {"Volcanic Greatsword","Lava Spellblade","Lava Kings Magma Blade"
                ,"Lava Kings Hellfire Greatstaff" };

        public static string[] normal_armors = {"Magmatic Warrior Helmet", "Magmatic Warrior Armor"
                ,"Magmatic Mage Helmet", "Magmatic Mage Armor" };

        public static string[] easy_spells = {"Demonic Blades", "Infernal Orbs", "Molten Spear Blast", "Magma Barrage"};

        public static string[] normal_spells = {"Molten Spear Blast", "Magma Barrage" };

        public static Dictionary<string, int> items_stats = new Dictionary<string, int>();

        public static int physical_dmg;

        public static int spell_dmg;

        public static int Hp;
    }
}