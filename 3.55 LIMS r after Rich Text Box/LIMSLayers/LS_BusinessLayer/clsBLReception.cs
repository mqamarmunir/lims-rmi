using System;
using System.Data;
using System.Collections;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLReceiption.
	/// </summary>
	public class clsBLReceiption
	{
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		
		#region Class Variables
		private string StrErrorMessage = "";
		private string processID = "0001";
		private string StrLastEntry="";
		#endregion

		#region Class Properties
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string LastEntry
		{			
			get{	return StrLastEntry;	}
		}
		#endregion
		
		public clsBLReceiption()
		{
		}
		
		#region Methods
		
		public bool Save(clsBLPatient patient, clsBLMTransaction transaction, DataTable testDetail)
		{
			// retrieve entitled and iop information
			int iopIndex = -1, entitledIndex = -1;
			if(transaction.PatientType.Equals("C"))
				entitledIndex = 1;
			else
				entitledIndex = 0;
			if(transaction.IOP.Equals("O"))
				iopIndex = 1;
			
			/*
			 * this process enters transaction into database and if an error returns
			 * then transaction rollback else patient enters into database and then
			 * test detail
			 */
			objTrans.Start_Transaction();
			objTrans.StrMsg = "True";
			objdbhims.Query = transaction.Insert(entitledIndex, iopIndex);
			if(!objdbhims.Query.Equals("") && objTrans.DataTrigger_Insert(objdbhims).Equals("False"))
			{
				objTrans.StrMsg = "True";
				objdbhims.Query = patient.Insert(entitledIndex, iopIndex, Convert.ToInt64(transaction.MSerialNo));
				if(!objdbhims.Query.Equals("") && objTrans.DataTrigger_Insert(objdbhims).Equals("False"))
				{
					objTrans.StrMsg = "True";
					if(testDetail.Rows.Count > 0)
					{
						if(SaveTestDetail(testDetail, transaction) == true)
						{
							objTrans.End_Transaction();
							StrLastEntry = long.Parse(transaction.MSerialNo).ToString();
							return true;
						}
						else
						{
							// error will be set in SaveTestDetail method
							StrErrorMessage = objTrans.OperationError;
							StrErrorMessage += patient.ErrorMessage;
							objTrans.End_Transaction();
						}
					}
					else
					{
						objTrans.StrMsg = "True";
						StrErrorMessage = "Please enter test(s) before proceeding";
						objTrans.End_Transaction();
					}
				}
				else
				{
					StrErrorMessage = objTrans.OperationError;
					StrErrorMessage += patient.ErrorMessage;
					objTrans.End_Transaction();
				}
			}
			else
			{
				StrErrorMessage = objTrans.OperationError;
				StrErrorMessage += transaction.ErrorMessage;
				objTrans.End_Transaction();
			}
			
			return false;
		}

		public bool SaveTestDetail(DataTable testDetail, clsBLMTransaction transaction)
		{
			clsoperation tempTrans = new clsoperation();
			clsBLTestProcess objTTestProcess = new clsBLTestProcess();				
			for(int i = 0; i < testDetail.Rows.Count; i++)
			{
				objdbhims.Query = "select t.testid, t.sectionid, t.testgroupid, t.charges, tp.procedureid, "+
					"tps.processid, t.testnolevel, t.testnogenon from ls_ttest t, ls_ttestprocedure tp, ls_ttestprocess tps "+
					"where t.procedureid = tp.procedureid and tp.procedureid = tps.procedureid "+
					"and t.testid='"+testDetail.Rows[i].ItemArray[7].ToString()+"'";
				DataTable testInfo = tempTrans.DataTrigger_Get_Single(objdbhims).Table;
				
				clsBLDTransaction detail = new clsBLDTransaction();
				detail.MSerialNo = transaction.MSerialNo;
				//detail.DSerialNo = (i+1).ToString();
				detail.TestID = testDetail.Rows[i].ItemArray[7].ToString();
				detail.Times = testDetail.Rows[i].ItemArray[3].ToString();
				detail.TestGroupID = testDetail.Rows[i].ItemArray[9].ToString();
				detail.SectionID = testDetail.Rows[i].ItemArray[8].ToString();
				detail.Charges = testDetail.Rows[i].ItemArray[5].ToString();
				detail.DeliveryDate = testDetail.Rows[i].ItemArray[6].ToString();
				detail.EnteredBy = transaction.EntryPerson;
				detail.EnteredDateTime = transaction.EntryDateTime;
				detail.RSerialNo = "0";
				detail.NoPrint = "N";
				detail.SpecimenCollection = "N";
				detail.ProcedureID = testInfo.Rows[0].ItemArray[4].ToString();
				
				// getting/setting next process id
				detail.ProcessID = objTTestProcess.GetNextProcessID(detail.ProcedureID, processID);
				// getting/setting value of DeptTestNo
				
				string generator = testInfo.Rows[0].ItemArray[7].ToString();
				string level = testInfo.Rows[0].ItemArray[6].ToString();
				string levelNo = "";
				if(level.Equals("S"))
					levelNo = detail.SectionID;
				else if(level.Equals("G"))
					levelNo = detail.TestGroupID;
				else if(level.Equals("T"))
					levelNo = detail.TestID;
				detail.DeptTestNo = new clsBLTest().GetTestNo(detail.TestID, generator, objTrans).ToString();
				
				objdbhims.Query = detail.Insert(objTrans);
				string queryResult = objTrans.DataTrigger_Insert(objdbhims);
				if(objdbhims.Query.Equals("") || !queryResult.Equals("False"))
				{
					StrErrorMessage = objTrans.OperationError;
					return false;
				}
			}
			return true;
		}
		
		public DataView GetAllTestByGroupWise(long year, string sex, string testGroupID, string sectionID, string st)
		{
			string query = "select distinct sectionname As section, tg.testgroup, t.test testname, t.charges, 	Max((sysdate+m.maxtime)) As delivery, t.testid, t.sectionid, t.testgroupid, t.testbatchno, tg.DOrder, t.DOrder from ls_tsection s, ls_ttestgroup tg, ls_ttest t, ls_ttestattribute at, ls_tattributerange atrg, ls_tmethod m where s.sectionid = tg.sectionid and tg.sectionid = t.sectionid and tg.testgroupid = t.testgroupid and at.sectionid = t.sectionid and at.testgroupid = t.testgroupid and at.testid = t.testid and atrg.sectionid = at.sectionid and atrg.testgroupid = at.testgroupid and atrg.testid = at.testid and atrg.attributeid = at.attributeid and m.sectionid = atrg.sectionid and m.methodid = atrg.methodid and s.active = 'Y' and tg.active = 'Y' and t.active = 'Y' and at.active = 'Y' and atrg.agemax >= "+year+" and atrg.agemin <= "+year+" and (atrg.sex='"+sex+"' or atrg.Sex = 'All') ";

			if(!sectionID.Equals(""))
				query += "and s.SectionID = '" + sectionID + "'";

			if(!testGroupID.Equals("All"))
				query += " and tg.testgroupid='"+testGroupID+"'";

			if(!st.Equals(""))
			{
				query += " and (Upper(t.test) like '"+st+"' or Upper(t.Acronym) like '"+st+"' or Upper(tg.testgroup) like '"+st+"' or Upper(tg.Acronym) like '"+st+"')";				
			}
			
			objdbhims.Query = query+" Group By sectionName, tg.testgroup, t.test, t.charges, t.testid, t.sectionid, t.testgroupid, t.testbatchno, tg.DOrder, t.DOrder Order By tg.DOrder, t.DOrder";			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView AddTest(DataView dvSelectedTest, DataView dvAllTest, string testID, bool isBatch)
		{
			DataRow row = dvAllTest.Table.Select("testid='"+testID+"'")[0];
			long batchNo = long.Parse("0");

			if(isBatch)
			{
				batchNo = long.Parse(row.ItemArray[8].ToString());
			}

			if(batchNo != 0)
			{
				DataRow[] rows = dvAllTest.Table.Select("testbatchno="+batchNo);

				for(int i = 0; i < rows.Length; i++)
				{
					row = dvSelectedTest.Table.NewRow();
				
					row["Section"] = rows[i].ItemArray[0].ToString();
					row["TestGroup"] = rows[i].ItemArray[1].ToString();
					row["TestName"] = rows[i].ItemArray[2].ToString();
					row["Charges"] = rows[i].ItemArray[3].ToString();
					row["Delivery"] = DateTime.Parse(rows[i].ItemArray[4].ToString()).ToString("dd/MM/yyyy");
					row["TestID"] = rows[i].ItemArray[5].ToString();
					row["SectionID"] = rows[i].ItemArray[6].ToString();
					row["TestGroupID"] = rows[i].ItemArray[7].ToString();
					row["TestBatchNo"] = rows[i].ItemArray[8].ToString();
				
					dvSelectedTest.Table.Rows.Add(row);
				}
			}
			else
			{
				DataRow selectedRow = dvSelectedTest.Table.NewRow();
				
				selectedRow["Section"] = row[0].ToString();
				selectedRow["TestGroup"] = row[1].ToString();
				selectedRow["TestName"] = row[2].ToString();
				selectedRow["Charges"] = row[3].ToString();
				selectedRow["Delivery"] = DateTime.Parse(row[4].ToString()).ToString("dd/MM/yyyy");
				selectedRow["TestID"] = row[5].ToString();
				selectedRow["SectionID"] = row[6].ToString();
				selectedRow["TestGroupID"] = row[7].ToString();
				selectedRow["TestBatchNo"] = row[8].ToString();
				
				dvSelectedTest.Table.Rows.Add(selectedRow);
			}

			ArrayList IDs = new ArrayList();
			for(int i = 0; i < dvSelectedTest.Table.Rows.Count; i++)
			{
				if(!IDs.Contains(dvSelectedTest.Table.Rows[i].ItemArray[7].ToString()))
				{
					IDs.Add(dvSelectedTest.Table.Rows[i].ItemArray[7].ToString());
				}
			}
			
			Hashtable table = new Hashtable();
			for(int i = 0; i < IDs.Count; i++)
			{
				table.Add(IDs[i].ToString(), 1);
			}
			
			DataTable rs = new DataTable();
			rs.Columns.Add("SNO");
			rs.Columns.Add("Section");
			rs.Columns.Add("TestGroup");
			rs.Columns.Add("Times");
			rs.Columns.Add("TestName");
			rs.Columns.Add("Charges");
			rs.Columns.Add("Delivery");
			rs.Columns.Add("TestID");
			rs.Columns.Add("SectionID");
			rs.Columns.Add("TestGroupID");
			rs.Columns.Add("TestBatchNo");
			
			for(int i = 0; i < dvSelectedTest.Table.Rows.Count; i++)
			{
				row = rs.NewRow();
				
				// column zero is serial #, temparoryly empty
				row["SNO"] = (i+1).ToString();
				row["Section"] = dvSelectedTest.Table.Rows[i].ItemArray[1];
				row["TestGroup"] = dvSelectedTest.Table.Rows[i].ItemArray[2];
				row["TestName"] = dvSelectedTest.Table.Rows[i].ItemArray[4];
				row["Charges"] = dvSelectedTest.Table.Rows[i].ItemArray[5];
				row["Delivery"] = dvSelectedTest.Table.Rows[i].ItemArray[6];
				row["TestID"] = dvSelectedTest.Table.Rows[i].ItemArray[7];
				row["SectionID"] = dvSelectedTest.Table.Rows[i].ItemArray[8];
				row["TestGroupID"] = dvSelectedTest.Table.Rows[i].ItemArray[9];
				row["TestBatchNo"] = dvSelectedTest.Table.Rows[i].ItemArray[10];

				int times = int.Parse(table[dvSelectedTest.Table.Rows[i].ItemArray[7]].ToString());
				row["Times"] = times;
				table.Remove(dvSelectedTest.Table.Rows[i].ItemArray[7].ToString());
				table.Add(dvSelectedTest.Table.Rows[i].ItemArray[7].ToString(), times+1);

				rs.Rows.Add(row);
			}
			dvSelectedTest = null;
			return rs.DefaultView;
		}
		
		private double totalAmount;
		public DataView RemoveTest(DataView dvSelectedTest, int index)
		{
			totalAmount = 0;
			string times = dvSelectedTest.Table.Rows[index]["Times"].ToString();
			string batchNo = dvSelectedTest.Table.Rows[index]["TestBatchNo"].ToString();
			int sNo = int.Parse(dvSelectedTest.Table.Rows[index]["sno"].ToString());

			dvSelectedTest.Table.Rows[index].Delete();
			dvSelectedTest.Table.AcceptChanges();

			/*for(int counter = 0; counter < dvSelectedTest.Count; counter++)
			{				
				if(dvSelectedTest.Table.Rows[counter]["TestBatchNo"].ToString() == batchNo)
				{
					if(dvSelectedTest.Table.Rows[counter]["Times"].ToString() == times)
					{
						dvSelectedTest.Table.Rows[counter].Delete();
						dvSelectedTest.Table.AcceptChanges();
						counter--;
					}
					else if(int.Parse(dvSelectedTest.Table.Rows[counter]["Times"].ToString()) > int.Parse(times))
					{
						dvSelectedTest.Table.Rows[counter]["Times"] = int.Parse(dvSelectedTest.Table.Rows[counter]["Times"].ToString()) - 1;
					}
				}
			}*/

			sNo = 1;
			
			foreach(DataRow dr in dvSelectedTest.Table.Rows)
			{
				dr["sno"] = sNo++;
			}

			dvSelectedTest.Table.AcceptChanges();
			return dvSelectedTest;
		}

		public double GetTotalAmount()
		{
			return totalAmount;
		}

		#endregion
	}
}
