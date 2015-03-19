using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmAllEmployeesEval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "003";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                FillGV();

            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }

    }

    private void FillGV()
    {
        clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        DataView dv_persons = obj_Empeval.GetAll(5);
        if (dv_persons.Count > 0)
        {
            gvPerfomance.DataSource = dv_persons;
            gvPerfomance.DataBind();
        }
        else
        {
            
        }


        #region Depricated

        // DataTable dt = new DataTable();
        //createTable(dt);
        //clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        ////DataView dv_results = obj_Empeval.GetAll(1);
        //DataView dv_persons = obj_Empeval.GetAll(4);
        //if (dv_persons.Count > 0)
        //{
        //    for (int i = 0; i < dv_persons.Count; i++)
        //    {
        //        obj_Empeval.EnteredBy = dv_persons[i]["EnteredBy"].ToString();
        //        DataView dv_results = obj_Empeval.GetAll(1);
        //        int countExcellent = 0;
        //        int countVGood = 0;
        //        int countGood = 0;
        //        int countPoor = 0;
        //        int countVPoor = 0;
        //        if (dv_results.Count > 0)
        //        {
        //            for (int j = 0; j < dv_results.Count; j++)
        //            {
        //                if (dv_results[j]["Quantitative"].ToString() == "E")
        //                {
        //                    countExcellent++;
        //                }
        //                if (dv_results[j]["Quantitative"].ToString() == "vG")
        //                {
        //                    countVGood++;
        //                }
        //                if (dv_results[j]["Quantitative"].ToString() == "G")
        //                {
        //                    countGood++;
        //                }
        //                if (dv_results[j]["Quantitative"].ToString() == "P")
        //                {
        //                    countPoor++;
        //                }
        //                if (dv_results[j]["Quantitative"].ToString() == "vP")
        //                {
        //                    countVPoor++;
        //                }
        //            }
        //        }
        //        DataView dv_emp = obj_Empeval.GetAll(2);
               
               
        //        DataRow dr = dt.NewRow();
        //        dr["PersonName"] = dv_emp[0]["EmployeeName"].ToString();
        //        dr["Excellent"] = (countExcellent*100 / Convert.ToInt32(dv_persons[i]["Total"].ToString())).ToString() + "%";
        //        dr["VeryGood"] = (countVGood*100 / Convert.ToInt32(dv_persons[i]["Total"].ToString())).ToString() + "%";
        //        dr["Good"] = (countGood*100 / Convert.ToInt32(dv_persons[i]["Total"].ToString())).ToString() + "%";
        //        dr["Poor"] = (countPoor*100 / Convert.ToInt32(dv_persons[i]["Total"].ToString())).ToString() + "%";
        //        dr["VeryPoor"] = (countVPoor*100 / Convert.ToInt32(dv_persons[i]["Total"].ToString())).ToString() + "%";
        //        dr["TotalTests"] = dv_persons[i]["Total"].ToString();
        //        dr["PersonID"] = dv_persons[i]["EnteredBy"].ToString();
        //        dt.Rows.Add(dr);




        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        gvPerfomance.DataSource = dt;
        //        gvPerfomance.DataBind();
        //    }

        //}
        #endregion
    }

    private void createTable(DataTable dt)
    {
        dt.Columns.Add("PersonName");
        dt.Columns.Add("Excellent");
        dt.Columns.Add("VeryGood");
        dt.Columns.Add("Good");
        dt.Columns.Add("Poor");
        dt.Columns.Add("VeryPoor");
        dt.Columns.Add("TotalTests");
        dt.Columns.Add("PersonID");
    }
    protected void gvPerfomance_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.DataItemIndex ;
        Control Container = e.Row;
        DataControlRowType RowType = e.Row.RowType;
        
        if (RowType==DataControlRowType.DataRow )
        {
            string PersonID = gvPerfomance.DataKeys[index].Value.ToString();
            clsBlAllEmplooyesEval obj_allEmp = new clsBlAllEmplooyesEval();
            obj_allEmp.EnteredBy = PersonID;
            DataView dv_allemp = obj_allEmp.GetAll(6);
            if (dv_allemp.Count > 0)
            {
                GridView gvQualitative = (GridView)Container.FindControl("gvQualitative");
                //GridView gvQualitative = (GridView)gvPerfomance.Rows[index].Cells[8].FindControl("gvQualitative");
                gvQualitative.DataSource = dv_allemp;
                gvQualitative.DataBind();
            }
        }

    }
}