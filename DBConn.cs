// @utf-8

// © 2014~2023 정경환(jwcwjung@naver.com)
// https://coding-abc.kr/19 (SQL Server, LocalDB)
// https://coding-abc.kr/22 (select 구문 실행하기)
// https://coding-abc.kr/48 (OleDb)

// -- DBConn.cs
// -- for SQL Server, LocalDB

using System;
using System.Data;
using System.Data.SqlClient;

class DBConn
{
    // LocalDB	
    string connectionString = @"Server=(LocalDB)\MSSQLLocalDb;database=haksa;integrated security=true";

    // SQL Server, Express
    // string connectionString = @"Server=192.168.xxx.xxx;uid="xxx";pwd="xxx";Database=xxx";

    public SqlConnection conn;

    public DBConn()
    {
        conn = new SqlConnection(connectionString);
        conn.Open();
    }

    public void Close()
    {
        conn.Close();
    }

    public SqlConnection GetConn()
    {
        return conn;
    }

    public int ExecuteNonQuery(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        return cmd.ExecuteNonQuery();
    }

    public SqlDataReader ExecuteReader(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        return cmd.ExecuteReader();
    }

    public object ExecuteScalar(string sql)   // 한개만 가져올때
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        return cmd.ExecuteScalar();
    }

    public DataSet GetDataSet(string sql)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(sql, conn);

        DataSet ds = new DataSet();
        adapter.Fill(ds);
        return ds;
    }
}
