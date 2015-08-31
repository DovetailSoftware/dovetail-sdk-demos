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

	public class MyOpenCases : System.Web.UI.UserControl
	{
		#region Page Controls
		protected DataGrid openCasesGrid;
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack )
			{
				this.DataBind();
			}
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

			//	Set the filter for query the records
			caseGeneric.AppendFilter( "owner", StringOps.Equals, session.UserName);
			caseGeneric.AppendFilter( "condition", StringOps.Like, "Open%");

			//	Set the sorting for the results
			caseGeneric.AppendSort( "creation_time", false );

			//	Query the results
			caseGeneric.Query();

			//	Set the datasource of the grid to the generic
			this.openCasesGrid.DataSource = caseGeneric;

			//	Build the DataGrid by calling DataBind()
			this.openCasesGrid.DataBind();
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
			this.openCasesGrid.PageIndexChanged += new DataGridPageChangedEventHandler(openCasesGrid_PageIndexChanged);
		}
		#endregion

		private void openCasesGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			//	Set the selected page of the grid
			this.openCasesGrid.CurrentPageIndex = e.NewPageIndex;

			//	ReBind the grid to update the display
			this.DataBind();
		}
	}
}
