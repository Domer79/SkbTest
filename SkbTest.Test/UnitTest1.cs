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
        public void LetterInfoAddTest()
        {
            LetterInfo.Add("abc", 10);
            LetterInfo.Add("abcc", 20);
        }
    }
}
