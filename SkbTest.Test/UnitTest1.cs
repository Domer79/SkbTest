using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using IntelliSenseHelper;
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

        [TestMethod]
        public void StackTest()
        {
            var stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('d');
            stack.Push('e');
            stack.Push('f');

            Debug.WriteLine(new string(stack.ToArray()));
        }

        [TestMethod]
        public void QueueTest()
        {
            var queue = new Queue<char>();
            queue.Enqueue('a');
            queue.Enqueue('b');
            queue.Enqueue('c');
            queue.Enqueue('d');
            queue.Enqueue('e');
            queue.Enqueue('f');

            Debug.WriteLine(new string(queue.ToArray()));
        }

        [TestMethod]
        public void LetterInfoAddTest()
        {
            LetterInfo.Add("abc", 10);
            LetterInfo.Add("abcc", 20);
        }
    }
}
