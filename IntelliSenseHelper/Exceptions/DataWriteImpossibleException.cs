using System;

namespace IntelliSenseHelper.Exceptions
{
    public class DataWriteImpossibleException : Exception
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="T:System.Exception"/>.
        /// </summary>
        public DataWriteImpossibleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// ��������� ������������� ������ ���������� ������ <see cref="T:System.Exception"/>, ��������� ��������� ��������� �� ������.
        /// </summary>
        /// <param name="message">���������, ����������� ������.</param>
        public DataWriteImpossibleException() 
            : base("�� �������� ��������� ������")
        {
        }
    }
}