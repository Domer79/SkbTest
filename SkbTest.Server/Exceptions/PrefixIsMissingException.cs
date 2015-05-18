using System;

namespace SkbTest.Server.Exceptions
{
    internal class PrefixIsMissingException : Exception
    {
        /// <summary>
        /// ��������� ������������� ������ ���������� ������ <see cref="T:System.Exception"/>, ��������� ��������� ��������� �� ������.
        /// </summary>
        /// <param name="message">���������, ����������� ������.</param>
        public PrefixIsMissingException() 
            : base("����������� �������")
        {
        }
    }
}