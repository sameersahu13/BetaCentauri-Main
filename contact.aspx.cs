using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Website
{
    public partial class contact : System.Web.UI.Page
    {
        private DataTable dt;
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        //public void SaveFeedBack()
        //{
        //    con = new SqlConnection(constr);
        //    SqlCommand cmd;
        //    try
        //    {

        //        cmd = new SqlCommand("PROC_SAVE_FEEDBACK", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@NAME", txtName.Text.ToString());
        //        cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.ToString());
        //        cmd.Parameters.AddWithValue("@MOBILE", txtMobile.Text.ToString());
        //        cmd.Parameters.AddWithValue("@MESSAGE", txtMessage.Text.ToString());
        //        cmd.Parameters.AddWithValue("@CREATED_DT", DateTime.UtcNow.Date);
        //        con.Open();
        //        int result = cmd.ExecuteNonQuery();
        //        if (result > 0)
        //        {

        //            string mesg = "Thank you for your Feedback..!";
        //            Execute(txtEmail.Text, mesg);
        //            Reset();
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Feedback Submitted.');", true);

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Could not Send Feedback.');", true);
        //        }
        //        con.Close();

        //    }
        //    catch (Exception e)
        //    {

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Oops...! Something wents wrong.');", true);
        //    }
        //}
        //Send Email to User
        //static async Task Execute(string Email, string mesg)
        //{
        //    var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
        //    var client = new SendGridClient("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");
        //    var from = new EmailAddress("noreply@betacentauri.in", "Feedback");
        //    var subject = "Feedback";
        //    var to = new EmailAddress(Email, "User Feedback");
        //    var plainTextContent = "Feedback";
        //    var htmlContent = mesg;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //     Console.WriteLine(response);
        //}
        public void Reset()
        {
            txtEmail.Text = "";
            txtMessage.Text = "";
            txtMobile.Text = "";
            txtName.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // SaveFeedBack();
            if(txtName.Text!="" && txtEmail.Text!="" && txtMessage.Text!="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Feedback Submitted.');", true);
                Reset();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Please enter all the fields.');", true);
            }
            
        }
    }
}