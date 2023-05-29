﻿using Dungeons_of_Ash;
using System.Diagnostics;
using System.IO;
using Spectre.Console;

string tittle = $" (                                                                               \r\n )\\ )                                                  (        (             )  \r\n(()/(     (          (  (     (                        )\\ )     )\\         ( /(  \r\n /(_))   ))\\   (     )\\))(   ))\\  (    (     (     (  (()/(  ((((_)(   (   )\\()) \r\n(_))_   /((_)  )\\ ) ((_))\\  /((_) )\\   )\\ )  )\\    )\\  /(_))  )\\ _ )\\  )\\ ((_)\\  \r\n |   \\ (_))(  _(_/(  (()(_)(_))  ((_) _(_/( ((_)  ((_)(_) _|  (_)_\\(_)((_)| |(_) \r\n | |) || || || ' \\))/ _` | / -_)/ _ \\| ' \\))(_-< / _ \\ |  _|   / _ \\  (_-<| ' \\  \r\n |___/  \\_,_||_||_| \\__, | \\___|\\___/|_||_| /__/ \\___/ |_|    /_/ \\_\\ /__/|_||_| \r\n                    |___/                                                       ";
Console.WriteLine(tittle);
Thread.Sleep(4000);
Console.Clear();
Console.WriteLine("Tell me your name ashen one.");
var name = Console.ReadLine();
if(name == "Admin")
{
    Items.physical_dmg += 1000;
    Items.spell_dmg += 1000;
    Items.Hp += 1000;
}
Thread.Sleep(3000);

Directory.CreateDirectory("items");
File.WriteAllText("items/items.txt", "tomas");
Dungeon dng = new Dungeon();
Player player = new Player();

int exp = 0;
double exp_max = 1000;
Dictionary<string, int> Stats = new Dictionary<string, int>();
Stats.Add("Durability", 1);
Stats.Add("Physical Power", 1);
Stats.Add("Spell Power", 1);
var color = new Style().Foreground(Color.DarkRed_1);
string option;
Console.Clear();
while (true)
{
    option = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .PageSize(10)
        .HighlightStyle(color)
        .AddChoices(new[] {
           "Play", "Stats", "Inventory", "Exit"
        }));
    //MENU
    switch(option)
    {
        case "Play": //DUNGEON MENU
            option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(10)
                .HighlightStyle(color)
                .AddChoices(new[] {
                   "Lava Catacombs", "Coming Soon"
                }));
            if (option == "Lava Catacombs") //DIFFICULTY MENU
            {
                option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(10)
                    .HighlightStyle(color)
                    .AddChoices(new[] {
                       "Easy", "Normal", "Coming Soon"
                    }));
                switch (option)
                {
                    case "Easy":
                        dng.Easy_dng();
                        exp += 100;
                        if (exp >= exp_max)
                        {
                            player.lvl++;
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "Normal":

                        break;
                }
            }
            break;
        case "Stats": //STATS
            Console.WriteLine($"name: {name}    lvl: {player.lvl}");
            Console.WriteLine($"Hp :  {player.playerHp}\nPhysical dmg :  {player.playerAttack}\nSpell dmg :  {player.playerSpell}");
            foreach (var att in Stats)
            {
                Console.WriteLine($"{att.Key} lvl:  {att.Value}");
            }
            Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnici.");
            Console.ReadLine();
            Console.Clear();
            break;
        case "Inventory": //INVENTORY
            while (true)
            {
                if (Player.inventory.Count == 0)
                {
                    Console.WriteLine("nic nemash");
                }
                else
                {
                    foreach (var items_att in Items.items_stats)
                    {
                        Console.WriteLine($"{items_att.Key}   Damage: {items_att.Value}");
                    }
                }
                Console.WriteLine("Pro equipnutí itemu napiš Yes, Pro vracení do jmenu zmáčkni jakoukoliv klávesu.");
                string volba = Console.ReadLine();
                if(volba == "Yes")
                {
                    Console.WriteLine("Napiš jméno itemu který chceš equipnout");
                    string equip = Console.ReadLine();
                    if (Player.inventory.Contains(equip))
                    {
                        int hodnota = Items.items_stats[equip];
                        if (equip.EndsWith("Staff"))
                        {
                            Items.spell_dmg += hodnota;
                        }
                        else
                        {
                            Items.physical_dmg += hodnota;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
            break;
        case "Exit": //EXIT
            return;
    }
}
//Add dmg to drops
//add more enemies
//second difficulty
//upgrades for items
//Stats upgrade