using System;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.Foundation.Clarify.Demo.WinAppCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class addressForm : System.Windows.Forms.Form
	{
		private ClarifyApplication FCApp;
		private ClarifySession session;
		private ClarifyDataSet dataSet;

		private System.Windows.Forms.Label addAddressLabel;
		private System.Windows.Forms.TextBox address;
		private System.Windows.Forms.TextBox address2;
		private System.Windows.Forms.TextBox city;
		private System.Windows.Forms.ComboBox country;
		private System.Windows.Forms.ComboBox state;
		private System.Windows.Forms.ComboBox timeZone;
		private System.Windows.Forms.TextBox zipCode;
		private System.Windows.Forms.Label addressLabel;
		private System.Windows.Forms.Label addressLabel2;
		private System.Windows.Forms.Label cityLabel;
		private System.Windows.Forms.Label zipcodeLabel;
		private System.Windows.Forms.Label countryLabel;
		private System.Windows.Forms.Label stateLabel;
		private System.Windows.Forms.Label timeZoneLabel;
		private System.Windows.Forms.Button addAddress;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public addressForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			try
			{
				FCApp = ClarifyApplication.Initialize();

				//this.addAddressLabel.Text = String.Format("Add an Address to the database: {0}", SchemaCache.c );

				//	Create a new ClarifySession
				this.session = FCApp.CreateSession();
				this.dataSet = new ClarifyDataSet(session);

				state.DropDownStyle = ComboBoxStyle.DropDownList;
				country.DropDownStyle = ComboBoxStyle.DropDownList;
				timeZone.DropDownStyle = ComboBoxStyle.DropDownList;

				FillCountryDropDown();
				FillStateDropDown( country.SelectedItem.ToString() );
				FillTimeZoneDropDown( country.SelectedItem.ToString() );

			}
			catch(Exception ex)
			{
				string errorMsg = string.Format("Trouble populating form:\n\n{0}", ex.Message);
				MessageBox.Show(errorMsg, "Demo Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		}

		private void FillCountryDropDown()
		{
			//	Remove any previous items
			country.Items.Clear();

			//	Build country combo box
			foreach( Country listCountry in FCApp.LocaleCache.Countries )
			{
				country.Items.Add( listCountry.Name );
			}

			//	Select default country
			country.SelectedItem = FCApp.LocaleCache.GetDefaultCountry().Name;
		}

		private void FillStateDropDown(string countryName)
		{
			//	Remove any previous items
			state.Items.Clear();

			//	Build state combo box
			foreach( StateProvince listState in FCApp.LocaleCache.GetStates( countryName ) )
			{
				state.Items.Add( listState.Name );
			}

			// Select default state
			state.SelectedItem = FCApp.LocaleCache.GetDefaultState( countryName ).Name;
		}

		private void FillTimeZoneDropDown(string countryName)
		{
			//	Remove any previous items
			timeZone.Items.Clear();

			//	Build state combo box
			foreach( FCTimeZone tz in FCApp.LocaleCache.GetTimeZonesInCountry( countryName ) )
			{
				timeZone.Items.Add( tz.FullName );
			}

			// Select default state
			timeZone.SelectedItem = FCApp.LocaleCache.GetDefaultTimeZone().FullName;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.addAddressLabel = new System.Windows.Forms.Label();
			this.address = new System.Windows.Forms.TextBox();
			this.address2 = new System.Windows.Forms.TextBox();
			this.city = new System.Windows.Forms.TextBox();
			this.country = new System.Windows.Forms.ComboBox();
			this.state = new System.Windows.Forms.ComboBox();
			this.timeZone = new System.Windows.Forms.ComboBox();
			this.zipCode = new System.Windows.Forms.TextBox();
			this.addressLabel = new System.Windows.Forms.Label();
			this.addressLabel2 = new System.Windows.Forms.Label();
			this.cityLabel = new System.Windows.Forms.Label();
			this.zipcodeLabel = new System.Windows.Forms.Label();
			this.countryLabel = new System.Windows.Forms.Label();
			this.stateLabel = new System.Windows.Forms.Label();
			this.timeZoneLabel = new System.Windows.Forms.Label();
			this.addAddress = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// addAddressLabel
			// 
			this.addAddressLabel.Location = new System.Drawing.Point(8, 8);
			this.addAddressLabel.Name = "addAddressLabel";
			this.addAddressLabel.Size = new System.Drawing.Size(152, 16);
			this.addAddressLabel.TabIndex = 0;
			this.addAddressLabel.Text = "Add an address to database:";
			// 
			// address
			// 
			this.address.Location = new System.Drawing.Point(112, 40);
			this.address.Name = "address";
			this.address.Size = new System.Drawing.Size(240, 20);
			this.address.TabIndex = 1;
			this.address.Text = "";
			// 
			// address2
			// 
			this.address2.Location = new System.Drawing.Point(112, 72);
			this.address2.Name = "address2";
			this.address2.Size = new System.Drawing.Size(240, 20);
			this.address2.TabIndex = 2;
			this.address2.Text = "";
			// 
			// city
			// 
			this.city.Location = new System.Drawing.Point(112, 104);
			this.city.Name = "city";
			this.city.Size = new System.Drawing.Size(144, 20);
			this.city.TabIndex = 3;
			this.city.Text = "";
			// 
			// country
			// 
			this.country.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.country.Location = new System.Drawing.Point(112, 168);
			this.country.Name = "country";
			this.country.Size = new System.Drawing.Size(144, 21);
			this.country.TabIndex = 5;
			this.country.SelectionChangeCommitted += new System.EventHandler(this.country_SelectionChangeCommitted);
			// 
			// state
			// 
			this.state.Location = new System.Drawing.Point(112, 200);
			this.state.Name = "state";
			this.state.Size = new System.Drawing.Size(144, 21);
			this.state.TabIndex = 6;
			// 
			// timeZone
			// 
			this.timeZone.Location = new System.Drawing.Point(112, 232);
			this.timeZone.Name = "timeZone";
			this.timeZone.Size = new System.Drawing.Size(144, 21);
			this.timeZone.TabIndex = 7;
			// 
			// zipCode
			// 
			this.zipCode.Location = new System.Drawing.Point(112, 136);
			this.zipCode.Name = "zipCode";
			this.zipCode.Size = new System.Drawing.Size(144, 20);
			this.zipCode.TabIndex = 4;
			this.zipCode.Text = "";
			// 
			// addressLabel
			// 
			this.addressLabel.Location = new System.Drawing.Point(8, 40);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.TabIndex = 8;
			this.addressLabel.Text = "Address";
			// 
			// addressLabel2
			// 
			this.addressLabel2.Location = new System.Drawing.Point(8, 72);
			this.addressLabel2.Name = "addressLabel2";
			this.addressLabel2.TabIndex = 9;
			this.addressLabel2.Text = "Address 2";
			// 
			// cityLabel
			// 
			this.cityLabel.Location = new System.Drawing.Point(8, 104);
			this.cityLabel.Name = "cityLabel";
			this.cityLabel.TabIndex = 10;
			this.cityLabel.Text = "City";
			// 
			// zipcodeLabel
			// 
			this.zipcodeLabel.Location = new System.Drawing.Point(8, 136);
			this.zipcodeLabel.Name = "zipcodeLabel";
			this.zipcodeLabel.TabIndex = 11;
			this.zipcodeLabel.Text = "Zipcode";
			// 
			// countryLabel
			// 
			this.countryLabel.Location = new System.Drawing.Point(8, 168);
			this.countryLabel.Name = "countryLabel";
			this.countryLabel.TabIndex = 12;
			this.countryLabel.Text = "Country";
			// 
			// stateLabel
			// 
			this.stateLabel.Location = new System.Drawing.Point(8, 200);
			this.stateLabel.Name = "stateLabel";
			this.stateLabel.TabIndex = 13;
			this.stateLabel.Text = "State";
			// 
			// timeZoneLabel
			// 
			this.timeZoneLabel.Location = new System.Drawing.Point(8, 232);
			this.timeZoneLabel.Name = "timeZoneLabel";
			this.timeZoneLabel.TabIndex = 14;
			this.timeZoneLabel.Text = "TimeZone";
			// 
			// addAddress
			// 
			this.addAddress.Location = new System.Drawing.Point(272, 288);
			this.addAddress.Name = "addAddress";
			this.addAddress.Size = new System.Drawing.Size(80, 23);
			this.addAddress.TabIndex = 8;
			this.addAddress.Text = "Add Address";
			this.addAddress.Click += new System.EventHandler(this.addAddress_Click);
			// 
			// addressForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 326);
			this.Controls.Add(this.addAddress);
			this.Controls.Add(this.timeZoneLabel);
			this.Controls.Add(this.stateLabel);
			this.Controls.Add(this.countryLabel);
			this.Controls.Add(this.zipcodeLabel);
			this.Controls.Add(this.cityLabel);
			this.Controls.Add(this.addressLabel2);
			this.Controls.Add(this.addressLabel);
			this.Controls.Add(this.zipCode);
			this.Controls.Add(this.timeZone);
			this.Controls.Add(this.state);
			this.Controls.Add(this.country);
			this.Controls.Add(this.city);
			this.Controls.Add(this.address2);
			this.Controls.Add(this.address);
			this.Controls.Add(this.addAddressLabel);
			this.Name = "addressForm";
			this.Text = "Address Form";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.addressForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new addressForm());
		}

		private void country_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			FillStateDropDown( country.SelectedItem.ToString() );
			FillTimeZoneDropDown( country.SelectedItem.ToString() );
		}

		private void addressForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void addAddress_Click(object sender, System.EventArgs e)
		{
			if( this.address.Text.Trim().Length == 0 )
			{
				MessageBox.Show("You must fill in the address.");
				this.address.Focus();
				return;
			}

			if( this.address2.Text.Trim().Length == 0 )
			{
				MessageBox.Show("You must fill in the address 2.");
				this.address2.Focus();
				return;
			}

			if( this.city.Text.Trim().Length == 0 )
			{
				MessageBox.Show("You must fill in the city.");
				this.city.Focus();
				return;
			}

			if( this.zipCode.Text.Trim().Length == 0 )
			{
				MessageBox.Show("You must fill in the ZipCode.");
				this.zipCode.Focus();
				return;
			}

			//	Create new address generic
			ClarifyGeneric addressGen = dataSet.CreateGeneric("address");

			//	Add a new row to the address generic
			GenericDataRow addressRow = addressGen.AddNew();
			
			//	Set the values of the fields of the generic row
			addressRow["address"] = address.Text.Trim();
			addressRow["address_2"] = address2.Text.Trim();
			addressRow["city"] = city.Text.Trim();
			addressRow["state"] = state.SelectedItem.ToString().Trim();
			addressRow["city"] = city.Text.Trim();
			addressRow["zipcode"] = zipCode.Text.Trim();
			addressRow["update_stamp"] = session.GetCurrentDate();

			//	Relate this new row to existing records by relation and objid
			addressRow.RelateByID( FCApp.LocaleCache.GetCountryObjID( country.SelectedItem.ToString() ), "address2country" );
			addressRow.RelateByID( FCApp.LocaleCache.GetStateObjID( country.SelectedItem.ToString(), state.SelectedItem.ToString() ), "address2state_prov" );
			addressRow.RelateByID( FCApp.LocaleCache.GetTimeZoneObjID( timeZone.SelectedItem.ToString() ), "address2time_zone" );

			//	Commit the new row to the database
			addressRow.Update();

			MessageBox.Show("Address successfully added.");
		}
	}
}

