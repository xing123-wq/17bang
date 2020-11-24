using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class DataStucture<T> where T : IMyCompare<T>
    {

        /// <summary>
        /// 二分查找While循环实现
        /// </summary>
        /// <param name="nums">数组</param>         
        /// <param name="low">开始索引</param>
        /// <param name="high">结束索引</param>
        /// <param name="target">要查找的对象</param>      
        /// <returns>返回索引</returns>
        public static int BinaryWhile(IList<T> nums, T target)
        {
            int low = 0;
            int high = nums.Count - 1;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (target.CompareTo(nums[middle]) == 0)
                {
                    Console.WriteLine(middle);
                    return middle;
                }
                else if (nums[middle].CompareTo(target) > 0)
                {
                    low = middle + 1;
                }
                else if (nums[middle].CompareTo(target) < 0)
                {
                    high = middle - 1;
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
