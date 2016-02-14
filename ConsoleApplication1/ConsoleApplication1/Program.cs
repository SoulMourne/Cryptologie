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
            Console.WriteLine("\n--Décomposition primaire de 54--\n");
            Dictionary<int, int> resultat = Primaire.decompose_primaire(54);
            Dictionary<int, int>.KeyCollection cles= resultat.Keys;
            foreach(int valeur in cles)
            {
                Console.WriteLine(valeur + "^" + resultat[valeur] + "*");
            }
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

    public class Primaire
    {
        public static bool[] crible(int n)
        {
            int max = (int)Math.Sqrt(n);
            bool[] crible = new bool[n];
            for (int i = 0; i < n; i++)
                crible[i] = true;

            for (int i = 2; i <= max; i++)
            {
                if (crible[i])
                    for (int j = 2; j < n; j++)
                    {
                        Console.WriteLine(i + "*" + j);
                        if (i * j < crible.Length)
                            crible[i * j] = false;
                    }
                // System.out.println("------\nA : "+n+"\nB : "+i+"\nQ : "+q);
            }
            crible[0] = false;
            crible[1] = false;
            return crible;
        }

        public static Dictionary<int, int> decompose_primaire(int n)
        {
            Dictionary<int, int> retour = new Dictionary<int,int>();
            int i = 2;
            while (i <= n)
            {
                if (n % i == 0)
                {
                    if (retour.ContainsKey(i))
                    {
                        try
                        {
                            retour[i]++;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                        retour.Add(i, 1);
                    n /= i;
                    i = 1;
                }
                i++;
            }
            return retour;
        }

        public static int euler(int n)
        {
            Dictionary<int,int> decompPrime = Primaire.decompose_primaire(n);
            int resultat = 1;
            Dictionary<int,int>.KeyCollection cles = decompPrime.Keys;
            foreach (int valeur in cles)
            {
                int power = decompPrime[valeur];
                resultat *= (int)(Math.Pow((int)valeur, (int)power) - Math.Pow((int)valeur, (int)power - 1));
            }
            return resultat;
        }
    }
}