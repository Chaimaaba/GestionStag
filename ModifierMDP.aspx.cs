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
    public partial class ModifierMDP : System.Web.UI.Page
    {
        string oldPass, NewPass;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsFirstTimeLogin())
                {
                    
                    Response.Redirect("ModifierMDP.aspx");
                }
                else
                {
                    
                    Response.Redirect("Acceuil.aspx");
                }
            }

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
           

            string str = ConfigurationManager.ConnectionStrings["Stagiaire"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Personnel set PassP=@NewPass where PassP=@oldPass";
            cmd.Parameters.AddWithValue("@oldPass", ChangePassword1.CurrentPassword);
            cmd.Parameters.AddWithValue("@NewPass", ChangePassword1.NewPassword);
            con.Open();
            if (ValidateFields(ChangePassword1.CurrentPassword, ChangePassword1.NewPassword, ChangePassword1.ConfirmNewPassword))
            {
                Response.Redirect("Acceuil.aspx");

            }
            else
            {
                ChangePassword1.PasswordRecoveryText = "Impossible de modifier le mot de passe !";
            }
        }

        private bool IsFirstTimeLogin()
        {
            
            if (Request.Cookies["FirstLogin"] == null)
            {
                Response.Cookies["FirstLogin"].Value = "true";
                return true;
            }
            else
            {
                return false;
            }

        }


         private bool ValidateFields(string oldPassword, string newPassword, string confirmPassword)
        {
            oldPassword = oldPassword.Trim();
            newPassword = newPassword.Trim();
            confirmPassword = confirmPassword.Trim();

            string str = ConfigurationManager.ConnectionStrings["Stagiaire"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PassP FROM Personnel WHERE PassP = @pass", con))
                {
                    cmd.Parameters.AddWithValue("@pass", oldPassword);
                    con.Open();
                    string rd = cmd.ExecuteScalar()?.ToString();

                    if (rd == oldPassword && newPassword == confirmPassword)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }



    }
}