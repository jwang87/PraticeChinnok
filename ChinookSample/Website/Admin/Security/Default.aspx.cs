﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region
using ChinookSystem.Security;
#endregion

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void RoleListView_ItemDeleted(object sender, ListViewDeletedEventArgs e)
    //{
    //    DataBind();
    //}

    //protected void RoleListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
    //{
    //    DataBind();
    //}

    protected void RefreshAll(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UnregisteredUsersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //position the gridview to the selectedindex (row) that caused 
        //the postback
        UnregisteredUsersGridView.SelectedIndex = e.NewSelectedIndex;

        //setup a variable that will be the the physical pointer to the selected row
        GridViewRow agvrow = UnregisteredUsersGridView.SelectedRow;

        //you can already check a pointer to see if something has been
        //obtained
        if (agvrow != null)
        {
            //access info contained in a textbox on the gv row
            //use the method .FindConrol("contorlidName") as controltype
            //once you have a pointer to the control, you can access the
            //     data content of the control using the control's access method
            string assignedusername = "";
            TextBox inputControl = agvrow.FindControl("AssignedUserName") as TextBox;
            if (inputControl != null)
            {
                assignedusername = inputControl.Text;
            }

            string assignedEmail = (agvrow.FindControl("AssignedEmail") as TextBox).Text;

            //create the UnregisteredUser instance
            //during creation, i will pass it the needed data
            //to load the instance attribute

            //accessing boundfeilds on a gridview row uses .Cells[index].Text
            //index represents the column of the grid
            //columns are index (string at 0)
            UnregisteredUserProfile user = new UnregisteredUserProfile()
            {
                UserId = int.Parse(UnregisteredUsersGridView.SelectedDataKey.Value.ToString()),
                UserTpye = (UnRegisteredUserType)Enum.Parse(typeof(UnRegisteredUserType), agvrow.Cells[1].Text),
                FirstName = agvrow.Cells[2].Text,
                LastName = agvrow.Cells[3].Text,
                Email = assignedEmail
            };
            //register the user via the Chinook.UserManager controller
            UserManager sysmgr = new UserManager();
            sysmgr.RegisterUser(user);

            //assume successful creation of a user
            //refresh the form
            DataBind();
        }
    }
}