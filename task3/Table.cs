using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace task3
{
    internal class Table
    {
        public void CreateTable(string[] moves, int[,] cl, int N)
        {
            var table = new ConsoleTable();
            string[] a = { "v PC/User >" };
            table.AddColumn(a)
                .AddColumn(moves);
            for (int i = 0; i < N; i++)
            {
                Object[] data = new object[N + 1];
                data[0] = moves[i];
                for (int j = 1;j < N+1; j++)
                {
                    data[j] = (cl[i,j-1] != 1) ? ( data[j] = (cl[i,j-1] == - 1) ? "Lose" : "Draw") : "Win";
                                           
                }
                table.AddRow(data);
            }
            table.Write(Format.Alternative);
        }
    }
}
