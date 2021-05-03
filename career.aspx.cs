using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class career : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApply1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobApplication.aspx?data=" + Label1.Text);
        }

        //protected void btnApply2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("JobApplication.aspx?data=" + Label2.Text);
        //}

        //protected void btnApply3_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("JobApplication.aspx?data=" + Label3.Text);
        //}

        //protected void btnApply4_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("JobApplication.aspx?data=" + Label4.Text);
        //}
    }
}