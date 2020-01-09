﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp3
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Save()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;
                                    Integrated Security=True;
                                    Connect Timeout=30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();  //需要显式的Open()
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT DREAM VALUES(N'{Name}',{Age})";
                int row = command.ExecuteNonQuery();

            }
        }
        public void Delete()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;
                                    Integrated Security=True;
                                    Connect Timeout=30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();  //需要显式的Open()
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"DELETE DREAM  ";
                int row = command.ExecuteNonQuery();

            }
        }
        //思考dynamic和var的区别
        //用代码证明struct定义的类型是值类型
        internal void Information()
        {
            object[] Student = new object[5];
            string Name = "阿泰";
            Student[0] = Name;
            int Score = 99;
            Student[1] = Score;
            double GPA = 88.5;
            Student[2] = GPA;
            DateTime EnrolTime = new DateTime(12, 3, 4);
            Student[3] = EnrolTime;
            bool gender = true;//true代表男生,false代表女生.
            Student[4] = gender;
            Console.WriteLine(Student[0]);
            Console.WriteLine(Student[1]);
            Console.WriteLine(Student[2]);
            Console.WriteLine(Student[3]);
            Console.WriteLine(Student[4]);
        }
    }
    internal struct StudentInformation
    {

        internal int score;
    }

}

//构造一个能装任何数据的数组，并完成数据的读写
//使用object改造数据结构栈（Stack），并在出栈时获得出栈元素
//一起帮中用户可以被分为：访客（Visited）、注册用户（Registered）、可发布（Published）和管理员（Admin）。请据此设计一个枚举类型Role（角色），并将其用于User对象，让User对象可以角色属性。

