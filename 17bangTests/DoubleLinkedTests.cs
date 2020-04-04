using ConsoleApp3;
using NUnit.Framework;

namespace _17bangTests
{
    public class DoubleLinkedTests
    {
        ConsoleApp3.DoubleLinkeds.DoubleLinked node1, node2, node3, node4, node5, node6;
        [SetUp]
        public void Setup()
        {
            node1 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node2 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node3 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node4 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node5 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node6 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node1.Value = 1;
            node2.Value = 2;
            node3.Value = 3;
            node4.Value = 4;
            node5.Value = 5;

            node2.InsretAfter(node1);
            node3.InsretAfter(node2);
            node4.InsretAfter(node3);
            node5.InsretAfter(node4);

        }

        [Test]
        public void FindByTest()
        {

        }

        [Test]
        public void SetupCorrectAfter()
        {
            Assert.IsTrue(node1.IsHead);
            Assert.IsNull(node1.Preivous);
            Assert.AreEqual(node1.Next, node2);

            Assert.AreEqual(node2.Next, node3);

            Assert.AreEqual(node3.Next, node4);

            Assert.AreEqual(node4.Next, node5);

            Assert.IsNull(node5.Next);

            Assert.IsTrue(node5.IsTail);
        }

        [Test]
        public void InsretAfterTest_Origin_2After5()
        {
            //1 2 3 4 5
            node2.InsretAfter(node5);
            //1 3 4 5 [2]

            Assert.IsNull(node1.Preivous);
            Assert.IsTrue(node1.IsHead);
            Assert.AreEqual(node1.Next, node3);

            Assert.IsTrue(node2.IsTail);
            Assert.IsNull(node2.Next);

            Assert.AreEqual(node3.Preivous, node1);
            Assert.AreEqual(node3.Next, node4);

            Assert.AreEqual(node4.Next, node5);

            Assert.AreEqual(node5.Next, node2);

        }

        [Test]
        public void InsretAfterTest_Origin_6After5()
        {
            node6.InsretAfter(node5);
            //1 2 3 4 5 [6] 
            Assert.IsNull(node1.Next);
            Assert.IsTrue(node1.IsHead);
            Assert.AreEqual(node1.Next, node2);

            Assert.AreEqual(node2.Next, node3);

            Assert.AreEqual(node3.Next, node4);

            Assert.AreEqual(node4.Next, node5);

            Assert.AreEqual(node5.Next, node6);
            Assert.AreEqual(node5.Preivous, node4);

            Assert.IsTrue(node6.IsTail);
            Assert.IsNull(node6.Next);

        }

        [Test]
        public void InsertBeforeTest_Origin_2Before5()
        {
            //1 2 3 4 5
            //1 3 4 2 5
            //1 3 4 [2] 5

        }

        [Test]
        public void DeleteTest()
        {

        }

        [Test]
        public void SwapTest()
        {
            //Assert.Fail();
        }
    }
}