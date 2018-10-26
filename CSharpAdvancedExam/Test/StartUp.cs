using System;
using System.Text.RegularExpressions;

namespace Test
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var name = "PeshoGoshoGergiKakin repablican".ToCharArray();
            var sum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                sum += Convert.ToInt32(name[i]);
               
            }

            Console.WriteLine(sum);
        }
        private static string GetDataM(Match item, string message)
        {
            foreach (var it in item.Groups[3].Value.ToString())
            {
                for (int j = 0; j < it.ToString().Length; j++)
                {
                    if (Char.IsLetter(it) || it == ' ')
                    {
                        message += it;
                    }
                }
            }
            return message;
        }

        private static string GetDataR(Match item, string recieverP)
        {
            foreach (var it in item.Groups[2].Value.ToString())
            {
                for (int j = 0; j < it.ToString().Length; j++)
                {
                    if (Char.IsLetter(it) || it == ' ')
                    {
                        recieverP += it;
                    }
                }
            }

            return recieverP;
        }

        private static string GetDataS(Match item, string senderP)
        {
            foreach (var it in item.Groups[1].Value.ToString())
            {
                for (int p = 0; p < it.ToString().Length; p++)
                {
                    if (Char.IsLetter(it) || it == ' ')
                    {
                        senderP += it;
                    }
                }
            }

            return senderP;
        }


    }
}
