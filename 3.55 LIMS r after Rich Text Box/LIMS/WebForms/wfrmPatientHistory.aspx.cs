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
using LS_BusinessLayer;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmPatientHistory.
	/// </summary>
	public partial class wfrmPatientHistory : System.Web.UI.Page
	{
		
		private static DataTable dtHistory;
		private static clsBLPatientHistory patientHistory;
		private static SComponents objComp = new SComponents();
		private string patientID;
		private string from;
		private string to;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				patientID = Request.QueryString.Get("patientID");
				from = Request.QueryString.Get("from");
				to = Request.QueryString.Get("to");
				if(!IsPostBack)
				{
					TxtFrom.Text = from;
					TxtTo.Text = to;
					patientHistory = new clsBLPatientHistory();
					dtHistory = patientHistory.GetAll(patientID, "-1", "-1", "-1", "-1", from, to).Table;
					DGPatientHistory.DataSource = dtHistory;
					DGPatientHistory.DataBind();

					// getting department table
					clsBLDepartment busDept = new clsBLDepartment();
					DataView dvDept = busDept.GetAll(1);
					objComp.FillDropDownList(this.CmbDept, dvDept, "Name", "DepartmentID");
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
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
			this.DGPatientHistory.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGPatientHistory_ItemCommand);

		}
		#endregion

		protected void ButGo_Click(object sender, System.EventArgs e)
		{
			this.LblMessage.Text = "";

			if(TxtFrom.Text.Equals(""))
			{
				LblMessage.Text = "<br>Dates cannot be empty<br><br>";
				return;
			}

			dtHistory = null;
			
			string departmentID = CmbDept.SelectedValue.ToString();
			string clinicID = CmbSubDept.SelectedValue.ToString();
			string serviceID = CmbService.SelectedValue.ToString();
			string doctorID = CmbDoctor.SelectedValue.ToString();
			
			dtHistory = patientHistory.GetAll(patientID, departmentID, clinicID, doctorID, serviceID, TxtFrom.Text, TxtTo.Text).Table;
			DGPatientHistory.DataSource = dtHistory;
			DGPatientHistory.DataBind();
		}

		private void DGPatientHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LblMessage.Text = "";

			if(e.CommandName.Equals("Select"))
			{
				TableCell cell = (TableCell) e.Item.Controls[5];
				string url = cell.Text;
				Response.Write("<script> alert('"+url+"'); </script>");
			}
		}

		protected void CmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string departmentID = CmbDept.SelectedValue.ToString();
			
			// getting clinic table
			clsBLClinic busClinic = new clsBLClinic();
			DataView dvClinic = busClinic.GetAll(departmentID);
			objComp.FillDropDownList(this.CmbSubDept, dvClinic, "ClinicName", "ClinicID");
		}

		protected void CmbSubDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(!CmbDept.SelectedValue.Equals("0001"))
			{
				string clinicID = CmbSubDept.SelectedValue.ToString();
				// getting service table
				clsBLService busService = new clsBLService();
				DataView dvService = busService.GetAll(clinicID);
				objComp.FillDropDownList(this.CmbService, dvService, "ServiceName", "ServiceID");
			}
			else
			{
				string departmentID = CmbDept.SelectedValue.ToString();
				// getting Doctor table
				clsBLDoctor busDoctor = new clsBLDoctor();
				DataView dvDoctor = busDoctor.GetAll(departmentID);
				objComp.FillDropDownList(this.CmbDoctor, dvDoctor, "PersonName", "PersonID");
			}
		}
	}
}
