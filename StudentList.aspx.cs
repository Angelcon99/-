using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 학사관리_2023_1912053오혜성
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"].ToString() != "admin")   // admin 만 페이지 접근가능
                {
                    Response.Write("<script>alert('관리자만 접근 가능합니다.')</script>");
                    Response.Redirect("~/");
                }
            }
        }

        protected void btnStudentInfo_Click(object sender, EventArgs e)
        {
            if(GridView1.SelectedIndex < 0)
            {
                Response.Write("<script>alert('학생을 선택해주세요.')</script>");
                return;
            }

            Response.Redirect("./Student.aspx?id=" + GridView1.SelectedRow.Cells[1].Text);
        }
    }
}