using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace 학사관리_2023_1912053오혜성
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkPwd_CheckedChanged(object sender, EventArgs e)
        {   
            if (txtPwd.TextMode == TextBoxMode.Password)
            {
                txtPwd.TextMode = TextBoxMode.SingleLine; 
            }
            else
            {
                txtPwd.TextMode = TextBoxMode.Password;       
            }
                
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Length < 4) 
            {
                Response.Write("<script>alert('아이디를 4글자 이상 입력하세요')</script>");
                txtID.Focus();
                return;
            }
            if(txtPwd.Text == "")
            {
                Response.Write("<script>alert('암호를 입력하세요')</script>");
                txtPwd.Focus();
                return;
            }
            string pwd = Site1.MD5Hash(txtPwd.Text);
            // 회원 저장
            string sql = "insert into member(id, pwd, name, reg_date) values(@id, @pwd, @name, @reg_date)";

            DBConn conn = new DBConn();
            SqlCommand cmd = new SqlCommand(sql, conn.GetConn());
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss"));
            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('회원가입 완료')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}