using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proccess_DlYa_Podcheta
{
    internal class Process
    {   
        static void Main(string[] args)
        {
          
            int[] Massiv_4_intov = args.Select(x=>Convert.ToInt32(x)).ToArray();
           
            int q = 1;

            //  в нулевом элементе храним номер строки

            for (int i=1; i<Massiv_4_intov.Length; i++)
            {
                q = q * Massiv_4_intov[i];

            }
            Console.WriteLine($"{args[0]} {q}");
        }
    }
}
