namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	using System;
	using System.Configuration;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	using FChoice.Common;
	using FChoice.Foundation;
	using FChoice.Foundation.Clarify;
	
	public class CasesCreatedInLastXDays : System.Web.UI.UserControl
	{
		private IClarifyApplication fcApp = ClarifyApplication.Instance;

		#region Page Controls
		protected Label daysLabel;
		protected DataGrid casesCreatedGrid;
		#endregion

		#region Public Properties

		/// <summary>
		/// Stores how many days back to retrieve cases.
		/// The default is 5 days.
		/// </summary>
		public int DaysBack
		{
			get{ return ViewState["DaysBack"] != null ? (int)ViewState["DaysBack"] : 5; }
			set{ ViewState["DaysBack"] = value; }
		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
				this.DataBind();
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			// Display DaysBack to user
			this.daysLabel.Text = this.DaysBack.ToString();
		}

		public override void DataBind()
		{
			base.DataBind ();

			//	Get the ClarifySession for the current user
			ClarifySession session = Global.GetFCSessionOrLogin();
			ClarifyDataSet dataSet = new ClarifyDataSet(session);


			//	Create a generic for the view "qry_case_view"
			ClarifyGeneric caseGeneric = dataSet.CreateGeneric("qry_case_view");

			//	Set the DataFields to return in the result set of the query
			caseGeneric.DataFields.AddRange( 
				new string[]{"id_number","site_name","title","condition","status","creation_time","owner"} );

			//	Set the filter for querying the records
			caseGeneric.AppendFilter( "creation_time", DateOps.MoreThanOrEqual, DateTime.Now.AddDays(DaysBack * -1) );

			//	Set the sorting for the results
			caseGeneric.AppendSort( "creation_time", false );

			//	Query the results
			caseGeneric.Query();

			//	Set the datasource of the grid to the generic
			this.casesCreatedGrid.DataSource = caseGeneric;

			//	Build the DataGrid by calling DataBind()
			this.casesCreatedGrid.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.casesCreatedGrid.PageIndexChanged += new DataGridPageChangedEventHandler(casesCreatedGrid_PageIndexChanged);
		}
		#endregion

		private void casesCreatedGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			//	Set the selected page of the grid
			this.casesCreatedGrid.CurrentPageIndex = e.NewPageIndex;

			//	ReBind the grid to update the display
			this.DataBind();
		}
	}
}
