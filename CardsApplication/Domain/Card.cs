using System;


namespace CardsApplication.Domain
{
    /// <summary>
    ///     Карточка путешествия
    /// </summary>
    public class Card
    {
        /// <summary>
        ///     Город отправления
        /// </summary>
        public string FromCity { get; set; }

        /// <summary>
        ///     Город назначения
        /// </summary>
        public string ToCity { get; set; }
    }
}