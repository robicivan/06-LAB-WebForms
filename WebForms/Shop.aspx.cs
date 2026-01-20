using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebForms
{
    public partial class Shop : System.Web.UI.Page
    {
        private readonly SqlConnection _connection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ToString());

        private SqlCommand _command;
        private SqlDataReader _dr;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblWelcome.Text = "Pozdrav, " + (Session["FullName"]?.ToString() ?? Session["UserName"].ToString());


            if (!IsPostBack)
            {
                Display();
            }
        }

        private void Display()
        {
            _connection.Open();
            _command = new SqlCommand("SELECT Id, Name, Description FROM Products ORDER BY Id", _connection);
            _dr = _command.ExecuteReader();

            gvProducts.DataSource = _dr;
            gvProducts.DataBind();

            _dr.Close();
            _connection.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

            string name = tbName.Text.Trim();
            string desc = tbDesc.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc))
            {
                lblMsg.Text = "Naziv i opis su obavezni.";
                return;
            }

            _connection.Open();

            _command = new SqlCommand(
                "INSERT INTO Products(Name, Description) VALUES(@n, @d)", _connection);

            _command.Parameters.AddWithValue("@n", name);
            _command.Parameters.AddWithValue("@d", desc);

            _command.ExecuteNonQuery();
            _connection.Close();


            Display();
            tbName.Text = "";
            tbDesc.Text = "";
            lblMsg.Text = "Proizvod spremljen.";
        }
    }
}