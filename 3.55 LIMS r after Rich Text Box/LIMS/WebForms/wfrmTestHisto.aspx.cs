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
using System.Data.OracleClient;
using System.IO;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmTestHisto.
	/// </summary>
    public partial class wfrmTestHisto : System.Web.UI.Page
    {
        protected static string id;
        protected static string sMSerialNo;
        protected static string sMSerialNos;
        protected static string ProcessID;
        protected static string SectionID;
        protected static string SelectedOpinion = "";
        protected static string SelectedComment = "";
        protected static string sOrgID;
        protected static string sDSerNo;
        protected static string sTag;
        protected static string testid="";
        protected static string path_images = "";

       protected static string sPAgeinDays;
        protected static string sSex;
        string[] saMSerialNos = new string[255];

        private DataView _dvForwardto;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Put user code to initialize the page here						
                id = Request.QueryString["id"].ToString();
                ProcessID = Request.QueryString["ProcessID"].ToString();
                sMSerialNos = Request.QueryString["MSerialNos"].ToString();
                parseMSerialNos(sMSerialNos);
                SectionID = Request.QueryString["SectionID"].ToString();
                sTag = Request.QueryString["Tag"].ToString();
                lblHeading.Text = "Test Detail";
                if (!IsPostBack)
                {
                    clsBLPreferenceSettings obj_Pref = new clsBLPreferenceSettings();
                    DataView dv = obj_Pref.GetAll(1);
                    if (dv.Count > 0)
                    {
                   
                        path_images = dv[0]["IMG_PATH"].ToString();
                        
                    }

                    dv.Dispose();
                    sMSerialNo = id;
                    sOrgID = "";
                    sDSerNo = "";
                    DisplayPatient(sMSerialNo);
                    //FillgvDiseases("abc");
                    if (ProcessID == "0005")
                    {
                        for (int i = 0; i < dgTest.Items.Count; i++)
                        {
                            // dgTest.Items[i].Cells[7].FindControl("lnkbtnEval").Visible = true;
                            dgTest.Items[i].Cells[7].FindControl("lnkbtnDiagnosis").Visible = true;
                            //dgTest.Items[i].Cells[7].FindControl("gvimgReviewComments").Visible = true;
                        }

                    }
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
            this.ibtnNextPatient.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
            this.ibtnViewOtherResult.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnViewOtherResult_Click);
            this.ibtnPatientStatus.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPatientStatus_Click);
            this.ImageButton2.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton2_Click);
          //  this.dgTest.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTest_ItemDataBound);

        }
        #endregion

        public DataView FillDDLForwardTo(string sValue)
        {
            clsBLTestProcess objTestProcess = new clsBLTestProcess();
            SComponents objComp = new SComponents();

            objTestProcess.ProcedureID = sValue;
            objTestProcess.DisplayTag = sTag;
            DataView dvTestProcess = objTestProcess.GetAll(1);
            _dvForwardto = dvTestProcess;
            return dvTestProcess;
        }

        public int GetForwardIndex(string sProcessID)
        {
            try
            {
                for (int i = 0; i < _dvForwardto.Table.DefaultView.Count; i++)
                {
                    if (_dvForwardto.Table.DefaultView[i]["ProcessID"].ToString() == sProcessID)
                    {
                        return i + 1;
                    }
                }
            }
            catch { }
            return 0;
        }

        public System.Web.UI.WebControls.TextBoxMode GetTextmode(string sFlag)
        {
            if (sFlag.Equals("1"))
            {
                return System.Web.UI.WebControls.TextBoxMode.SingleLine;
            }
            else
            {
                return System.Web.UI.WebControls.TextBoxMode.MultiLine;
            }

        }

        public DataView DisplayAttribute(string Str, string methodid,string testtid)
        {
            this.lblErrMsg.Text = "";

            clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();
            objTGeneralTestResult.DSerialNo = Str;
            objTGeneralTestResult.Age = sPAgeinDays;
            if (sSex == "M")
            {
                objTGeneralTestResult.Sex = "Male";
            }
            else if (sSex == "F")
            {
                objTGeneralTestResult.Sex = "Female";
            }
            else
            {
                objTGeneralTestResult.Sex = sSex;
            }
            DataView dvTGeneralTestResult = objTGeneralTestResult.GetAll(3);
            if (Request.QueryString["ProcessID"].ToString() == "0005")
            {
                if (dvTGeneralTestResult.Count > 0)
                {
                    return dvTGeneralTestResult;
                }
                else
                {
                    clsBLTest objtest = new clsBLTest();
                    objtest.TestID = testtid;
                    DataView dv_defaultmethodid = objtest.GetAll(12);
                    objTGeneralTestResult.DSerialNo = Str;
                    objTGeneralTestResult.MethodID = dv_defaultmethodid[0]["D_METHODID"].ToString().Trim();
                    dv_defaultmethodid.Dispose();
                    if (objTGeneralTestResult.UpdateMethod())
                    {
                        objTGeneralTestResult.Age = sPAgeinDays;
                        if (sSex == "M")
                        {
                            objTGeneralTestResult.Sex = "Male";
                        }
                        else if (sSex == "F")
                        {
                            objTGeneralTestResult.Sex = "Female";
                        }
                        else
                        {
                            objTGeneralTestResult.Sex = sSex;
                        }
                        dvTGeneralTestResult = objTGeneralTestResult.GetAll(3);

                    }
                    return dvTGeneralTestResult;
                }
            }
            else
            {
                if (dvTGeneralTestResult.Count > 0)
                {
                    return dvTGeneralTestResult;
                }
                else
                {
                    objTGeneralTestResult.DSerialNo = Str;
                    objTGeneralTestResult.Age = sPAgeinDays;

                    //DropDownList ddlMethod=(DropDownList)
                    objTGeneralTestResult.MethodID = methodid;
                    if (sSex == "M")
                    {
                        objTGeneralTestResult.Sex = "Male";
                    }
                    else if (sSex == "F")
                    {
                        objTGeneralTestResult.Sex = "Female";
                    }
                    else
                    {
                        objTGeneralTestResult.Sex = sSex;
                    }
                    objTGeneralTestResult.MethodID = methodid;
                    DataView dvTGeneralTestResult2 = objTGeneralTestResult.GetAll(4);
                    return dvTGeneralTestResult2;
                }
            }
        }

        private void parseMSerialNos(string sValue)
        {
            string sMSNo = "";
            int ArrayPosition = 0;

            for (int i = 0; i < sValue.Length; i++)
            {
                if (sValue[i].ToString() != "|")
                {
                    sMSNo += sValue[i].ToString();
                }
                else
                {
                    if (!sMSNo.Equals(""))
                    {
                        saMSerialNos[ArrayPosition] = sMSNo;
                        sMSNo = "";
                        ArrayPosition++;
                    }
                }
            }
        }

        private string NextMSerialNo(string sValue)
        {
            try
            {
                for (int i = 0; i <= saMSerialNos.GetUpperBound(0); i++)
                {
                    if (saMSerialNos[i].Equals(sValue))
                    {
                        return saMSerialNos[i + 1].ToString();
                    }
                }
            }
            catch { }
            return "";
        }

        private void DisplayPatient(string Str)
        {
            this.lblErrMsg.Text = "";

            clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();
            objTGeneralTestResult.MSerialNo = Str;
            objTGeneralTestResult.ProcessID = ProcessID;
            objTGeneralTestResult.SectionID = SectionID;
            objTGeneralTestResult.TestType = "H";
            DataView dvTGeneralTestResult = objTGeneralTestResult.GetAll(2);

            if (dvTGeneralTestResult.Count > 0)
            {
                lblLabID.Text = dvTGeneralTestResult.Table.Rows[0]["LabID"].ToString();
                lblMSerialNo.Text = dvTGeneralTestResult.Table.Rows[0]["MSerialNo"].ToString();
                lblName.Text = dvTGeneralTestResult.Table.Rows[0]["PatientName"].ToString();
                lblPriority.Text = dvTGeneralTestResult.Table.Rows[0]["Priority"].ToString();
                lblAgeSex.Text = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
                lblAgeSex.Text += ' ' + dvTGeneralTestResult.Table.Rows[0]["PAge"].ToString();
                lblType.Text = dvTGeneralTestResult.Table.Rows[0]["Type"].ToString();
                lblWard.Text = dvTGeneralTestResult.Table.Rows[0]["WardName"].ToString();
                lblPRNo.Text = dvTGeneralTestResult.Table.Rows[0]["PRNo"].ToString();
                lblReferredBy.Text = dvTGeneralTestResult.Table.Rows[0]["REFERREDBY"].ToString();
                txtRefDoctor.Text = dvTGeneralTestResult.Table.Rows[0]["REFERREDBY"].ToString();
                testid = dvTGeneralTestResult.Table.Rows[0]["TestID"].ToString();
                sPAgeinDays = dvTGeneralTestResult.Table.Rows[0]["PAgeinDays"].ToString();
                sSex = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();



                /*for (int i = 0; i < 11; i++)
                {  					
                    dgTest.EditItemIndex = i;
                }*/

                dgTest.EditItemIndex = 0;
                dgTest.EditItemIndex = 1;
                dgTest.EditItemIndex = 2;
                dgTest.EditItemIndex = 3;
                dgTest.EditItemIndex = 4;
                dgTest.EditItemIndex = 5;
                dgTest.EditItemIndex = 6;
                dgTest.EditItemIndex = 7;
                dgTest.EditItemIndex = 8;
                dgTest.EditItemIndex = 9;
                dgTest.EditItemIndex = 10;
                this.dgTest.DataSource = dvTGeneralTestResult;
                this.dgTest.DataBind();
                this.dgTest.Visible = true;
            }
            else
            {
                //this.dgTest.Visible = false;
                DisplayNextPatient();
            }
        }
        private void DisplayNextPatient()
        {
            sMSerialNo = NextMSerialNo(sMSerialNo);
            if (sMSerialNo.Equals(""))
            {
                Response.Write("<script language='javascript'>self.close();</script>");
            }
            else
            {
                DisplayPatient(sMSerialNo);
            }
        }

        protected void dgTest_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            Control container = e.Item;
            ListItemType itemType = e.Item.ItemType;
            string testtid = e.Item.Cells[2].Text;

            if (itemType == ListItemType.Item || itemType == ListItemType.Footer || itemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem == null)
                {
                    return;
                }

                HtmlImage btnExpandButton = (HtmlImage)container.FindControl("image_");
                if (btnExpandButton != null)
                {
                    btnExpandButton.Attributes.Add("OnClick", "Toggle('dgTest__ctl" + (e.Item.ItemIndex + 2) + "_divOrders', 'dgTest__ctl" + (e.Item.ItemIndex + 2) + "_image_');");
                }
                #region repeattest depricated
                /////////////////////////Check if the test is repeated//////////////////////////////
                //clsBlRepeatTest obj_Repeat = new clsBlRepeatTest();
                //obj_Repeat.LabID = lblLabID.Text;
                //obj_Repeat.TestID = testtid;
                //DataView dv_testrepeat = obj_Repeat.GetAll(1);
                //if (dv_testrepeat.Count > 0)
                //{
                //    ((CheckBox)container.FindControl("chkRepeat")).Checked = true;
                //    ((Label)container.FindControl("lblReasons")).Visible = true;
                //    DropDownList ddlRepeatResons = ((DropDownList)container.FindControl("ddlRepeatReasons"));
                //    ddlRepeatResons.Visible = true;
                //    clsBLRepeatReasons obj_Reasons = new clsBLRepeatReasons();
                //    SComponents obj_comp = new SComponents();
                //    DataView dv_Reasons = obj_Reasons.GetAll(1);
                //    if (dv_Reasons.Count > 0)
                //    {
                //        obj_comp.FillDropDownList(ddlRepeatResons, dv_Reasons, "Reason", "REPEATREASON_ID");

                //        //((DropDownList)(dgItem.Cells[7].FindControl("ddlRepeatReasons"))).DataSource = dv_Reasons;
                //        //((DropDownList)(dgItem.Cells[7].FindControl("ddlRepeatReasons"))).DataBind();

                //    }
                //    obj_comp = null;
                //    ddlRepeatResons.ClearSelection();
                //    ddlRepeatResons.Items.FindByValue(dv_testrepeat[0]["REPEATREASONID"].ToString()).Selected = true;
                //    //((DropDownList)container.FindControl("ddlRepeatReasons")).ClearSelection();
                //    //((DropDownList)container.FindControl("ddlRepeatReasons")).Items.FindByValue(dv_testrepeat[0]["REPEATREASONID"].ToString()).Selected = true;
                //    dv_testrepeat.Dispose();
                //}
                //else
                //{
                //    ((CheckBox)container.FindControl("chkRepeat")).Checked = false;
                //    ((Label)container.FindControl("lblReasons")).Visible = false;
                //    dv_testrepeat.Dispose();
                //}
                ////////////////////////////////----------/////////////////////////////////////////
                #endregion


                ////////////////////////////
                DropDownList ddlmethod = (DropDownList)container.FindControl("dgDDLMethod");
                ddlmethod.Attributes.Add("onchange", "if(!window.confirm('Changing method will change Attributes,Units and Ranges. Press Ok to change Method or press cancel otherwise?')) return false;");
                if (null != ddlmethod)
                {


                    DataView dv_methods = FillMethodDDL(testtid);
                    if (dv_methods.Count > 0)
                    {

                        SComponents obj_Com = new SComponents();
                        obj_Com.FillDropDownList(ddlmethod, dv_methods, "Method", "MethodID", false);
                        ddlmethod.ClearSelection();
                        try
                        {
                            ddlmethod.Items.FindByValue(e.Item.Cells[10].Text.Trim()).Selected = true;
                        }
                        catch
                        {
                            clsBLTest objtest = new clsBLTest();
                            objtest.TestID = testtid;
                            DataView dv_defaultmethodid = objtest.GetAll(12);
                            ddlmethod.Items.FindByValue(dv_defaultmethodid[0]["D_methodid"].ToString().Trim()).Selected = true;
                            clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();
                            objTGeneralTestResult.DSerialNo = e.Item.Cells[1].Text.Trim();
                            objTGeneralTestResult.MethodID = dv_defaultmethodid[0]["D_METHODID"].ToString().Trim();
                            dv_defaultmethodid.Dispose();
                            objTGeneralTestResult.UpdateMethod();
                        }
                        dv_methods.Dispose();
                        obj_Com = null;
                    }
                    else
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "No Attribute Set against this Test method";
                    }
                }



                DataGrid dgAttribute = (DataGrid)container.FindControl("dgAttribute");
                String DSerialNo = String.Empty;
                DSerialNo = e.Item.Cells[1].Text.ToString();
                if (null != dgAttribute)
                {
                    DataView data = new DataView();
                    data = DisplayAttribute(DSerialNo,"",testtid);
                    dgAttribute.DataSource = data;
                    dgAttribute.DataBind();
                    #region Controlling File Uploading and Downloading
                    /////////////////////////////////Controlling FileUploading and Downloading//////////////////////////
                    try
                    {
                        int startingindex = 0;
                         string filepath1="";
                         if (data[0]["Path_IMG1"].ToString().Trim() != "" && data[0]["Path_IMG1"].ToString().Trim() != null)
                         {
                             filepath1 = data[0]["Path_IMG1"].ToString().Trim();
                         }
                         else
                         {
                             if (data[0]["EXT_RESULT_REFERENCE"].ToString().Trim() != "" && data[0]["EXT_RESULT_REFERENCE"].ToString().Trim() != null)
                             {
                                 clsBLTest t = new clsBLTest();
                                 DataView dv = t.GetAll(16);
                                 filepath1 = dv[0]["DOC_PATH"].ToString() + "\\" + data[0]["EXT_RESULT_REFERENCE"].ToString().Trim();
                             }
                         }
                        string filepath2 = data[0]["Path_IMG2"].ToString().Trim();
                        string filepath3 = data[0]["Path_IMG3"].ToString().Trim();
                        if (filepath1 != "" && filepath1 != null && filepath1 != "&nbsp;" && filepath1.Trim() != "X")
                        {

                            ((FileUpload)container.FindControl("FileUploadControl1")).Visible = false;
                            ((LinkButton)container.FindControl("gvlnkpath1")).Visible = true;
                            ((LinkButton)container.FindControl("gvlnkpath1")).ToolTip = filepath1;
                            ((LinkButton)container.FindControl("gvlnkdelfile1")).Visible = true;
                            ((LinkButton)container.FindControl("gvlnkdelfile1")).CommandArgument = filepath1;
                            for (int i = 0; i < filepath1.Length; i++)
                            {
                                if (filepath1[i].ToString() == @"\")
                                {
                                    startingindex = i;
                                }
                            }
                            ((LinkButton)container.FindControl("gvlnkpath1")).Text = filepath1.Substring(startingindex + 1);
                        }
                        startingindex = 0;
                        if (filepath2 != "" && filepath2 != null && filepath2 != "&nbsp;" && filepath2.Trim() != "X")
                        {
                            ((FileUpload)container.FindControl("FileUploadControl2")).Visible = false;
                            ((LinkButton)container.FindControl("gvlnkpath2")).Visible = true;

                            ((LinkButton)container.FindControl("gvlnkpath2")).ToolTip = filepath2;
                            ((LinkButton)container.FindControl("gvlnkdelfile2")).Visible = true;
                            ((LinkButton)container.FindControl("gvlnkdelfile2")).CommandArgument = filepath2;
                            for (int i = 0; i < filepath2.Length; i++)
                            {
                                if (filepath2[i].ToString() == @"\")
                                {
                                    startingindex = i;
                                }
                            }
                            ((LinkButton)container.FindControl("gvlnkpath2")).Text = filepath2.Substring(startingindex + 1);
                        }
                        startingindex = 0;
                        if (filepath3 != "" && filepath3 != null && filepath3 != "&nbsp;" && filepath3.Trim() != "X")
                        {
                            ((FileUpload)container.FindControl("FileUploadControl3")).Visible = false;
                            ((LinkButton)container.FindControl("gvlnkpath3")).Visible = true;
                            ((LinkButton)container.FindControl("gvlnkpath3")).ToolTip = filepath3;
                            ((LinkButton)container.FindControl("gvlnkdelfile3")).Visible = true;
                            ((LinkButton)container.FindControl("gvlnkdelfile3")).CommandArgument = filepath3;
                            for (int i = 0; i < filepath3.Length; i++)
                            {
                                if (filepath3[i].ToString() == @"\")
                                {
                                    startingindex = i;
                                }
                            }
                            ((LinkButton)container.FindControl("gvlnkpath3")).Text = filepath3.Substring(startingindex + 1);
                        }
                    }
                    catch { }

                    ////////////////////////////////////////////////-------------/////////////////////////////////////////
                    #endregion
                }

                GridView gvDisease = (GridView)container.FindControl("gvDiseases");
                if (null != gvDisease)
                {
                    DataView dv_Diseases = FillgvDiseases(testtid);
                    gvDisease.DataSource = dv_Diseases;
                    gvDisease.DataBind();
                    dv_Diseases.Dispose();
                }

                GridView gvComments = (GridView)container.FindControl("gvComments");
                if (null != gvComments)
                {
                    DataView dvComments = FillgvComments(testtid);
                    gvComments.DataSource = dvComments;
                    gvComments.DataBind();
                    dvComments.Dispose();

                }

                clsBlPeerReviews obj_Reviews = new clsBlPeerReviews();
                obj_Reviews.DSerialNo = DSerialNo;
                DataView dv_PeerReviews = obj_Reviews.GetAll(3);
                if (dv_PeerReviews.Count > 0)
                {
                    ((Panel)container.FindControl("pnlComments")).Visible = true;
                    ((ImageButton)container.FindControl("gvimgReviewComments")).Visible = true;
                    ((GridView)container.FindControl("gvPeerReviews")).DataSource = dv_PeerReviews;
                    ((GridView)container.FindControl("gvPeerReviews")).DataBind();
                }

                clsBlTestSops objtestsops = new clsBlTestSops();
                objtestsops.TestID = testid;
                DataView dvtestsops = objtestsops.GetAll(2);
                if (dvtestsops.Count == 0)
                {
                    (e.Item.Cells[7].FindControl("ibtnSOP") as ImageButton).Visible = false;
                }
            }
        }

        protected void ibtnSelection_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent);

            TableCell tbc = ((TableCell)((ImageButton)sender).Parent);
            ListBox lbSelection = ((ListBox)tbc.FindControl("lbSelection"));

            if (lbSelection.Visible)
            {
                lbSelection.Visible = false;
            }
            else
            {
                if (lbSelection.Items.Count == 0)
                {

                    String AttributeID = String.Empty;
                    AttributeID = dgItem.Cells[0].Text.ToString();
                    if (null != lbSelection)
                    {
                        //clsBlAttributeTemplates obj_Templates = new clsBlAttributeTemplates();
                        //obj_Templates.AttributeID = AttributeID;
                        //DataView dvSection = obj_Templates.GetAll(3);
                        //SComponents objComp = new SComponents();
                        //objComp.FillListBox(lbSelection, dvSection, "Description", "TemplateID", true);
                        clsBLTestAttribute objTestAttribute = new clsBLTestAttribute();
                        SComponents objComp = new SComponents();

                        objTestAttribute.AttributeID = AttributeID;
                        DataView dvSection = objTestAttribute.GetAll(5);
                        objComp.FillListBox(lbSelection, dvSection, "SValue", "SValue", true);
                    }
                }
                lbSelection.Visible = (lbSelection.Items.Count > 0);
            }
        }

        protected void lbSelection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TableCell tbc = ((TableCell)((ListBox)sender).Parent);
            ListBox lbSelection = ((ListBox)tbc.FindControl("lbSelection"));
            TextBox dgAttributeResult = ((TextBox)tbc.FindControl("dgAttributeResult"));


            dgAttributeResult.Text = lbSelection.SelectedItem.ToString();
            lbSelection.Visible = false;
        }

        protected void dgAttribute_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            Control container = e.Item;
            ListItemType itemType = e.Item.ItemType;

            if (itemType == ListItemType.Item || itemType == ListItemType.Footer || itemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem == null)
                {
                    return;
                }
                ListBox lbSelection = ((ListBox)container.FindControl("lbSelection"));
                lbSelection.Visible = false;

                //TextBox dgAttributeResult = (TextBox) container.FindControl("dgAttributeResult");

                //dgAttributeResult.Text = e.Item.Cells[0].Text.ToString();

                /*DropDownList ddlSelection = (DropDownList) container.FindControl("ddlSelection");				

                DropDownList ddlSelection = (DropDownList) container.FindControl("ddlSelection");				
                String AttributeID = String.Empty;
                AttributeID = e.Item.Cells[0].Text.ToString();
                if (null != ddlSelection)
                {	
                    clsBLTestAttribute objTestAttribute = new clsBLTestAttribute();
                    SComponents objComp = new SComponents();

                    objTestAttribute.AttributeID = AttributeID;
                    DataView dvSection = objTestAttribute.GetAll(5);
                    objComp.FillDropDownList(ddlSelection, dvSection, "SValue", "SValue");
                }							*/
            }
        }

        private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DisplayNextPatient();
        }

        private void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>self.close();</script>");
        }

        protected void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent.Parent);

            string sMSerialNo = lblMSerialNo.Text;
            string sTestID = dgItem.Cells[2].Text;
            string sDSerialNo = dgItem.Cells[1].Text;

            FileUpload FileUploadControl1 = (FileUpload)dgItem.Cells[7].FindControl("FileUploadControl1");
            FileUpload FileUploadControl2 = (FileUpload)dgItem.Cells[7].FindControl("FileUploadControl2");
            FileUpload FileUploadControl3 = (FileUpload)dgItem.Cells[7].FindControl("FileUploadControl3");


            DropDownList ddl = (DropDownList)dgItem.Cells[7].FindControl("dgddlForwardtoIT");
            string sProcessID = ddl.SelectedItem.Value;
          
            TextBox txt1 = (TextBox)dgItem.Cells[7].FindControl("dgtxtOpinionET");
            string sOpinion = txt1.Text;

            TextBox txt2 = (TextBox)dgItem.Cells[7].FindControl("dgtxtCommentET");
            string sComment = txt2.Text;

            TextBox txtHistory = (TextBox)dgItem.Cells[7].FindControl("txtHistory");
            string sHistory = txtHistory.Text;

            DataGrid dg1 = (DataGrid)dgItem.Cells[7].FindControl("dgAttribute");
            string[,] AttributeResult = new string[dg1.Items.Count, 11];
            for (int i = 0; i < dg1.Items.Count; i++)
            {
                AttributeResult[i, 0] = dg1.Items[i].Cells[0].Text; //AttributeID
                AttributeResult[i, 1] = ((TextBox)dg1.Items[i].Cells[3].FindControl("dgAttributeResult")).Text; //Result
                if (AttributeResult[i, 1].Equals(""))
                {
                    AttributeResult[i, 1] = "-";
                }
                if (AttributeResult[i, 1].Length > 1024)
                {
                    AttributeResult[i, 1] = AttributeResult[i, 1].Substring(0, 1024);
                }

                AttributeResult[i, 2] = "Y"; //Print
                AttributeResult[i, 3] = dg1.Items[i].Cells[6].Text; //MinRange
                AttributeResult[i, 4] = dg1.Items[i].Cells[7].Text; //MaxRange
                AttributeResult[i, 5] = dg1.Items[i].Cells[5].Text; //RUnit			
                AttributeResult[i, 6] = (((CheckBox)dg1.Items[i].Cells[1].FindControl("chkRPrint")).Checked == true) ? "Y" : "N"; //Report
                AttributeResult[i, 7] = ""; //MinPanicValue
                AttributeResult[i, 8] = ""; //MaxPanicValue
                AttributeResult[i, 9] = "T";//Attribute Type
                AttributeResult[i, 10] = AttributeResult[i, 3] + AttributeResult[i, 4] + AttributeResult[i, 5];
            }

            clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

            objTGenTestResult.DSerialNo = sDSerialNo;
            objTGenTestResult.NextProcessID = sProcessID;
            objTGenTestResult.MSerialNo = sMSerialNo;
            objTGenTestResult.TestID = sTestID;
            objTGenTestResult.Times = "0";
            objTGenTestResult.Opinion = sOpinion;
            objTGenTestResult.Comments = sComment;
            objTGenTestResult.Sensitivity = "N";
            objTGenTestResult.History = sHistory;

            objTGenTestResult.currProcessID = Request.QueryString["ProcessID"].ToString();
            if (Request.QueryString["ProcessID"].ToString().Trim() == "0004")
            {
                objTGenTestResult.EnteredBy = Session["loginid"].ToString();
                objTGenTestResult.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else if (Request.QueryString["ProcessID"].ToString().Trim() == "0005")
            {
                objTGenTestResult.EvaluatedBy = Session["loginid"].ToString().Trim();
                objTGenTestResult.EvaluatedOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            objTGenTestResult.ClientID = "0005";
            objTGenTestResult.PRNo = lblPRNo.Text.Trim();
            if (sProcessID == "0002")
            {
                objTGenTestResult.Spec_Coment = txt2.Text.Trim();
            }
            objTGenTestResult.System_IP = getIpAddress();

            if (!FileUploadControl1.FileName.Equals(""))
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl1.FileName);
                    FileUploadControl1.SaveAs(path_images + @"\" + filename);
                    objTGenTestResult.path_Img1 = path_images + @"\" + filename;
                    //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

                }
                catch (Exception ee)
                {
                    lblErrMsg.Text = ee.ToString();
                }
            }
            if (!FileUploadControl2.FileName.Equals(""))
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl2.FileName);
                    FileUploadControl2.SaveAs(path_images + @"\" + filename);
                    objTGenTestResult.path_Img2 = path_images + @"\" + filename;
                    //FileUploadControl2.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    //objTGenTestResult.path_Img2 = Server.MapPath("~/Uploads/") + filename;
                }
                catch (Exception ee)
                {
                    lblErrMsg.Text = ee.ToString();
                }
            }
            if (!FileUploadControl3.FileName.Equals(""))
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl3.FileName);
                    FileUploadControl3.SaveAs(path_images + @"\" + filename);
                    objTGenTestResult.path_Img3 = path_images + @"\" + filename;
                    //FileUploadControl3.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    //objTGenTestResult.path_Img3 = Server.MapPath("~/Uploads/") + filename;
                }
                catch (Exception ee)
                {
                    lblErrMsg.Text = ee.ToString();
                }
            }

            objTGenTestResult.MethodID = ((DropDownList)dgItem.Cells[7].FindControl("dgDDLMethod")).SelectedValue.ToString().Trim();// Method ID For TestResultM
            updatePictures(filecontent(FileUploadControl1), filecontent(FileUploadControl2), getfilename(FileUploadControl1), getfilename(FileUploadControl2), sDSerialNo);
            bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult, AttributeResult, "N");

            if (!isSuccessful)
            {
                this.lblErrMsg.Text = objTGenTestResult.ErrorMessage;
            }
            else
            {
                if (((CheckBox)dgItem.Cells[7].FindControl("chkRepeat")).Checked == true)
                {
                    clsBlRepeatTest obj_repeattest = new clsBlRepeatTest();
                    obj_repeattest.LabID = lblLabID.Text.Trim();
                    obj_repeattest.TestID = sTestID;
                    obj_repeattest.RepeatReasonID = ((DropDownList)dgItem.Cells[7].FindControl("ddlRepeatReasons")).SelectedValue.ToString();
                    obj_repeattest.EnteredBy = Session["loginid"].ToString();
                    obj_repeattest.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_repeattest.ClientID = "005";
                    obj_repeattest.PRNumber = lblPRNo.Text.Trim();
                    if (obj_repeattest.insert())
                    {
                        lblErrMsg.Text = "Insertion Successful";
                    }
                }
                try
                {
                    clsBLTransHistory objTTransHistory = new clsBLTransHistory();

                    objTTransHistory.MSERIALNO = sMSerialNo;
                    objTTransHistory.DSERIALNO = sDSerialNo;
                    objTTransHistory.PROCESSID = ProcessID;
                    objTTransHistory.PERSONID = Session["loginid"].ToString();
                    objTTransHistory.Insert();
                }
                catch { };

                dgTest.EditItemIndex = -1;
                DisplayPatient(sMSerialNo);
            }


        }

        private void ibtnPatientStatus_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno=" + sMSerialNo + "','','channelmode')</script>");
        }

        private void ibtnViewOtherResult_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT2.MSerialNo} in [" + lblMSerialNo.Text + "]";

            LIMS.reports.GeneralReports.PdfSetting = null;
            LIMS.reports.GeneralReports.ReportReference = "LMS-001-11";
            LIMS.reports.GeneralReports.mFromDate = "";
            LIMS.reports.GeneralReports.mToDate = "";

            Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-11','','channelmode')</script>");
        }

        protected void ibtnOpinion_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent.Parent);
            this.dgTest.SelectedIndex = dgItem.ItemIndex;
            SelectedOpinion = ((TextBox)this.dgTest.SelectedItem.Cells[7].FindControl("dgtxtOpinionET")).ClientID.ToString();

            Response.Write("<script language='javascript'>window.open('wfrmOpinion.aspx?testID=" + this.dgTest.SelectedItem.Cells[2].Text + "', '', 'scrollbars=yes');</script>");
        }

        protected void ibtnComment_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            #region oldcode
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent.Parent);
            this.dgTest.SelectedIndex = dgItem.ItemIndex;
            SelectedComment = ((TextBox)this.dgTest.SelectedItem.Cells[7].FindControl("dgtxtCommentET")).ClientID.ToString();

            Response.Write("<script language='javascript'>window.open('wfrmComment.aspx?testID=" + this.dgTest.SelectedItem.Cells[2].Text + "','','scrollbars=yes');</script>");
            #endregion
            //DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent.Parent);
            //int rowindex = dgItem.ItemIndex;
            //((TextBox)dgTest.Items[rowindex].Cells[7].FindControl("dgtxtCommentET")).Visible = true;
            //((LinkButton)dgTest.Items[rowindex].Cells[7].FindControl("lnksavecomment")).Visible = true;
        }
        protected void ibtnResultByPRNo_Click(object sender, ImageClickEventArgs e)
        {
            if (!lblPRNo.Text.Equals(""))
            {
               // LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT1.PRNO} = '" + lblPRNo.Text + "'";
                LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT2.PRNO} = '" + lblPRNo.Text + "'";
                LIMS.reports.GeneralReports.PdfSetting = null;
                LIMS.reports.GeneralReports.ReportReference = "LMS-001-11";
                //LIMS.reports.GeneralReports.mFromDate = "";
                //LIMS.reports.GeneralReports.mToDate = "";

                Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-11','','channelmode')</script>");
            }
        }

        private void FillDDLPathologists(int index)
        {
            #region "Depricated"
            // clsBLICDDiseases obj_Diseases = new clsBLICDDiseases();
           // SComponents objComp = new SComponents();
           // DataView dv_diseases = obj_Diseases.GetAll(5);

           // DataTable dt = new DataTable();
           // dt.Columns.Add("diseasename");
           // dt.Columns.Add("diseasecode");
           // dt.Columns.Add("diseaseid");

           // DataRow dr = dt.NewRow();
           // dr["diseasename"] = "Select";
           // dr["diseasecode"] = "Select";
           // dr["diseaseid"] = "-1";
           // dt.Rows.Add(dr);
           // for (int i = 0; i < dv_diseases.Count; i++)
           // {
           //     dr = dt.NewRow();
           //     dr["diseasename"] = dv_diseases[i]["diseasename"].ToString();
           //     dr["diseasecode"] = dv_diseases[i]["diseasecode"].ToString();
           //     dr["diseaseid"] = dv_diseases[i]["diseaseid"].ToString();
           //     dt.Rows.Add(dr);
           // }
           //dv_diseases = new DataView(dt);

            // return dv_diseases;
            #endregion
            PatientRegView prv = new PatientRegView();
            DropDownList DDLPathologist = (DropDownList)dgTest.Items[index].Cells[7].FindControl("DDLPathologist");
            DataView dv_pathologists = prv.GetAll(21);
            if (dv_pathologists.Count > 0)
            {
                SComponents ddlrefby = new SComponents();
                ddlrefby.FillDropDownList(DDLPathologist, dv_pathologists, "PersonName", "PersonID");
                ddlrefby = null;

            }
            DDLPathologist.Focus();
            dv_pathologists.Dispose();
        }

        protected void ddlDiseasename_SelectedIndexchanged(object sender, EventArgs e)
        {
            // lblName.Text = "abcd";

            DataGridItem dgItem = ((DataGridItem)((DropDownList)sender).Parent.Parent.Parent.Parent.Parent.Parent);
            DropDownList ddlname = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasename");
            string _diseasename = ddlname.SelectedValue.ToString();
            DropDownList ddlcode = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasecode");
            ddlcode.ClearSelection();
            ddlcode.Items.FindByValue(_diseasename).Selected = true;


        }
        protected void ddlDiseasecode_SelectedIndexchanged(object sender, EventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((DropDownList)sender).Parent.Parent.Parent.Parent.Parent.Parent);
            DropDownList ddlcode = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasecode");
            string _diseaseid = ddlcode.SelectedValue.ToString();
            DropDownList ddlname = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasename");
            ddlname.ClearSelection();
            ddlname.Items.FindByValue(_diseaseid).Selected = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            #region Depricated
            // clsBLDiagnose obj_Diagnose = new clsBLDiagnose();

            // DataGridItem dgItem = ((DataGridItem)((Button)sender).Parent.Parent.Parent.Parent.Parent.Parent);
            // DropDownList ddl = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasename");
            //// DataGrid dgAttri = (DataGrid)dgItem.Cells[7].FindControl("dgAttribute");
            // int rowindex = dgItem.ItemIndex;

            // testid = dgTest.Items[rowindex].Cells[2].Text;


            // DropDownList ddlcode = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasecode");
            // if (ddl.SelectedValue.ToString() == "-1" || ddlcode.SelectedValue.ToString() == "-1")
            // {
            //     lblErrMsg.Text = "Please Select Disease";

            // }
            // else
            // {
            //     obj_Diagnose.ClientID = "0005";
            //     obj_Diagnose.DiseaseID = ddl.SelectedValue.ToString();
            //     obj_Diagnose.DiseaseName = ddl.SelectedItem.Text;
            //     obj_Diagnose.ICDCode = ddlcode.SelectedItem.Text;
            //     obj_Diagnose.EnteredBy = Session["loginid"].ToString();
            //     obj_Diagnose.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            //     CheckBox chprint = (CheckBox)(dgItem.Cells[7].FindControl("chkPrint"));
            //     obj_Diagnose.Print = chprint.Checked == true ? "Y" : "N";
            //     obj_Diagnose.PRNumber = lblPRNo.Text;
            //     obj_Diagnose.TestID = testid;
            //     obj_Diagnose.LabID = lblLabID.Text;


            //     if (obj_Diagnose.Insert())
            //     {
            //         DataView dv_diseases = obj_Diagnose.GetAll(1);
            //         ((GridView)(dgTest.Items[rowindex].Cells[7].FindControl("gvDiseases"))).DataSource = dv_diseases;
            //         ((GridView)(dgTest.Items[rowindex].Cells[7].FindControl("gvDiseases"))).DataBind();
            //         //((GridView)(dgItem.Cells[7].FindControl("gvDiseases"))).DataSource = dv_diseases;
            //         // gvDis.DataSource = dv_diseases;
            //         dv_diseases.Dispose();
            //         obj_Diagnose = null;
            //         //FillgvDiseases(testid);
            //        // DisplayPatient(sMSerialNo);
            //     }
            //     else
            //     {
            //         this.lblErrMsg.Text = obj_Diagnose.Errormessage;
            //     }
            // }
            #endregion
            #region Refer to Peer--- Code
            DataGridItem dgItem = ((DataGridItem)((Button)sender).Parent.Parent.Parent.Parent.Parent.Parent);
            DropDownList ddl = (DropDownList)dgItem.Cells[7].FindControl("DDLPathologist");


            int rowindex = dgItem.ItemIndex;

            string DSerialNumber = dgTest.Items[rowindex].Cells[1].Text.Trim();
            string ReferredBy = Session["loginid"].ToString().Trim();
            string ReferredTo = ddl.SelectedValue.ToString().Trim();
            string EnteredBy = Session["loginid"].ToString().Trim();
            string EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            string ClientID = "0005";
            string System_Ip = Request.UserHostAddress.ToString().Trim();

            clsBlPeerReviews obj_Peers = new clsBlPeerReviews();
            obj_Peers.ReferredBy = ReferredBy;
            obj_Peers.ReferredTo = ReferredTo;
            obj_Peers.EnteredBy = EnteredBy;
            obj_Peers.EnteredOn = EnteredOn;
            obj_Peers.ClientID = ClientID;
            obj_Peers.System_Ip = System_Ip;
            obj_Peers.DSerialNo = DSerialNumber;
            obj_Peers.Reviewed = "N";

            if (obj_Peers.Insert())
            {
                lblErrMsg.Text = "<font color='green'>Test Added for Peer Review.</font>";


            }
            else
            {
                lblErrMsg.Text = obj_Peers.ErrorMessage;
            }




            #endregion
        }

        protected void gvDiseases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Delete")
            //{
            //    //lblErrMsg.Text = "Delete button Called";
            //    int rowindex = int.Parse(e.CommandArgument.ToString());
            //    DataGridItem dgItem = ((DataGridItem)((GridView)sender).Parent.Parent.Parent);
            //    GridView gvdisease = (GridView)dgItem.Cells[7].FindControl("gvDiseases");
            //    string id = gvdisease.DataKeys[rowindex].Value.ToString();
            //    clsBLDiagnose obj_diagnosis = new clsBLDiagnose();
            //    obj_diagnosis.DiagnosisID = id;
            //    if (obj_diagnosis.delete())
            //    {
            //        //FillgvDiseases();
            //        //DisplayPatient(sMSerialNo);
            //        Response.Redirect(Request.Url.ToString());
            //    }
            //    else
            //    {
            //        lblErrMsg.Text = obj_diagnosis.Errormessage;
            //    }

            //}
        }

        protected DataView FillgvDiseases(string str)
        {

            clsBLDiagnose obj_diagnose = new clsBLDiagnose();
            obj_diagnose.LabID = lblLabID.Text;
            obj_diagnose.TestID = str;
            //DataView dv =
            return obj_diagnose.GetAll(1);
            //if (dv.Count > 0)
            //{
            //    gvDiseases.DataSource = dv;
            //    gvDiseases.DataBind();
            //}


        }


        protected void ibtnsearch_Click(object sender, EventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((Button)sender).Parent.Parent.Parent.Parent.Parent.Parent);
            //DropDownList ddl = (DropDownList)dgItem.Cells[7].FindControl("DDLdiseasename");

            int rowindex = dgItem.ItemIndex;

            testid = dgTest.Items[rowindex].Cells[2].Text;
           
            //Response.Write("<script language='javascript'>window.open('wfrmICD_Diseases.aspx','channel mode');</script>");
            Response.Write("<script language='javascript'>window.open('wfrmICD_Diseases.aspx?testid="+ testid  + "&labid=" + lblLabID.Text + "&PRNumber=" + lblPRNo.Text + "&MSerialNum=" + lblMSerialNo.Text + "&SectionID=" + SectionID + "&ProcessID=" + ProcessID + "&Type=H','channel mode');</script>");
        }

        protected void gvDiseases_RowDeleting_Click(object sender, GridViewDeleteEventArgs e)
        {
            int rowindex = e.RowIndex;
            DataGridItem dgItem = ((DataGridItem)((GridView)sender).Parent.Parent.Parent.Parent);
            int index_row = dgItem.ItemIndex;
            testid = dgTest.Items[index_row].Cells[2].Text;
            GridView gvdisease = (GridView)dgItem.Cells[7].FindControl("gvDiseases");
            string id = gvdisease.DataKeys[rowindex].Value.ToString();
            clsBLDiagnose obj_diagnosis = new clsBLDiagnose();
            obj_diagnosis.DiagnosisID = id;
            if (obj_diagnosis.delete())
            {

                obj_diagnosis.LabID = lblLabID.Text;
                obj_diagnosis.TestID = testid;
                DataView dv_diseases = obj_diagnosis.GetAll(1);
                gvdisease.DataSource = dv_diseases;
                gvdisease.DataBind();
                //((GridView)(dgTest.Items[index_row].Cells[7].FindControl("gvDiseases"))).DataSource = dv_diseases;
                //((GridView)(dgTest.Items[index_row].Cells[7].FindControl("gvDiseases"))).DataBind();
                //((GridView)(dgItem.Cells[7].FindControl("gvDiseases"))).DataSource = dv_diseases;
                // gvDis.DataSource = dv_diseases;
                dv_diseases.Dispose();
                obj_diagnosis = null;
                // DisplayPatient(sMSerialNo);
                //FillgvDiseases(testid);
                //Response.ContentType = "text/HTML";
                //Response.Redirect(Request.Url.ToString());

            }
            else
            {
                lblErrMsg.Text = obj_diagnosis.Errormessage;
            }


        }

        protected void lnkbtnPeerReview_Click(object sender, EventArgs e)
        {
            LinkButton btnPeerReview = ((LinkButton)sender);
            //string ids = btnDiagnosis.Parent.Parent.UniqueID.ToString();
            DataGridItem dgItem = (DataGridItem)btnPeerReview.Parent.Parent.Parent;
            int testgridindex = dgItem.ItemIndex;
            if (dgItem.Cells[7].FindControl("tblDiagnosis").Visible == true)
            {
                dgItem.Cells[7].FindControl("tblDiagnosis").Visible = false;
            }
            else
            {
                dgItem.Cells[7].FindControl("tblDiagnosis").Visible = true;
                FillDDLPathologists(testgridindex);
            }
            
            //lblErrMsg.Text = testgridindex.ToString();
        }

        protected void chkReport_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkrepeat = (CheckBox)sender;
            if (chkrepeat.Checked == true)
            {
                DataGridItem dgItem = (DataGridItem)chkrepeat.Parent.Parent.Parent;
                dgItem.Cells[7].FindControl("lblReasons").Visible = true;
                dgItem.Cells[7].FindControl("ddlRepeatReasons").Visible = true;
                DropDownList ddlRepeatResons = (DropDownList)dgItem.Cells[7].FindControl("ddlRepeatReasons");
                clsBLRepeatReasons obj_Reasons = new clsBLRepeatReasons();
                SComponents obj_comp = new SComponents();
                DataView dv_Reasons = obj_Reasons.GetAll(1);
                if (dv_Reasons.Count > 0)
                {
                    obj_comp.FillDropDownList(ddlRepeatResons, dv_Reasons, "Reason", "REPEATREASON_ID");

                    //((DropDownList)(dgItem.Cells[7].FindControl("ddlRepeatReasons"))).DataSource = dv_Reasons;
                    //((DropDownList)(dgItem.Cells[7].FindControl("ddlRepeatReasons"))).DataBind();

                }
                obj_comp = null;
                ((TextBox)(dgItem.Cells[7].FindControl("dgtxtCommentET"))).Text = "** Test Repeat **";

            }

            else
            {
                DataGridItem dgItem = (DataGridItem)chkrepeat.Parent.Parent.Parent;
                dgItem.Cells[7].FindControl("lblReasons").Visible = false;
                dgItem.Cells[7].FindControl("ddlRepeatReasons").Visible = false;
                ((TextBox)(dgItem.Cells[7].FindControl("dgtxtCommentET"))).Text = "";
            }

        }

        private string getIpAddress()
        {
            return Request.UserHostAddress;
        }
        private bool VD_ForwardProcess(DataGridItem dgItem)
        {
            if (((CheckBox)dgItem.Cells[7].FindControl("chkRepeat")).Checked == true)
            {
                int current_process = Convert.ToInt32(Request.QueryString["ProcessID"].ToString());
                DropDownList ddlForward = (DropDownList)dgItem.Cells[7].FindControl("dgddlForwardtoIT");
                int Forward_Process = Convert.ToInt32(ddlForward.SelectedValue.ToString());
                if (Forward_Process > current_process)
                {

                    return false;
                }

                //int ForwardProcess=Convert.ToInt

            }

            return true;

        }


        protected void ibtn_SOPClick(object sender, CommandEventArgs e)
        {
           // DataGridItem dgItem = (DataGridItem)((ImageButton)sender).Parent.Parent.Parent.Parent.Parent.Parent.Parent;
            int rowindex = Convert.ToInt16(e.CommandArgument);
            testid = dgTest.Items[rowindex].Cells[2].Text;
            //lblErrMsg.Text = dgItem.UniqueID.ToString();
            Response.Write("<script language = 'javascript'>window.open('wfrmSOPresultge.aspx?id=" + ProcessID + "&TestID=" + testid + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
            //Response.Write("<script language='javascript'>window.open('wfrmSOPResultGE.aspx?Processid="+ProcessID+"&TestID="+testid+",'channelmode'')</script>");

        }

        protected void lnkbtnEval_Click(object sender, EventArgs e)
        {

            DataGridItem dgItem = (DataGridItem)((LinkButton)sender).Parent.Parent.Parent;
            int rowindex = dgItem.ItemIndex;
            testid = dgTest.Items[rowindex].Cells[2].Text;
            //lblErrMsg.Text = testid;
            Response.Write("<script language = 'javascript'>window.open('wfrmEmployeeEvaluation.aspx?testid=" + testid + "&MSerialNo=" + lblMSerialNo.Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
            // Response.Write("<script language='javascript'>window.open(wfrmEmployeeEvaluation.aspx?testid=" + testid + "&MSerialNo=" + lblMSerialNo.Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");


        }

        private DataView FillgvComments(string testtid)
        {
            clsBlTestResultComments obj_Comments = new clsBlTestResultComments();
            obj_Comments.LabId = lblLabID.Text;
            obj_Comments.TestID = testtid;
            DataView dvComments = obj_Comments.GetAll(1);
            return dvComments;


        }

        protected void lnkbtnsavecomment_Click(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "save")
            {
                clsBlTestResultComments obj_Comments = new clsBlTestResultComments();
                obj_Comments.LabId = lblLabID.Text;
                DataGridItem dgItem = ((DataGridItem)((LinkButton)sender).Parent.Parent.Parent);
                int rowindex = dgItem.ItemIndex;

                obj_Comments.TestID = dgTest.Items[rowindex].Cells[2].Text;
                TextBox txtComment = (TextBox)dgItem.Cells[7].FindControl("dgtxtCommentET");
                obj_Comments.Comment = txtComment.Text;
                obj_Comments.EnteredBy = Session["loginid"].ToString();
                obj_Comments.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_Comments.ClientID = "0005";
                obj_Comments.System_Ip = Request.UserHostAddress.ToString();
                if (obj_Comments.insert())
                {
                    DataView dv_Comments = obj_Comments.GetAll(1);
                    ((GridView)(dgTest.Items[rowindex].Cells[7].FindControl("gvComments"))).DataSource = dv_Comments;
                    ((GridView)(dgTest.Items[rowindex].Cells[7].FindControl("gvComments"))).DataBind();
                    dv_Comments.Dispose();
                    obj_Comments = null;
                    txtComment.Text = "";
                    txtComment.Visible = true;
                    ((LinkButton)sender).Visible = false;
                }

            }
        }

        protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMethod = (DropDownList)sender;

            if (ddlMethod.SelectedValue.ToString().Trim() != "-1")
            {
                string methodid = "";
                methodid = ddlMethod.SelectedValue.ToString().Trim();
                string parentid = ddlMethod.Parent.Parent.UniqueID.ToString();
                DataGridItem dgItem = ((DataGridItem)ddlMethod.Parent.Parent);
                int rowindex = dgItem.ItemIndex;
                string DSerialNo = "";
                DSerialNo = dgTest.Items[rowindex].Cells[1].Text.Trim();
                string testtid = dgTest.Items[rowindex].Cells[2].Text.Trim();
                /////////////////////////////////Updating method used in performing the test///////////////////////////////
                clsBLGeneralTestResult obj_generaltest = new clsBLGeneralTestResult();
                obj_generaltest.MethodID = methodid;
                obj_generaltest.DSerialNo = DSerialNo;

                //////////////////////////////////////----------//////////////////////////////////////
                if (obj_generaltest.UpdateMethod())
                {
                    DataGrid gvAttributes = (DataGrid)dgTest.Items[rowindex].Cells[7].FindControl("dgAttribute");
                    if (null != gvAttributes)
                    {
                        DataView data = new DataView();
                        data = DisplayAttribute(DSerialNo, ddlMethod.SelectedValue.ToString().Trim(),testtid);

                        gvAttributes.DataSource = data;
                        gvAttributes.DataBind();
                    }
                }




            }
        }

        private DataView FillMethodDDL(string testid)
        {
            clsBlTestMethod obj_TestMethods = new clsBlTestMethod();
            obj_TestMethods.TestID = testid;
            DataView dv_methods = obj_TestMethods.GetAll(7);
            return dv_methods;
        }
        protected void gvlnkPath1_Click(object sender, EventArgs e)
        {
            LinkButton lnkPath1 = (LinkButton)sender;
            string filepath = lnkPath1.ToolTip.ToString();// @"D:\negno25462.jpg";
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }

        }
        protected void gvlnkPath2_Click(object sender, EventArgs e)
        {
            LinkButton lnkPath2 = (LinkButton)sender;
            string filepath = lnkPath2.ToolTip.ToString();// @"D:\negno25462.jpg";
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }
        }
        protected void gvlnkPath3_Click(object sender, EventArgs e)
        {
            LinkButton lnkPath3 = (LinkButton)sender;
            string filepath = lnkPath3.ToolTip.ToString();// @"D:\negno25462.jpg";
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }
        }

        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";

                case ".docx":
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        protected void btnSearchDisease_Click(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt16(e.CommandArgument);
            if (((TextBox)dgTest.Items[index].Cells[7].FindControl("txtItemName")).Text.Trim() != "")
            {
                FillgvsearchDiagnosis(((TextBox)dgTest.Items[index].Cells[7].FindControl("txtItemName")).Text.Trim(), index);
                ((GridView)dgTest.Items[index].Cells[7].FindControl("gvDiagnosissearch")).Focus();
            }
            //if (txtItemName.Text.Trim() != "")
            //{

            //    FillgvsearchDiagnosis();
            //    gvDiagnosissearch.Focus();
            //}
            //else
            //{
            //    lblErrMsg.Text = "Enter Search Query";
            //}
        }
        private void FillgvsearchDiagnosis(string squery, int index)
        {
            clsBLICDDiseases obj_Diseases = new clsBLICDDiseases();
            obj_Diseases.SearchQuery = squery;//.Text.Trim();
            DataView Diseases = obj_Diseases.GetAll(3);
            if (Diseases.Count > 0)
            {

                //divsearcharea.Visible = true;
                ((GridView)dgTest.Items[index].Cells[7].FindControl("gvDiagnosissearch")).DataSource = Diseases;
                ((GridView)dgTest.Items[index].Cells[7].FindControl("gvDiagnosissearch")).DataBind();
            }
            //else
            //{
            //    lblErrMsg.Text = "No Such Disease Found";
            //}
        }


        protected void gvDiagnosissearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            DataGridItem dgTestItem = (DataGridItem)((System.Web.UI.WebControls.GridView)sender).Parent.Parent.Parent.Parent.Parent;
            int dgtestindex = dgTestItem.ItemIndex;
            GridView gvDiagnosissearch = (GridView)dgTest.Items[dgtestindex].Cells[7].FindControl("gvDiagnosissearch");
            GridView gvDiseases = (GridView)dgTest.Items[dgtestindex].Cells[7].FindControl("gvDiseases");
            if (e.CommandName == "Select")
            {
                clsBLDiagnose obj_Diagnose = new clsBLDiagnose();
                int index = Convert.ToInt16(e.CommandArgument);

                obj_Diagnose.ClientID = "0005";
                // obj_Diagnose.DiseaseID=(GridView)dgTest.Items[dgtestindex].Cells[7].FindControl("gvDiagnosissearch"))
                obj_Diagnose.DiseaseID = gvDiagnosissearch.DataKeys[index].Value.ToString().Trim();
                obj_Diagnose.DiseaseName = gvDiagnosissearch.Rows[index].Cells[2].Text.Trim();
                obj_Diagnose.ICDCode = gvDiagnosissearch.Rows[index].Cells[1].Text.Trim();
                obj_Diagnose.EnteredBy = Session["loginid"].ToString();
                obj_Diagnose.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                CheckBox chprint = (CheckBox)(gvDiagnosissearch.Rows[index].Cells[3].FindControl("gvdiagnosischkPrint"));
                obj_Diagnose.Print = chprint.Checked == true ? "Y" : "N";
                obj_Diagnose.PRNumber = lblPRNo.Text;

                obj_Diagnose.LabID = lblLabID.Text;
                obj_Diagnose.TestID = dgTest.Items[dgtestindex].Cells[2].Text.Trim();

                if (obj_Diagnose.Insert())
                {
                    gvDiagnosissearch.Rows[index].BackColor = System.Drawing.Color.SlateGray;
                    DataView dv_diseases = obj_Diagnose.GetAll(1);
                    gvDiseases.DataSource = dv_diseases;
                    gvDiseases.DataBind();
                    gvDiseases.Focus();

                }
                else
                {
                    this.lblErrMsg.Text = obj_Diagnose.Errormessage;
                }

            }
        }
        protected void gvimgReviewComments_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void lnkClose_Click(object sender, EventArgs e)
        {

        }
        protected void imghistory_Click(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt16(e.CommandArgument);
            string labid = lblLabID.Text.Trim();
            string PRNo = lblPRNo.Text.Trim();
            string TestId = dgTest.Items[index].Cells[2].Text.Trim();

            Response.Write("<script language='javascript'>window.open('wfrmhistoryTaking.aspx?labid=" + labid + "&testid=" + TestId + "&PRNo=" + PRNo + "');</script>");

        }

        protected void gvComments_RowDeleting_Click(object sender, GridViewDeleteEventArgs e)
        {
            int rowindex = e.RowIndex;
            DataGridItem dgItem = ((DataGridItem)((GridView)sender).Parent.Parent.Parent);
            int index_row = dgItem.ItemIndex;
            GridView gvComments = (GridView)dgItem.Cells[7].FindControl("gvComments");
            testid = dgTest.Items[index_row].Cells[2].Text;
            string commentid = gvComments.DataKeys[rowindex].Value.ToString().Trim();
            clsBlTestResultComments obj_comment = new clsBlTestResultComments();
            obj_comment.TestResultCommentID = commentid;
            if (obj_comment.delete())
            {
                obj_comment.LabId = lblLabID.Text;
                obj_comment.TestID = testid;
                DataView dv_comments = obj_comment.GetAll(1);
                gvComments.DataSource = dv_comments;
                gvComments.DataBind();

                dv_comments.Dispose();
                obj_comment = null;

            }

            else
            {
                lblErrMsg.Text = obj_comment.ErrorMessage;
            }







        }
        protected void gvlnkdelfile_Command(object sender, CommandEventArgs e)
        {
            DataGridItem dgITem = (DataGridItem)((LinkButton)sender).Parent.Parent.Parent;
            int index = dgITem.ItemIndex;
            string DSerialno = dgTest.Items[index].Cells[1].Text.Trim();
            clsBLGeneralTestResult obj_gen = new clsBLGeneralTestResult();
            obj_gen.DSerialNo = DSerialno;
            //obj_gen.path_Img1 = "X";

            if (e.CommandName == "file1")
            {
                deletePictures("1", DSerialno);
                obj_gen.path_Img1 = "X";
                if (obj_gen.UpdateLs_TdTransaction(false))
                {

                    LinkButton lnkdel = (LinkButton)sender;
                    string filepath = lnkdel.CommandArgument;
                    if (File.Exists(filepath))
                    {
                        try
                        {

                            File.Delete(filepath);

                        }
                        catch (Exception ee)
                        {
                            Response.Write(ee.ToString());
                        }
                    }
                    else
                    {
                        Response.Write("File don't Exist");
                    }
                    ((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl1")).Visible = true;
                    ((LinkButton)sender).Visible = false;
                    ((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath1")).Visible = false;
                    //lnkdel.Visible = false;
                }
            }

            if (e.CommandName == "file2")
            {
                deletePictures("2", DSerialno);
                obj_gen.path_Img2 = "X";
                if (obj_gen.UpdateLs_TdTransaction(false))
                {

                    LinkButton lnkdel = (LinkButton)sender;
                    string filepath = lnkdel.CommandArgument;
                    if (File.Exists(filepath))
                    {
                        try
                        {

                            File.Delete(filepath);

                        }
                        catch (Exception ee)
                        {
                            Response.Write(ee.ToString());
                        }
                    }
                    else
                    {
                        Response.Write("File don't Exist");
                    }
                    ((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl2")).Visible = true;
                    ((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath2")).Visible = false;
                    lnkdel.Visible = false;
                }
            }
            if (e.CommandName == "file3")
            {
                obj_gen.path_Img3 = "X";
                if (obj_gen.UpdateLs_TdTransaction(false))
                {

                    LinkButton lnkdel = (LinkButton)sender;
                    string filepath = lnkdel.CommandArgument;
                    if (File.Exists(filepath))
                    {
                        try
                        {

                            File.Delete(filepath);

                        }
                        catch (Exception ee)
                        {
                            Response.Write(ee.ToString());
                        }
                    }
                    else
                    {
                        Response.Write("File don't Exist");
                    }
                    ((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl3")).Visible = true;
                    ((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath3")).Visible = false;
                    lnkdel.Visible = false;
                }
            }

        }

        public void updatePictures(Byte[] imgByte1, Byte[] imgByte2, string filename1, string filename2, string Dserialno)
        {


            try
            {
                string connstr = "User ID=whims;Data Source=HIMS;Password=whims";
                OracleConnection conn = new OracleConnection(connstr);
                conn.Open();
                OracleCommand cmnd;
                string query;
                query = "update LS_tDTransaction set ";
                if (imgByte1 != null && filename1 != null)
                {
                    query += "image_binary1=:BlobParameter1,image1_name='" + filename1 + "'";


                }
                if (imgByte2 != null && filename2 != null)
                {
                    if (imgByte1 != null)
                    {
                        query += ",image_binary2=:BlobParameter2,image2_name='" + filename2 + "'";
                    }
                    else
                    {
                        query += "image_binary2=:BlobParameter2,image2_name='" + filename2 + "'";
                    }
                }
                query += " where DSerialNo='" + Dserialno + "'";
                // OracleParameter blobParameter = new OracleParameter();
                //blobParameter.OracleType = OracleType.Blob;
                // blobParameter.ParameterName = "BlobParameter";
                // blobParameter.Value = imgByte1;

                cmnd = new OracleCommand(query, conn);

                if (imgByte1 != null)
                {
                    cmnd.Parameters.AddWithValue("BlobParameter1", imgByte1);
                }
                if (imgByte2 != null)
                {
                    cmnd.Parameters.AddWithValue("BlobParameter2", imgByte2);
                }
                cmnd.ExecuteNonQuery();
                //lblIndicattor.Text = "added to blob field";
                cmnd.Dispose();
                conn.Close();

                conn.Dispose();
            }

            catch (Exception ex)
            {
                //lblIndicattor.Text = ex.Message;

            }
        }
        public void deletePictures(string fcontrolno, string Dserialno)
        {


            try
            {
                string connstr = "User ID=whims;Data Source=HIMS;Password=whims";
                OracleConnection conn = new OracleConnection(connstr);
                conn.Open();
                OracleCommand cmnd;
                string query;
                query = "update LS_tDTransaction set image_binary" + fcontrolno + "=Empty_blob(),image" + fcontrolno + "_name=null where DSerialNo='" + Dserialno + "'";
                // OracleParameter blobParameter = new OracleParameter();
                //blobParameter.OracleType = OracleType.Blob;
                // blobParameter.ParameterName = "BlobParameter";
                // blobParameter.Value = imgByte1;

                cmnd = new OracleCommand(query, conn);


                cmnd.ExecuteNonQuery();
                //lblIndicattor.Text = "added to blob field";
                cmnd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            catch (Exception ex)
            {
                //lblIndicattor.Text = ex.Message;

            }
        }

        public Byte[] filecontent(FileUpload upload)
        {
            FileUpload img = (FileUpload)upload;
            Byte[] imgByte = null;

            if (img.HasFile && img.PostedFile != null)
            {
                string filename = img.FileName;


                HttpPostedFile File = upload.PostedFile;

                imgByte = new Byte[File.ContentLength];

                File.InputStream.Read(imgByte, 0, File.ContentLength);

            }
            return imgByte;
        }
        public string getfilename(FileUpload upload)
        {
            FileUpload img = (FileUpload)upload;
            string filename = null;

            if (img.HasFile && img.PostedFile != null)
            {


                HttpPostedFile File = upload.PostedFile;
                filename = img.FileName;




            }
            return filename;
        }
        
}

}
