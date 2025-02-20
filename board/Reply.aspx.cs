﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 학사관리_2023_1912053오혜성.board
{
    public partial class Reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = "admin";

            if (Session["id"] == null || Session["id"].ToString() == "")
            {
                // Response.Write("<script>alert('로그인을 해야 글을 쓸 수 있습니다.')</script>");

                Response.Redirect("~/board/");
            }

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/board/");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 저장 버튼
            if (txtTitle.Text.Trim() == "")
            {
                Response.Write("<script>alert('제목을 입력하세요')</script>");
                txtTitle.Focus();
                return;
            }
            if (txtMessage.Text.Trim() == "")
            {
                Response.Write("<script>alert('내용을 입력하세요')</script>");
                txtMessage.Focus();
                return;
            }

            string sql2 = "select ref_id,inner_id,depth from board where id=" +
                Request.QueryString["id"];

            int ref_id = 0;
            int inner_id = 0;
            int depth = 0;

            DBConn conn = new DBConn();
            SqlDataReader dr = conn.ExecuteReader(sql2);
            if (dr.Read())
            {
                ref_id = (int)dr["ref_id"];
                inner_id = (int)dr["inner_id"];
                depth = (int)dr["depth"];
            }
            dr.Close();

            string sql_u = "update board set inner_id=inner_id+1 where ref_id="
                + ref_id.ToString() +
                " AND inner_id > " + inner_id.ToString();
            conn.ExecuteNonQuery(sql_u);

            string sql = "insert into board(writer, title, message, ref_id," +
                "inner_id, depth, read_count, del_flag, reg_date) " +
                "values(@writer, @title, @message, @ref_id, " +
                "@inner_id, @depth, @read_count, @del_flag, @reg_date)";

            //string sql = "insert into board(writer, title) " +
            // 2  "values(@writer, @title)";

            SqlCommand cmd = new SqlCommand(sql, conn.GetConn());
            cmd.Parameters.AddWithValue("@writer", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@message", txtMessage.Text.Trim());
            cmd.Parameters.AddWithValue("@ref_id", ref_id);
            cmd.Parameters.AddWithValue("@inner_id", ++inner_id);
            cmd.Parameters.AddWithValue("@depth", ++depth);
            cmd.Parameters.AddWithValue("@read_count", 0);
            cmd.Parameters.AddWithValue("@del_flag", "0");
            //cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            Response.Redirect("~/board/");
        }
    }
}