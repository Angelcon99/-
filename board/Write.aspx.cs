using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace 학사관리_2023_1912053오혜성.board
{
    public partial class Write : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = "admin";

            if (Session["id"] == null || Session["id"].ToString() == "")
            {
                // Response.Write("<script>alert('로그인을 해야 글을 쓸 수 있습니다.')</script>");
                Response.Redirect("~/board");
            }
            if (!IsPostBack)
            {
                ref_id.Visible = false;
                inner_id.Visible = false;
                depth.Visible = false;
                read_count.Visible = false;

                if (Request.QueryString["mode"] != null)   // 수정으로 넘어오면 mode, id 값을 넘겨줌
                {
                    if (Request.QueryString["mode"] == "edit")
                    {
                        lbTitle.Text = "글 수정";

                        string sql = "select * from board where id=" +
                            Request.QueryString["id"];

                        DBConn conn = new DBConn();
                        SqlDataReader dr = conn.ExecuteReader(sql);
                        if (dr.Read())
                        {
                            txtTitle.Text = dr["title"].ToString();
                            txtMessage.Text = dr["message"].ToString();

                            ref_id.Text = dr["ref_id"].ToString();
                            inner_id.Text = dr["inner_id"].ToString();
                            depth.Text = dr["depth"].ToString();
                            read_count.Text = dr["read_count"].ToString();

                            if (dr["file1"].ToString() == "")
                                lbFile1.Text = "";
                            else
                                lbFile1.Text = dr["file1"].ToString();
                        }
                        else
                        {
                            ref_id.Text = "0";
                            inner_id.Text = "0";
                            depth.Text = "0";
                            read_count.Text = "0";
                        }
                        dr.Close();
                        conn.Close();
                    }
                }
                else
                    lbTitle.Text = "글 쓰기";
            }
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            // 글 저장

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
            string sql = "";
            if (Request.QueryString["mode"] == null)
                sql = "insert into board(writer,title,file1,file1_size," +
                "message, ref_id,inner_id,depth,read_count,del_flag," +
                "reg_date) " +
                "values(@writer,@title,@file1,@file1_size," +
                "@message, @ref_id,@inner_id,@depth,@read_count,@del_flag," +
                "@reg_date)";
            else if (Request.QueryString["mode"] == "edit")
                sql = "update board set writer=@writer,title=@title," +
                "file1= @file1,file1_size = @file1_size," +
                "message=@message, ref_id=@ref_id,inner_id=@inner_id," +
                "depth=@depth,read_count=@read_count,del_flag=@del_flag," +
                "reg_date=@reg_date " +
                "where id=" + Request.QueryString["id"];

            string sql2 = "update board set ref_id=id where ref_id=0";

            // 파일첨부
            string filename = "";
            int file_size = 0;

            if (FileUpload1.HasFile)  // 첨부파일이 있으면
            {
                filename = FileUpload1.FileName;
                string file1 = Server.MapPath("~/pub") + "\\" + filename;

                // 파일명 중복 체크
                if (File.Exists(file1))
                    filename = DuplicateFile(Server.MapPath("~/pub"), file1);

                file1 = Server.MapPath("/pub") + "\\" + filename;

                FileUpload1.SaveAs(file1);

                file_size = FileUpload1.PostedFile.ContentLength; // 바이트

                //HyperLink1.NavigateUrl = "pub/" + filename;
                //HyperLink1.Text = filename;
            }
            else
            {
                filename = lbFile1.Text;
            }

            DBConn conn = new DBConn();
            SqlCommand cmd = new SqlCommand(sql, conn.GetConn());
            cmd.Parameters.AddWithValue("@writer", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@file1", filename);
            cmd.Parameters.AddWithValue("@file1_size", file_size);
            cmd.Parameters.AddWithValue("@message", txtMessage.Text.Trim());
            cmd.Parameters.AddWithValue("@ref_id", ref_id.Text);
            cmd.Parameters.AddWithValue("@inner_id", inner_id.Text);
            cmd.Parameters.AddWithValue("@depth", depth.Text);
            cmd.Parameters.AddWithValue("@read_count", read_count.Text);
            cmd.Parameters.AddWithValue("@del_flag", "0");
            cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            try
            {
                cmd.ExecuteNonQuery();
                conn.ExecuteNonQuery(sql2);

                Response.Write("<script>alert('저장되었습니다')</script>");

            }
            finally
            {
                conn.Close();
            }

            Response.Redirect("~/board");
        }

        public string DuplicateFile(string dir, string filename)
        {
            string file = Path.GetFileNameWithoutExtension(filename);
            string ext = Path.GetExtension(filename);
            string new_filename = filename;
            string temp_filename = String.Empty;

            int cnt = 1;
            while (File.Exists(new_filename))
            {
                temp_filename = String.Format("{0}({1})", file, cnt++);
                new_filename = Path.Combine(dir + "\\" + temp_filename + ext);
            }
            return temp_filename + ext;     // 파일명만 반환
        }

    }
}