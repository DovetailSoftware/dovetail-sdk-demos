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
using FChoice.Toolkits.Clarify;
using FChoice.Toolkits.Clarify.Support;

using FCLic = FChoice.Common.Licensing;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class CreateCase : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label message;
		protected System.Web.UI.WebControls.TextBox siteID;
		protected System.Web.UI.WebControls.TextBox firstName;
		protected System.Web.UI.WebControls.TextBox lastName;
		protected System.Web.UI.WebControls.TextBox phone;
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.TextBox notes;
		protected System.Web.UI.WebControls.Button createButton;
		protected System.Web.UI.HtmlControls.HtmlInputButton resetButton;
		protected System.Web.UI.WebControls.CustomValidator contactValidator;
		protected ClarifySession session;
		protected ClarifyDataSet dataSet;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!FCLic.LicenseManager.Instance.VerifyLicense(Global.SUPPORT_TOOLKIT_PRODUCT_ID))
			{
				this.message.Text = "License for SupportToolkit was not found.";
				DisableForm();
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void createButton_Click(object sender, System.EventArgs e)
		{
			Page.Validate();

			if(Page.IsValid)
			{
				try
				{
					// Create toolkit instance
					SupportToolkit toolkit = new SupportToolkit( session );

					// Create setup parameter object with min required parameters.
					CreateCaseSetup setup = new CreateCaseSetup( this.siteID.Text, this.firstName.Text,
						this.lastName.Text, this.phone.Text );

					// Set any additional information for creating the case
					setup.Title = this.title.Text;
					setup.PhoneLogNotes = this.notes.Text;

					// Set any additional fields using the AdditionalFields property of the setup object
					setup.AdditionalFields.Append("alt_address", AdditionalFieldType.String, "Test");

					// Actually create the case
					ToolkitResult result = toolkit.CreateCase( setup );

					ResetFormData();
					message.Text = "Case created successfully with IDNum '" + result.IDNum + "'.";
				}
				catch(Exception ex)
				{
					message.Text = ex.Message;
				}
			}

		}

		protected void ResetFormData()
		{
			this.siteID.Text = "";
			this.firstName.Text = "";
			this.lastName.Text = "";
			this.phone.Text = "";
			this.title.Text = "";
			this.notes.Text = "";


		}

		protected void DisableForm()
		{
			this.siteID.Enabled = false;
			this.firstName.Enabled = false;
			this.lastName.Enabled = false;
			this.phone.Enabled = false;
			this.title.Enabled = false;
			this.notes.Enabled = false;

			this.siteID.CssClass = "disabled";
			this.firstName.CssClass = "disabled";
			this.lastName.CssClass = "disabled";
			this.phone.CssClass = "disabled";
			this.title.CssClass = "disabled";
			this.notes.CssClass = "disabled";

			createButton.Enabled = false;
			resetButton.Disabled = true;
		}

		protected void DoesSiteExist( object source, ServerValidateEventArgs args )
		{
			ClarifyGeneric siteGeneric = dataSet.CreateGeneric("site");
			siteGeneric.AppendFilter("site_id", StringOps.Equals, args.Value );
			siteGeneric.Query();

			args.IsValid = siteGeneric.Rows.Count > 0;
		}

		protected void DoesContactExist( object source, ServerValidateEventArgs args )
		{
			ClarifyGeneric contactGeneric = dataSet.CreateGeneric("contact");
			contactGeneric.AppendFilter("first_name", StringOps.Equals, firstName.Text );
			contactGeneric.AppendFilter("last_name", StringOps.Equals, lastName.Text );
			contactGeneric.AppendFilter("phone", StringOps.Equals, phone.Text );
			contactGeneric.Query();

			args.IsValid = contactGeneric.Rows.Count > 0;
		}
	}
}
