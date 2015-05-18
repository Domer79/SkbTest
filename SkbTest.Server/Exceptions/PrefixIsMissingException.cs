using System;

namespace SkbTest.Server.Exceptions
{
    internal class PrefixIsMissingException : Exception
    {
        /// <summary>
        /// ¬ыполн€ет инициализацию нового экземпл€ра класса <see cref="T:System.Exception"/>, использу€ указанное сообщение об ошибке.
        /// </summary>
        /// <param name="message">—ообщение, описывающее ошибку.</param>
        public PrefixIsMissingException() 
            : base("ќтсутствует префикс")
        {
        }
    }
}