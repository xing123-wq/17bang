using ConsoleApp3;
using ConsoleApp3.DoubleLinkeds;
using NUnit.Framework;

namespace _17bangTests
{
    public class DoubleLinkedTests
    {
        DoubleLinked node1, node2, node3, node4, node5, node6;
        [SetUp]
        public void Setup()
        {
            node1 = new DoubleLinked();
            node2 = new DoubleLinked();
            node3 = new DoubleLinked();
            node4 = new DoubleLinked();
            node5 = new DoubleLinked();
            node6 = new DoubleLinked();

            node1.Value = 1;
            node2.Value = 2;
            node3.Value = 3;
            node4.Value = 4;
            node5.Value = 5;
            node6.Value = 6;

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
            Assert.IsNull(node1.Preivous);
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
            //1 3 4 [2] 5
            node2.InsertBefore(node5);

            Assert.IsTrue(node1.IsHead);
            Assert.IsNull(node1.Preivous);
            Assert.AreEqual(node1.Next, node3);

            Assert.AreEqual(node3.Preivous, node1);
            Assert.AreEqual(node3.Next, node4);

            Assert.AreEqual(node4.Preivous, node3);
            Assert.AreEqual(node4.Next, node2);

            Assert.AreEqual(node2.Preivous, node4);
            Assert.AreEqual(node2.Next, node5);

            Assert.IsTrue(node5.IsTail);
            Assert.AreEqual(node5.Preivous, node2);
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void DeleteTest_delete_3()
        {
            //1 2 [3] 4 5
            node3.Delete();
            Assert.IsTrue(node1.IsHead);
            Assert.IsNull(node1.Preivous);
            Assert.AreEqual(node1.Next, node2);

            Assert.AreEqual(node2.Preivous, node1);
            Assert.AreEqual(node2.Next, node4);

            Assert.AreEqual(node4.Preivous, node2);
            Assert.AreEqual(node4.Next, node5);

            Assert.IsTrue(node5.IsTail);
            Assert.AreEqual(node5.Preivous, node4);
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void DeleteTest_delete_3and2()
        {
            //1 2 [3] 4 5
            node3.Delete();
            //1 [2] 4 5
            node2.Delete();
            Assert.IsTrue(node1.IsHead);
            Assert.IsNull(node1.Preivous);
            Assert.AreEqual(node1.Next, node4);

            Assert.AreEqual(node4.Preivous, node1);
            Assert.AreEqual(node4.Next, node5);

            Assert.IsTrue(node5.IsTail);
            Assert.AreEqual(node5.Preivous, node4);
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void DeleteTest_delete_3and2and1()
        {
            //1 2 [3] 4 5
            node3.Delete();
            //1 [2] 4 5
            node2.Delete();
            //[1] 4 5
            node1.Delete();

            Assert.IsTrue(node4.IsHead);
            Assert.IsNull(node4.Preivous);
            Assert.AreEqual(node4.Next, node5);

            Assert.IsTrue(node5.IsTail);
            Assert.AreEqual(node5.Preivous, node4);
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void DeleteTest_delete_3and2and1and4()
        {
            //1 2 [3] 4 5
            node3.Delete();
            //1 [2] 4 5
            node2.Delete();
            //[1] 4 5
            node1.Delete();
            //[4] 5
            node4.Delete();

            Assert.IsTrue(node5.IsHead);
            Assert.IsTrue(node5.IsTail);
            Assert.IsNull(node5.Next);
            Assert.IsNull(node5.Preivous);
        }

        [Test]
        public void DeleteTest_delete_3and2and1and4and5()
        {
            //1 2 [3] 4 5
            node3.Delete();
            //1 [2] 4 5
            node2.Delete();
            //[1] 4 5
            node1.Delete();
            //[4] 5
            node4.Delete();
            //[5]
            node5.Delete();

            Assert.IsNull(node5.Preivous) ;
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void SwapTest()
        {
            //1 2 3 4 5
            //1 [2] 3 4 [5]
            //1 [5] 3 4 [2]
            //node2.Swap(node5);
            //Assert.AreEqual(node1.Next, node5);
        }
    }
}