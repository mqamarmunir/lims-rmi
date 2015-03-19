  using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data.OleDb;


public partial class asyncgridview : System.Web.UI.Page, ICallbackEventHandler
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!Page.IsCallback)
      ltCallback.Text = ClientScript.GetCallbackEventReference(this, "'bindgrid'", "EndGetData", "'asyncgrid'", false);
  }

  private DataTable RetrieveDataTableFromDatabase()
  {
    DataTable table = new DataTable();
    clsBLTest objTest = new clsBLTest();
    table = objTest.GetAll(19).ToTable();
      //table.Columns.Add("Product", typeof(string));
    //table.Columns.Add("Price", typeof(float));

    //table.Rows.Add("Hat", 16);
    //table.Rows.Add("Jacket", 234);
    //table.Rows.Add("Socks", 35);

    return table;
  }

  #region ICallbackEventHandler Members

  private string _Callback;

  public string GetCallbackResult()
  {
    return _Callback;
  }

  public void RaiseCallbackEvent(string eventArgument)
  {
    //DataTable table = RetrieveDataTableFromDatabase();
    //gvAsync.DataSource = table;
    //gvAsync.DataBind();

      using (OleDbConnection conn = new OleDbConnection("Provider=MSDAORA.1;User ID=whims;Data Source=HIMS;Password=whims"))
      {
          conn.Open();
          string query = "Select labid,mserialno from ls_tmtransaction where rownum<20000";
          OleDbCommand _command = new OleDbCommand(query, conn);
          ////////////Reader
          OleDbDataReader _Reader = _command.ExecuteReader();
          //////////Adapter

          //DataSet ds = new DataSet();
          //OleDbDataAdapter _Adapter = new OleDbDataAdapter(_command);

          //_Adapter.Fill(ds);
          
          
          
          gvAsync.DataSource = _Reader;
          gvAsync.DataBind();



      }

      

    using (System.IO.StringWriter sw = new System.IO.StringWriter())
    {
      gvAsync.RenderControl(new HtmlTextWriter(sw));
      _Callback = sw.ToString();
    }
  }

  #endregion
  protected void gvAsync_RowDataBound(object sender, GridViewRowEventArgs e)
  {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          e.Row.BackColor = System.Drawing.Color.FromArgb(int.Parse(e.Row.RowIndex.ToString().PadLeft(4,'0')));
      }
  }
}
