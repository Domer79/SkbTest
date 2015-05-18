using System;

namespace IntelliSenseHelper.Exceptions
{
    public class DataReadImpossibleException : Exception
    {
        public DataReadImpossibleException()
            : base("Невозможно прочитать данные")
        {
            
        }

        public DataReadImpossibleException(string message)
            : base(message)
        {
            
        }
    }
}