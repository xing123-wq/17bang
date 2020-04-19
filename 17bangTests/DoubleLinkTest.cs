using ConsoleApp3.DoubleLinkeds;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _17bangTests
{
    class DoubleLinkTest
    {
        DoubleLinkList node0, node1, node2, node3, node4, node5, node6;
        [SetUp]
        public void SetUp()
        {
            node0 = new DoubleLinkList { Item = 0 };
            node1 = new DoubleLinkList { Item = 1 };
            node2 = new DoubleLinkList { Item = 2 };
            node3 = new DoubleLinkList { Item = 3 };
            node4 = new DoubleLinkList { Item = 4 };
            node5 = new DoubleLinkList { Item = 5 };
            node6 = new DoubleLinkList { Item = 6 };

            //node1.InsertAfter(node0);
            node2.InsertAfter(node1);
            node3.InsertAfter(node2);
            node4.InsertAfter(node3);
            node5.InsertAfter(node4);
        }
        [Test]
        public void SetupCorrectAfter()
        {
            Assert.AreEqual(node1._prev, node5);
            Assert.AreEqual(node1._next, node2);

            Assert.AreEqual(node2._prev, node1);
            Assert.AreEqual(node2._next, node3);

            Assert.AreEqual(node3._prev, node2);
            Assert.AreEqual(node3._next, node4);

            Assert.AreEqual(node4._prev, node3);
            Assert.AreEqual(node4._next, node5);

            Assert.AreEqual(node5._prev, node4);
            Assert.AreEqual(node5._next, node1);
        }
        [Test]
        public void InsertAfterTest_2and5()
        {
            node2.InsertAfter(node5);
            //1 2 3 4 5
            //1 3 4 5 [2]
            Assert.AreEqual(node1._prev, node2);
            //Assert.AreEqual(node1._next, node3);

            //Assert.AreEqual(node3._prev, node1);
            Assert.AreEqual(node3._next, node4);

            Assert.AreEqual(node4._prev, node3);
            Assert.AreEqual(node4._next, node5);

            Assert.AreEqual(node5._prev, node4);
            Assert.AreEqual(node5._next, node2);

            Assert.AreEqual(node2._prev, node5);
            Assert.AreEqual(node2._next, node1);
        }
    }
}
