using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.DoubleLinkeds
{
    public class DoubleLinked : IEnumerable
    {
        ///链表需求：
        ///怎么获取链表的长度
        ///怎样指定当前节点
        ///之前节点，之后节点
        ///查找节点的方法
        ///插入之前节点方法，之后节点方法
        ///删除节点方法
        ///判断链表是不是空的方法
        ///判断是否越界的方法
        ///交换两个节点位置的方法
        ///确定头和尾的属性
        ///黑窗口显示链表的方法
        ///链表的排序（时间顺序，大小顺序）
        ///判断插入的节点是不是尾和头

        /// <summary>
        /// 之前节点
        /// </summary>
        public DoubleLinked Preivous { get; private set; }

        /// <summary>
        /// 之后节点
        /// </summary>
        public DoubleLinked Next { get; private set; }

        public int? Value { get; set; }

        /// <summary>
        /// 头节点
        /// </summary>
        public bool IsHead
        {
            get => Preivous == null;
        }

        /// <summary>
        /// 尾节点
        /// </summary>
        public bool IsTail
        {
            get => Next == null;
        }

        /// <summary>
        /// 根据当前节点向上向下指定value的第一个链表节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public DoubleLinked FindBy(DoubleLinked node)
        {
            //向上找一次

            //向下找一次
            return null;
        }

        /// <summary>
        /// 在node之后插入当前节点 
        /// </summary>
        /// <param name="node">节点</param>
        public void InsretAfter(DoubleLinked node)
        {
            this.Delete();
            this.Preivous = node;
            if (node.Next == null)
            {
                node.Next = this;
            }
            else
            {
                this.Next = node.Next;
                this.Next.Preivous = this;
            }
        }
        /// <summary>
        /// 在node之前插入当前节点
        /// </summary>
        /// <param name="node"></param>
        public void InsertBefore(DoubleLinked node)
        {
            this.Delete();

            this.Next = node;
            if (node.Preivous == null)
            {
                node.Preivous = this;
            }
            else
            {
                this.Preivous = node.Preivous;
                this.Preivous.Next = this;
            }
        }

        /// <summary>
        /// 删除当前对象
        /// </summary>
        public void Delete()
        {
            DoubleLinked nodePreivous = Preivous;
            DoubleLinked nodeNext = Next;
            if (nodePreivous != null)
            {
                nodePreivous.Next = nodeNext;
            }// else do nothing
            if (nodeNext != null)
            {
                nodeNext.Preivous = nodePreivous;
            }// else do nothing
            Preivous = Next = null;
        }

        /// <summary>
        /// 交换两个值的位置
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Swap(DoubleLinked node)
        {

        }

        /// <summary>
        /// 通过计算获得长度
        /// </summary>
        /// <returns></returns>
        public void GetLingth(DoubleLinked DBLingth)
        {

        }

        /// <summary>
        /// 判断链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsNull()
        {
            if (Value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public struct NodEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
