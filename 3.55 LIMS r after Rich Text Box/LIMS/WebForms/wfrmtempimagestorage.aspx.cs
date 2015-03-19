using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using LS_DataLayer;
using System.Data.OleDb;
using System.Text;

public partial class LIMS_WebForms_wfrmtempimagestorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("imageID");
        dt.Columns.Add("image");
        try
        {
            FileStream fs = new FileStream(@"C:\users\M Qamar\Desktop\DefenseBudgetre.jpg", FileMode.Open, FileAccess.Read);
           // BinaryReader BinRed = new BinaryReader(fs);
            DataRow dr = dt.NewRow();
            dr["imageID"] = 1;
            //dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
            
            byte[] b = new byte[fs.Length-1];
            fs.Read(b, 0,Convert.ToInt32(fs.Length-1));
           // string bstring=ASCIIEncoding.As

            //b=BinRed.ReadBytes((int)BinRed.BaseStream.Length);
            //fs.Rent)Bad(b, 0, b.Length);
            fs.Close();
           // dt.Rows.Add(dr);
 //           for (int i = 0; i < b.Length; i++)
 //           {
 //               lblx.Text += b[i].ToString();
 ////Byte b=Convert.ToByte(dt.Rows[0]["image"])
 //           }
           // clsoperation objTrans = new clsoperation();
          //  clsdbhims objdbhims = new clsdbhims();
            //objdbhims.Query = @"Insert Into Test_Image(ImageID,image) Values(" + dt.Rows[0]["imageID"] + "," + dt.Rows[0]["image"] + ")";
           // objTrans.Start_Transaction();
            OleDbConnection conn = new OleDbConnection(@"Provider=MSDAORA; User ID=whims;password=whims;Data Source=HIMS;Unicode=True");
            
            OleDbCommand cmd = new OleDbCommand("Insert into Test_Image(ImageID,image) Values(8,?)",conn);

            cmd.Parameters.Add("image", OleDbType.LongVarBinary,b.Length).Value = b;
            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();
            //string Err = objTrans.DataTrigger_Insert(objdbhims);
          //  objTrans.End_Transaction();
            //if (Err.Equals("True"))
            //{

            //}
            //else
            //{
 
            //}



        }
        catch
        {
 
        }
    }
}