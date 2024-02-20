using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace 학사관리_2023_1912053오혜성
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() == "")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                lbID.Text = Session["id"].ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // 로그인 버튼            
            if(txtID.Text.Trim() == "")
            {
                Response.Write("<script>alert('아이디를 입력하세요')</script>");   // JS
                txtID.Focus();
                return;
            }
            if (txtPwd.Text == "")
            {
                Response.Write("<script>alert('암호를 입력하세요')</script>");   // JS
                txtPwd.Focus();
                return;
            }

            string pwd = MD5Hash(txtPwd.Text);   // 암호화

            DBConn conn = new DBConn();
            string sql = "select pwd from member where id='" + txtID.Text + "'";
            SqlDataReader dr = conn.ExecuteReader(sql);

            bool login = false;
            if (dr.Read())
            {
                if(pwd == dr["pwd"].ToString())
                {
                    login = true;
                }
                else
                {
                    Response.Write("<script>alert('아이디 또는 암호가 틀렸습니다')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('아이디 또는 암호가 틀렸습니다')</script>");
            }

            dr.Close();
            conn.Close();

            if (login)
            {
                Session["id"] = txtID.Text;
                Response.Redirect("~/");
            }
        }

        // MD5 암호화 128bit 암호화
        public static string MD5Hash(string s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(s));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // 로그아웃 버튼
            Session.Abandon();   // Session 정보 모두 삭제
            Response.Redirect("~/");
        }
    }
}