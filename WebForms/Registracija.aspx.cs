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
    public partial class Registracija : System.Web.UI.Page
    {
        private readonly SqlConnection _connection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ToString());

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string userName = tbUserName.Text.Trim();
            string fullName = tbFullName.Text.Trim();
            string pass1 = tbPassword.Text;
            string pass2 = tbPassword2.Text;

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(pass1))
            {
                lblMsg.Text = "Sva polja su obavezna.";
                return;
            }

            if (pass1 != pass2)
            {
                lblMsg.Text = "Lozinke se ne podudaraju.";
                return;
            }

            _connection.Open();

            using (SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName=@u", _connection))
            {
                check.Parameters.AddWithValue("@u", userName);
                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    _connection.Close();
                    lblMsg.Text = "Korisničko ime već postoji.";
                    return;
                }
            }

            using (SqlCommand insert = new SqlCommand(
                "INSERT INTO Users(UserName, Password, FullName) VALUES (@u,@p,@f)", _connection))
            {
                insert.Parameters.AddWithValue("@u", userName);
                insert.Parameters.AddWithValue("@p", pass1);
                insert.Parameters.AddWithValue("@f", fullName);

                insert.ExecuteNonQuery();
            }

            _connection.Close();


            Response.Redirect("Login.aspx");
        }
    }
}