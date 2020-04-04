using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class stack<T> where T : IComparable
    {
        T[] StackArray;
        int StackPointer = 0;

        public void Push(T x)
        {
            if (!IsStackFull)
                StackArray[StackPointer++] = x;
        }

        public T Pop()
        {
            return (!IsStackEmpty)
                ? StackArray[++StackPointer]
                : StackArray[0];
        }

        const int MaxStack = 10;
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        bool IsStackEmpty { get { return StackPointer <= 0; } }

        public stack()
        {
            StackArray = new T[MaxStack];
        }

        public void Print()
        {
            for (int i = StackPointer - 1; i >= 0; i--)
            {
                Console.WriteLine("Value:{0}", StackArray[i]);
            }
        }
        public T GetMax(T[] array)
        {
            T max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max.CompareTo(array[i]) < 0)
                {
                    max = array[i];
                }
            }
            Console.WriteLine(max);
            return max;
        }
    }
}
