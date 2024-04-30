using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Menu
    {
        private string[] action;

        public Menu(string[] action) 
        {
            this.action = action;
        }

        public void ShowMenu()
        {
            Console.WriteLine("Available moves: ");
            for (int i = 0; i < action.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {action[i]}");
            }
            Console.WriteLine("""
                0 - exit
                ? - rules
                """);
        }


    }
}
