using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleWAD1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* TextBox1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1_Click.ClientID + "')");*/
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {/*
            if (btnClick.Text == "OK")
            {
                btnClick.Text = "Hãy Click vào em!";
            }
            else
            {
                btnClick.Text = "OK";
            }*/
        }

        protected void btnClick_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument == "Delete")
            {

            }
            if (e.CommandArgument == "Update")
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="admin" && txtPassword.Text == "admin")
            {
                Response.Redirect("~/About.aspx");
            }
            else
            {
                lblfail.Text = "Thông tin người dùng không đúng!";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int result= Convert.ToInt32(txtA.Text)+ Convert.ToInt32(txtB.Text);
            txtA.Text = "";
            txtB.Text = "";
            lblResult.Text = result.ToString();
        }

        protected void btnCheckFile_Click(object sender, EventArgs e)
        {
            
            try
            {
                StreamReader reader = new StreamReader("File.txt");
                string read = reader.ReadToEnd();
                reader.Close();
            }
            catch(FileNotFoundException ex)
            {
                lblCheckFile.Text = "Tệp tin không tồn tại: "+ ex.Message;
            }
        }
    }
}