using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using ConsoleApp3;
using ConsoleApp3.DoubleLinkeds;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            #region ADO.NET
            DBhelper dBhelper = new DBhelper();
            string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=add;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(ConnectionString);
            //string saveUser = "INSERT Register VALUES(N'阿泰')";
            //dBhelper.ExecuteNonQuery(saveUser,connection);
            //string name = Console.ReadLine();
            //string SelectUsers = "SELECT * FROM Register";
            //string InsertUser = "INSERT Register VALUES(@UserName,@UserPassword)";
            //string saveUser = "INSERT Register VALUES(@UserName,@UserPassword)";
            #endregion

            #region binarySeek
            Student student = new Student(12);
            Student student1 = new Student(19);
            Student student2 = new Student(15);
            Student student3 = new Student(10);
            Student student4 = new Student();

            List<Student> students = new List<Student>
            {
                student,student1,student3,student2,student4
            };

            students.Sort();

            //foreach (var item in students)
            //{
            //    Console.WriteLine(item.Age);
            //}

            //int a = students.BinarySearch(student4);
            //Console.WriteLine(a);
            //DataStucture<Student>.BinaryWhile(students, student4);
            #endregion

            string site = "http://pv.sohu.com/cityjson ";
            Console.WriteLine(site);
        }

        #region 委托方法
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
        #endregion

        #region 找最大数
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
        #endregion

        #region 时间方法
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
        #endregion
    }
}
