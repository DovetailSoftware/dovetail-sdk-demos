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
using System.Web.Security;

using FChoice.Common;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;
//using FCApp = FChoice.Foundation.Clarify.ClarifyApplication;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		private IClarifyApplication fcApp = ClarifyApplication.Instance;

		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.RadioButton userTypeContact;
		protected System.Web.UI.WebControls.Button loginButton;
		protected System.Web.UI.WebControls.Label msgLabel;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RadioButton userTypeUser;

		private void Page_Load(object sender, System.EventArgs e)
		{
			msgLabel.Text = "";

			

			if( IsPostBack )
			{

				Page.Validate();

				if( Page.IsValid )
				{

					ClarifySession sess;

					ClarifyLoginType loginType = userTypeContact.Checked ? ClarifyLoginType.Contact : ClarifyLoginType.User;

					try
					{
						sess = fcApp.CreateSession( username.Text, password.Text, loginType );
						Session["FCSessionID"] = sess.SessionID;

						FormsAuthentication.RedirectFromLoginPage(username.Text, true);
					}
					catch(FCInvalidLoginException)
					{
						msgLabel.Text = "Invalid username or password.";
					}

				}
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
