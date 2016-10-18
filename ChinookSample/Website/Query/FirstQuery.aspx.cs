using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChinookSystem.Security;

public partial class Query_FirstQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //are you logged in
            if(!Request.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            //are you allowed to be on this page
            else if(!User.IsInRole(SecurityRoles.WebsiteAdmin))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}