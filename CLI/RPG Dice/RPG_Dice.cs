using System;
using System.Threading;
using System.Collections.Generic;

namespace RPG_Dice
{
    class RPG_Dice
    {
        public RPG_Dice()
        {
            RN = new Random();
            RC = 1;
            RB = new List<string>();
            Console.Title = "RPG Dice";
        }
        ~RPG_Dice()
        {
            RB = null;
            RN = null;
        }

        private Random RN; //Sudo Random Number
        private int RC; //Roll Count
        private List<String> RB; //Roll Buffer
        private int UI; //User Input

        public void ResetConsole()
        {
            Console.Clear();
        }

        public void OutputRollBuffer()
        {
            Console.Write("Roll buffer: ");

            foreach (string i in RB)
            {
                Console.Write(i);
            }

            if (RB.Count == 0)
            {
                Console.Write("No dice have been rolled.");
            }
        }
        public void Instructions()
        {
            Console.WriteLine();
            Console.WriteLine("Please type");
            Console.WriteLine("[a] for a d4");
            Console.WriteLine("[b] for a d6");
            Console.WriteLine("[c] for a d8");
            Console.WriteLine("[d] for a d10");
            Console.WriteLine("[e] for a d12");
            Console.WriteLine("[f] for a d20");
            Console.WriteLine("[g] to clear the roll buffer");
            Console.WriteLine("[h] to end app");
        }

        public void GetUserInput()
        {
            this.UI = (int)Console.ReadKey(true).Key;
        }

        public bool DiceRoll()
        {
            switch (this.UI)
            {
                case 65: //a
                    GenerateRoll(4);
                    break;
                case 66: //b
                    GenerateRoll(6);
                    break;
                case 67: //c
                    GenerateRoll(8);
                    break;
                case 68: //d
                    GenerateRoll(10);
                    break;
                case 69: //e
                    GenerateRoll(12);
                    break;
                case 70: //f
                    GenerateRoll(20);
                    break;
                case 71: //g
                    RB.Clear();
                    RC = 1;
                    Console.WriteLine("Dice roll buffer is clear.");
                    Thread.Sleep(1000);
                    break;
                case 72: //h
                    Console.WriteLine("Thank you for using this app.");
                    Thread.Sleep(1000);
                    return false;
                default:
                    Console.WriteLine("Invalid input.");
                    Thread.Sleep(800);
                    break;
            }

            return true;
        }

        private void GenerateRoll(int a)
        {
            int randNumber = 0;
            int consoleColumn;
            for (int i = 0; i < 10; i++)
            {
                consoleColumn = Console.CursorLeft;
                randNumber = RN.Next(1, a);
                Console.Write(randNumber + " ");
                Console.CursorLeft = consoleColumn;
                Thread.Sleep(100 * (i + 1));
            }
            RB.Add("Roll" + RC + "-d" + a + "-" + randNumber + " ");
            RC += 1;
        }
    }
}
