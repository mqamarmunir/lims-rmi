using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HMIS.LIMS.WebForms
{
	/// <SUMMARY>
	/// Summary description for WebUIFacade.
	/// </SUMMARY>
	public class WebUIFacade
	{
		/// <SUMMARY>
		/// Constructor.
		/// </SUMMARY>
		public WebUIFacade()
		{
            
		}

		/// <SUMMARY>
		/// This method creates a tooltip for the header columns in a datagrid.  
		/// Note:  This should only be used when the grid has sorting enabled.
		/// </SUMMARY>
		/// <PARAM name="e">DataGridItemEventArgs</PARAM>
		public void 
			SetHeaderToolTip(System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			// Is the item type of type header?
			if (e.Item.ItemType == ListItemType.Header)
			{
				string headerText = "";
				// Add the onmouseover and onmouseout
				// attribute to each header item.
				foreach (TableCell cell in e.Item.Cells)
				{
					try
					{
						LinkButton lb = (LinkButton) cell.Controls[0];
						headerText = "";

						if(lb != null)
						{
							headerText = lb.Text;
						}
                        
						lb.ToolTip = "Sort By " + lb.Text;
					}
					catch{}
				}
			}
		}
    
		/// <SUMMARY>
		/// This method changes the color of the row when the mouse is over it.
		/// Note: You must have a class called gridHover
		///       that sets the color of the hover row.
		/// </SUMMARY>
		/// <PARAM name="dg">DataGrid</PARAM>
		/// <PARAM name="e">DataGridItemEventArgs</PARAM>
		public void SetRowHover(DataGrid dg, 
			System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				string className = "";

				// Is the item an item or alternating item?
				if((e.Item.ItemType == ListItemType.Item) || 
					(e.Item.ItemType == ListItemType.AlternatingItem))
				{
					// Is the itemtype of type item?
					if (e.Item.ItemType == ListItemType.Item)
					{
						className = dg.ItemStyle.CssClass;
					}
					else if(e.Item.ItemType == ListItemType.AlternatingItem)
					{
						className = dg.AlternatingItemStyle.CssClass;
					}

					e.Item.Attributes.Add("onmouseover", 
						"this.className='gridHover';");
					e.Item.Attributes.Add("onmouseout", 
						"this.className='" + className + "';");
				}
			}
			catch
			{
			}
		}
        public void SetRowHover(GridView dg,
            System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                string className = "";

                // Is the item an item or alternating item?
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Is the itemtype of type item?
                    if (e.Row.RowIndex%2==0)
                    {
                        className = dg.RowStyle.CssClass;
                    }
                    else
                    {
                        className = dg.AlternatingRowStyle.CssClass;
                    }

                    e.Row.Attributes.Add("onmouseover",
                        "this.className='gridHover';");
                    e.Row.Attributes.Add("onmouseout",
                        "this.className='" + className + "';");
                }
            }
            catch
            {
            }
        }
		/// <SUMMARY>
		/// This method sets the CssStyle for a link button
		/// contained in the datagrid item, alternatingitem,
		/// or edititem row.  
		/// </SUMMARY>
		/// <PARAM name="e">DataGridItemEventArgs</PARAM>
		public void 
			SetGridLinkButtonStyle(System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem ||
				e.Item.ItemType == ListItemType.EditItem)
			{
				foreach(TableCell cell in e.Item.Cells)
				{
					try
					{
						LinkButton lb = (LinkButton) cell.Controls[0];
        
						if(lb != null)
						{
							lb.CssClass = "GridLink";
						}
					}
					catch{}
				}
			}
		}

	}
}