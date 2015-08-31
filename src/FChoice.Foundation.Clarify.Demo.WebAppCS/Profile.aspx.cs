using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using FChoice.Common;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	/// <summary>
	/// Summary description for Profile.
	/// </summary>
	public class Profile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label firstNameLabel;
		protected System.Web.UI.WebControls.Label lastNameLabel;
		protected System.Web.UI.WebControls.Label phoneLabel;
		protected System.Web.UI.WebControls.TextBox firstName;
		protected System.Web.UI.WebControls.TextBox lastName;
		protected System.Web.UI.WebControls.TextBox phone;
		protected System.Web.UI.WebControls.Button modifyButton;

		protected ClarifySession session;
		protected ClarifyDataSet dataSet;

		protected string userTable = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			//	On the first load of the page set the values of the labels
			//	and textboxes to the values contained in the session data.
			if( !IsPostBack)
			{
        firstNameLabel.Text = session[userTable + ".first_name"].ToString();
				lastNameLabel.Text = session[userTable + ".last_name"].ToString();
				phoneLabel.Text = session[userTable + ".phone"].ToString();

				firstName.Text = session[userTable + ".first_name"].ToString();
				lastName.Text = session[userTable + ".last_name"].ToString();
				phone.Text = session[userTable + ".phone"].ToString();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			//	Get the ClarifySession
			session = Global.GetFCSessionOrLogin();
			dataSet = new ClarifyDataSet(session);

			//	Get the name of the table that contains the name of current user
			userTable = session.LoginType == ClarifyLoginType.Contact ? "contact" : "employee";
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void modifyButton_Click(object sender, System.EventArgs e)
		{
			//	Create a generic to update user information
			ClarifyGeneric generic = dataSet.CreateGeneric( userTable );
			
			//  Query the record by the current users id
			generic.AppendFilter("objid", NumberOps.Equals, (int)session[ userTable + ".id"] );

			//	Select the fields to include in the query
			generic.DataFields.Add("first_name");
			generic.DataFields.Add("last_name");
			generic.DataFields.Add("phone");
				
			//	Execute the query
			generic.Query();

			//	Update the values of the fields from the data on the page
			generic[0]["first_name"] = firstName.Text;
			generic[0]["last_name"] = lastName.Text;
			generic[0]["phone"] = phone.Text;

			//	Update the record in the database
			generic[0].Update();

			//	Refresh the session context
			session.RefreshContext();

			//	Reload the page to show updated data
			Response.Redirect("profile.aspx", true);
		}
	}
}
