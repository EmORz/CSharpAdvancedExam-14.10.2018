using System;
using System.Text.RegularExpressions;

namespace DataTransfer
{
    class Start
    {
        static void Main(string[] args)
        {
            StartProject();
        }

        private static void StartProject()
        {
            string newPattern = @"s\:([^\;]+)\;r\:([^\;]+)\;m--""([A-Za-z ]+)""";

            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < num; i++)
            {
                string inputStr = Console.ReadLine();
                MatchCollection match = Regex.Matches(inputStr, newPattern);

                foreach (Match item in match)
                {
                    var senderP = "";
                    var recieverP = "";
                    var message = "";
                    senderP = GetData(item.Groups[1].Value);
                    recieverP = GetData(item.Groups[2].Value);
                    message = GetData(item.Groups[3].Value);
                    string allDigitsFrom = item.Groups[1].Value.ToString() + item.Groups[2].Value.ToString();
                    sum += IsDigit(allDigitsFrom);
                    Console.WriteLine($"{senderP} says \"{message}\" to {recieverP}");
                }
            }
            int total = sum;
            Console.WriteLine($"Total data transferred: {total}MB");
        }

        private static int IsDigit(string value1)
        {
            int sum = 0;
            string word = value1;
            foreach (var it in word)
            {
                if (Char.IsDigit(it))
                {
                    sum += Convert.ToInt32(it.ToString());
                }
            }
            return sum;
        }

        private static string GetData(string word)
        {
            string info = "";
            foreach (var it in word)
            {                
                if (Char.IsLetter(it) || it == ' ')
                {
                    info += it;
                }                
            }
    
            return info;
        }
    }
}
