using System;

namespace IntelliSenseHelper.Exceptions
{
    public class DataReadImpossibleException : Exception
    {
        public DataReadImpossibleException()
            : base("���������� ��������� ������")
        {
            
        }

        public DataReadImpossibleException(string message)
            : base(message)
        {
            
        }
    }
}