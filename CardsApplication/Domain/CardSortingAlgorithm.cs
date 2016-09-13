using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CardsApplication.Domain
{
    /// <summary>
    /// Представляет алгоритм сортировки карточки
    /// </summary>
    public class CardSortingAlgorithm
    {
        /// <summary>
        /// Отсортировать массив карточек
        /// </summary>
        /// <param name="cards">
        /// Входной массив карточек
        /// </param>
        /// <returns>
        /// Массив отсортированных карточек
        /// </returns>
        public Card[] Sort(Card[] cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException();
            }
            if (cards.Length == 0)
            {
                return new Card[] { };
            }
            Dictionary<string, Card> cardsFromDictionary = cards.ToDictionary(c => c.FromCity);
            Dictionary<string, Card> cardsToDictionary = cards.ToDictionary(c => c.ToCity);

            //Надо найти первую карточку, т.е. ту, у которой есть ключ в cardsFromDictionary, но нету ключа в cardsToDictionary
            Card firstCard = null;
            foreach (var cardFromPair in cardsFromDictionary)
            {
                if (!cardsToDictionary.ContainsKey(cardFromPair.Key))
                {
                    firstCard = cardFromPair.Value;
                }
            }

            if (firstCard == null)
            {
                throw new ArgumentException(Properties.Resources.RouteStartNotFound, "cards");
            }
            var result = new Card[cards.Length];
            result[0] = firstCard;
            for (int i = 1; i < result.Length; i++)
            {
                result[i] = cardsFromDictionary[result[i - 1].ToCity];
            }
            return result;
        }
    }
}
