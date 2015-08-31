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

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class cr_desc : System.Web.UI.Page
	{
		private IClarifyApplication fcApp = ClarifyApplication.Instance;

		protected FCCompositeList crdescList;
		protected FCDropDownList cpuListItems;
		protected FCDropDownList osListItems;
		protected FCDropDownList memoryListItems;

		protected Label cpuLabel;
		protected Label osLabel;
		protected Label memoryLabel;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//	Set the datasource of the control so that all the list can be built
			crdescList.DataSource = fcApp.ListCache.HierarchicalStrings["cr_desc"];

			if( !IsPostBack )
			{
				//	Build the list and set it to the defaults
				crdescList.DataBind();

				// Override the defaults by setting the selected values
				cpuListItems.SelectedValue = "SUN";
				osListItems.SelectedValue = "Sparc 10";
				memoryListItems.SelectedValue = "256m";
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			//	Show the values of the selected items in the lists
			cpuLabel.Text = cpuListItems.SelectedValue;
			osLabel.Text = osListItems.SelectedValue;
			memoryLabel.Text = memoryListItems.SelectedValue;
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
