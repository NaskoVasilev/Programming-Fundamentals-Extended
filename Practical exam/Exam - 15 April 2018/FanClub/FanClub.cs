using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> boys = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            while (command != "Make a decision already!")
            {
                string[] info = command.Split(' ');
                if (command.EndsWith("does Gyubek!"))
                {
                    string name = command.Substring(0, command.IndexOf(' '));

                    if (boys.ContainsKey(name))
                    {

                        if (boys[name].Values.Any(x => x > 0))
                        {
                            boys[name].Clear();
                        }
                    }
                }
                else
                {
                    string name = info[0];
                    string trait = info[1];
                    int value = int.Parse(info[2]);
                    if (!boys.ContainsKey(name))
                    {
                        Dictionary<string, int> current = new Dictionary<string, int>();
                        int newValue = GetChange(trait, value);
                        current.Add(trait, newValue);
                        boys.Add(name, current);
                    }
                    else
                    {
                        if (!boys[name].ContainsKey(trait))
                        {
                            int newValue = GetChange(trait, value);
                            boys[name].Add(trait, newValue);
                        }
                        else
                        {
                            if (boys[name][trait] < value)
                            {
                                boys[name][trait] = GetChange(trait, value);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }
            foreach (var pair in boys.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine("# {0}: {1}", pair.Key, pair.Value.Values.Sum());
                foreach (var item in pair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("!!! {0} -> {1}", item.Key, item.Value);
                }
            }
            Console.WriteLine();
        }
        static int GetChange(string trait, int value)
        {
            switch (trait)
            {
                case "Greedy":
                case "Rude":
                case "Dumb": value *= -1; break;
                case "Kind": value *= 2; break;
                case "Handsome": value *= 3; break;
                case "Smart": value *= 5; break;
            }
            return value;
        }
    }
}
