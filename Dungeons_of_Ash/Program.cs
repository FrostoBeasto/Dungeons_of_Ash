﻿using System.Diagnostics;

Console.WriteLine("Welcome to Dungeons of Ash");
Thread.Sleep(3000);
Console.Clear();
Console.WriteLine("Tell me your name ashen one.");
var name = Console.ReadLine();
Thread.Sleep(3000);

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
                    switch(option)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                    }
                }
            }
            break;
        case 2: //STATS
            Console.WriteLine($"name: {name}");
            foreach (var att in Stats)
            {
                Console.WriteLine($"{att.Key}  {att.Value}");
            }
            Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnici.");
            Console.ReadLine();
            Console.Clear();
            break;
        case 3: //INVENTORY

            break;
        case 4: //EXIT
            return;
    }
}