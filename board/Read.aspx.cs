﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 학사관리_2023_1912053오혜성.board
{
    public partial class Read : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 로그인 아이디를 "admin"으로 설정하고 테스트
            Session["id"] = "admin";

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/board/");
            }
            if (!IsPostBack)
            {
                ViewPage(Request.QueryString["id"].ToString());
            }
        }

        protected void ViewPage(string id)
        {
            string sql = "select * from board where id=" + id;
            string sql_u = "update board set read_count=read_count+1 where id=" + id;

            DBConn conn = new DBConn();

            conn.ExecuteNonQuery(sql_u);

            SqlDataReader dr = conn.ExecuteReader(sql);

            if (dr.Read())
            {
                lbWriter.Text = dr["writer"].ToString();
                lbDate.Text = dr["reg_date"].ToString();
                lbCount.Text = dr["read_count"].ToString();
                lbTitle.Text = dr["title"].ToString();
                lbMessage.Text = dr["message"].ToString().Replace("\n", "<br />");

                if (dr["file1"].ToString() != "")
                {
                    HyperLink1.Text = dr["file1"].ToString();
                    HyperLink1.NavigateUrl = "~/pub/" + dr["file1"].ToString();
                }
                else
                {
                    HyperLink1.Text = "";
                }
            }
            else
            {
                Response.Redirect("~/board/");
            }
            dr.Close();
            conn.Close();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // 글 수정

            if (Session["id"].ToString() == "admin" ||
                Session["id"].ToString() == lbWriter.Text)
            {
                Response.Redirect("write.aspx?mode=edit&id=" +
                    Request.QueryString["id"]);
            }
            else
                Response.Write("<script>alert('글 수정 권한이 없습니다.')</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 글 삭제
            if (Session["id"].ToString() != "admin" &&
                Session["id"].ToString() != lbWriter.Text)
            {
                Response.Write("<script>alert('삭제할 권한이 없습니다.');</script>");
                return;
            }
            
            string sql = "update board set del_flag='1' where id=" +
                Request.QueryString["id"].ToString();
            DBConn conn = new DBConn();
            conn.ExecuteNonQuery(sql);
            conn.Close();
            Response.Redirect("~/board/");
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            // 목록으로
            Response.Redirect("~/board/");
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            // 답변 작성
            Response.Redirect("Reply.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}