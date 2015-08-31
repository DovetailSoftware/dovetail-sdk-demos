using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using FChoice.Common;
using FChoice.Foundation;
using FChoice.Foundation.Clarify;
using FChoice.Foundation.Clarify.DataObjects;

namespace FChoice.Foundation.Clarify.Demo.WebAppCS
{
	public class FCDropDownList : DropDownList, IPostBackDataHandler
	{
		private IHierarchicalStringElementCollection compositeListDataSource;

		private FCDropDownList parentDropDownList;
		private FCDropDownList childDropDownList;
		private FCCompositeList parentCompositeList;
		private string postedSelectedValue = null;

		public FCDropDownList ParentDropDownList
		{
			get{ return parentDropDownList; }
			set{ parentDropDownList = value; }
		}

		public FCDropDownList ChildDropDownList
		{
			get{ return childDropDownList; }
			set{ childDropDownList = value; }
		}

		public FCCompositeList ParentCompositeList
		{
			get{ return parentCompositeList; }
			set{ parentCompositeList = value; }
		}

		public IHierarchicalStringElementCollection CompositeListDataSource
		{
			get{ return compositeListDataSource; }
			set
			{ 
				compositeListDataSource = value;
				if( this.compositeListDataSource != null && childDropDownList != null )
				{
					if( this.SelectedIndex == -1 && compositeListDataSource.DefaultElement != null )
						childDropDownList.compositeListDataSource = compositeListDataSource.DefaultElement.Elements;
					else
					{
						int selected = this.SelectedIndex > -1 ? this.SelectedIndex : 0;
						childDropDownList.compositeListDataSource = compositeListDataSource[selected].Elements;
					}
				}
			}
		}

		public override int SelectedIndex
		{
			get
			{
				return base.SelectedIndex;
			}
			set
			{
				base.SelectedIndex = value;
				DataBindChildList();
			}
		}


		public override string SelectedValue
		{
			get
			{
				return base.SelectedValue;
			}
			set
			{
				base.SelectedValue = value;
				DataBindChildList();
			}
		}


		public void DataBindChildList()
		{
			if( this.compositeListDataSource != null && childDropDownList != null )
			{
				childDropDownList.compositeListDataSource = compositeListDataSource[this.SelectedValue].Elements;
				childDropDownList.DataBind();

				if( childDropDownList.postedSelectedValue != null)
				{
					if(childDropDownList.Items.FindByValue(childDropDownList.postedSelectedValue) != null)
						childDropDownList.SelectedValue = childDropDownList.postedSelectedValue;
				}

				childDropDownList.DataBindChildList();
			}
		}

		
		protected override void OnDataBinding(EventArgs e)
		{
			//base.OnDataBinding (e);

			if( this.compositeListDataSource != null )
			{
				this.Items.Clear();

				foreach(IHierarchicalStringElement element in compositeListDataSource)
				{
					ListItem item = new ListItem( element.Title, element.Title );
					item.Selected = element.IsDefault;

					this.Items.Add( item );
				}
			}
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged (e);
			DataBindChildList();
		}
		#region IPostBackDataHandler Members

		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			this.OnSelectedIndexChanged(EventArgs.Empty);
		}

		bool IPostBackDataHandler.LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			int num1 = -1;
			string[] textArray1 = postCollection.GetValues(postDataKey);
			if (textArray1 != null)
			{
				this.postedSelectedValue = textArray1[0];

				//num1 = this.Items.FindByValueInternal(textArray1[0]);
				foreach( ListItem item in this.Items )
				{
					if( item.Value == textArray1[0] )
						num1 = this.Items.IndexOf( item );
				}

				if (this.SelectedIndex != num1)
				{
					this.SelectedIndex = num1;
					return true;
				}
			}
			return false;
		}

		#endregion
	}
}
