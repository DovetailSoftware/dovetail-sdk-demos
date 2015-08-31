namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.Security;

	/// <summary>
	///		This is the Side menu bar for the site
	/// </summary>
	public class SideMenu : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton logoutButton;

		private void Page_Load(object sender, System.EventArgs e)
		{

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void logoutButton_Click(object sender, System.EventArgs e)
		{
			//	Log the user out
			FormsAuthentication.SignOut();

			// Redirect back to the default page
			Response.Redirect("default.aspx", true);
		}
	}
}
