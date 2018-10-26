using System;
using System.Collections.Generic;
using System.Linq;

namespace Tangram
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StartTangramProject();
        }

        private static void StartTangramProject()
        {
            string input = Console.ReadLine();

            var dataInfo = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                string[] tokens = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] != "ban")
                {
                    string name = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);
                    //
                    PutDataInDictionary(dataInfo, name, tag, likes);
                }
                else
                {
                    BanUser(dataInfo, tokens);
                }
                input = Console.ReadLine();
            }
            Print(dataInfo);
        }

        private static void BanUser(Dictionary<string, Dictionary<string, int>> dataInfo, string[] tokens)
        {
            string name = tokens[1];
            if (dataInfo.ContainsKey(name))
            {
                dataInfo.Remove(name);
            }
        }

        private static void PutDataInDictionary(Dictionary<string, Dictionary<string, int>> dataInfo, string name, string tag, int likes)
        {
            if (!dataInfo.ContainsKey(name))
            {
                dataInfo.Add(name, new Dictionary<string, int>());
            }
            if (!dataInfo[name].ContainsKey(tag))
            {
                dataInfo[name].Add(tag, likes);
            }
            dataInfo[name][tag] = likes;
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> dataInfo)
        {
            foreach (var item in dataInfo.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(c => c.Value.Count))
            {
                Console.WriteLine(item.Key);
                foreach (var i in item.Value)
                {
                    Console.WriteLine($"- {i.Key}: {i.Value}");
                }
            }
        }
    }
}
