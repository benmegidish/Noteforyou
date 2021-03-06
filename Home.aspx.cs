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

            if (!IsPostBack)
            { 
            LoadNotes();
            }

            if (UNote.Text == UNote.Text+"")
            {
                CRT.Enabled = true;
            }
            else
            {
                CRT.Enabled = false;
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            if (UNote.Text=="")
            {
                Response.Write("<script>alert('Can Not Create a new Note Without Text');</script>");
            }
            else
            { 
                SqlCommand cmd = new SqlCommand("insert into Notes_Table(Importance,Note,UserID) values('"+Importance.SelectedValue+ "','"+UNote.Text+"','" + Session["id"] + "')",con);
                cmd.ExecuteNonQuery();
                LoadNotes();
                UNote.Text = "";
                Importance.SelectedValue ="1";
            }
        }

        public void LoadNotes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            if (Sort.SelectedValue == "0")
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
            UNote.Text = "";
        }
        
        protected void Search_click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Notes_Table where USERID='"+Session["id"]+"' and Note like '%"+Searchtxt.Text+"%'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            { 
            RPT.DataSource = dr;
            RPT.DataBind();
            con.Close();
            }
            else
            {
                Response.Write("<script>alert('No Records has found');</script>");
            }
            Searchtxt.Text = "";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LoadNotes();
        }
    }
}