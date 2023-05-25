using Dungeons_of_Ash;
using System.Diagnostics;
using System.IO;

string tittle = $" (                                                                               \r\n )\\ )                                                  (        (             )  \r\n(()/(     (          (  (     (                        )\\ )     )\\         ( /(  \r\n /(_))   ))\\   (     )\\))(   ))\\  (    (     (     (  (()/(  ((((_)(   (   )\\()) \r\n(_))_   /((_)  )\\ ) ((_))\\  /((_) )\\   )\\ )  )\\    )\\  /(_))  )\\ _ )\\  )\\ ((_)\\  \r\n |   \\ (_))(  _(_/(  (()(_)(_))  ((_) _(_/( ((_)  ((_)(_) _|  (_)_\\(_)((_)| |(_) \r\n | |) || || || ' \\))/ _` | / -_)/ _ \\| ' \\))(_-< / _ \\ |  _|   / _ \\  (_-<| ' \\  \r\n |___/  \\_,_||_||_| \\__, | \\___|\\___/|_||_| /__/ \\___/ |_|    /_/ \\_\\ /__/|_||_| \r\n                    |___/                                                       ";
Console.WriteLine(tittle);
Thread.Sleep(4000);
Console.Clear();
Console.WriteLine("Tell me your name ashen one.");
var name = Console.ReadLine();
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
Console.Clear();
while (true)
{
    ConsoleKeyInfo key;
    int option = 1;
    bool isSelected = false;
    (int left, int top) = Console.GetCursorPosition();
    string color = "\u001B[31m";
    Console.CursorVisible = false;
    while (!isSelected)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine($"{(option == 1 ? color : "")}|                       Play                         |\u001b[0m");
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine($"{(option == 2 ? color : "")}|                       Stats                        |\u001b[0m");
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine($"{(option == 3 ? color : "")}|                     Inventory                      |\u001b[0m");
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine($"{(option == 4 ? color : "")}|                        Exit                        |\u001b[0m");
        Console.WriteLine("|----------------------------------------------------|");
        key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                option = (option == 1 ? 4 : option - 1);
                break;
            case ConsoleKey.DownArrow:
                option = (option == 4 ? 1 : option + 1);
                break;
            case ConsoleKey.Enter:
                isSelected = true;
                break;
        }
        Console.Clear();
    }//MENU
    switch(option)
    {
        case 1: //DUNGEON MENU
            isSelected = false;
            while(!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine($"{(option == 1 ? color : "")}|                   Lava Catacombs                   |\u001b[0m");
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine($"{(option == 2 ? color : "")}|                    Coming Soon                     |\u001b[0m");
                Console.WriteLine("|----------------------------------------------------|");
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 2 : option - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        option = (option == 2 ? 1 : option + 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
                Console.Clear();
            }
            if (option == 1)
            {
                isSelected = false;
                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine($"{(option == 1 ? color : "")}|                       Easy                         |\u001b[0m");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine($"{(option == 2 ? color : "")}|                      Normal                        |\u001b[0m");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine($"{(option == 3 ? color : "")}|                    Coming Soon                     |\u001b[0m");
                    Console.WriteLine("|----------------------------------------------------|");
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            option = (option == 1 ? 3 : option - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            option = (option == 3 ? 1 : option + 1);
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                    Console.Clear();
                }
                switch (option)
                {
                    case 1:
                        dng.Easy_dng();
                        exp += 100;
                        if (exp >= exp_max)
                        {
                            player.lvl++;
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case 2:

                        break;
                }
            }
            break;
        case 2: //STATS
            Console.WriteLine($"name: {name}    lvl: {player.lvl}");
            foreach (var att in Stats)
            {
                Console.WriteLine($"{att.Key}  {att.Value}");
            }
            Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnici.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 3: //INVENTORY
            if (Player.inventory.Count == 0)
            {
                Console.WriteLine("nic nemash");
            }
            else
            {
                foreach (string vec in Player.inventory)
                {
                    Console.WriteLine(vec);
                }
            }
            break;
        case 4: //EXIT
            return;
    }
}
//Add dmg to drops
//add more enemies
//second difficulty
//upgrades for items