using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;

namespace ConsoleApp3.DoubleLinkeds
{
    class DoubleLinkList : DoubleLink<Object>
    {
        internal DoubleLinkList()
        {
        }

        internal bool IsEmpty()
        {
            return _next == this;
        }

        internal virtual void InsertHead(DoubleLink<object> entry)
        {
            entry.InsertAfter(this);
        }
        internal virtual void InsertTail(DoubleLink<object> entry)
        {
            entry.InsertBefore(this);
        }

        public DoubleLinkListEnumerator GetEnumerator()
        {
            return new DoubleLinkListEnumerator(this);
        }
        public int Length
        {
            get
            {
                DoubleLinkListEnumerator lenum;
                int c = 0;
                lenum = GetEnumerator();
                while (lenum.MoveNext())
                {
                    c++;
                }

                return c;
            }
        }
    }
}
