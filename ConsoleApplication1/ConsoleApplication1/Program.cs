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
}