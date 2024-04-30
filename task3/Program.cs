

using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace task3
{
    internal class Program
    {
        public static bool FindDuplicates(string[] args)
        {
            HashSet<string> uniqueElements = new HashSet<string>();
            HashSet<string> duplicates = new HashSet<string>();

            foreach (string element in args)
            {
                if (!uniqueElements.Add(element))
                {
                    duplicates.Add(element);
                }
            }
            if (duplicates.Count > 0) { return true; }
            else { return false; }
        }

        public static bool IsValid(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OutputTable(string[] args, Rule rule)
        {
            Table table = new Table();
            table.CreateTable(args, rule.Rules, args.Length);
        }

        public static int InputAction(string[] args, Menu menu, Rule rule)
        {
            string userAction;
            do
            {
                userAction = Console.ReadLine();
                if (userAction == "?")
                {
                    OutputTable(args, rule);
                }
                else if (userAction == "0")
                {
                    System.Environment.Exit(0);
                }
                else if (Convert.ToInt32(userAction) > args.Length || Convert.ToInt32(userAction) < 0)
                {
                    menu.ShowMenu();
                }
                else
                {
                    return Convert.ToInt32(userAction);
                }
            } while (true);
        }

       

        static void Main(string[] args)
        {
            if(IsValid(args)) 
            {
                Console.WriteLine("Invalid input. The number of elements must be more than 3, equal to 3 odd.\nExample: 'game.exe rock paper scissors'.");
                return;
            }
            else if (FindDuplicates(args))
            {
                Console.WriteLine("Invalid input. You have repeated elements. \nExample: 'game.exe rock paper scissors'.");
                return ;
            }
            else
            {
                Menu menu = new Menu(args);
                Rule rule = new Rule(args.Length);
                HmacKey key = new HmacKey();
                Random random = new Random();
                Hmac hmac = new Hmac();
                int pcMove = random.Next(0, args.Length - 1);
                key.CreateKey();
                hmac.CreateHmac(key.KeyByte, args[pcMove]);
                Console.WriteLine("HMAC:");
                Console.WriteLine(hmac.Hash);
                rule.FillRules();
                menu.ShowMenu();
                int userAction = InputAction(args, menu, rule);
                Console.WriteLine($"""
                    Your move: {args[userAction - 1]}
                    PC move: {args[pcMove]}
                    """);
                if(rule.GetWinner(pcMove, userAction - 1) == 1)
                {
                    Console.WriteLine("You win!");
                }else if (rule.GetWinner(pcMove, userAction - 1) == -1)
                {
                    Console.WriteLine("You lose!");
                }else
                {
                    Console.WriteLine("Draw");
                }
                Console.WriteLine($"""              
                    HMAC key:
                    {key.Key}
                    """);
            }
        }
    }
}
