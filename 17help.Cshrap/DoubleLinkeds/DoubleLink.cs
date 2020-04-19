using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.DoubleLinkeds
{
    public class DoubleLink<T>
    {
        public DoubleLink<T> _next, _prev;
        public T Item;
        public DoubleLink()
        {
            _next = _prev = this;
        }
        internal DoubleLink(T item) : this()
        {
            this.Item = item;
        }
        internal DoubleLink<T> Next { get { return _next; } }
        internal DoubleLink<T> Preivous { get { return _prev; } }

        public void InsertAfter(DoubleLink<T> after)
        {
            this._prev = after;
            this._next = after._next;
            after._next = this;
            this._next._prev = this;
        }

        public void InsertBefore(DoubleLink<T> before)
        {
            this._prev = before._prev;
            this._next = before;
            before._prev = this;
            this._prev._next = this;
        }

        internal void Remove()
        {
            this._prev._next = this._next;
            this._next._prev = this._prev;
            _next = _prev = this;
        }
    }
}
