﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    class DBhelper
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
        public static void SQL()
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
                command.CommandText = @"INSERT DREAM VALUES(N'与围墙',11)";
                int row = command.ExecuteNonQuery();

            }
        }
    }
}
