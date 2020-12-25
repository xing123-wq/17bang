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
        private SqlConnection _connection;
        protected const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=18bang;Integrated Security=True;";
        public DBhelper()
        {
            _connection = new SqlConnection(connectionString);
        }

        public bool HasConnection(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();  //需要显式的Open()
            }
            return true;
        }
        public int ExecuteNonQuery(string cmdText)
        {
            using (_connection)
            {
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
                command.Connection = _connection;
                //command.CommandText = cmdText;
                int row = command.ExecuteNonQuery();
                return row;
            }
        }
        public int Inserte(string cmdText, params DbParameter[] parameters)
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
