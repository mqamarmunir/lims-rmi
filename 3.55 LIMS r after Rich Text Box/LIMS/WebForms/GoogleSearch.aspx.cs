using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
using System.Text;

public partial class LIMS_WebForms_GoogleSearch : System.Web.UI.Page
{
    string ClientName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientName = Request["search"].ToString();
        Getresult();
    }
    //The Method Getresult will return (Response.Write) which contains search results seprated by character "~"
    // For E.G. "Ra~Rab~Racd~Raef~Raghi"   which will going to display in search suggest box 
    private void Getresult()
    {
        //clsCaseRegister cases = new clsCaseRegister();
        clsBLICDDiseases cases = new clsBLICDDiseases();
        DataTable dt = new DataTable();
       // DataView dv = new DataView();
        cases.SuitTitle = ClientName;
        DataView dv_diseases = cases.GetAll(6);

       // dv_diseases = cases.GetAll(13);
        dt = dv_diseases.ToTable();

        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append(dt.Rows[i].ItemArray[0].ToString() + "~");   //Create Con
            }
        }
        Response.Write(sb.ToString());
    }
}