using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication13
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from User_table where Id='" + Uid.Text + "' and Password='" + UPass.Text + "'", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Session["id"] = rd.GetValue(0).ToString();
                        Session["name"] = rd.GetValue(1).ToString();
                    }
                    Response.AddHeader("REFRESH", "2;Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('invalid info');</script>");
                }
            }
            catch
            {
                
            }
        }
    }
}