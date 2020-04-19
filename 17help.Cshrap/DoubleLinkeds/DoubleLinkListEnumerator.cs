using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.DoubleLinkeds
{
    public class DoubleLinkListEnumerator : IEnumerator
    {
        private DoubleLinkList _list;
        private DoubleLink<object> _current;

        public DoubleLinkListEnumerator(DoubleLinkList list)
        {
            _list = list;
            _current = list;
        }

        public void Reset()
        {
            _current = _list;
        }

        public bool MoveNext()
        {
            if (_current.Next == _list)
            {
                _current._prev = null;
                return false;
            }
            _current = _current.Next;
            return true;
        }

        public object Current
        {
            get
            {
                if (_current == null || _current == _list)
                    throw new InvalidOperationException();
                return _current.Item;
            }
        }

        internal DoubleLink<object> GetDoubleLink()
        {
            return _current;
        }
    }
}

