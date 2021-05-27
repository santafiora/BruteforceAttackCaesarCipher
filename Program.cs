using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteforceAttackCaesarCipher
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte geben Sie ein verschlüsseltes Wort ein, ich werde versuchen es zu knacken ;-)");
            string verschluesseltenTextKnacken = Console.ReadLine().ToLower();

            BruteforceAttackCaesarCipher(verschluesseltenTextKnacken);
            Console.ReadKey();
        }

        /// <summary>
        /// Die Zeichenlänge könnte man in einem Char aus Alphabet Array prüfen!
        /// Die Zeichen kommen ja aus einem Zeichensatz "Unicode-Zeichen" deshalb die -97 / +97
        /// </summary>
        /// <param name="CipherText"></param>
        static public void BruteforceAttackCaesarCipher(string CipherText)

        {
            string BruteforceText = CipherText;
            char[] characterCipher = BruteforceText.ToCharArray();

            char chr;
            for (int key = 0; key < 26; key++)
            {
                string Klartext = Decryption(characterCipher, key);


                Console.WriteLine("Wenn der Schlüssel = " + key + " wäre \t " + " biete ich als Beispiel folgende Variante an: \t:  " + Klartext);
            }
        }
        static public string Decryption(char[] vsecretMessage, int vkey)
        {

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            string verschluesselteNachricht = "";


            for (int i = 0; i < vsecretMessage.Length; i++)
            {
                char c = vsecretMessage[i];

                if (alphabet.Contains(c))
                {
                    int position = Array.IndexOf(alphabet, c);
                    int position_new = position - vkey;
                    int rest = position_new % 26;
                    verschluesselteNachricht += alphabet[rest];
                }
                else
                {
                    verschluesselteNachricht += c;
                }
            }

            return verschluesselteNachricht;
        }
    }
}