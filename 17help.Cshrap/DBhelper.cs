using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

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
        private SqlConnection _connection;
        public DBhelper(string connection)
        {
            _connection = new SqlConnection(connection);
        }
        public void HasConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();  //需要显式的Open()
            }
        }
        public int ExecuteNonQuery(string cmdText)
        {
            using (_connection)
            {
                HasConnection(_connection);
                SqlCommand command = new SqlCommand();
                command.Connection = _connection;
                command.CommandText = cmdText;
                int row = command.ExecuteNonQuery();
                return row;
            }
        }
        public object ExecuteScalar(string cmdText)//得到的结果是个标量
        {
            using (_connection)
            {
                HasConnection(_connection);
                SqlCommand command = new SqlCommand();
                command.Connection = _connection;
                command.CommandText = cmdText;
                object row = command.ExecuteScalar();
                return row;
            }
        }
        public SqlDataReader ExecuteReader(string cmdText)//通过SqDataReader对象来获得返回的结果
        {
            using (_connection)
            {
                HasConnection(_connection);
                SqlCommand command = new SqlCommand();
                command.Connection = _connection;
                command.CommandText = cmdText;
                SqlDataReader row = command.ExecuteReader();
                return row;
            }
        }
        public int Inserte(DbCommand command)
        {
            using (_connection)
            {
                HasConnection(_connection);
                command.Connection = _connection;
                //command.CommandText = cmdText;
                int row = command.ExecuteNonQuery();
                return row;
            }
        }
        public int Inserte(string cmdText,params DbParameter[] parameters)
        {
            DbCommand command = new SqlCommand(cmdText);
            return Inserte(command);
        }
        public void Delete()//全表
        {

        }
        public void Remove()//行数据
        {

        }
        public void Update()
        {

        }
        public void Select()
        {

        }
    }
}
