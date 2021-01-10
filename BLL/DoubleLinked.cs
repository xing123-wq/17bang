using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDoubleLinked<T> where T : IDoubleLinked<T>
    {
        T Previous { get; set; }
        T Next { get; set; }
    }

    public class DLTookit<T> where T : IDoubleLinked<T>
    {
        private T _previous, _next, _current;
        public DLTookit(T current)
        {
            _current = current;
            _previous = current.Previous;
            _next = current.Next;
        }

        public bool IsHead(T node) => node.Previous == null;
        public bool IsTail(T node) => node.Next == null;

        /// <summary>
        /// 只移动这一个节点，不影响其他节点
        /// </summary>
        /// <param name="node"></param>
        public void InsertAfter(T node)
        {
            if (_current.Equals(node))
            {
                throw new ArgumentException("不能将自己插入自己后面");
            }

            Delete();

            if (node == null)
            {
                return;
            }

            _current.Previous = node;
            _current.Next = node.Next;
            node.Next = _current;
            if (_current.Next != null)
            {
                _current.Next.Previous = _current;
            }
        }

        /// <summary>
        /// 连接两条链表，只能是表头连接表尾
        /// </summary>
        /// <param name="node"></param>
        public void JoinAfter(T node)
        {
            if (node == null)
            {
                throw new ArgumentException("不能Join到Null之后");
            }
            if (!IsHead(_current))
            {
                throw new ArgumentException("当前node不是链表头");
            }
            if (!IsTail(node))
            {
                throw new ArgumentException("要Join的node不是链表尾");
            }
            node.Next = this._current;
            this._current.Previous = node;
        }

        public void Delete()
        {
            if (_previous != null)
            {
                _previous.Next = _current.Next;
            }
            if (_next != null)
            {
                _next.Previous = _current.Previous;
            }

            _current.Next = default(T);
            _current.Previous = default(T);
        }

        public DLPage<T> Get(Sort sort, MoveDirection direction, int amount)
        {
            bool desc = sort == Sort.Desc;
            bool forward = direction == MoveDirection.Forward;

            DLPage<T> model = new DLPage<T> { Items = new List<T>() };
            T starter = _current;
            model.Items.Add(starter);
            for (int i = 1; i < amount; i++)
            {
                if ((desc && forward) || (!desc && !forward))
                {
                    starter = starter.Previous;
                }
                else /*if ((desc && !forward) || (!desc && forward))*/
                {
                    starter = starter.Next;
                }

                if (starter == null)
                {
                    break;
                }//else nothing

                model.Items.Add(starter);
            }
            if (!forward)
            {
                model.Items = model.Items.Reverse().ToList();
            }//else nothing

            T first = model.Items.First();
            T last = model.Items.Last();
            model.Prepage = desc ? first.Next : first.Previous;
            model.Nextpage = desc ? last.Previous : last.Next;

            return model;
        }
    }

    public class DLPage<T> where T : IDoubleLinked<T>
    {
        public IList<T> Items { get; set; }
        public T Prepage { get; set; }
        public T Nextpage { get; set; }
    }
}
