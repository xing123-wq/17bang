using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Global
{
    public class Pager
    {
        public Pager()
        {

        }

        public Pager(int index, int size)
        {
            Index = index;
            Size = size;
        }

        public int Index { get; set; }
        public int Size { get; set; }

        public int GetSumOfPage(int sumOfItems)
        {
            return (sumOfItems - 1) / Size + 1;
        }
    }
}