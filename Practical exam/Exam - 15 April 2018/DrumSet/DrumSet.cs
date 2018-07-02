using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumset = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var initialDrumset = drumset.ToList();
            string command = Console.ReadLine();
            while(command!= "Hit it again, Gabsy!")
            {
                double price = 0.0;
                int hitPower = int.Parse(command);
                for (int i = 0; i < drumset.Count; i++)
                {
                    drumset[i] -= hitPower;
                }
                for (int i = 0; i < drumset.Count; i++)
                {
                    if(drumset[i]<=0)
                    {
                        price = initialDrumset[i] * 3;
                        if(savings>=price)
                        {
                            drumset[i] = initialDrumset[i];
                            savings -= price;
                        }
                        else
                        {
                            drumset.RemoveAt(i);
                            initialDrumset.RemoveAt(i);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",drumset));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
