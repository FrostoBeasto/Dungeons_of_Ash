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
            int playerHp = 100;
            int enemyHp = 50;
            int bossHp = 200;

            int playerAttack = 5;
            int playerSpell = 10;
            int enemyAttack = 5;
            int bossAttack = 6;
            int bossSpell = 8;
            Random rnd = new Random();

            while(playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine($"--- Player Turn ---\nPlayer Hp - {playerHp}.  Enemy Hp - {enemyHp}\nChoose your action\n1.Attack enemy with weapon\n2.Use a spell");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine($"Player attacks enemy with sword and deals {playerAttack} damage!");
                    enemyHp -= playerAttack;
                }
                if (choice == "2")
                {
                    Console.WriteLine($"Player uses a spell on the enemy and deals {playerSpell} damage!");
                    enemyHp -= playerSpell;
                }

                if(enemyHp >0)
                {
                    Console.WriteLine($"--- Enemy turn ---\nPlayer Hp - {playerHp}.  Enemy Hp - {enemyHp}\nEnemy attacks and deals {enemyAttack} damage!");
                    playerHp -= enemyAttack;
                }
                Thread.Sleep(5000);
                Console.Clear();
            }
            Console.WriteLine("But this is not over yet because it is Bossfight time!");
            Thread.Sleep(3000);
            Console.Clear();
            while (playerHp > 0 && enemyHp <= 0 && bossHp >0)
            {
                Console.WriteLine($"Bossfight time\n--- Player Turn ---\nPlayer Hp - {playerHp}.  Boss Hp - {bossHp}\nChoose your action\n1.Attack Boss with weapon\n2.Use a spell");
                var choice = Console.ReadLine();
                if (choice == "1") 
                {
                    Console.WriteLine($"Player attacks Boss with sword and deals {playerAttack} damage!");
                    bossHp -= playerAttack;
                }
                if (choice == "2")
                {
                    Console.WriteLine($"Player uses a spell on the Boss and deals {playerSpell} damage!");
                    bossHp -= playerSpell;
                }

                int bosschoice = rnd.Next(0, 2);
                if(bossHp > 0)
                {
                    Console.WriteLine($"--- Boss turn ---\nPlayer Hp - {playerHp}.  Boss Hp - {bossHp}");
                    if(bosschoice == 0)
                    {
                        Console.WriteLine($"Boss attacks and deals {bossAttack} damage!");
                        playerHp -= bossAttack;
                    }
                    if (bosschoice == 1)
                    {
                        Console.WriteLine($"Boss uses a spell and deals {bossSpell} damage!");
                        playerHp -= bossSpell;
                    }
                }
                Thread.Sleep(5000);
                Console.Clear();
            }

            if(playerHp > 0)
            {
                Console.WriteLine("GG, you won!\nHere are your drops: \nReturning to main menu");
            }
            else
            {
                Console.WriteLine("Unlucky, you lost\nReturning to main menu.");
            }
        }
    }
}