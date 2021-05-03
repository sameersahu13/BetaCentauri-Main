using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Xml;

namespace Website
{
    public partial class Apply : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Server=185.52.53.206,2439;Database=RMS;User Id=BCPLRMS;Password=8yo2Jz4?;");
                SqlCommand cmd = new SqlCommand("select * from Qualification", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlQualification.DataSource = dt;
                ddlQualification.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string newline = "\r\n";
            string from = "betacentauri.career@gmail.com";
            string to = "hr@betacentauri.in";
            using (MailMessage mail = new MailMessage(from, to))
            {
                mail.Subject = "Job Application for " + Request.QueryString["data"].ToString() + " position";
                mail.Body = "Name: " + txtName.Text.ToString() + "" + newline +
                            "Email: " + txtEmail.Text.ToString() + "" + newline +
                            "MobileNo: " + txtMobileNo.Text.ToString() + "" + newline +
                            "Experience: " + ddlExperience.Text.ToString() + "" + newline +
                            "Qualification: " + ddlQualification.SelectedItem.Text.ToString() + "" + newline +
                            "Description: " + txtDescription.Text.ToString() + "";
                if (FileUpload1.HasFile)
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    mail.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, fileName));
                }
                mail.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(from, "career@4525");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            try
            {
                string file = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Resume/" + file));
                string Document = "../Resume/" + file;
                con = new SqlConnection(constr);
                    con.Open();
                    cmd = new SqlCommand("", con);
                    cmd.CommandText = "Registration";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CandidateName", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@Experience", ddlExperience.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@QualificationId", ddlQualification.Text.ToString());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.ToString());
                    cmd.Parameters.AddWithValue("@Resume", Document);
                    cmd.Parameters.AddWithValue("@AppliedPosition", Request.QueryString["data"].ToString());
                    cmd.Parameters.AddWithValue("@AppliedDate", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You Applied successfully.');", true);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    }
