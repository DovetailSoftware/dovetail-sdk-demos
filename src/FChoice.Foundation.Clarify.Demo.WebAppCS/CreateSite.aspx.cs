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
using FChoice.Foundation.Clarify.DataObjects;

using FChoice.Toolkits.Clarify;
using FChoice.Toolkits.Clarify.Interfaces;

using FCLic = FChoice.Common.Licensing;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class CreateSite : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label message;
		protected System.Web.UI.WebControls.TextBox siteName;
		protected System.Web.UI.WebControls.TextBox address1;
		protected System.Web.UI.WebControls.TextBox address2;
		protected System.Web.UI.WebControls.TextBox city;
		protected System.Web.UI.WebControls.DropDownList state;
		protected System.Web.UI.WebControls.TextBox zip;
		protected System.Web.UI.WebControls.DropDownList country;
		protected System.Web.UI.WebControls.DropDownList timeZone;
		protected System.Web.UI.WebControls.Button createButton;
		protected System.Web.UI.HtmlControls.HtmlInputButton resetButton;
		protected System.Web.UI.WebControls.CustomValidator contactValidator;
		protected ClarifySession session;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!FCLic.LicenseManager.Instance.VerifyLicense(Global.INTERFACES_TOOLKIT_PRODUCT_ID))
			{
				this.message.Text = "License for InterfacesToolkit was not found.";
				DisableForm();
			}

			if(!IsPostBack)
			{
				DataBindCountry();
				DataBindState(country.SelectedValue);
				DataBindTimeZone(country.SelectedValue);
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			this.country.SelectedIndexChanged += new EventHandler(country_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void DataBindCountry()
		{
			//	Remove any previous items
			country.Items.Clear();

			//	Build country combo box
			foreach( Country listCountry in ClarifyApplication.Instance.LocaleCache.Countries )
			{
				country.Items.Add( listCountry.Name );
			}

			//	Select default country
			Country defaultCountry = ClarifyApplication.Instance.LocaleCache.GetDefaultCountry();

			if( country != null )
				country.SelectedValue = defaultCountry.Name;
		}

		private void DataBindState(string countryName)
		{
			//	Remove any previous items
			state.Items.Clear();

			//	Build state combo box
			foreach( StateProvince listState in ClarifyApplication.Instance.LocaleCache.GetStates( countryName ) )
			{
				state.Items.Add( listState.Name );
			}

			// Select default state
			StateProvince defaultState = ClarifyApplication.Instance.LocaleCache.GetDefaultState( countryName );

			if( defaultState != null )
				state.SelectedValue = defaultState.Name;
		}

		private void DataBindTimeZone(string countryName)
		{
			//	Remove any previous items
			timeZone.Items.Clear();

			//	Build state combo box
			foreach( FCTimeZone tz in ClarifyApplication.Instance.LocaleCache.GetTimeZonesInCountry( countryName ) )
			{
				timeZone.Items.Add( new ListItem( tz.FullName, tz.Name) );
			}

			// Select default time zone
			var defaultTimezone = ClarifyApplication.Instance.LocaleCache.GetDefaultTimeZone();

			if( defaultTimezone != null )
			{
				ListItem item = timeZone.Items.FindByValue( defaultTimezone.Name );

				if( item != null )
					timeZone.SelectedValue = defaultTimezone.Name;
			}

		}

		private void createButton_Click(object sender, System.EventArgs e)
		{
			Page.Validate();

			if(Page.IsValid)
			{
				try
				{
					// Create toolkit instance
					InterfacesToolkit toolkit = new InterfacesToolkit( session );

					ToolkitResult addressResult = toolkit.CreateAddress(address1.Text, city.Text,
						state.SelectedValue, zip.Text, country.SelectedValue, timeZone.SelectedValue);

					// Create setup parameter object with min required parameters.
					CreateSiteSetup setup = new CreateSiteSetup(SiteType.Customer,SiteStatus.Active, addressResult.Objid);

					// Set any additional information for creating the site
					setup.SiteName = siteName.Text;
					setup.SiteIDNum = session.GetNextNumScheme("Site ID");

					// Actually create the site
					ToolkitResult result = toolkit.CreateSite( setup );

					ResetFormData();
					message.Text = "Site created successfully with IDNum '" + result.IDNum + "'.";
				}
				catch(Exception ex)
				{
					message.Text = ex.Message;
				}
			}

		}

		protected void ResetFormData()
		{
			this.siteName.Text = "";
			this.address1.Text = "";
			this.address2.Text = "";
			this.city.Text = "";
			this.zip.Text = "";

			DataBindCountry();
		}

		protected void DisableForm()
		{
			this.siteName.Enabled = false;
			this.address1.Enabled = false;
			this.address2.Enabled = false;
			this.city.Enabled = false;
			this.zip.Enabled = false;
			this.country.Enabled = false;
			this.state.Enabled = false;
			this.timeZone.Enabled = false;

			this.siteName.CssClass = "disabled";
			this.address1.CssClass = "disabled";
			this.address2.CssClass = "disabled";
			this.city.CssClass = "disabled";
			this.zip.CssClass = "disabled";
			this.country.CssClass = "disabled";
			this.state.CssClass = "disabled";
			this.timeZone.CssClass = "disabled";

			createButton.Enabled = false;
			resetButton.Disabled = true;
		}

		private void country_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataBindState( country.SelectedValue );
			DataBindTimeZone( country.SelectedValue );
		}
	}
}
