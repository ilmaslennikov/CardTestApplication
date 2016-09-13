using System;
using CardsApplication.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class CardSortingAlgorithmTest
    {
        [TestMethod]
        public void SortTestMethod()
        {
            var cardSortingAlgorithm = new CardSortingAlgorithm();
            var card0 = new Card
            {
                FromCity = "Париж",
                ToCity = "Осло"
            };
            var card1 = new Card
            {
                FromCity = "Мельбурн",
                ToCity = "Кельн"
            };
            var card2 = new Card
            {
                FromCity = "Москва",
                ToCity = "Париж"
            };
            var card3 = new Card
            {
                FromCity = "Кельн",
                ToCity = "Москва"
            };
            var actual = cardSortingAlgorithm.Sort(new[] { card0, card1, card2, card3 });
            CollectionAssert.AreEqual(new[] { card1, card3, card2, card0 }, actual);
        }

        [TestMethod]
        public void SortEmptyArrayTestMethod()
        {
            var cardSortingAlgorithm = new CardSortingAlgorithm();
            var actual = cardSortingAlgorithm.Sort(new Card[] { });
            CollectionAssert.AreEqual(new Card[] { }, actual);
        }

        [TestMethod]
        public void SortNullThrowsArgumentNullExceptionTestMethod()
        {
            var cardSortingAlgorithm = new CardSortingAlgorithm();
            try
            {
                cardSortingAlgorithm.Sort(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
            }
        }
    }
}