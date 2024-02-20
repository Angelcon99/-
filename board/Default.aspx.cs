using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 학사관리_2023_1912053오혜성.board
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string ShowDepth(int depth)
        {
            string s = "";
            for (int i = 0; i < depth; i++)
                s += "&nbsp;&nbsp;&nbsp;&nbsp;";
            return s;
        }

        protected string ShowReplayIcon(int inner_id)
        {
            string s = "";
            if (inner_id != 0)
                s = "<img src='./img/reply_icon.gif' />";
            return s;
        }
        protected string ShowTitle(string id, string title, string del_flag)
        {
            string s = "";
            if (del_flag == "0")  // 삭제되지 않은 글
            {
                s = "<a href='Read.aspx?id=" + id;
                s += "' class='a01'>" + title + "</a>";
            }
            else
                s = "삭제된 게시물입니다.";
            return s;
        }

        protected string ShowDate(string date)
        {
            if (date.Length >= 10)
                return "<span style='font-size:16px'>" + date.Substring(0, 10) + "</span>";
            else
                return "";
        }
    }
}