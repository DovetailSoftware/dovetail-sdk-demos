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
using System.Text;

using FChoice.Common;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class Family : System.Web.UI.Page
	{
		private IClarifyApplication fcApp = ClarifyApplication.Instance;

		protected FCCompositeList familyList;
		protected FCDropDownList familyListItems;
		protected FCDropDownList lineListItems;

		protected Label familyLabel;
		protected Label lineLabel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//	Set the datasource of the control so that all the list can be built
			familyList.DataSource = fcApp.ListCache.HierarchicalStrings["family"];

			if( !IsPostBack )
			{
				//	Build the list and set it to the defaults
				familyList.DataBind();
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			//	Show the values of the selected items in the lists
			familyLabel.Text = familyListItems.SelectedValue;
			lineLabel.Text = lineListItems.SelectedValue;
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
