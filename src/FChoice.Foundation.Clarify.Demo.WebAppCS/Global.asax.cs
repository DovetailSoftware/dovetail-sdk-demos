using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using FChoice.Common;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		public const int INTERFACES_TOOLKIT_PRODUCT_ID = 101;
		public const int SUPPORT_TOOLKIT_PRODUCT_ID = 102;

		public static ClarifySession GetFCSessionOrLogin()
		{
			//	Check to see if the FCSessionID exists in the asp.net session
			if (HttpContext.Current.Session["FCSessionID"] != null)
			{
				//	return the ClarifySession for the FCSessionID
				return ClarifyApplication.Instance.GetSession((Guid) HttpContext.Current.Session["FCSessionID"]);
			}
			else
			{
				//	Signout an redirect to the default page
				FormsAuthentication.SignOut();
				HttpContext.Current.Response.Redirect("default.aspx", true);
			}

			return null;
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

		protected void Application_Start(Object sender, EventArgs e)
		{
			InitializeClarifyApplication();
		}

		private void InitializeClarifyApplication()
		{
			if (! ClarifyApplication.IsInitialized)
			{
				// Set working directory to the application path
				NameValueCollection envValues =
					new NameValueCollection(ConfigurationManager.AppSettings);

				envValues[ConfigValues.CACHE_FILE_PATH] = Path.Combine(
					Server.MapPath("."),
					CacheManager.FC_CACHE_PATH_SUFFIX);

				//	Initialize the application
				ClarifyApplication.Initialize(envValues);
			}
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			InitializeClarifyApplication();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			if (Session["FCSessionID"] != null)
			{
				ClarifySession sess = GetFCSessionOrLogin();
				sess.CloseSession();
			}
		}

		protected void Application_End(Object sender, EventArgs e)
		{
		}

		#region Web Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		#endregion
	}
}