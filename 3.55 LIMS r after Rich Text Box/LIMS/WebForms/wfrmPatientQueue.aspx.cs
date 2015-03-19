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
	/// Summary description for wfrmPatientQueue.
	/// </summary>
	public partial class wfrmPatientQueue : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				clsBLPatientQueue patientQueue = new clsBLPatientQueue();
				string deptID = Request.QueryString.Get("deptID").ToString();
				string clinicID = Request.QueryString.Get("clinicID").ToString();
				string doctorID = Request.QueryString.Get("doctorID").ToString();
				string serviceID = Request.QueryString.Get("serviceID").ToString();
				string url = Request.QueryString.Get("url").ToString();

				if(!IsPostBack)
				{
					DGQueue.DataSource = patientQueue.GetAllLIMSPatients(deptID);
					DGQueue.DataBind(); 
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

		}
		#endregion

		private void DGQueue_SelectedIndexChanged(object sender, System.EventArgs e)
		{
/*
			ArrayList formValues = new ArrayList();				
			formValues.Add(RdoEntitled.SelectedIndex);			// 1
			formValues.Add(RdoRequestType.SelectedIndex);		// 2
			formValues.Add(RdoIOP.SelectedIndex);				// 3
			formValues.Add(TxtPFName.Text);						// 4
			formValues.Add(TxtPMName.Text);						// 5
			formValues.Add(TxtPLName.Text);						// 6
			formValues.Add(CmbGender.SelectedIndex);			// 7
			formValues.Add(TxtDOB.Text);						// 8
			formValues.Add(TxtAge.Text);						// 9
			formValues.Add(CmbAgeType.SelectedIndex);			// 10
			formValues.Add(TxtRegimentalNo.Text);				// 11
			formValues.Add(CmbRank.SelectedIndex);				// 12
			formValues.Add(CmbUnit.SelectedIndex);				// 13
			formValues.Add(CmbRelationShip.SelectedIndex);		// 14
			formValues.Add(TxtKFName.Text);						// 15
			formValues.Add(TxtKLName.Text);						// 16
			formValues.Add(TxtPatientNo.Text);					// 17
			formValues.Add(CmbPanel.SelectedIndex);				// 18
			formValues.Add(TxtWardNo.Text);						// 19
			formValues.Add(TxtAdmDate.Text);					// 20
			formValues.Add(TxtRequestNo.Text);					// 21
			formValues.Add(TxtMobile.Text);						// 22
			formValues.Add(CmbResultDespatch.SelectedIndex);	// 23
			formValues.Add(CmbPaymentMode.SelectedIndex);		// 24
			formValues.Add(TxtAddress.Text);					// 25
			formValues.Add(TxtDiscountPer.Text);				// 26
			formValues.Add(TxtAmount.Text);						// 27
			formValues.Add(dtSelectedTest);						// 28

			Session.Add("ReceptionFormValues", formValues);
			
			try
			{
				LblMessage.Text = "";
				if( !TxtAge.Text.Equals("") && Int16.Parse(TxtAge.Text) > 0)
				{
					int year = Int16.Parse(TxtAge.Text);
					if(CmbAgeType.SelectedValue.ToString().Equals("Year"))
						year = year * 365;
					else if(CmbAgeType.SelectedValue.ToString().Equals("Month"))
						year = year * 30;
					else if(CmbAgeType.SelectedValue.ToString().Equals("Week"))
						year = year * 7;
					Response.Write("<script language='javascript'> window.open('wfrmSearchTest.aspx?gender="+CmbGender.SelectedValue+"&age="+year+"'); </script>");
				}
				else
				{
					LblMessage.ForeColor = Color.Red;
					LblMessage.Text = "Please enter patient age.";
				}
			}
			catch(Exception err)
			{
				LblMessage.ForeColor = Color.Red;
				LblMessage.Text = "Please enter valid age.";
			}*/
		}
	}
}