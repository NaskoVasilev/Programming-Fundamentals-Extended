using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            int members = int.Parse(Console.ReadLine());
            double guitarPrice = double.Parse(Console.ReadLine());
            const int vocalist = 1;
            int guitars = (int)(Math.Floor(members / 3.00));   
            int drummers = members - vocalist - guitars;
            double drumPrice = guitarPrice * 1.5;
            double totalGuitarPrice = guitarPrice * guitars;
            double totalDrumPrice = drummers * drumPrice;
            double microphonePrice = totalDrumPrice - totalGuitarPrice;
            double rent = (totalDrumPrice + totalGuitarPrice + microphonePrice) / members;
            double rentForYear = rent * 12;
            double totalExpense = totalGuitarPrice + totalDrumPrice + microphonePrice + rentForYear;
            Console.WriteLine($"Total cost: {totalExpense:f2}lv.");
        }
    }
}
