using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using System.IO;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmTestMicro.
	/// </summary>
    public partial class wfrmTestMicro : System.Web.UI.Page
    {
        protected static string id;
        protected static string sDSerialNo;
        protected static string sDSerialNos;
        protected static string ProcessID;
        protected static string SectionID;
        protected static string SelectedOpinion = "";
        protected static string SelectedComment = "";
        protected static string sOrgID;
        protected static string sDSerNo;
        protected static string sTag;
        protected static string path_images = "";
        protected static string sPAgeinDays;
        protected static string sSex;
        string[] saDSerialNos = new string[255];


        protected void Page_Load(object sender, System.EventArgs e)
        {
            //if(User.Identity.IsAuthenticated)
            //{
            // Put user code to initialize the page here						
            id = Request.QueryString["id"].ToString();
            ProcessID = Request.QueryString["ProcessID"].ToString();
            sDSerialNos = Request.QueryString["DSerialNos"].ToString();
            parseDSerialNos(sDSerialNos);
            SectionID = Request.QueryString["SectionID"].ToString();
            sTag = Request.QueryString["Tag"].ToString();
            lblHeading.Text = "Test Detail (Micro)";
            
            if (!IsPostBack)
            {
                try
                {
                    clsBLPreferenceSettings obj_Pref = new clsBLPreferenceSettings();
                    DataView dv = obj_Pref.GetAll(1);
                    if (dv.Count > 0)
                    {

                        path_images = dv[0]["IMG_PATH"].ToString();

                    }

                    dv.Dispose();
                    sDSerialNo = id;
                    sOrgID = "";
                    sDSerNo = "";
                    FillDDLForwardTo("001");
                    FillDDLOrganism();

                    DisplayPatient(sDSerialNo);

                    DisplayAttribute(sDSerialNo, "abc");
                    FillgvDiseases();
                    FillgvComments();
                    FillMethodDDL();
                    ShowHideButtons();
                    #region RepeatTest Depricated
                    /////////////////////////Check if the test is repeated//////////////////////////////
                    //clsBlRepeatTest obj_Repeat = new clsBlRepeatTest();
                    //obj_Repeat.LabID = lblLabID.Text;
                    //obj_Repeat.TestID = this.lblTestID.Text;
                    //DataView dv_testrepeat = obj_Repeat.GetAll(1);
                    //if (dv_testrepeat.Count > 0)
                    //{
                    //    chkRepeat.Checked = true;
                    //    ddlRepeatReasons.Visible = true;
                    //    clsBLRepeatReasons obj_Reasons = new clsBLRepeatReasons();
                    //    SComponents obj_comp = new SComponents();
                    //    DataView dv_Reasons = obj_Reasons.GetAll(1);
                    //    if (dv_Reasons.Count > 0)
                    //    {
                    //        obj_comp.FillDropDownList(ddlRepeatReasons, dv_Reasons, "Reason", "REPEATREASON_ID");
                    //    }
                    //    obj_comp = null;
                    //    ddlRepeatReasons.ClearSelection();
                    //    ddlRepeatReasons.Items.FindByValue(dv_testrepeat[0]["REPEATREASONID"].ToString()).Selected = true;
                    //    //((DropDownList)container.FindControl("ddlRepeatReasons")).ClearSelection();
                    //    //((DropDownList)container.FindControl("ddlRepeatReasons")).Items.FindByValue(dv_testrepeat[0]["REPEATREASONID"].ToString()).Selected = true;
                    //    dv_testrepeat.Dispose();

                    //}
                    //else
                    //{
                    //    chkRepeat.Checked = false;
                    //    ddlRepeatReasons.Visible = false;
                    //}
                    ///////////////////////////////////////------------------------////////////////////////////////////////////
                    #endregion
                }
                catch (Exception ee)
                {
                    Response.Write(ee.ToString());
                }

            }
            
            
            //}
            //else
            //{
            //Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
            //}
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
            this.dgMicro.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgMicro_ItemCreated);
            this.dgMicro2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgMicro_ItemCreated);
            this.dgMicro3.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgMicro_ItemCreated);
            this.ibtnHold.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnHold_Click);
        //    this.ibtnSave.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSave_Click);

        }
        #endregion

        private void ShowHideButtons()
        {
            clsBlTestSops objtestSops = new clsBlTestSops();
            objtestSops.TestID = lblTestID.Text.Trim();
            DataView dv_Sops = objtestSops.GetAll(2);
            if (dv_Sops.Count == 0)
            {
                ibtnSOP.Visible = false;
            }
        }
        private void FillDDLOrganism()
        {
            clsBLOrganism objOrganism = new clsBLOrganism();
            SComponents objComp = new SComponents();
            DataView dvOrganism = objOrganism.GetAll(1);
            objComp.FillDropDownList(this.ddlOrganism, dvOrganism, "Organism", "OrganismID");
            objComp.FillDropDownList(this.ddlOrganism2, dvOrganism, "Organism", "OrganismID");
            objComp.FillDropDownList(this.ddlOrganism3, dvOrganism, "Organism", "OrganismID");
        }

        protected void chkSensitivity_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSensitivity.Checked)
            {
                ddlOrganism.Visible = true;
                dgMicro.Visible = true;

                ddlOrganism2.Visible = true;
                dgMicro2.Visible = true;

                ddlOrganism3.Visible = true;
                dgMicro3.Visible = true;
            }
            else
            {
                ddlOrganism.Visible = false;
                dgMicro.Visible = false;

                ddlOrganism2.Visible = false;
                dgMicro2.Visible = false;

                ddlOrganism3.Visible = false;
                dgMicro3.Visible = false;
            }
        }

        private void fillMicro()
        {
            clsBLDrug objTDrug = new clsBLDrug();
            objTDrug.OrganismID = ddlOrganism.SelectedValue.ToString();
            objTDrug.DerialNo = sDSerialNo;
            DataView dvTDrug = objTDrug.GetAll(1);

            dgMicro.Visible = (!dvTDrug.Count.Equals(0));
            dgMicro.DataSource = null;
            dgMicro.DataSource = dvTDrug;
            dgMicro.DataBind();
        }

        private void fillMicro2()
        {
            clsBLDrug objTDrug = new clsBLDrug();
            objTDrug.OrganismID = ddlOrganism2.SelectedValue.ToString();
            objTDrug.DerialNo = sDSerialNo;
            DataView dvTDrug = objTDrug.GetAll(2);

            dgMicro2.Visible = (!dvTDrug.Count.Equals(0));
            dgMicro2.DataSource = null;
            dgMicro2.DataSource = dvTDrug;
            dgMicro2.DataBind();
        }

        private void fillMicro3()
        {
            clsBLDrug objTDrug = new clsBLDrug();
            objTDrug.OrganismID = ddlOrganism3.SelectedValue.ToString();
            objTDrug.DerialNo = sDSerialNo;
            DataView dvTDrug = objTDrug.GetAll(3);

            dgMicro3.Visible = (!dvTDrug.Count.Equals(0));
            dgMicro3.DataSource = null;
            dgMicro3.DataSource = dvTDrug;
            dgMicro3.DataBind();
        }

        private void FillDDLForwardTo(string sValue)
        {
            clsBLTestProcess objTestProcess = new clsBLTestProcess();
            SComponents objComp = new SComponents();

            objTestProcess.ProcedureID = sValue;
            objTestProcess.DisplayTag = sTag;
            DataView dvTestProcess = objTestProcess.GetAll(1);
            objComp.FillDropDownList(this.ddlForwardto, dvTestProcess, "Process", "ProcessID", false, false, false);
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

        private void DisplayAttribute(string Str,string methodid)
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

            if (dvTGeneralTestResult.Count > 0)
            {
                this.dgAttribute.DataSource = dvTGeneralTestResult;
                this.dgAttribute.DataBind();
                #region Controlling FileUploading and Downlioading
                /////////////////////Controlling File Uploading and Downloading////////////////////////////
                try
                {
                    int startingindex = 0;
                    string filepath1 = dvTGeneralTestResult[0]["Path_IMG1"].ToString().Trim();
                    string filepath2 = dvTGeneralTestResult[0]["Path_IMG2"].ToString().Trim();
                    string filepath3 = dvTGeneralTestResult[0]["Path_IMG3"].ToString().Trim();
                    if (filepath1 != "" && filepath1 != null && filepath1 != "&nbsp;" && filepath1.Trim() != "X")
                    {
                        FileUploadControl1.Visible = false;
                        gvlnkpath1.Visible = true;
                        gvlnkdelfile1.Visible = true;
                        gvlnkpath1.ToolTip = filepath1;


                        for (int i = 0; i < filepath1.Length; i++)
                        {
                            if (filepath1[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkpath1.Text = filepath1.Substring(startingindex + 1);

                    }
                    startingindex = 0;
                    if (filepath2 != "" && filepath2 != null && filepath2 != "&nbsp;" && filepath2.Trim() != "X")
                    {
                        FileUploadControl2.Visible = false;
                        gvlnkPath2.Visible = true;
                        gvlnkdelfile2.Visible = true;
                        gvlnkPath2.ToolTip = filepath2;


                        for (int i = 0; i < filepath1.Length; i++)
                        {
                            if (filepath2[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkPath2.Text = filepath2.Substring(startingindex + 1);
                    }
                    startingindex = 0;
                    if (filepath3 != "" && filepath3 != null && filepath3 != "&nbsp;" && filepath3.Trim() != "X")
                    {
                        FileUploadControl3.Visible = false;
                        gvlnkPath3.Visible = true;
                        gvlnkPath3.ToolTip = filepath2;

                        gvlnkdelfile3.Visible = true;

                        for (int i = 0; i < filepath3.Length; i++)
                        {
                            if (filepath3[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkPath3.Text = filepath3.Substring(startingindex + 1);
                    }
                }
                catch { }
                //////////////////////////----------------////////////////////////////////////////
                #endregion


            }
            else
            {
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
                DataView dvTGeneralTestResult2 = objTGeneralTestResult.GetAll(4);
                this.dgAttribute.DataSource = dvTGeneralTestResult2;
                this.dgAttribute.DataBind();
            }


        }

        private void parseDSerialNos(string sValue)
        {
            string sDSNo = "";
            int ArrayPosition = 0;

            for (int i = 0; i < sValue.Length; i++)
            {
                if (sValue[i].ToString() != "|")
                {
                    sDSNo += sValue[i].ToString();
                }
                else
                {
                    if (!sDSNo.Equals(""))
                    {
                        saDSerialNos[ArrayPosition] = sDSNo;
                        sDSNo = "";
                        ArrayPosition++;
                    }
                }
            }
        }

        private string NextDSerialNo(string sValue)
        {
            try
            {
                for (int i = 0; i <= saDSerialNos.GetUpperBound(0); i++)
                {
                    if (saDSerialNos[i].Equals(sValue))
                    {
                        return saDSerialNos[i + 1].ToString();
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
            objTGeneralTestResult.DSerialNo = Str;
            objTGeneralTestResult.ProcessID = ProcessID;
            objTGeneralTestResult.SectionID = SectionID;
            objTGeneralTestResult.TestType = "M";
            DataView dvTGeneralTestResult = objTGeneralTestResult.GetAll(2);

            if (dvTGeneralTestResult.Count > 0)
            {
                this.lblLabID.Text = dvTGeneralTestResult.Table.Rows[0]["LabID"].ToString();
                this.lblMSerialNo.Text = dvTGeneralTestResult.Table.Rows[0]["MSerialNo"].ToString();
                this.lblName.Text = dvTGeneralTestResult.Table.Rows[0]["PatientName"].ToString();
                this.lblPriority.Text = dvTGeneralTestResult.Table.Rows[0]["Priority"].ToString();
                this.lblAgeSex.Text = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
                this.lblAgeSex.Text += ' ' + dvTGeneralTestResult.Table.Rows[0]["PAge"].ToString();
                this.lblType.Text = dvTGeneralTestResult.Table.Rows[0]["Type"].ToString();
                this.lblWard.Text = dvTGeneralTestResult.Table.Rows[0]["WardName"].ToString();
                this.lblTest.Text = dvTGeneralTestResult.Table.Rows[0]["Test"].ToString();
                sPAgeinDays = dvTGeneralTestResult.Table.Rows[0]["PAgeinDays"].ToString();
                sSex = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
                this.lblDSerialNo.Text = dvTGeneralTestResult.Table.Rows[0]["DSerialNo"].ToString();
                this.lblTestID.Text = dvTGeneralTestResult.Table.Rows[0]["TestID"].ToString();
                this.lblPRNo.Text = dvTGeneralTestResult.Table.Rows[0]["PRNo"].ToString();
                this.lblReferredBy.Text = dvTGeneralTestResult.Table.Rows[0]["REFERREDBY"].ToString();
                this.txtRefDoctor.Text = dvTGeneralTestResult.Table.Rows[0]["REFERREDBY"].ToString();
                this.chkSensitivity.Checked = (dvTGeneralTestResult.Table.Rows[0]["Sensitivity"].ToString().Equals("Y"));
                lblDeliveryDate.Text = dvTGeneralTestResult.Table.Rows[0]["DeliveryDate"].ToString();
                imghistory.Visible = dvTGeneralTestResult.Table.Rows[0]["historytaking"].ToString() == "Y" ? true : false;
                this.dgMicro.DataSource = null;
                dgMicro.DataBind();
                this.dgMicro2.DataSource = null;
                dgMicro2.DataBind();
                this.dgMicro3.DataSource = null;
                dgMicro3.DataBind();
                this.ddlOrganism.SelectedItem.Selected = false;
                this.ddlOrganism2.SelectedItem.Selected = false;
                this.ddlOrganism3.SelectedItem.Selected = false;
                try
                {
                    this.ddlOrganism.Items.FindByValue(dvTGeneralTestResult.Table.Rows[0]["OrganismID"].ToString()).Selected = true;
                    fillMicro();
                }
                catch { }

                try
                {
                    this.ddlOrganism2.Items.FindByValue(dvTGeneralTestResult.Table.Rows[0]["OrganismID2"].ToString()).Selected = true;
                    fillMicro2();
                }
                catch { }

                try
                {
                    this.ddlOrganism3.Items.FindByValue(dvTGeneralTestResult.Table.Rows[0]["OrganismID3"].ToString()).Selected = true;
                    fillMicro3();
                }
                catch { }


                this.ddlOrganism.Visible = (chkSensitivity.Checked);
                this.dgMicro.Visible = ((chkSensitivity.Checked) && (!ddlOrganism.SelectedIndex.Equals(-1)));

                this.ddlOrganism2.Visible = (chkSensitivity.Checked);
                this.dgMicro2.Visible = ((chkSensitivity.Checked) && (!ddlOrganism2.SelectedIndex.Equals(-1)));

                this.ddlOrganism3.Visible = (chkSensitivity.Checked);
                this.dgMicro3.Visible = ((chkSensitivity.Checked) && (!ddlOrganism3.SelectedIndex.Equals(-1)));

                this.ddlForwardto.SelectedItem.Selected = false;
                this.ddlForwardto.Items.FindByValue(dvTGeneralTestResult.Table.Rows[0]["ProcessID"].ToString()).Selected = true;
                this.ddlForwardto.SelectedIndex = this.ddlForwardto.SelectedIndex + 1;

                this.txtOpinionET.Text = dvTGeneralTestResult.Table.Rows[0]["Opinions"].ToString();
                this.txtCommentET.Text = dvTGeneralTestResult.Table.Rows[0]["Comments"].ToString();



                #region Controlling FileUploading and Downlioading
                /////////////////////Controlling File Uploading and Downloading////////////////////////////
                try
                {
                    int startingindex = 0;
                    string filepath1 = "";
                    if (dvTGeneralTestResult[0]["Path_IMG1"].ToString().Trim() != "" && dvTGeneralTestResult[0]["Path_IMG1"].ToString().Trim() != null)
                    {
                        filepath1 = dvTGeneralTestResult[0]["Path_IMG1"].ToString().Trim();
                    }
                    else
                    {
                        if (dvTGeneralTestResult[0]["EXT_RESULT_REFERENCE"].ToString().Trim() != "" && dvTGeneralTestResult[0]["EXT_RESULT_REFERENCE"].ToString().Trim() != null)
                        {
                            clsBLTest t = new clsBLTest();
                            DataView dv = t.GetAll(16);
                            filepath1 = dv[0]["DOC_PATH"].ToString() + "\\" + dvTGeneralTestResult[0]["EXT_RESULT_REFERENCE"].ToString().Trim();
                        }
                    }
                    string filepath2 = dvTGeneralTestResult[0]["Path_IMG2"].ToString().Trim();
                    string filepath3 = dvTGeneralTestResult[0]["Path_IMG3"].ToString().Trim();
                    if (filepath1 != "" && filepath1 != null && filepath1 != "&nbsp;" && filepath1.Trim() != "X")
                    {
                        FileUploadControl1.Visible = false;
                        gvlnkpath1.Visible = true;
                        gvlnkdelfile1.Visible = true;
                        gvlnkpath1.ToolTip = filepath1;


                        for (int i = 0; i < filepath1.Length; i++)
                        {
                            if (filepath1[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkpath1.Text = filepath1.Substring(startingindex + 1);

                    }
                    startingindex = 0;
                    if (filepath2 != "" && filepath2 != null && filepath2 != "&nbsp;" && filepath2.Trim() != "X")
                    {
                        FileUploadControl2.Visible = false;
                        gvlnkPath2.Visible = true;
                        gvlnkdelfile2.Visible = true;
                        gvlnkPath2.ToolTip = filepath2;


                        for (int i = 0; i < filepath1.Length; i++)
                        {
                            if (filepath2[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkPath2.Text = filepath2.Substring(startingindex + 1);
                    }
                    startingindex = 0;
                    if (filepath3 != "" && filepath3 != null && filepath3 != "&nbsp;" && filepath3.Trim() != "X")
                    {
                        FileUploadControl3.Visible = false;
                        gvlnkPath3.Visible = true;
                        gvlnkPath3.ToolTip = filepath2;

                        gvlnkdelfile3.Visible = true;

                        for (int i = 0; i < filepath3.Length; i++)
                        {
                            if (filepath3[i].ToString() == @"\")
                            {
                                startingindex = i;
                            }
                        }
                        gvlnkPath3.Text = filepath3.Substring(startingindex + 1);
                    }
                }
                catch { }
                //////////////////////////----------------////////////////////////////////////////
                #endregion
               

            }
            else
            {
                DisplayNextPatient();
            }
        }
        private void DisplayNextPatient()
        {
            sDSerialNo = NextDSerialNo(sDSerialNo);
            if (sDSerialNo.Equals(""))
            {
                Response.Write("<script language='javascript'>self.close();</script>");
            }
            else
            {
                DisplayPatient(sDSerialNo);
                DisplayAttribute(sDSerialNo,"abc");
                FillgvDiseases();
                FillgvComments();
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
                        //objComp.FillListBox(lbSelection,dvSection,"Description","templateID",true);

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

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>self.close();</script>");
        }

        protected void ddlOrganism_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fillMicro();
        }

        protected void ibtnR_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent);
            dgItem.Cells[3].Text = "R";
        }

        protected void ibtnS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent);
            dgItem.Cells[3].Text = "S";
        }

        protected void ibtnI_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent);
            dgItem.Cells[3].Text = "I";
        }

        protected void ibtnBlank_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataGridItem dgItem = ((DataGridItem)((ImageButton)sender).Parent.Parent);
            dgItem.Cells[3].Text = "";
        }

        protected void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string sMSerialNo = lblMSerialNo.Text;
            string sTestID = lblTestID.Text;
            string sDSerialNo = lblDSerialNo.Text;
            string sProcessID = ddlForwardto.SelectedItem.Value;
            string sOpinion = txtOpinionET.Text;
            string sComment = txtCommentET.Text;
            string sSensitivity = (chkSensitivity.Checked == true) ? "Y" : "N"; //Sensitivity

            string[,] AttributeResult = new string[dgAttribute.Items.Count, 11];
            for (int i = 0; i < dgAttribute.Items.Count; i++)
            {
                AttributeResult[i, 0] = dgAttribute.Items[i].Cells[0].Text; //AttributeID
                AttributeResult[i, 1] = ((TextBox)dgAttribute.Items[i].Cells[3].FindControl("dgAttributeResult")).Text; //Result
                if (AttributeResult[i, 1].Equals(""))
                {
                    AttributeResult[i, 1] = "-";
                }
                if (AttributeResult[i, 1].Length > 1024)
                {
                    AttributeResult[i, 1] = AttributeResult[i, 1].Substring(0, 1024);
                }

                AttributeResult[i, 2] = "Y"; //Print
                AttributeResult[i, 3] = dgAttribute.Items[i].Cells[6].Text; //MinRange
                AttributeResult[i, 4] = dgAttribute.Items[i].Cells[7].Text; //MaxRange
                AttributeResult[i, 5] = dgAttribute.Items[i].Cells[5].Text; //RUnit			
                AttributeResult[i, 6] = (((CheckBox)dgAttribute.Items[i].Cells[1].FindControl("chkRPrint")).Checked == true) ? "Y" : "N"; //Report
                AttributeResult[i, 7] = ""; //MinPanicValue
                AttributeResult[i, 8] = ""; //MaxPanicValue
                AttributeResult[i, 9] = "T";
                AttributeResult[i, 10] = AttributeResult[i, 3] + " " + AttributeResult[i, 4] + " " + AttributeResult[i, 5];
            }

            clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

            objTGenTestResult.DSerialNo = sDSerialNo;
            objTGenTestResult.NextProcessID = sProcessID;
            objTGenTestResult.MSerialNo = sMSerialNo;
            objTGenTestResult.TestID = sTestID;
            objTGenTestResult.Times = "0";
            objTGenTestResult.Opinion = sOpinion;
            objTGenTestResult.Comments = sComment;
            objTGenTestResult.Sensitivity = sSensitivity;
           
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
                objTGenTestResult.Spec_Coment = txtCommentET.Text.Trim();
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

            string[,] MicroResult = new string[dgMicro.Items.Count + dgMicro2.Items.Count + dgMicro3.Items.Count, 4];
            if (sSensitivity.Equals("Y"))
            {
                //string sOrganismID = ddlOrganism.SelectedItem.Value;									
                //string[,] MicroResult = new string[dgMicro.Items.Count, 3];			
                int j = 0;
                for (int i = 0; i < dgMicro.Items.Count; i++)
                {
                    MicroResult[j, 0] = "1";
                    MicroResult[j, 1] = dgMicro.Items[i].Cells[0].Text; //OrganismID
                    MicroResult[j, 2] = dgMicro.Items[i].Cells[1].Text; //DrugID						
                    MicroResult[j, 3] = dgMicro.Items[i].Cells[3].Text.Replace("&nbsp;", "");
                    j++;
                }
                for (int i = 0; i < dgMicro2.Items.Count; i++)
                {
                    MicroResult[j, 0] = "2";
                    MicroResult[j, 1] = dgMicro2.Items[i].Cells[0].Text; //OrganismID
                    MicroResult[j, 2] = dgMicro2.Items[i].Cells[1].Text; //DrugID						
                    MicroResult[j, 3] = dgMicro2.Items[i].Cells[3].Text.Replace("&nbsp;", "");
                    j++;
                }
                for (int i = 0; i < dgMicro3.Items.Count; i++)
                {
                    MicroResult[j, 0] = "3";
                    MicroResult[j, 1] = dgMicro3.Items[i].Cells[0].Text; //OrganismID
                    MicroResult[j, 2] = dgMicro3.Items[i].Cells[1].Text; //DrugID						
                    MicroResult[j, 3] = dgMicro3.Items[i].Cells[3].Text.Replace("&nbsp;", "");
                    j++;
                }
            }
            objTGenTestResult.MethodID = dgDDLMethod.SelectedValue.ToString().Trim();
            updatePictures(filecontent(FileUploadControl1), filecontent(FileUploadControl2), getfilename(FileUploadControl1), getfilename(FileUploadControl2), sDSerialNo);
            bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult, MicroResult, "Y");
            if (!isSuccessful)
            {
                this.lblErrMsg.Text = objTGenTestResult.ErrorMessage;
            }
            else
            {
                if (chkRepeat.Checked == true)
                {
                    clsBlRepeatTest obj_RepeatTest = new clsBlRepeatTest();
                    obj_RepeatTest.LabID = lblLabID.Text.Trim();
                    obj_RepeatTest.TestID = sTestID;
                    obj_RepeatTest.RepeatReasonID = ddlRepeatReasons.SelectedValue.ToString();
                    obj_RepeatTest.EnteredBy = Session["loginid"].ToString();
                    obj_RepeatTest.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_RepeatTest.ClientID = "0005";
                    obj_RepeatTest.PRNumber = lblPRNo.Text.Trim();
                    if (obj_RepeatTest.insert())
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
                DisplayPatient(sDSerialNo);
                //DisplayNextPatient();
            }
        }

        private void ibtnHold_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
        }

        protected void ddlOrganism2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlOrganism.SelectedIndex == 0)
            {
                ddlOrganism2.SelectedIndex = 0;
                dgMicro2.Visible = false;
                dgMicro2.DataSource = null;
                dgMicro2.DataBind();

                ddlOrganism3.SelectedIndex = 0;
                dgMicro3.Visible = false;
                dgMicro3.DataSource = null;
                dgMicro3.DataBind();
            }
            else
            {
                fillMicro2();
            }
        }

        protected void ddlOrganism3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlOrganism2.SelectedIndex == 0)
            {
                ddlOrganism3.SelectedIndex = 0;
                dgMicro3.Visible = false;
                dgMicro3.DataSource = null;
                dgMicro3.DataBind();
            }
            else
            {
                fillMicro3();
            }
        }

        private void dgMicro_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            // Create a new WebUIFacade.
            WebUIFacade uiFacade = new WebUIFacade();

            // This is gives a tool tip for each
            // of the columns to sort by.
            uiFacade.SetHeaderToolTip(e);


            // This sets a class for the link buttons in a grid.
            uiFacade.SetGridLinkButtonStyle(e);

            // Make the row change color when the mouse hovers over.
            // *** You must have a class called gridHover with a different background 
            // color in your StyleSheet.
            uiFacade.SetRowHover((DataGrid)sender, e);
        }

        private void ibtnPatientStatus_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno=" + lblMSerialNo.Text.ToString() + "','','fullscreen')</script>");
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
            SelectedOpinion = txtOpinionET.ClientID.ToString();

            Response.Write("<script language='javascript'>window.open('wfrmOpinion.aspx?testID=" + lblTestID.Text + "', '', 'scrollbars=yes');</script>");
        }

        protected void ibtnComment_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            #region oldcode
            SelectedComment = txtCommentET.ClientID.ToString();

            Response.Write("<script language='javascript'>window.open('wfrmComment.aspx?testID=" + lblTestID.Text + "', '', 'scrollbars=yes');</script>");
            #endregion

            //txtCommentET.Visible = true;
            //lnksavecomment.Visible = true;
        }
        protected void ibtnResultByPRNo_Click(object sender, ImageClickEventArgs e)
        {
            if (!lblPRNo.Text.Equals(""))
            {
                LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT2.PRNO} = '" + lblPRNo.Text + "'";

                LIMS.reports.GeneralReports.PdfSetting = null;
                LIMS.reports.GeneralReports.ReportReference = "LMS-001-11";
                //LIMS.reports.GeneralReports.mFromDate = "";
                //LIMS.reports.GeneralReports.mToDate = "";

                Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-11','','channelmode')</script>");
            }
        }

        public void FillDDLDiseases()
        {
            clsBLICDDiseases obj_Diseases = new clsBLICDDiseases();
            SComponents objComp = new SComponents();
            DataView dv_diseases = obj_Diseases.GetAll(5);
            if (dv_diseases.Count > 0)
            {
                objComp.FillDropDownList(DDLdiseasename, dv_diseases, "DiseaseName", "DiseaseID");
                objComp.FillDropDownList(DDLdiseasecode, dv_diseases, "DiseaseCode", "DiseaseID");

            }

        }

        protected void ddlDiseasename_SelectedIndexchanged(object sender, EventArgs e)
        {
            // lblName.Text = "abcd";


            string _diseaseid = DDLdiseasename.SelectedValue.ToString();
            DDLdiseasecode.ClearSelection();
            //.ClearSelection();
            DDLdiseasecode.Items.FindByValue(_diseaseid).Selected = true;


        }
        protected void ddlDiseasecode_SelectedIndexchanged(object sender, EventArgs e)
        {

            string _diseaseid = DDLdiseasecode.SelectedValue.ToString();

            DDLdiseasename.ClearSelection();
            DDLdiseasename.Items.FindByValue(_diseaseid).Selected = true;
        }
        protected void ibtnsearch_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.open('wfrmICD_Diseases.aspx?testid=" + lblTestID.Text + "&labid=" + lblLabID.Text + "&PRNumber=" + lblPRNo.Text + "&MSerialNum=" + lblMSerialNo.Text + "&SectionID=" + SectionID + "&ProcessID=" + ProcessID + "&Type=M','channel mode');</script>");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            clsBLDiagnose obj_Diagnose = new clsBLDiagnose();
            
            if (DDLdiseasecode.SelectedValue.ToString() == "-1" || DDLdiseasename.SelectedValue.ToString() == "-1")
            {
                lblErrMsg.Text = "Please Select Disease";
            }
            else
            {
                obj_Diagnose.ClientID = "0005";
                obj_Diagnose.DiseaseID = DDLdiseasecode.SelectedValue.ToString();
                obj_Diagnose.DiseaseName = DDLdiseasename.SelectedItem.Text;
                obj_Diagnose.ICDCode = DDLdiseasecode.SelectedItem.Text;
                obj_Diagnose.EnteredBy = Session["loginid"].ToString();
                obj_Diagnose.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_Diagnose.Print = this.chkPrint.Checked == true ? "Y" : "N";
                obj_Diagnose.PRNumber = this.lblPRNo.Text;
                obj_Diagnose.TestID = this.lblTestID.Text;
                obj_Diagnose.LabID = this.lblLabID.Text;


                if (obj_Diagnose.Insert())
                {
                    FillgvDiseases();
                }
                else
                {
                    this.lblErrMsg.Text = obj_Diagnose.Errormessage;
                }
            }
        }
        protected void gvDiseases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //lblErrMsg.Text = "Delete button Called";
                int rowindex = int.Parse(e.CommandArgument.ToString());
                string id = gvDiseases.DataKeys[rowindex].Value.ToString();
                clsBLDiagnose obj_diagnosis = new clsBLDiagnose();
                obj_diagnosis.DiagnosisID = id;
                if (obj_diagnosis.delete())
                {
                    //Response.ContentType = "text/HTML";
                    //DisplayPatient(sDSerialNo);
                    //DisplayAttribute(sDSerialNo);
                    //FillgvDiseases();
                    Response.Redirect(Request.Url.ToString());
                    

                }
                else
                {
                    lblErrMsg.Text = obj_diagnosis.Errormessage;
                }

            }
        }
        protected void FillgvDiseases()
        {
            clsBLDiagnose obj_diagnose = new clsBLDiagnose();
            obj_diagnose.LabID = this.lblLabID.Text;
            obj_diagnose.TestID = this.lblTestID.Text;
            DataView dv = obj_diagnose.GetAll(1);
            if (dv.Count > 0)
            {
                gvDiseases.DataSource = dv;
                gvDiseases.DataBind();
            }
            else
            {
                gvDiseases.DataSource = "";
                gvDiseases.DataBind();
            }
        }

        protected void gvDiseases_RowDeleting_Click(object sender, GridViewDeleteEventArgs e)
        {
            int rowindex = e.RowIndex;
           // DataGridItem dgItem = ((DataGridItem)((GridView)sender).Parent.Parent.Parent);
           // GridView gvdisease = (GridView)dgItem.Cells[7].FindControl("gvDiseases");
            string id = gvDiseases.DataKeys[rowindex].Value.ToString();
            clsBLDiagnose obj_diagnosis = new clsBLDiagnose();
            obj_diagnosis.DiagnosisID = id;
            if (obj_diagnosis.delete())
            {


                DisplayPatient(sDSerialNo);
                FillgvDiseases();
                //Response.ContentType = "text/HTML";
                //Response.Redirect(Request.Url.ToString());

            }
            else
            {
                lblErrMsg.Text = obj_diagnosis.Errormessage;
            }


        }

        protected void lnkAddDiagnosis_Click(object sender, EventArgs e)
        {
            FillDDLDiseases();
            tblDiagnosis.Visible = true;
        }

        protected void chkReport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepeat.Checked == true)
            {
                lblReasons.Visible = true;
                ddlRepeatReasons.Visible = true;
                txtCommentET.Text = "** Repeat Test **";
                SComponents ob_Comp = new SComponents();
                clsBLRepeatReasons obj_Reasons = new clsBLRepeatReasons();
                DataView dv_obj_Reasons = obj_Reasons.GetAll(1);
                if (dv_obj_Reasons.Count > 0)
                {
                    ob_Comp.FillDropDownList(ddlRepeatReasons, dv_obj_Reasons, "Reason", "RepeatReason_ID");

                }
                dv_obj_Reasons.Dispose();
                obj_Reasons = null;
                ob_Comp = null;

            }
                

            else
            {
                lblReasons.Visible = false;
                ddlRepeatReasons.Visible = false;
                txtCommentET.Text = "";
            }
        }
        private string getIpAddress()
        {
            return Request.UserHostAddress;
        }

        protected void UploadButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl1.FileName);
                FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                StatusLabel1.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
        protected void UploadButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl2.FileName);
                FileUploadControl2.SaveAs(Server.MapPath("~/Uploads/") + filename);
                StatusLabel2.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel2.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }

        }
        protected void UploadButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl3.FileName);
                FileUploadControl3.SaveAs(Server.MapPath("~/Uploads/") + filename);
                StatusLabel3.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel3.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
        protected void ibtn_SOPClick(object sender, EventArgs e)
        {
        
            //int rowindex = dgItem.ItemIndex;
            //testid = dgTest.Items[rowindex].Cells[2].Text;
            //lblErrMsg.Text = dgItem.UniqueID.ToString();
            Response.Write("<script language = 'javascript'>window.open('wfrmSOPresultge.aspx?id=" + ProcessID + "&TestID=" + lblTestID.Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
            //Response.Write("<script language='javascript'>window.open('wfrmSOPResultGE.aspx?Processid="+ProcessID+"&TestID="+testid+",'channelmode'')</script>");

        }
        protected void lnkbtnEval_Click(object sender, EventArgs e)
        {

        }

        protected void FillgvComments()
        {
            clsBlTestResultComments obj_Comments = new clsBlTestResultComments();
            obj_Comments.LabId = lblLabID.Text;
            obj_Comments.TestID = lblTestID.Text;
            DataView dvComments = obj_Comments.GetAll(1);
            if (dvComments.Count > 0)
            {
                gvComments.DataSource = dvComments;
                gvComments.DataBind();
            }
            else
            {
                gvComments.DataSource = "";
                gvComments.DataBind();
            }
        }

        protected void lnkbtnsavecomment_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                clsBlTestResultComments obj_Comments = new clsBlTestResultComments();
                obj_Comments.LabId = lblLabID.Text;
                obj_Comments.TestID = lblTestID.Text;
                obj_Comments.Comment = txtCommentET.Text;
                obj_Comments.EnteredBy = Session["loginid"].ToString();
                obj_Comments.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_Comments.ClientID = "0005";
                obj_Comments.System_Ip = Request.UserHostAddress.ToString();
                if (obj_Comments.insert())
                {
                    DataView dv_Comments = obj_Comments.GetAll(1);
                    gvComments.DataSource = dv_Comments;
                    gvComments.DataBind();
                    dv_Comments.Dispose();
                    obj_Comments = null;
                    txtCommentET.Text = "";
                    txtCommentET.Visible = true;
                    ((LinkButton)sender).Visible = true;
                }
            }
        }

        private void FillMethodDDL()
        {
            clsBlTestMethod obj_TestMethods = new clsBlTestMethod();
            string testid = "";
            //testid = Request.QueryString["testid"].ToString().Trim(); 
            testid = lblTestID.Text.Trim();
            obj_TestMethods.TestID = testid;
            DataView dv_methods = obj_TestMethods.GetAll(7);
            if (dv_methods.Count > 0)
            {
                SComponents oj_Com = new SComponents();
                oj_Com.FillDropDownList(dgDDLMethod, dv_methods, "Method", "MethodID", false);
                dgDDLMethod.ClearSelection();
                dgDDLMethod.Items[1].Selected = true;
                dv_methods.Dispose();
                oj_Com = null;
            }
        }
        protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList ddlMethod = (DropDownList)sender;

            if (dgDDLMethod.SelectedValue.ToString().Trim() != "-1")
            {
                string methodid = "";
                methodid = dgDDLMethod.SelectedValue.ToString().Trim();
                //string parentid = ddlMethod.Parent.Parent.UniqueID.ToString();
                //DataGridItem dgItem = ((DataGridItem)ddlMethod.Parent.Parent);
                //int rowindex = dgItem.ItemIndex;
                //dgTest.Items[rowindex].Cells[1].Text.Trim();
                /////////////////////////////////Updating method used in performing the test///////////////////////////////
                clsBLGeneralTestResult obj_generaltest = new clsBLGeneralTestResult();
                obj_generaltest.MethodID = methodid;
                obj_generaltest.DSerialNo = sDSerialNo;

                //////////////////////////////////////----------//////////////////////////////////////
                if (obj_generaltest.UpdateMethod())
                {
                    DisplayAttribute(sDSerialNo, methodid);
                }




            }
        }

        protected void gvlnkPath1_Click(object sender, EventArgs e)
        {
            string filepath = gvlnkpath1.ToolTip.ToString();// @"D:\negno25462.jpg";
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
            string filepath = gvlnkPath2.ToolTip.ToString();// @"D:\negno25462.jpg";
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
            string filepath = gvlnkPath3.ToolTip.ToString();// @"D:\negno25462.jpg";
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

        protected void btnSearchDisease_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text.Trim() != "")
            {

                FillgvsearchDiagnosis();
                gvDiagnosissearch.Focus();
            }
            else
            {
                lblErrMsg.Text = "Enter Search Query";
            }
        }
        private void FillgvsearchDiagnosis()
        {
            clsBLICDDiseases obj_Diseases = new clsBLICDDiseases();
            obj_Diseases.SearchQuery = txtItemName.Text.Trim();
            DataView Diseases = obj_Diseases.GetAll(3);
            if (Diseases.Count > 0)
            {
                divsearcharea.Visible = true;
                gvDiagnosissearch.DataSource = Diseases;
                gvDiagnosissearch.DataBind();
            }
            else
            {
                lblErrMsg.Text = "No Such Disease Found";
            }
        }


        protected void gvDiagnosissearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                clsBLDiagnose obj_Diagnose = new clsBLDiagnose();
                int index = Convert.ToInt16(e.CommandArgument);

                obj_Diagnose.ClientID = "0005";
                obj_Diagnose.DiseaseID = gvDiagnosissearch.DataKeys[index].Value.ToString().Trim();
                obj_Diagnose.DiseaseName = gvDiagnosissearch.Rows[index].Cells[2].Text.Trim();
                obj_Diagnose.ICDCode = gvDiagnosissearch.Rows[index].Cells[1].Text.Trim();
                obj_Diagnose.EnteredBy = Session["loginid"].ToString();
                obj_Diagnose.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                CheckBox chprint = (CheckBox)(gvDiagnosissearch.Rows[index].Cells[3].FindControl("gvdiagnosischkPrint"));
                obj_Diagnose.Print = chprint.Checked == true ? "Y" : "N";
                obj_Diagnose.PRNumber = lblPRNo.Text;

                obj_Diagnose.LabID = lblLabID.Text;
                obj_Diagnose.TestID = lblTestID.Text.Trim();

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

        protected void gvComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowindex = e.RowIndex;
            clsBlTestResultComments obj_comments = new clsBlTestResultComments();
            obj_comments.TestResultCommentID = gvComments.DataKeys[rowindex].Value.ToString().Trim();
            if (obj_comments.delete())
            {
                obj_comments.LabId = lblLabID.Text;
                obj_comments.TestID = lblTestID.Text;
                DataView dv = obj_comments.GetAll(1);
                gvComments.DataSource = dv;
                gvComments.DataBind();
                dv.Dispose();
                obj_comments = null;
            }
            else
            {
                lblErrMsg.Text = obj_comments.ErrorMessage;
                obj_comments = null;
            }
        }
        
        
        protected void imghistory_Click(object sender, ImageClickEventArgs e)
        {
            string labid = lblLabID.Text.Trim();
            string PRNo = lblPRNo.Text.Trim();
            string TestId = lblTestID.Text.Trim();

            Response.Write("<script language='javascript'>window.open('wfrmhistoryTaking.aspx?labid=" + labid + "&testid=" + TestId + "&PRNo=" + PRNo + "');</script>");

        }
        protected void gvlnkdelfile_Command(object sender, CommandEventArgs e)
        {
           // DataGridItem dgITem = (DataGridItem)((LinkButton)sender).Parent.Parent.Parent;
           // int index = dgITem.ItemIndex;
            string DSerialno = lblDSerialNo.Text.Trim();
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
                    FileUploadControl1.Visible = true;
                    //((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl1")).Visible = true;
                    ((LinkButton)sender).Visible = false;
                    gvlnkdelfile1.Visible = false;
                    gvlnkpath1.Visible = false;
                    //((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath1")).Visible = false;
                   
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
                    //((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl2")).Visible = true;
                    FileUploadControl2.Visible = true;
                    //((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath2")).Visible = false;
                    gvlnkdelfile2.Visible = false;
                    gvlnkPath2.Visible = false;
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
                    //((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl3")).Visible = true;
                    FileUploadControl3.Visible = true;
                   // ((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath3")).Visible = false;
                    gvlnkdelfile3.Visible = false;
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
            string file = null;

            if (img.HasFile && img.PostedFile != null)
            {


                HttpPostedFile File = upload.PostedFile;
                file = img.FileName;




            }
            return file;
        }
}
}
