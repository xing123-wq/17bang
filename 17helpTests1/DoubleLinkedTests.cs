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

            Assert.IsNull(node2.Next);
            Assert.IsNull(node1.Next);
            Assert.IsNull(node3.Next);
            Assert.IsNull(node4.Next);
            //Assert.IsNull(node5.Next);
            Assert.IsNull(node1.Preivous);
            //Assert.IsNull(node2.Preivous);
            Assert.IsNull(node3.Preivous);
            Assert.IsNull(node4.Preivous);
            Assert.IsNull(node5.Preivous);

            Assert.AreEqual(node2.Preivous, node5);



        }

        [TestMethod()]
        public void InsretAfterTest_Origin_1After5()
        {
            ///1 2 3 4 5
            ///2 3 4 5 [1]


        }

        [TestMethod()]
        public void InsertBeforeTest_Origin_2Before5()
        {
            //1 2 3 4 5
            //1 3 4 2 5
            //1 3 4 [2] 5
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