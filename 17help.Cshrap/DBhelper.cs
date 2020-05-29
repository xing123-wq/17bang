using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp3
{
    public class DBhelper //工具类
    {
        //构建一个DBHelper，可以提供：
        //封装过后的ExecuteNonQuery()/ExecuteScalar()/ExecuteReader()方法
        //由外部控制开闭（Open()/Close()）的长连接（LongConnection）
        //ExecuteNonQuery()使用长连接的重载

        //使用上述DBHelper，完成以下操作：
        //将用户名和密码存入数据库：Register()
        //根据用户名和密码检查某用户能够成功登陆：Logon()
        //如果用户成功登陆，将其最后登录时间（LatestLogonTime）改成当前时间
        //批量标记Message为已读
        private const string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=17bang;Integrated Security=True;";
        public string connection { get => connectionString; }
        public SqlConnection LongConnection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public int ExecuteNonQuery(string cmdText, SqlConnection connection)
        {
            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();  //需要显式的Open()
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmdText;
                int row = command.ExecuteNonQuery();
                Console.WriteLine(row);
                return row;
            }
        }
        public int ExecuteNonQuery(string cmdText)
        {
            using (var connection = LongConnection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }//else:do notthing
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmdText;
                int row = command.ExecuteNonQuery();
                Console.WriteLine(row);
                return row;
            }
        }
        public object ExecuteScalar(string cmdText)//得到的结果是个标量
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }//else:do notthing
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmdText;
                object row = command.ExecuteScalar();
                Console.WriteLine(row);
                return row;
            }
        }
        public SqlDataReader ExecuteReader(string cmdText)//通过SqDataReader对象来获得返回的结果
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }//else:do notthing
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmdText;
                SqlDataReader row = command.ExecuteReader();
                if (row.HasRows)    //在ExecuteReader()之后立即获取
                {
                    while (row.Read())
                    {
                        Console.WriteLine($"{row[0]},{row[1]}");
                    }
                }
                return row;
            }
        }
        public SqlDataReader ExecuteReader(string cmdText, SqlConnection connection)
        {
            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();  //需要显式的Open()
                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmdText;
                SqlDataReader row = command.ExecuteReader();
                if (row.HasRows)    //在ExecuteReader()之后立即获取
                {
                    while (row.Read())
                    {
                        Console.WriteLine($"{row[0]},{row[1]}");
                    }
                }
                return row;
            }
        }
    }
}
