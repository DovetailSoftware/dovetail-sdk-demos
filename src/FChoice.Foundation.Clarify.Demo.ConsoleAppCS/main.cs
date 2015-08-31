using System;
using System.Configuration;
using System.IO;
using System.Xml;

using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.Foundation.Clarify.Demo.ConsoleAppCS
{
	class main
	{
		private const string ADDRESS_PATH = @"address.xml";
		private static ClarifyApplication FCApp;

		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				// Initialize ClarifyApplication
				FCApp = ClarifyApplication.Initialize();

				// Create a new ClarifySession
				ClarifySession sess = FCApp.CreateSession();

				//Create a new ClarifyDataSet
				ClarifyDataSet ds = new ClarifyDataSet(sess);

				//	Create a new ClarifyGeneric object for address records
				ClarifyGeneric generic = ds.CreateGeneric("address");

				//	Check for address xml file
				if( !File.Exists(ADDRESS_PATH) )
				{
					Console.WriteLine("Unable to find \"{0}\".", ADDRESS_PATH);
					Console.WriteLine("Please ensure this file is in the same directory as the exe.");

					//	Exit application
					Console.WriteLine("Press Enter to exit...");
					Console.ReadLine();
					return;
				}

				//	Load address.xml into a XmlDocument
				XmlDocument doc = new XmlDocument();
				doc.Load(ADDRESS_PATH);

				//	Insert new address records into the database.
				InsertRecords(doc, generic);

				//	Exit application
				Console.WriteLine("Press Enter to exit...");
				Console.ReadLine();
			}
			catch( Exception ex )
			{
				Console.WriteLine("There was an unhandled exception when running the demo.");
				Console.WriteLine();
				Console.WriteLine(ex);
			}
		}


		private static void InsertRecords(XmlDocument doc, ClarifyGeneric generic)
		{
			IClarifyApplication FCApp = ClarifyApplication.Instance;

			bool isValid = true;
			int i = 0;

			//	Loop for each address record in the xml file
			foreach(XmlNode address in doc.SelectNodes("//addresses/address") )
			{
				i++;

				//	Get values of attributes
				string address1 = GetAttributeValue(address, "address1", i);
				string address2 = GetAttributeValue(address, "address2", i);
				string city = GetAttributeValue(address, "city", i);
				string state = GetAttributeValue(address, "state", i);
				string zip = GetAttributeValue(address, "zip", i);
				string country = GetAttributeValue(address, "country", i);
				string timezone = GetAttributeValue(address, "timezone", i);

				//	Check to see if the country, timezone, and state are valid
				isValid = isValid & IsValid(country, timezone, state, i);

				//	Only add new rows if all previous rows are valid
				if( isValid )
				{
					//	Add a new address row to the address generic
					GenericDataRow row = generic.AddNew();

					//	Set the field values of the new address row
					row["address"] = address1;
					row["address_2"] = address2;
					row["city"] = city;
					row["state"] = state;
					row["zipcode"] = zip;
					row["update_stamp"] = DateTime.Now;

					//	Relate this new row to existing records by relation and objid
					row.RelateByID( FCApp.LocaleCache.GetCountryObjID( country ), "address2country" );
					row.RelateByID( FCApp.LocaleCache.GetStateObjID( country, state ), "address2state_prov" );
					row.RelateByID( FCApp.LocaleCache.GetTimeZoneObjID( timezone ), "address2time_zone" );
				}

			}

			try
			{
				//	If all the records are valid then commit new rows to the database
				if( isValid )
				{
					//	Commit all the new rows to the database
					generic.UpdateAll();
					Console.WriteLine("Finished. Added {0} address records.", i);
				}
				else
				{
					Console.WriteLine("No records were added due to invalid data.");
				}
			}
			catch(Exception ex)
			{
				// Error inserting rows
				Console.WriteLine("Error adding new addresses.\n{0}", ex.Message);
			}
		}

		private static string GetAttributeValue(XmlNode node, string attribute, int rowNumber)
		{
			XmlAttribute att = node.Attributes[attribute];

			if ( att != null )
				return att.Value;
			else
			{
        Console.WriteLine(@"Warning: Missing attribute ""{0}"" on address element {1}", attribute, rowNumber);
				return "";
			}
		}

		private static bool IsValid(string country, string timezone, string state, int rowNumber)
		{
			bool isValid = true;

			// Check Country
			if( !FCApp.LocaleCache.IsCountry( country ) )
			{
				Console.WriteLine("Invalid country on address element {0} - {1}", rowNumber, country);
				isValid = false;
			}

			//	Check TimeZone
			if(FCApp.LocaleCache.IsCountry( country ) && !FCApp.LocaleCache.IsTimeZoneInCountry( country, timezone, true ) )
			{
				Console.WriteLine("Invalid timezone on address element {0} - {1}", rowNumber, timezone);
				isValid = false;
			}

			//	Check State
			if( !FCApp.LocaleCache.IsState( country, state ) )
			{
				Console.WriteLine("Invalid state on address element {0} - {1}", rowNumber, state);
				isValid = false;
			}

			return isValid;
		}
	}
}
