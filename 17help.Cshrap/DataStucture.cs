using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class DataStucture<T> where T : IMyCompare<T>
    {
        public static int binarySeek(IList<T> array, T Key)
        {
            int low = 0;
            int high = array.Count-1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid].CompareTo(Key) < 0)
                {
                    low = mid + 1;
                }
                else if (array[mid].CompareTo(Key) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    Console.WriteLine(mid);
                    return mid;
                }
            }
            Console.WriteLine("没有找到该对象！");
            return -1;
        }
    }
    public interface IMyCompare<T> : IComparable<T>
    {

    }
}
