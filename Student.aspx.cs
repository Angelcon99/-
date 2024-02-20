using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace 학사관리_2023_1912053오혜성
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() != "admin")   // admin 만 페이지 접근가능
            {
                Response.Write("<script>alert('관리자만 접근 가능합니다.')</script>");
                Response.Redirect("~/");
            }

            if (!IsPostBack)
            {                
                ViewState["insert"] = true;

                ddlSYear.Items.Add("1");
                ddlSYear.Items.Add("2");
                ddlSYear.Items.Add("3");
                ddlSYear.Items.Add("4");
                ddlSYear.SelectedIndex = 0;
                
                Dept();   // 학과 코드

                if (Request.QueryString["id"] != null)
                {
                    txtHakbun.Text = Request.QueryString["id"].ToString();
                    ViewStudent(Request.QueryString["id"].ToString());
                }
            }
        }

        protected void Dept()
        {
            DBConn conn = new DBConn();
            string sql = "select * from department order by deptCD";
            SqlDataReader dr = conn.ExecuteReader(sql);

            while (dr.Read())
            {
                ddlDept.Items.Add(new ListItem(dr["department"].ToString(), dr["deptCD"].ToString()));                
            }
            ddlDept.SelectedIndex = 0;

            dr.Close();
            conn.Close();
        }

        protected void btnFind_Student_Click(object sender, EventArgs e)
        {
            ViewStudent(txtHakbun.Text);           
        }

        public void ViewStudent(string hakbun)
        {
            DBConn conn = new DBConn();
            string sql = "select * from student where hakbun='" + hakbun + "'";
            SqlDataReader dr = conn.ExecuteReader(sql);

            if (dr.Read())
            {
                ViewState["insert"] = false;                

                txtName.Text = dr["name"].ToString();
                rdM.Checked = false; 
                rdW.Checked = false;
                if (dr["sx"].ToString() == "1") rdM.Checked = true;
                else if (dr["sx"].ToString() == "2") rdW.Checked = true;
                
                txtBirth.Text = dr["birthday"].ToString().Substring(0,10);
                txtAddr.Text = dr["addr"].ToString();
                txtTel.Text = dr["tel"].ToString();
                
                // 학과코드
                ddlDept.Text = dr["deptCD"].ToString();

                //사진
                if (dr["picfile"].ToString() != "")
                {
                    try
                    {
                        Image2.ImageUrl = "~/pic/" + dr["picfile"].ToString();
                    }
                    catch { }                   
                }
            }
            else   // 검색한 학번이 없는 경우
            {
                Response.Write("<script>alert('등록된 학번이 아닙니다.')</script>");
                txtHakbun.Text = "";
            }

            dr.Close();
            conn.Close();            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtHakbun.Text = string.Empty;
            ViewState["insert"] = true;
            txtName.Text = "";
            rdM.Checked = false;
            rdW.Checked = false;
            txtAddr.Text = "";
            txtTel.Text = string.Empty;
            Image2.ImageUrl = "";
            txtBirth.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtHakbun.Text.Length != 7)
            {
                Response.Write("<script>alert('학번은 7자리입니다.')</script>");
                txtHakbun.Focus();
                return;
            }

            string sql = "";
            if ((bool)ViewState["insert"])
            {
                sql = "insert into student(name, sx, birthday, deptCD, s_year, picfile, addr, tel, hakbun) values" +
                    "(@name, @sx, @birthday, @deptCD, @s_year, @picfile, @addr, @tel, @hakbun)";
            }
            else
            {
                sql = "update student set name=@name, sx=@sx, birthday=@birthday, deptCD=@deptCD, s_year=@s_year," +
                    "picfile=@picfile, addr=@addr, tel=@tel " + 
                    "where hakbun=@hakbun";
            }

            DBConn conn = new DBConn();
            SqlCommand cmd = new SqlCommand(sql, conn.GetConn());
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            string sx = "";
            if (rdM.Checked) sx = "1";
            else if(rdW.Checked) sx = "2";
            cmd.Parameters.AddWithValue("@sx", sx);
            cmd.Parameters.AddWithValue("@birthday", txtBirth.Text);
            cmd.Parameters.AddWithValue("@deptCD", ddlDept.SelectedValue);
            cmd.Parameters.AddWithValue("@s_year", ddlSYear.Text);
            // 사진 저장
            string filename = "";
            string ext = "";
            if (FileUpload1.HasFile)
            {                
                filename = FileUpload1.FileName;
                // 파일명, 확장자 분할
                //string file = Path.GetFileNameWithoutExtension(filename);               
                ext = Path.GetExtension(filename);
                
                string newFile = txtHakbun.Text + ext;

                string file1 = Server.MapPath("/pic") + "\\" + newFile;

                FileUpload1.SaveAs(file1);

                // 사진 출력
                try
                {
                    Image2.ImageUrl = "~/pic/" + newFile;
                }
                catch { }
                
            }
            cmd.Parameters.AddWithValue("@picfile", txtHakbun.Text + ext);

            cmd.Parameters.AddWithValue("@addr", txtAddr.Text);
            cmd.Parameters.AddWithValue("@tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@hakbun", txtHakbun.Text);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('저장되었습니다.')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtHakbun.Text.Length != 7) 
            {
                Response.Write("<stript>alert('삭제할 학번을 입력하세요.')</stript>");
                txtHakbun.Focus();
                return;
            }

            string sql = "delete from student where hakbun='" + txtHakbun.Text + "'";
            DBConn conn = new DBConn();
            try
            {
                conn.ExecuteNonQuery(sql);
                btnClear_Click(null, null);
            } 
            catch { }
            finally 
            { 
                conn.Close(); 
            }            
        }
    }
}