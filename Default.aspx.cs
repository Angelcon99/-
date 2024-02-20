using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 학사관리_2023_1912053오혜성
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // counter
            string n = Application["counter"].ToString();
            for (int i = 0; i < n.Length; i++)
            {
                Image img = new Image();
                img.ImageUrl = "img/" + n[i] + ".png";
                img.Height = 30;
                Panel1.Controls.Add(img);
            }

            // curr_counter
            n = Application["curr_counter"].ToString();
            for (int i = 0; i < n.Length; i++)
            {
                Image img = new Image();
                img.ImageUrl = "img/" + n[i] + ".png";
                img.Height = 30;
                Panel2.Controls.Add(img);
            }


            DBConn conn = new DBConn();
            string sql = "update counter set count=" + (int)Application["counter"] + "where pagename='main'";
            conn.ExecuteNonQuery(sql);
            conn.Close();
        }
    }
}