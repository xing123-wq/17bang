using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using ConsoleApp3;
using ConsoleApp3.DoubleLinkeds;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
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

            ////Console.ReadLine();

            ///委托
            //Person Waters = new Person { Name = "阿泰", age = 17 };
            //ProvideWater persons = AssginWay;
            //persons(Waters);
            DoubleLinkList node0 = new DoubleLinkList { Item = 0 };
            DoubleLinkList node1 = new DoubleLinkList { Item = 1 };
            DoubleLinkList node2 = new DoubleLinkList { Item = 2 };
            DoubleLinkList node3 = new DoubleLinkList { Item = 3 };
            DoubleLinkList node4 = new DoubleLinkList { Item = 4 };
            DoubleLinkList node5 = new DoubleLinkList { Item = 5 };
            DoubleLinkList node6 = new DoubleLinkList { Item = 6 };

            //node1.InsertAfter(node0);
            node2.InsertAfter(node1);
            node3.InsertAfter(node2);
            node4.InsertAfter(node3);
            node5.InsertAfter(node4);
            node6.InsertBefore(node2);

            foreach (var item in node1)
            {
                Console.WriteLine(item);
            }
        }
        //声明一个方法GetWater()，该方法接受ProvideWater作为参数，并能将ProvideWater的返回值输出
        public static int GetWater(ProvideWater provide)
        {
            Person person = new Person();
            return provide(person);
        }

        public static int assignDelegate(Person person)
        {
            return person.age++;
        }

        public static int AssginWay(Person person)
        {
            //使用方法给委托赋值
            ProvideWater provideWater1 = new ProvideWater(assignDelegate);
            Console.WriteLine(provideWater1(person));

            //使用匿名方法给委托赋值
            ProvideWater provideWater2 = delegate (Person person)
            {
                return person.age++;
            };
            Console.WriteLine(provideWater2(person));

            //使用lambda表达式给上述委托赋值，并运行该委托
            ProvideWater provideWater3 = p => person.age++;
            Console.WriteLine(provideWater3(person));

            //将ProvideWater的返回值输出
            ProvideWater provideWater4 = p => person.age++;
            Console.WriteLine(GetWater(provideWater4));
            return person.age;
        }
        public static int Getmax(params int[] array)
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
        public static void GetWeeks(int year)
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
