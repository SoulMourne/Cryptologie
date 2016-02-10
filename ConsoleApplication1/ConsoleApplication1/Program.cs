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
            int[] message = {1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0 }; //message a chiffrer
            int[] cle = { 1, 1, 0 };    //cle de chiffrage
            int[] res = Vernam.chiffrer(message, cle);  //chiffrage du message
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i]);
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
}