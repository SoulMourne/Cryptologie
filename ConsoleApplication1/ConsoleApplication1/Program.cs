using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crytpologie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Chiffrage du message--");
            int[] message = {1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }; //message a chiffrer
            int[] cle = { 1, 1, 0 };    //cle de chiffrage
            int[] res = Vernam.chiffrer(message, cle);  //chiffrage du message
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i]);
            }
            Console.WriteLine("\n--Test Algo Etendu--");
            int[] tab = Euclide.algoEtendu(26, 15);
            Console.WriteLine(tab[0] + " " + tab[1]+"\n--Inverse--\n"+ Euclide.inverse(51, 242));
            Console.WriteLine("");
        }
    }

    class Vernam
    {
        public static int[] chiffrer(int[] parMessage, int[] parCle)
        {
            int[] retour = new int[parMessage.Length];
            for (int i = 0; i < parMessage.Length; i++)
            {
                retour[i] = (parMessage[i] + parCle[i % parCle.Length]) % 2;
            }
            return retour;
        }
    }

    class Euclide
    {
        public static int[] algoEtendu(int a, int b)
        {
            if (a<b || b<1)
                throw new Exception("a<b ou b<1");
            int r = a % b;
            int q = (a - r) / b;
            if (r == 1)
            {
                int[] tab = { r, -q };
                return tab;
            }
            else
            {
                int[] tab = algoEtendu(b, r);
        tab[0] = tab[0]-(q* tab[1]);
                int t = tab[0]; tab[0] = tab[1]; tab[1] = t;
                return tab;
            }
        }
    
        public static int inverse(int n, int m)
        {  
            return Euclide.algoEtendu(m, n)[1];
        }
    }
}