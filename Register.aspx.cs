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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into User_table(Id,Name,Password) values('"+id.Text.Trim()+"','"+Fname.Text+"','"+Pass.Text+"')",con);
                cmd.ExecuteNonQuery();
                con.Close();
                confirm.Text = "Data Saved Succefully!";
                confirm.ForeColor = System.Drawing.Color.Green;
                Response.AddHeader("REFRESH","5;LogIn.aspx");
            }
            catch
            {
                confirm.Text = "Something Went Wrong! Please Try Again later...";
                confirm.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}