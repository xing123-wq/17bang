using ConsoleApp3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _17bangTests
{
    public class WordsTest
    {
        [Test]
        public void GetMaxTest()
        {
            stack<int> arrays = new stack<int>();
            stack<double> doubles = new stack<double>();
            double[] numbers = { 1, 3, 5, 7, 39, 40.6, 1000.33331, 1, 0.6666, 1000.3333 };
            int[] number = { 1, 3, 5, 7, 39, 40, 1 };
            Assert.AreEqual(40, arrays.GetMax(number));
            Assert.AreEqual(1000.33331, doubles.GetMax(numbers));
        }

    }
}
