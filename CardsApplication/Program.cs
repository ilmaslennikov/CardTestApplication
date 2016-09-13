using System;
using CardsApplication.Domain;

namespace CardsApplication
{
    static class Program
    {
        /// <summary>
        /// Cортирует и выводит маршрут поездки по карточкам начальных и конечных точек 
        /// </summary>
        /// <param name="args">
        /// Массив строк, каждая из которых разделяет пробелом пункт начала маршрута и окончания маршрута.
        /// </param>
        static void Main(string[] args)
        {
            var cards = new Card[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                var cities = arg.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (cities.Length != 2)
                {
                    Console.WriteLine(Properties.Resources.WrongNumberOfCitiesInAString, arg);
                    return;
                }
                cards[i] = new Card { FromCity = cities[0], ToCity = cities[1] };
            }
            var cardSortingAlgorithm = new CardSortingAlgorithm();
            var sortedCards = cardSortingAlgorithm.Sort(cards);
            Console.WriteLine(Properties.Resources.SortedRouteHeader);
            foreach (var card in sortedCards)
            {
                Console.WriteLine(Properties.Resources.CardOutputTemplate, card.FromCity, card.ToCity);
            }
        }
    }
}
