using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class DoubleLinkedTests
    {
        [TestMethod()]
        public void FindByTest()
        {

        }

        [TestMethod()]
        public void InsretAfterTest()
        {
            DoubleLinked node = new DoubleLinked();
            DoubleLinked current = new DoubleLinked();
            Assert.AreEqual(node.Next, current.Preivous);
            Assert.AreEqual(node.Preivous, current.Next);
            Assert.AreEqual(current.Next, node.Preivous);
            Assert.AreEqual(current.Preivous, node.Next);
            Assert.AreEqual(current.IsHead, node.IsTail);
            DoubleLinked _current = new DoubleLinked();
            DoubleLinked current1 = new DoubleLinked();
            Assert.AreEqual(_current.Next, current1.Preivous);
            Assert.AreEqual(_current.IsHead, current1.IsTail);
            Assert.AreEqual(current1.IsHead, _current.IsTail);
            Assert.AreEqual(_current.IsHead, current.IsTail);
            Assert.AreEqual(current.Next, _current.Preivous);
        }

        [TestMethod()]
        public void InsertBeforeTest()
        {
            DoubleLinked node = new DoubleLinked();
            DoubleLinked current = new DoubleLinked();
            Assert.AreEqual(node.Next, current.Preivous);
            Assert.AreEqual(node.Preivous, current.Next);
            Assert.AreEqual(current.Next, node.Preivous);
            Assert.AreEqual(current.Preivous, node.Next);
            Assert.AreEqual(current.IsHead, node.IsTail);
            DoubleLinked _current = new DoubleLinked();
            Assert.AreEqual(_current.IsHead, current.IsTail);
            Assert.AreEqual(current.Next, _current.Preivous);
            Assert.AreEqual(_current.Preivous, current.Next);
            DoubleLinked current1 = new DoubleLinked();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void SwapTest()
        {
            //Assert.Fail();
        }
    }
}