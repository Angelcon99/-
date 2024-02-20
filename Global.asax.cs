using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace 학사관리_2023_1912053오혜성
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            DBConn conn = new DBConn();
            string sql = "select count from counter where pagename='main'";
            object o_cnt = conn.ExecuteScalar(sql);
            conn.Close();

            Application["counter"] = o_cnt;
            Application["curr_counter"] = 0;            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["id"] = "";

            Application.Lock();
            Application["counter"] = (int)Application["counter"] + 1;
            Application["curr_counter"] = (int)Application["curr_counter"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["curr_counter"] = (int)Application["curr_counter"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            DBConn conn = new DBConn();
            string sql = "update counter set count=" + (int)Application["counter"] + "where main";
            conn.ExecuteNonQuery(sql);
            conn.Close();
        }
    }
}