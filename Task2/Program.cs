using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sales> salesCollection = new List<Sales>
            {
                new Sales(1, "Katya", 2510m, "comment"),
                new Sales(2, "Katya", 500m, "comment"),
                new Sales(3, "Katya", 750m, "comment"),
                new Sales(4, "Katya", 12000m, "comment"),
                new Sales(5, "Katya", 120m, "comment"),

                new Sales(6, "Alina", 150m, "comment"),
                new Sales(7, "Alina", 200m, "comment"),
                new Sales(8, "Alina", 180m, "comment"),
                new Sales(9, "Alina", 2500m, "comment"),
                new Sales(10, "Alina", 32000m, "comment"),

                new Sales(11, "Maksim", 3000m, "comment"),
                new Sales(12, "Maksim", 950m, "comment"),
                new Sales(13, "Maksim", 1100m, "comment"),
                new Sales(14, "Maksim", 6700m, "comment"),
                new Sales(15, "Maksim", 145m, "comment"),
                new Sales(16, "Maksim", 82m, "comment"),

                new Sales(17, "Alina", 800m, ""),
                new Sales(18, "Katya", 1300m, "  "),
                new Sales(19, "Katya", 33m, ""),
                new Sales(20, "Alina", 120m, null),
                new Sales(21, "Maksim", 7800m, "   ")
            };
            Dictionary<decimal, decimal> saleBonuses = new Dictionary<decimal, decimal>();
            for (int i = 0; i < salesCollection.Count; i++)
            {
                saleBonuses.Add(salesCollection[i].saleId, salesCollection[i].price * 0.01m);
            }

            bonusAdjust(salesCollection, saleBonuses);
            premiumBonus(salesCollection, saleBonuses);

            Dictionary<string, decimal> managerBonus = new Dictionary<string, decimal>();
            foreach (var sale in salesCollection)
            {
                if (!managerBonus.ContainsKey(sale.salesManager))
                {
                    managerBonus.Add(sale.salesManager, saleBonuses[sale.saleId]);
                }
                else
                {
                    managerBonus[sale.salesManager] += saleBonuses[sale.saleId];
                }
            }    
            
            foreach (var pair in managerBonus)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            //foreach (var sale in sortedSalesCollection)
            //{
            //    Console.Write($"{sale.Key} - ");
            //    Console.WriteLine($"{Decimal.Round(sale.Sum(x => x.bonus))}");
            //}
        }

        public static Dictionary<decimal, decimal> bonusAdjust(List<Sales> collection, Dictionary<decimal, decimal> bonuses)
        {
            foreach (var sale in collection)
            {
                if (string.IsNullOrWhiteSpace(sale.comment))
                {
                    bonuses[sale.saleId] = sale.price * 0.005m;
                    //sale.bonus = sale.price * 0.005m;
                }
            }
            return bonuses;
        }

        public static Dictionary<decimal, decimal> premiumBonus(List<Sales> collection, Dictionary<decimal, decimal> bonuses)
        {
            int counter = collection.Count(x => !string.IsNullOrWhiteSpace(x.comment));
            if (counter > 15)
            {
                for(int i = 0; i < collection.Count; i++)
                {
                    bonuses[collection[i].saleId] += collection[i].price * 0.004m;
                }
                //collection.ForEach(x => x.bonus += x.price * 0.004m);
            }
            return bonuses;
        }
    }
}
