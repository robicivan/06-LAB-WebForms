using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly SqlConnection _connection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ToString());

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string userName = tbUserName.Text.Trim();
            string pass = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pass))
            {
                lblMsg.Text = "Unesi korisničko ime i lozinku.";
                return;
            }

            _connection.Open();

            using (SqlCommand cmd = new SqlCommand(
                "SELECT FullName FROM Users WHERE UserName=@u AND Password=@p", _connection))
            {
                cmd.Parameters.AddWithValue("@u", userName);
                cmd.Parameters.AddWithValue("@p", pass);

                object result = cmd.ExecuteScalar();
                _connection.Close();

                if (result != null)
                {

                    Session["UserName"] = userName;
                    Session["FullName"] = result.ToString();

                    Response.Redirect("Shop.aspx");
                }
                else
                {
                    lblMsg.Text = "Neispravni podaci.";
                }
            }
        }
    }
}