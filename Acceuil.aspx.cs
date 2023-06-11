using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Acceuil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["Stagiaire"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Personnel where Matricule=@login and PassP=@pass";
            cmd.Parameters.AddWithValue("@login", Login1.UserName);
            cmd.Parameters.AddWithValue("@pass", Login1.Password);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                Session["Matricule"] = rd.GetValue(0).ToString();
                Session["NomPerso"] = rd.GetValue(2).ToString();
                Session["PrenomPerso"] = rd.GetValue(3).ToString();
                e.Authenticated = true;
            
            }
            else
            {
                e.Authenticated = false;
            }
            con.Close();
        }
    }
}