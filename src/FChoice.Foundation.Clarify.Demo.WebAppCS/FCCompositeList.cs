using System;
using System.Collections;
using System.Web.UI;
using System.Text;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class FCCompositeList : Control
	{
		protected IHierarchicalStringList dataSource;
		protected string dropDownListIDs = "";
		protected ArrayList dropdownLists = new ArrayList();
		protected bool enableClientScript = true;

		public string FCDropDownListIDs
		{
			get{ return dropDownListIDs; }
			set{ dropDownListIDs = value; }
		}

		public bool EnableClientScript
		{
			get{ return enableClientScript; }
			set{ enableClientScript = value; }
		}

		public IHierarchicalStringList DataSource
		{
			get{ return dataSource; }
			set
			{ 
				dataSource = value;

				if( this.dataSource != null && dropdownLists.Count > 0)
				{
					((FCDropDownList)dropdownLists[0]).CompositeListDataSource = dataSource.Elements;
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			string[] dropdowns = dropDownListIDs.Split(',');

			foreach( string dropdownID in dropdowns )
			{
				if( dropdownID.Trim().Length > 0 )
				{
					FCDropDownList ddl = (FCDropDownList)this.Parent.FindControl(dropdownID.Trim());

					if( ddl == null )
						throw new InvalidOperationException("Cannot find FCDropDownList control with an ID of " + dropdownID.Trim());

					dropdownLists.Add( ddl );
				}
			}

			if( dropdownLists.Count > 0 )
				((FCDropDownList)dropdownLists[0]).ParentCompositeList = this;
        
			for(int i=0;i<dropdownLists.Count-1;i++)
			{
				((FCDropDownList)dropdownLists[i]).ChildDropDownList = ((FCDropDownList)dropdownLists[i+1]);
				((FCDropDownList)dropdownLists[i+1]).ParentDropDownList = ((FCDropDownList)dropdownLists[i]);
			}

			base.OnInit (e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			if( this.enableClientScript )
			{
				if( this.dataSource != null )
				{
					RegisterJSBaseScript();
					RegisterJSLists();
					RegisterJSInitFunction();
				}
			}
			else
			{
				for(int i=0;i<dropdownLists.Count;i++)
				{
					if( i < dropdownLists.Count-1)
						((FCDropDownList)dropdownLists[i]).AutoPostBack = true;
				}
			}
		}

		#region Javascript Helper methods
		private void RegisterJSBaseScript()
		{
			#region Javascript
			string jsBaseScript =
				@"<script language=""javascript"">

	function _addHandler(target, eventName, handler, capture) 
	{  
		capture = (capture) ? capture : false;  
		if ( target.addEventListener ) 
			target.addEventListener(eventName, handler, capture);  
		else if ( target.attachEvent ) 
			target.attachEvent('on' + eventName, handler); 
	}  

	function CompositeList(title, isDefault, listID)
	{
		this.list = null;
		
		this.title = title;
		
		this.isDefault = isDefault != null ? isDefault : false;
		this.listID = listID != null ? listID : '';
			
		this.lists = new Array();
		
		this.defaultSubListTitle = '';
	}
	
	CompositeList.prototype.getChildList = function( title )
	{
		for(i=0;i<this.lists.length;i++)
		{
			if( title == this.lists[i].title )
				return this.lists[i];
		}	

		return null;	
	}
	
	CompositeList.prototype.getDefaultChildList = function()
	{
		for(i=0;i<this.lists.length;i++)
		{
			if( defaultSubListTitle == this.lists[i].title )
				return this.lists[i];
		}	

		return null;	
	}	
	
	function fillDDL( ddl, list)
	{
		ddl.list = list;
		ddl.innerHTML = '';

		var agt=navigator.userAgent.toLowerCase();
		var is_ie = ((agt.indexOf('msie') != -1) && (agt.indexOf('opera') == -1));
		
		for(i=0;i<list.lists.length;i++)
		{
			option = document.createElement('OPTION');
			option.text = list.lists[i].title;
			option.value = list.lists[i].title;
			if(is_ie)
				ddl.add(option);
			else
				ddl.appendChild(option);
			
			if( list.lists[i].isDefault )
			{
				list.defaultSubListTitle = list.lists[i].title;
				ddl.selectedIndex = i;
			}				
		}
		
		if( ddl.childDDL != null && ddl.childDDL.length > 0)
			fillDDL( ddl.childDDL, list.getChildList(ddl.value))
	}
	
	function fillChildDDL(e)
	{
		//handy script from http://www.quirksmode.org/js/events_properties.html
		var targ;
		if (!e) var e = window.event;
		if (e.target) targ = e.target;
		else if (e.srcElement) targ = e.srcElement;
		if (targ.nodeType == 3) // defeat Safari bug
			targ = targ.parentNode;


		ddl = targ;

		if(!ddl.list)
			ddl.list = getMasterListByListID( ddl.listID );

		fillDDL( ddl.childDDL, ddl.list.getChildList(ddl.value) );
	}

	function getMasterListByListID( listID )
	{
		for(i=0;i<FCCompositeLists.length;i++)
		{
			//alert(listID + ' - ' + FCCompositeLists[i].listID);
			if( listID == FCCompositeLists[i].listID )
				return FCCompositeLists[i];
		}	

		//alert('did not find list :' + listID);

		return null;
	}	
</script>";
			ClientScriptManager cs = Page.ClientScript;
			cs.RegisterClientScriptBlock(this.GetType(), "FCCompositeList", jsBaseScript);
			#endregion
		}

		private void RegisterJSLists()
		{
			StringBuilder scriptOutput = new StringBuilder();

			int i = 0;
			foreach(IHierarchicalStringElement element in dataSource.Elements)
			{
				BuildJSLists( element, scriptOutput, this.ClientID + "_List", i );
				i++;
			}

			#region Javascript
			string jsLists =
				string.Format(
					@"<script language=""javascript"">{0}_List = new CompositeList('{1}', false, '{2}_List');{3}</script>",
					this.ClientID, dataSource.Title, this.ClientID, scriptOutput);

			ClientScriptManager cs = Page.ClientScript;
			cs.RegisterClientScriptBlock(this.GetType(), "FCCompositeList_", jsLists);
			#endregion

		}

		private void RegisterJSInitFunction()
		{
			StringBuilder sb = new StringBuilder();

			#region Javascript
			sb.AppendFormat(@"
<script language=""javascript"">
function init_{0}()
{1}
{2}
{3}
_addHandler(window, 'load', init_{0}, false) 
</script>", ClientID, "{", BuildJSListAssignments(), "}" );
			#endregion

			ClientScriptManager cs = Page.ClientScript;
			cs.RegisterClientScriptBlock(this.GetType(), "init_" + this.ClientID, sb.ToString());
		}

		private string BuildJSListAssignments()
		{
			StringBuilder sb = new StringBuilder();

			string baseListName = string.Format("{0}_List", ClientID );
			sb.Append("var parentList, childList;\n");
					
			for( int i=0; i< this.dropdownLists.Count; i++ )
			{
				sb.Append("parentList = document.getElementById('" + ((FCDropDownList)dropdownLists[i]).ClientID + "');\n");
		
				if( i != this.dropdownLists.Count-1 )
				{
					sb.Append("childList = document.getElementById('" + ((FCDropDownList)dropdownLists[i+1]).ClientID + "');\n");
					sb.Append("_addHandler(parentList, 'change', fillChildDDL, false);\n" );
					sb.Append("parentList.childDDL = childList;\n" );
				}

				sb.Append("parentList.list = " + baseListName);
				for( int t=0; t<i; t++ )
				{
					sb.Append( GetJSListLevel(t) );
				}

				sb.Append(";\n");
			}
			return sb.ToString();
		}

		private string GetJSListLevel(int level)
		{
			return string.Format(".lists[{0}]", ((FCDropDownList)dropdownLists[level]).SelectedIndex);
		}

		private void BuildJSLists(IHierarchicalStringElement element, StringBuilder sb, string parentList, int index)
		{
			string item = string.Format( "{0}.lists[{1}]", parentList, index);
			sb.AppendFormat("{0} = new CompositeList('{1}'{2});\n", item, element.Title, element.IsDefault ? ", true" : "");

			int childIndex = 0;
			foreach(IHierarchicalStringElement childElement in element.Elements )
			{
				BuildJSLists( childElement, sb, item, childIndex );
				childIndex++;
			}
		}
		#endregion

		public override void DataBind()
		{
			base.DataBind ();

			if( this.dataSource != null && dropdownLists.Count > 0)
			{
				((FCDropDownList)dropdownLists[0]).DataBind();
				((FCDropDownList)dropdownLists[0]).DataBindChildList();
			}
		}
	}
}
