using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Fill()
        {
            PageInput pageIn = new PageInput(Format.Fill, 5, 0, 0, new List<String>(new String[] { "abc", "abc" }));
            Page page = pageIn.Compose();
            String actual = page.ToString();
            Assert.AreEqual("abc\nabc\n", actual);
        }

        [TestMethod]
        public void FillSoft()
        {
            PageInput pageIn = new PageInput(Format.FillSoft, 10, 3, 0, new List<String>(new String[] { "abc", "abc", "abc", "abc", "abc", "abc", "abc", "abc" }));
            Page page = pageIn.Compose();         
            String actual = page.ToString();
            Assert.AreEqual("abc abc\nabc abc\nabc abc\nabc\nabc\n", actual);
        }

        [TestMethod]
        public void FillAdjust()
        {
            PageInput pageIn = new PageInput(Format.FillAdjust, 13, 0, 0, new List<String>(new String[] { "abc", "abc", "acei", "abc", "abc", "acei", "abc", "abc" }));
            Page page = pageIn.Compose();
            String actual = page.ToString();
            Assert.AreEqual("abc abc  acei\nabc abc  acei\nabc       abc\n", actual);
        }

        [TestMethod]
        public void LineMoment()
        {
            PageInput pageIn = new PageInput(Format.LineMoment, 14, 0, 7, new List<String>(new String[] { "abc", "abc", "acei", "abc", "abc", "acei", "abc", "abc", "abc", "ace", "ai" }));
            Page page = pageIn.Compose();
            String actual = page.ToString();
            Assert.AreEqual("abc abc acei\nabc abc acei\nabc  abc abc\nace       ai\n", actual);
        }

        [TestMethod]
        public void FillSet()
        {
            PageInput pageIn = new PageInput(Format.FillSet, 13, 0, 0, new List<String>(new String[] { "abc", "abc", "acei", "abc", "abc", "acei", "abc", "abc", "ace", "ai" }));
            Page page = pageIn.Compose();
            String actual = page.ToString();
            Assert.AreEqual("acei acei abc\nabc abc abc\nabc abc ace\nai\n", actual);
        }
    }
}
