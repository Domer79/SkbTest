using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkbTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringHashCodeTest()
        {
            Debug.WriteLine("a".GetHashCode());
            Debug.WriteLine("b".GetHashCode());
            Debug.WriteLine("c".GetHashCode());
            Debug.WriteLine("d".GetHashCode());
            Debug.WriteLine("e".GetHashCode());
            Debug.WriteLine("f".GetHashCode());
            Debug.WriteLine("g".GetHashCode());
            Debug.WriteLine("h".GetHashCode());
            Debug.WriteLine("i".GetHashCode());
            Debug.WriteLine("j".GetHashCode());
        }

        [TestMethod]
        public void CharToIntTest()
        {
            Debug.WriteLine(2^4);
        }
    }
}
