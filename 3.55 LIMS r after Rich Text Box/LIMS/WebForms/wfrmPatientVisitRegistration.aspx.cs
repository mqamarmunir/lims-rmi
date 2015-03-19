using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

public partial class WebForms_wfrmPatientVisitRegistration : System.Web.UI.Page
{
    /*=======create static data table and totalAmount here to hold selected services==============*/    
    private static int totalAmount = 0;    
    
    /*===========================================================================*/

    protected void Page_Load(object sender, EventArgs e)
    {//&& System.Configuration.ConfigurationManager.AppSettings["formid"].Equals("001")
        if (!Session["LoginID"].Equals("") )
        {
            if (!IsPostBack)
            {
                LS_BusinessLayer.clsBLUMatrix objMat = new LS_BusinessLayer.clsBLUMatrix();

                    objMat.PersonID = Session["LoginID"].ToString();
                    objMat.FormID = "003";
                    objMat.ApplicationID = "003";
                    
                    DataView dv = objMat.GetAll(1);
                    if (Convert.ToInt32(dv.Table.Rows[0]["Rec"].ToString()) > 0)
                    {
                        //FillDepartmentDDL();
                        //if (!Session["DepId"].Equals(""))
                        //{
                        //    this.ddlDepartment.SelectedValue = Session["DepId"].ToString();
                        //    FillSubDepartmentDDL();
                        //}
                        

                        ClearAll();
                        this.lblPersonName.Text = this.Session["PersonName"].ToString();
                        try
                        {
                            this.txtPRNo.Text = Request.QueryString.Get("PRNo");
                            DisplayPatientInfo();
                            FillSubDepartmentDDL();
                        }
                        catch { }
                    }
                    else
                    {
                        Response.Redirect("../wfrmUserMatrix.aspx");
                    }
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }
    }
    private void DisplayPatientInfo()
    {
        if (!txtPRNo.Text.Trim().Equals(""))
        {
            clsBLPatientSearch objPatientSearch = new clsBLPatientSearch();

            SComponents objComp = new SComponents();
            DataView dv = null;

            objPatientSearch.PRNO = this.txtPRNo.Text;
            dv = objPatientSearch.GetAll(1);
            if (dv.Count > 0)
            {
                if (dv.Table.Rows[0]["EXPIRE"].ToString().Equals("Y"))
                {
                    this.lblErrMsg.Text = " This patient has been expired. Visit can't be made for this patient.";
                    this.lbtnSave.Enabled = false;
                    this.ddlSalutation.SelectedItem.Selected = false;
                    this.ddlSalutation.Items.FindByValue(dv.Table.Rows[0]["SALUTATION"].ToString().Trim()).Selected = true;
                    txtFName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim();
                    txtMName.Text = dv.Table.Rows[0]["MNAME"].ToString().Trim();
                    txtLName.Text = dv.Table.Rows[0]["LNAME"].ToString().Trim();
                    txtdOB.Text = dv.Table.Rows[0]["DOB"].ToString().Trim();
                    this.ddlSex.SelectedItem.Selected = false;
                    this.ddlSex.Items.FindByValue(dv.Table.Rows[0]["SEX"].ToString().Trim()).Selected = true;
                    this.ddlMaritalStatus.SelectedItem.Selected = false;
                    this.ddlMaritalStatus.Items.FindByValue(dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim()).Selected = true;
                    return;
                }
                else
                {

                    txtPRNo.Text = dv.Table.Rows[0]["PRNO"].ToString().Trim();
                    this.ddlSalutation.SelectedItem.Selected = false;
                    this.ddlSalutation.Items.FindByValue(dv.Table.Rows[0]["SALUTATION"].ToString().Trim()).Selected = true;
                    txtFName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim();
                    txtMName.Text = dv.Table.Rows[0]["MNAME"].ToString().Trim();
                    txtLName.Text = dv.Table.Rows[0]["LNAME"].ToString().Trim();
                    txtdOB.Text = dv.Table.Rows[0]["DOB"].ToString().Trim();
                    this.ddlSex.SelectedItem.Selected = false;
                    this.ddlSex.Items.FindByValue(dv.Table.Rows[0]["SEX"].ToString().Trim()).Selected = true;
                    this.ddlMaritalStatus.SelectedItem.Selected = false;
                    this.ddlMaritalStatus.Items.FindByValue(dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim()).Selected = true;
                    lblErrMsg.Text = "";
                    lbtnSave.Enabled = true;
                }
            }
            else
            {
                lblErrMsg.Text = "Patient not found!";
                ClearAll();
            }
        }
    }
    private void FillDepartmentDDL()
    {
        clsBLDepartment objDept = new clsBLDepartment();
        SComponents objComp = new SComponents();

        objDept.Active = "Y";
        DataView dv = objDept.GetAll(2); //Change 080116 1 from 2
            objComp.FillDropDownList(this.ddlDepartment, dv, "name", "departmentid");
    }
    private void FillSubDepartmentDDL()
    {
        clsBLSubDepartment objSubDept = new clsBLSubDepartment();
        SComponents objComp = new SComponents();

        //if (!Session["DepId"].Equals(""))
        //{
        //    objSubDept.DepartmentID = Session["DepId"].ToString();
        //    objSubDept.Active = "Y";
            DataView dv = objSubDept.GetAll(1);
            objComp.FillDropDownList(this.ddlSubDepartment, dv, "name", "subdepartmentid");
        //}
        //if (!Session["ClinicId"].Equals(""))
        //{
        //    this.ddlSubDepartment.SelectedValue = Session["ClinicId"].ToString();
        //    //FillServiceDG();
        //}

        
    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
            
        this.lblErrMsg.Text = "";
        lblDept.Text = "011";
        if (this.txtPatientVisitNo.Text.Equals(""))
        {
            //if (this.ddlDepartment.SelectedValue.Equals("001") && this.txtTotalAmount.Text.Equals("800") )
            //{
            //    lblErrMsg.Text = "Please check amount.it is not matching with consultant charges";
            //    return;
            //}
            //clsBLPatientRegistration pr = new clsBLPatientRegistration();
            //DataView dv = pr.GetAll(7);
            //string str = System.Configuration.ConfigurationManager.AppSettings["panelcode"].ToString() + "000";
            //if (Convert.ToInt32(dv[0]["maxid"]) > Convert.ToInt32(str))
            //{
            //    //DataView dve = pr.GetAll(8);
            //    //DataView dvp = pr.GetAll(9);
            //    //DataView dvs = pr.GetAll(10);
            //    //DataView dvr = pr.GetAll(11);
            //    pr.mehtod_query();
            //    lbtnSave_Click(sender, e);
            //}
            //if (this.ddlDepartment.SelectedValue == "001" || this.ddlDepartment.SelectedValue == "013" || this.ddlDepartment.SelectedValue == "035" || this.ddlDepartment.SelectedValue == "041" || this.ddlDepartment.SelectedValue == "030" || this.ddlDepartment.SelectedValue == "042" || this.ddlDepartment.SelectedValue == "038" ||this.ddlDepartment.SelectedValue=="052" || this.ddlSubDepartment.SelectedValue=="0154" || this.ddlDepartment.SelectedValue == "-1")
              
             
            //    Insert();
            //else
                Insert2();
        }

    }
    private void Insert()
    {
        bool isSuccessful = true;
        
        clsBLPatientVisitRegistrationM objPVisitRegM = new clsBLPatientVisitRegistrationM();

        objPVisitRegM.PRNO = this.txtPRNo.Text;
        objPVisitRegM.VisitDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");        

        objPVisitRegM.Condition = this.ddlCondition.SelectedItem.Value;        
        objPVisitRegM.FollowUp = (this.chkFollowUp.Checked == true) ? "Y" : "N";
        objPVisitRegM.Emergency = (this.chkEmergency.Checked == true) ? "Y" : "N";
        objPVisitRegM.TotalAmount = this.txtTotalAmount.Text.Trim();
        objPVisitRegM.EnteredBy = Session["LoginID"].ToString();
        objPVisitRegM.EnteredAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPVisitRegM.MStatus = "A";

        if (!objPVisitRegM.ValidationM())
        {
            
            this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
            return;
        }


        // Service Details
        string[,] VisitDetails = new string[dgServiceSelected.Items.Count, 5];
        for (int i = 0; i < dgServiceSelected.Items.Count; i++)
        {
            VisitDetails[i, 0] = "011"; //Department
            VisitDetails[i, 1] = dgServiceSelected.Items[i].Cells[4].Text; //SubDepartment
            VisitDetails[i, 2] = dgServiceSelected.Items[i].Cells[0].Text; //ServiceID;
            VisitDetails[i, 3] = dgServiceSelected.Items[i].Cells[2].Text; //Amount;
            VisitDetails[i, 4] = "N";            
        }

        for (int i = 0; i <= VisitDetails.GetUpperBound(0); i++)
        {
            objPVisitRegM.DepartmentID = VisitDetails[i, 0]; //Department
            objPVisitRegM.SubDepartmentID = VisitDetails[i, 1]; //SubDepartment
            objPVisitRegM.ServiceID = VisitDetails[i, 1]; //ServiceID;
            objPVisitRegM.Amount = VisitDetails[i, 1]; //Amount;
            objPVisitRegM.Status = VisitDetails[i, 1]; // Status                                
            if (!objPVisitRegM.ValidationD())
            {
                this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
                return;
            }
       }

      

           isSuccessful = objPVisitRegM.Insert(VisitDetails);
           if (!isSuccessful)
           {
               Response.Write("<script language = 'javascript'> alert('" + objPVisitRegM.ErrorMessage + "')</script>");
               this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
           }
           else
           {
               this.txtPatientVisitNo.Text = objPVisitRegM.VisitNo;
               this.txtPatientVisitNo.ToolTip = objPVisitRegM.VisitNo;
               PrintVisitSlip(this.txtPatientVisitNo.Text);
               Session["PrintVisitSlip"] = (this.chkPrint.Checked == true) ? "Y" : "N";
               ClearAll();
               //if (Request.QueryString.Get("appid") != null)
               //{
               //    clsBlAppointment objApp = new clsBlAppointment();
               //    objApp.PERSONID = Request.QueryString.Get("appid");
               //    objApp.Update();
               //}
               this.lblErrMsg.Text = "<br><font color='Green'>Visit has been done successfully.</font><br><br>";
           }            
    }
    private void Insert2()
    {
        bool isSuccessful = true;

        clsBLPatientVisitRegistrationM objPVisitRegM = new clsBLPatientVisitRegistrationM();
        objPVisitRegM.PRNO = this.txtPRNo.Text;
        objPVisitRegM.VisitDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPVisitRegM.Condition = this.ddlCondition.SelectedItem.Value;
        objPVisitRegM.FollowUp = (this.chkFollowUp.Checked == true) ? "Y" : "N";
        objPVisitRegM.Emergency = (this.chkEmergency.Checked == true) ? "Y" : "N";
        objPVisitRegM.TotalAmount = "0";
        objPVisitRegM.EnteredBy = Session["LoginID"].ToString();
        objPVisitRegM.EnteredAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPVisitRegM.MStatus = "A";
        if (!objPVisitRegM.ValidationM())
        {
            this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
            return;
        }
       
        // Service Details
        string[,] VisitDetails = new string[1, 5];
        VisitDetails[0, 0] = "011"; //Department
        VisitDetails[0, 1] = GetSubDepID();//SubDep ID
        VisitDetails[0, 2] = ""; //ServiceID;
        VisitDetails[0, 3] = "0"; //Amount;
        VisitDetails[0, 4] = "N";
        for (int i = 0; i <= VisitDetails.GetUpperBound(0); i++)
        {
            objPVisitRegM.DepartmentID ="011"; //Department
            objPVisitRegM.SubDepartmentID = VisitDetails[i, 1]; //SubDepartment
            objPVisitRegM.ServiceID = VisitDetails[i, 1]; //ServiceID;
            objPVisitRegM.Amount = VisitDetails[i, 1]; //Amount;
            objPVisitRegM.Status = VisitDetails[i, 1]; // Status                                
            if (!objPVisitRegM.ValidationD2())
            {
                this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
                return;
            }
        }
        isSuccessful = objPVisitRegM.Insert(VisitDetails);
        if (!isSuccessful)
        {
            this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
        }
        else
        {
            this.txtPatientVisitNo.Text = objPVisitRegM.VisitNo;
            this.txtPatientVisitNo.ToolTip = objPVisitRegM.VisitNo;
            PrintVisitSlip(this.txtPatientVisitNo.Text);
            Session["PrintVisitSlip"] = (this.chkPrint.Checked == true) ? "Y" : "N";
            ClearAll();
            //if (Request.QueryString.Get("appid") != null)
            //{
            //    clsBlAppointment objApp = new clsBlAppointment();
            //    objApp.PERSONID = Request.QueryString.Get("appid");
            //    objApp.Update();
            //}
            this.lblErrMsg.Text = "<br><font color='Green'>Visit has been done successfully.</font><br><br>";
            //Response.Redirect("wfrmPatientReg.aspx");
        }
    }
    private string GetSubDepID() 
    {
        if (ddlSubDepartment.Items.Count == 1)
            return ddlSubDepartment.SelectedValue.ToString();
        else
            return ddlSubDepartment.SelectedValue.ToString().Equals("-1") ? "" : ddlSubDepartment.SelectedValue.ToString(); //SubDepartment
    }
    private void  PrintVisitSlip(string sValue)
    {
        if (this.chkPrint.Checked == true)
        {
            if (!sValue.Equals(""))
            {
                string sSelectionFormula;

                sSelectionFormula = "{PR_VPATIENTINFO.VISITNO} = '" + sValue + "'";

                //clsBLReport.sSelectionFormula = sSelectionFormula;
                //clsBLReport.ReportName = "003_001_0003";
                //clsBLReport.FromDate = "";
                //clsBLReport.ToDate = "";

                //Response.Write("<script language = 'javascript'>window.open('../../Reports/GeneralReports.aspx','_blank')</script>");
            }
        }
    }
    private void ClearAll()
    {
        this.chkPrint.Checked = (Session["PrintVisitSlip"] == "Y") ? true : false;
        this.txtPatientVisitNo.Text = "";
        this.txtPRNo.Text = "";
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtLName.Text = "";
        this.ddlSalutation.SelectedItem.Selected = false;
        this.ddlSalutation.Items.FindByValue("-1").Selected = true;
        this.ddlSex.SelectedItem.Selected = false;
        this.ddlSex.Items.FindByValue("-1").Selected = true;
        this.txtdOB.Text = "";
        this.ddlMaritalStatus.SelectedItem.Selected = false;
        this.ddlMaritalStatus.Items.FindByValue("-1").Selected = true;
        this.ddlCondition.SelectedItem.Selected = false;
        this.ddlCondition.Items.FindByValue("N").Selected = true;
        this.chkEmergency.Checked = false;
        this.chkFollowUp.Checked = false;
        this.txtTotalAmount.Text = "";
        totalAmount = 0;
        lbtnSave.Enabled = true;
        //this.ddlDepartment.SelectedItem.Selected = false;
        //this.ddlDepartment.Items.FindByValue("-1").Selected = true;
        //try
        //{
        //    this.ddlSubDepartment.SelectedItem.Selected = false;
        //    this.ddlSubDepartment.Items.FindByValue("-1").Selected = true;
        //}
        //catch { }
        
        //DataTable dtg = new DataTable();

        //if (Session["dtServices"] != null)
        //{
        //    dtg = (DataTable)Session["dtServices"];
        //    dtg.Clear();
        //    dtg = null;
        //    Session["dtServices"] = dtg; 
        //    //((DataTable)Session["dtServices"]).Clear();
        //    //((DataTable)Session["dtServices"]) = null;

        //}
        Session["dtServices"] = null;
        if (Session["ClinicId"].Equals(""))
        {
            dgService.Visible = false;
            dgService.DataSource = null;
            dgService.DataBind(); 
        }
        this.dgServiceSelected.Visible = false;
        this.txtTotalAmount.Text = "";        

        
        
        dgServiceSelected.DataSource = null;        
        dgServiceSelected.DataBind();        
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();
        this.lblErrMsg.Text = "";
    }    
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ClinicId"] = this.ddlSubDepartment.SelectedItem.Value.ToString();
        //if (this.ddlDepartment.SelectedValue == "001" || this.ddlDepartment.SelectedValue == "013" || this.ddlDepartment.SelectedValue == "035" || this.ddlDepartment.SelectedValue == "041" || this.ddlDepartment.SelectedValue == "030" || this.ddlDepartment.SelectedValue == "042" || this.ddlDepartment.SelectedValue == "038" || this.ddlDepartment.SelectedValue=="052" || this.ddlSubDepartment.SelectedValue=="0154" ||this.ddlDepartment.SelectedValue == "-1")
        //    //FillServiceDG();
        //else
            dgService.DataSource = null;
        dgService.DataBind();
    }
    //private void FillServiceDG()
    //{
    //    clsBLService objService = new clsBLService();

    //    if (!Session["ClinicId"].Equals(""))
    //    {
    //        objService.DepartmentId = Session["DepId"].ToString();
    //        objService.SubdepartmentId = Session["ClinicId"].ToString();

    //        DataView dv = objService.GetAll(1);

    //        if (dv.Count > 0)
    //        {
    //            //dv.Sort = DGSort;
                
    //            this.dgService.DataSource = dv;
    //            this.dgService.DataBind();
    //            this.dgService.Visible = true;
    //        }
    //        else
    //        {
    //            this.dgService.DataSource = null;
    //            //this.dgServiceSelected.DataSource = null;                
    //            this.dgService.Visible = false;
    //            this.dgServiceSelected.Visible = (this.dgServiceSelected.Items.Count > 0);
    //        }
    //    }
    //    else
    //    {
    //        this.dgService.DataSource = null;
    //        this.dgServiceSelected.DataSource = null;
    //        this.dgService.Visible = false;
    //        this.dgServiceSelected.Visible = false;
    //    }
    //}    
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["DepId"].Equals("") || !Session["DepId"].Equals(this.ddlDepartment.SelectedItem.Value.ToString()))
        {
            if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
            {
                Session["DepId"] = "011";
                Session["ClinicId"] = "";
                FillSubDepartmentDDL();
            }
        }
        else
        {
            FillSubDepartmentDDL();
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        bool duplicateFlag = false;
        DataTable dtg = new DataTable();

        if (Session["dtServices"] == null)
        {
            DataColumn dc;
            dc = new DataColumn("ServiceID", System.Type.GetType("System.String"));
            dtg.Columns.Add(dc);
            dc = new DataColumn("ServiceName", System.Type.GetType("System.String"));
            dtg.Columns.Add(dc);
            dc = new DataColumn("Amount", System.Type.GetType("System.String"));
            dtg.Columns.Add(dc);
            dc = new DataColumn("DepartmentID", System.Type.GetType("System.String"));
            dtg.Columns.Add(dc);
            dc = new DataColumn("SubDepartmentID", System.Type.GetType("System.String"));
            dtg.Columns.Add(dc);
        }
        else { dtg = (DataTable)Session["dtServices"]; }        

        DataRow dr;

        #region Building the dynamic data table
        for (int serviceCounter = 0; serviceCounter < this.dgService.Items.Count; serviceCounter++)
        {
            if (((CheckBox)this.dgService.Items[serviceCounter].Cells[3].FindControl("chkSelect")).Checked)
            {
                #region Selected services table is not empty
                if (dtg.Rows.Count > 0)
                {
                    duplicateFlag = false;

                    #region Duplicate Entry Process
                    for (int serDuplicateCheck = 0; serDuplicateCheck < this.dgServiceSelected.Items.Count; serDuplicateCheck++)
                    {
                        if (this.dgService.Items[serviceCounter].Cells[0].Text.Trim().Equals(this.dgServiceSelected.Items[serDuplicateCheck].Cells[0].Text.Trim()))
                        {
                            //duplicate entry found
                            duplicateFlag = true;
                        }
                    }

                    #endregion

                    //if no duplicate entry found then add row
                    if (duplicateFlag.Equals(false))
                    {
                        dr = dtg.NewRow();
                        dr["ServiceID"] = this.dgService.Items[serviceCounter].Cells[0].Text;
                        dr["ServiceName"] = this.dgService.Items[serviceCounter].Cells[1].Text; ;
                        dr["Amount"] = this.dgService.Items[serviceCounter].Cells[2].Text;
                        dr["DepartmentID"] = this.ddlDepartment.SelectedValue.ToString();
                        dr["SubDepartmentID"] = this.ddlSubDepartment.SelectedValue.ToString();

                        totalAmount = totalAmount + int.Parse(this.dgService.Items[serviceCounter].Cells[2].Text.Trim());
                        dtg.Rows.Add(dr);
                    }
                }

                #endregion
                #region Selected services table is empty
                else
                {
                    dr = dtg.NewRow();
                    dr["ServiceID"] = this.dgService.Items[serviceCounter].Cells[0].Text;
                    dr["ServiceName"] = this.dgService.Items[serviceCounter].Cells[1].Text; ;
                    dr["Amount"] = this.dgService.Items[serviceCounter].Cells[2].Text;
                    dr["DepartmentID"] = this.ddlDepartment.SelectedValue.ToString();
                    dr["SubDepartmentID"] = this.ddlSubDepartment.SelectedValue.ToString();

                    totalAmount = totalAmount + int.Parse(this.dgService.Items[serviceCounter].Cells[2].Text.Trim());
                    dtg.Rows.Add(dr);
                }

                #endregion
            }
        }
        
        #endregion

        if (dtg.Rows.Count > 0)
        {
            dgServiceSelected.DataSource = dtg;
            dgServiceSelected.PageSize += 1;
            dgServiceSelected.DataBind();
            Session["dtServices"] = dtg;             
            this.dgServiceSelected.Visible = true;
            this.txtTotalAmount.Text = totalAmount.ToString();
        }
        else
        {
            this.dgServiceSelected.Visible = false;
            this.txtTotalAmount.Text = "";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //clsBLPatientSearch objPSearch = new clsBLPatientSearch();
        //objPSearch.PRNO = this.txtPRNo.Text.Trim();
        //DataView dv = new DataView();
        //dv = objPSearch.GetAll(2);
        //string ahsan = dv.Table.Columns["FName"].Caption.ToString();
    }    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DisplayPatientInfo();
        FillSubDepartmentDDL();
    }
    protected void ibtnPanelPatient_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("wfrmPatientReg.aspx");
    }
    protected void Imagebutton2_Click(object sender, ImageClickEventArgs e)
    {
        PrintVisitSlip(this.txtPatientVisitNo.ToolTip);
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }

}
