using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_of_Ash
{
    internal class Dungeon
    {
        public void Easy_dng()
        {
            Random rnd = new Random();
            Player player = new Player();

            int enemyHp = 50;
            int bossHp = 150;
            int player_maxHp = player.playerHp;

            int enemyAttack = 5;
            int bossAttack = 6;
            int bossSpell = 8;

            string item_drops = "";

            var color = new Style().Foreground(Color.DarkRed_1);
            string choice;

            while (player.playerHp > 0 && enemyHp > 0)
            {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title($"     --- Player Turn ---\nPlayer Hp - {player.playerHp}.   Enemy Hp - {enemyHp}")
                    .PageSize(10)
                    .HighlightStyle(color)
                    .AddChoices(new[] {
                        "Attack with weapon", "Use your spell", "Heal yourself"
                    }));
                switch(choice)
                {
                    case "Attack with weapon":
                        Console.WriteLine($"Player attacks enemy with sword and deals {player.playerAttack} damage!");
                        enemyHp -= player.playerAttack;
                        break;
                    case "Use your spell":
                        Console.WriteLine($"Player uses a spell on the enemy and deals {player.playerSpell} damage!");
                        enemyHp -= player.playerSpell;
                        break;
                    case "Heal yourself":
                        Console.WriteLine($"Player uses heal and heals himself for {player.playerheal} Hp!");
                        player.playerHp += player.playerheal;
                        if (player.playerHp > player_maxHp)
                        {
                            player.playerHp = player_maxHp;
                        }
                        break;
                }
                if(enemyHp >0)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine($"--- Enemy turn ---\nPlayer Hp - {player.playerHp}.  Enemy Hp - {enemyHp}\nEnemy attacks and deals {enemyAttack} damage!");
                    player.playerHp -= enemyAttack;
                }
                Thread.Sleep(5000);
                Console.Clear();
            }
            Console.WriteLine("GG, you reached the last room with heavy door.");
            Thread.Sleep(2000);
            Console.WriteLine("As you open the door you notice some big figure as you look closely you relise");
            Console.WriteLine("BOSSFIGHT TIME");
            Thread.Sleep(3000);
            Console.Clear();
            while (player.playerHp > 0 && enemyHp <= 0 && bossHp >0)
            {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title($"     --- Player Turn ---\nPlayer Hp - {player.playerHp}.   Boss Hp - {bossHp}")
                    .PageSize(10)
                    .HighlightStyle(color)
                    .AddChoices(new[] {
                        "Attack with weapon", "Use your spell", "Heal yourself"
                    }));
                switch (choice)
                {
                    case "Attack with weapon":
                        Console.WriteLine($"Player attacks Boss with sword and deals {player.playerAttack} damage!");
                        bossHp -= player.playerAttack;
                        break;
                    case "Use your spell":
                        Console.WriteLine($"Player uses a spell on the Boss and deals {player.playerSpell} damage!");
                        bossHp -= player.playerSpell;
                        break;
                    case "Heal yourself":
                        Console.WriteLine($"Player uses heal and heals himself for {player.playerheal} Hp!");
                        player.playerHp += player.playerheal;
                        if (player.playerHp > player_maxHp)
                        {
                            player.playerHp = player_maxHp;
                        }
                        break;
                }
                int bosschoice = rnd.Next(0, 2);
                if(bossHp > 0)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine($"--- Boss turn ---\nPlayer Hp - {player.playerHp}.  Boss Hp - {bossHp}");
                    if(bosschoice == 0)
                    {
                        Console.WriteLine($"Boss attacks and deals {bossAttack} damage!");
                        player.playerHp -= bossAttack;
                    }
                    if (bosschoice == 1)
                    {
                        Console.WriteLine($"Boss uses a spell and deals {bossSpell} damage!");
                        player.playerHp -= bossSpell;
                    }
                }
                Thread.Sleep(5000);
                Console.Clear();
            }
            if(player.playerHp > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    int rnd_item = rnd.Next(0, 3);
                    if (rnd_item == 0)
                    {
                        int rnd_weapon = rnd.Next(0, 2);
                        int weapon_dmg = rnd.Next(20, 31);
                        item_drops += Items.easy_weapons[rnd_weapon] + " ,";
                        Player.inventory.Add($"{Items.easy_weapons[rnd_weapon]}");
                        Items.items_stats.Add($"{Items.easy_weapons[rnd_weapon]}", weapon_dmg);
                        if (item_drops == "Hellstone Greataxe")
                        {
                            Items.physical_dmg += weapon_dmg;
                        }
                        else if (item_drops == "Lava Shard Staff")
                        {
                            Items.spell_dmg += weapon_dmg;
                        }
                    }
                    if (rnd_item == 1)
                    {
                        int rnd_armor = rnd.Next(0, 3);
                        int armor_dmg = rnd.Next(15, 23);
                        int armor_hp = rnd.Next(10, 16);
                        item_drops += Items.easy_armors[rnd_armor] + " ,";
                        Player.inventory.Add($"{Items.easy_armors[rnd_armor]}");
                        Items.items_stats.Add($"{Items.easy_weapons[rnd_armor]}", armor_dmg);
                        if (item_drops == "Molten Forged Warrior Helmet" || item_drops == "Molten Forged Warrior Armor")
                        {
                            Items.physical_dmg += armor_dmg;
                        }
                        else if (item_drops == "Molten Forged Mage Helmet" || item_drops == "Molten Forged Mage Armor")
                        {
                            Items.spell_dmg += armor_dmg;
                        }
                        Items.Hp += armor_hp;
                    }
                    if (rnd_item == 2)
                    {
                        int rnd_spell = rnd.Next(0, 2);
                        item_drops += Items.easy_spells[rnd_spell] + " ,";
                        Player.inventory.Add($"{Items.easy_spells[rnd_spell]}");
                    }
                }
                Console.WriteLine($"GG, you won!\nHere are your drops: {item_drops}");
                Thread.Sleep(5000);
                Console.WriteLine("Returning to main menu");
            }
            else
            {
                Console.WriteLine("Unlucky, you lost\nReturning to main menu.");
            }
        }
    }
}