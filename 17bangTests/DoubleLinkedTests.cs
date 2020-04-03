using ConsoleApp3;
using NUnit.Framework;

namespace _17bangTests
{
    public class DoubleLinkedTests
    {
        ConsoleApp3.DoubleLinkeds.DoubleLinked node1, node2, node3, node4, node5;
        [SetUp]
        public void Setup()
        {
            node1 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node2 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node3 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node4 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            node5 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();

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
        public void SetupCorrect()
        {
            Assert.IsNull(node1.Preivous);

            Assert.AreEqual(node1.Next,node2);

            Assert.AreEqual(node2.Next,node3);
            
            Assert.AreEqual(node3.Next,node4);
            
            Assert.AreEqual(node4.Next,node5);
            
            Assert.IsNull(node5.Next);
        }

        [Test]
        public void InsretAfterTest_Origin_2After5()
        {
            //1 3 4 5 [2]
            node2.InsretAfter(node5);

            Assert.AreEqual(node1.Next,node3);
            Assert.IsNull(node1.Preivous);

            Assert.AreEqual(node3.Next,node4);

            Assert.AreEqual(node4.Next,node5);

            Assert.AreEqual(node5.Next,node2);

            Assert.AreEqual(node2.Next, node3) ;

        }

        [Test]
        public void InsretAfterTest_Origin_1After5()
        {
            ///1 2 3 4 5
            ///2 3 4 5 [1]


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
            //Assert.Fail();
        }

        [Test]
        public void SwapTest()
        {
            //Assert.Fail();
        }
    }
}