using System;

namespace IntelliSenseHelper.Exceptions
{
    public class DataWriteImpossibleException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Exception"/>.
        /// </summary>
        public DataWriteImpossibleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Выполняет инициализацию нового экземпляра класса <see cref="T:System.Exception"/>, используя указанное сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public DataWriteImpossibleException() 
            : base("Не возможно отправить данные")
        {
        }
    }
}