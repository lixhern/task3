using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Rule
    {
        private int[,] rules;

        public  int[,] Rules
        {
            get
            {
                return rules;
            }

        }
        private int quantityActions;

        public Rule(int quantityActions)
        {
            this.quantityActions = quantityActions;
            rules = new int[quantityActions, quantityActions];
        }

        public void FillRules()
        {
            for (int i = 0; i < quantityActions; i++)
            {
                for (int j = 0; j < quantityActions; j++)
                {
                    rules[i, j] = Math.Sign((j - i + quantityActions + (quantityActions >> 1)) % quantityActions - (quantityActions >> 1));
                }
            }
        }

        public void ShowRule()
        {
            for(int i = 0; i < quantityActions;i++)
            {
                for( int j = 0;j < quantityActions;j++)
                {
                    Console.Write(rules[i, j] + " ");
                }    
                Console.WriteLine();
            }
        }

        public int GetWinner(int actionPc, int actionUser)
        {
            return rules[actionPc, actionUser];  
        }

    }
}
