using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Stack<T> : IComparable
    {
        private string[] _container;
        private int top { get; set; }
        public Stack(int length)
        {
            _container = new string[length];
        }
        public void Push(string[] element)
        {
            for (int i = 0; i < element.Length; i++)
            {
                if (top >= _container.Length)
                {
                    Console.WriteLine("栈满了,挤不进去了");
                }
                else
                {
                    //do nothing
                }
            }
        }
        public string Pop()
        {
            if (_container[0] == null)
            {
                Console.WriteLine("栈空了,弹不出去");
            }
            else
            {
                for (int i = (_container.Length); i >= 0; i++)
                {
                    if (_container[i] != null)
                    {
                        _container[i] = null;
                        Console.WriteLine("弹出去了一个");
                        break;
                    }
                }
            }
            return _container[top];
        }
        public void Output(string[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != null)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        //public T[] GetMax(T[] score)
        //{
        //    Console.WriteLine("\nSeek Max：");
        //    T max = score[0];
        //    for (int i = 0; i < score.Length; i++)
        //    {
        //        if (max < score[i])
        //        {
        //            max = score[i];
        //        }
        //    }
        //    Console.WriteLine(max);
        //    return score;
        //}
    }
}
