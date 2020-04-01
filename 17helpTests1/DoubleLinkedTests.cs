using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class DoubleLinkedTests
    {
        DoubleLinked node1 = new DoubleLinked();
        DoubleLinked node2 = new DoubleLinked();
        DoubleLinked node3 = new DoubleLinked();
        DoubleLinked node4 = new DoubleLinked();
        DoubleLinked node5 = new DoubleLinked();

        [TestMethod()]
        public void FindByTest()
        {

        }


        [TestMethod()]
        public void InsretAfterTest_Origin_2After5()
        {
            //1 3 4 5 [2]
            node2.InsretAfter(node5);

            Assert.AreEqual(node5.Next, node2);

            Assert.AreEqual(node2.Next, null);
            Assert.AreEqual(node2.Preivous, node5);
        }

        [TestMethod()]
        public void InsretAfterTest_Origin_1After5()
        {
            ///1 2 3 4 5
            ///2 3 4 5 [1]
            node1.InsretAfter(node5);
            Assert.AreEqual(node5.Next, node1);

            Assert.AreEqual(node1.IsTail, node2);
            Assert.AreEqual(node2.Next,node3);
            Assert.AreEqual(node5.Preivous,node4);

            Assert.AreEqual(node4.Next,node5);
            Assert.AreEqual(node4.Preivous,node3);
        }

        [TestMethod()]
        public void InsertBeforeTest_Origin_2Before5()
        {
            //1 2 3 4 5
            //1 3 4 2 5
            //1 3 4 [2] 5
            node2.InsertBefore(node5);

            Assert.AreEqual(node5.Next, null);

            Assert.AreEqual(node2.Next, node5);
            Assert.AreEqual(node5.Preivous, node2);

            Assert.AreEqual(node2.Preivous, node4);
            Assert.AreEqual(node4.Next, node2);
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