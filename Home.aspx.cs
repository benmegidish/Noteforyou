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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Hello.Text = "Hello Dear " + Session["name"].ToString() + "";
            
                LoadNotes();
            
            if (UNote.Text == null)
            {
                CRT.Enabled = false;
            }
            else
            {
                CRT.Enabled = true;
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Notes_Table(Importance,Note,UserID) values('"+Importance.SelectedValue+ "','"+UNote.Text+"','" + Session["id"] + "')",con);
            cmd.ExecuteNonQuery();
            LoadNotes(); 
        }

        public void LoadNotes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            if (Sort.SelectedValue == "1")
            {
                SqlCommand cmd = new SqlCommand("select * from Notes_Table where UserID='" + Session["id"] + "' order by Importance desc", con);
                SqlDataReader dr = cmd.ExecuteReader();
                RPT.DataSource = dr;
                RPT.DataBind();
                con.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Notes_Table where UserID='" + Session["id"] + "' order by Importance ASC", con);
                SqlDataReader dr = cmd.ExecuteReader();
                RPT.DataSource = dr;
                RPT.DataBind();
                con.Close();
            }
              
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            RepeaterItem rep =(sender as LinkButton).Parent as RepeaterItem;
            Label lbdel = ((Label)rep.FindControl("Nid") as Label);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand($"DELETE FROM Notes_Table WHERE Id='"+lbdel.Text+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadNotes();
        }
        protected void Edit_click(object sender, EventArgs e)
        {
            RepeaterItem rep = (sender as LinkButton).Parent as RepeaterItem;
            Label lbdel = ((Label)rep.FindControl("Nid") as Label);
            UNote.Text=((Label)rep.FindControl("Notus") as Label).Text;
            Importance.Text= ((Label)rep.FindControl("IMport") as Label).Text;
            UPD.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Notes_Table where Id='" +lbdel.Text+ "'", con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Session["NEid"] = rd.GetValue(0).ToString();
                }
            }
            CRT.Visible = false;
        }
        protected void Update_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand($"Update Notes_Table set Importance='"+Importance.SelectedValue+"', Note='" +UNote.Text+"' where Id='"+Session["NEid"]+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadNotes();
            UPD.Visible = false;
            CRT.Visible = true;
        }
        
        protected void Search_click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Notes_Table where UserID='"+Session["id"]+"' and Note=*'"+Searchtxt.Text+"'*,", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LoadNotes();
        }
    }
}