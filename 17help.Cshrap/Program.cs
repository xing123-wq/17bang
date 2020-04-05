using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using ConsoleApp3;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //User newbie = new User("");
            //User not = new User();
            //Program a = new Program();
            //HelpMoney b = new HelpMoney();
            //new User().Reward = -1;
            ////作者积分
            //Problem Release = new Problem("1");
            //Release.Author = new User("阿泰");
            //Release.Publish();
            //Content ad = new Problem("1");
            //Problem p = new Problem();
            //new ContentService().Publish(p);
            //new DBMessage().send();
            //new EmailMessage().send();

            //StudentInformation atai = new StudentInformation();
            //atai.score = 98;
            //StudentInformation wx = atai;
            //Console.WriteLine(wx.score);
            //atai.score = 100;
            //Console.WriteLine(wx.score);

            //GetWeeks(2019/1/1);
            //Student s = new Student();
            //s.Information();

            //Problem keyword = new Problem();
            //Console.WriteLine(keyword[1]);

            //LinqWork.Do();

            //XML.Do();

            //Repoistory.Do();

            //new Student().Delete();

            //Random random = new Random();
            //int[] a = new int[10];
            //for (int i = 0; i < a.Length; i++)
            //{
            //    a[i] = random.Next(1, 100);
            //}
            //getmax(a);
            //ConsoleApp3.DoubleLinkeds.DoubleLinked node1, node2, node3, node4, node5, node6;

            //node1 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            //node2 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            //node3 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            //node4 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            //node5 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();
            //node6 = new ConsoleApp3.DoubleLinkeds.DoubleLinked();

            //node1.Value = 1;
            //node2.Value = 2;
            //node3.Value = 3;
            //node4.Value = 4;
            //node5.Value = 5;
            //node6.Value = 6;

            //node2.InsretAfter(node1);
            //node3.InsretAfter(node2);
            //node4.InsretAfter(node3);
            //node5.InsretAfter(node4);
            //node6.InsretAfter(node2);

            //stack<int> StackInt = new stack<int>();
            //stack<string> StackString = new stack<string>();

            //StackInt.Push(3);
            //StackInt.Push(5);
            //StackInt.Push(7);
            //StackInt.Push(9);
            //StackInt.Print();

            //StackString.Push("This is a stack");
            //StackString.Push("Hello World!");
            //StackString.Print();

            //Console.ReadLine();

            

        }
        static int getmax(params int[] array)
        {
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }

                }
            }
            Console.WriteLine("升序排序后的结果为：");
            foreach (int b in array)
            {
                Console.Write(b + " ");
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (temp < array[i])
                {
                    temp = array[i];
                }
            }
            Console.WriteLine("\n最大值：" + temp + "!");
            return temp;
        }
        //源栈的学费是按周计费的，所以请实现这两个功能：
        //函数GetDate()，能计算一个日期若干（日 / 周 / 月）后的日期
        //给定任意一个年份，就能按周排列显示每周的起始日期，如下图所示：                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        static void GetWeeks(int year)
        {
            DateTime date = GetFirstModay(year);
            DateTime LastMonday = GetFirstModay(year + 1).AddDays(-7);
            while (date < LastMonday)
            {
                Console.WriteLine(date.ToString("yyyy年MM月dd日"));
                date = date.AddDays(6);
                Console.WriteLine("-");
                Console.WriteLine(date.ToString("yyyy年MM月dd日"));
                date = date.AddDays(1);
                Console.WriteLine();
            }
        }
        private static DateTime GetFirstModay(int year)
        {
            DateTime date = new DateTime(year, 1, 1);
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(1);
            }
            return date;
        }

    }
}
