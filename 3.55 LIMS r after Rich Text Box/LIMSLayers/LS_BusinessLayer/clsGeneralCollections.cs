using System;
using System.Data;


namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsGeneralCollections.
	/// </summary>
	public class clsGeneralCollections
	{
		public clsGeneralCollections()
		{
			//
			// TODO: Add constructor logic here
			//
			
		}

		/*	Mr 			men 
			Mrs 		married women 
			Miss 		unmarried women/girls 
			Ms 			women 
			Madam 		women (very formal) */

		public DataView Titles()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("Titles");
			mDataTable.Columns.Add("SexType");
			mDataRow = mDataTable.NewRow();
			myArray[0]="Mr";
			myArray[1]="M";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="Mrs";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="Miss";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

/*			mDataRow = mDataTable.NewRow();
			myArray[0]="Mst";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="Madam";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);*/

			mDataTable.TableName = "Titles";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView Titles(string mSex)
		{
			DataView mDataView = new DataView();
			mDataView=Titles();
			{mDataView.RowFilter ="SexType in ('"  + mSex+ "', 'B')";}
			return mDataView;
		}


		public DataView BloodGroups()
		{
			object [] myArray = new object[1];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("BloodGroups");

			mDataRow = mDataTable.NewRow();
			myArray[0]="A+";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="A-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="B+";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="B-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="O+";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="O-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="AB+";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="AB-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);


			mDataTable.TableName = "BloodGroups";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView Condition()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("ConditionCode");
			mDataTable.Columns.Add("ConditionDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="N";
			myArray[1]="Normal";
			
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="S";
			myArray[1]="Serious";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "Condition";
			mDataView.Table = mDataTable;
			return mDataView;	
		}

		public DataView Relations()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("Relation");
			mDataTable.Columns.Add("SexType");
			mDataRow = mDataTable.NewRow();
			myArray[0]="Self";
			myArray[1]="B";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="F/O";
			myArray[1]="M";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="M/O";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="W/O";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="H/O";
			myArray[1]="M";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="S/O";
			myArray[1]="M";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="D/O";
			myArray[1]="F";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "Relations";
			mDataView.Table = mDataTable;
			return mDataView;	
		}

		public DataView PatientTypes()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("PatientType");
			mDataTable.Columns.Add("PTypeCode");

			mDataRow = mDataTable.NewRow();
			myArray[0]="ENT";
			myArray[1] = "E";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="CNE";
			myArray[1] = "C";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "PatienTypes";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView SexTypes()
		{
			object [] myArray = new object[2];
			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;
			mDataTable.Columns.Add("SexCode");
			mDataTable.Columns.Add("SexDesc");
			mDataRow = mDataTable.NewRow();
			myArray[0]="M";
			myArray[1]="Male";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);
			mDataRow = mDataTable.NewRow();
			myArray[0]="F";
			myArray[1]="Female";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);
			mDataTable.TableName = "SexType";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView MaritalStatus()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("MaritalCode");
			mDataTable.Columns.Add("MaritalDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="S";
			myArray[1]="Single";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="M";
			myArray[1]="Married";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);


			mDataRow = mDataTable.NewRow();
			myArray[0]="W";
			myArray[1]="Widow";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="-";
			myArray[1]="-";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "MaritalStatus";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

	

		public DataView FactoryType()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("FactoryTypeCode");
			mDataTable.Columns.Add("FactoryTypeDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="F";
			myArray[1]="POF Factory";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="A";
			myArray[1]="Allied Department";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="P";
			myArray[1]="Panel Company";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="M";
			myArray[1]="Miscellaneous";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "FactoryType";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView EmployeeStatus()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("EmployeeStatusCode");
			mDataTable.Columns.Add("EmployeeStatusDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="S";
			myArray[1]="Single";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="M";
			myArray[1]="Married";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "MaritalStatus";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView DeptTypes()
		{
			object [] myArray = new object[2];
			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;
			mDataTable.Columns.Add("DTypeCode");
			mDataTable.Columns.Add("DTypeDesc");
			mDataRow = mDataTable.NewRow();
			myArray[0]="I";
			myArray[1]="Internal";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);
			mDataRow = mDataTable.NewRow();
			myArray[0]="S";
			myArray[1]="Services";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);
			mDataTable.TableName = "DeptTYpe";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView PrintOption()
		{
			object [] myArray = new object[2];

			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("PrintCode");
			mDataTable.Columns.Add("PrintDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="1";
			myArray[1]="Print on Printer";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="2";
			myArray[1]="Print on Browser";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="3";
			myArray[1]="Print on PDF";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "PrintOption";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView PatientCondition()
		{
			object [] myArray = new object[2];
			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("PCCode");
			mDataTable.Columns.Add("PCDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="N";
			myArray[1]="Normal";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="S";
			myArray[1]="Serious";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="V";
			myArray[1]="Severe";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "PatientCondition";
			mDataView.Table = mDataTable;
			return mDataView;		
		}


		public DataView TStatus()
		{
			object [] myArray = new object[2];
			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("TSCode");
			mDataTable.Columns.Add("TSDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="T";
			myArray[1]="Treated";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="U";
			myArray[1]="Un-Treated";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="C";
			myArray[1]="Cancelled";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "TStatus";
			mDataView.Table = mDataTable;
			return mDataView;		
		}

		public DataView DoctorStatus()
		{
			object [] myArray = new object[2];
			DataView mDataView = new DataView();
			DataTable mDataTable = new DataTable();
			DataRow mDataRow;

			mDataTable.Columns.Add("DSCode");
			mDataTable.Columns.Add("DSDesc");

			mDataRow = mDataTable.NewRow();
			myArray[0]="1";
			myArray[1]="Doctor Status-1";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="2";
			myArray[1]="Doctor Status-2";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataRow = mDataTable.NewRow();
			myArray[0]="3";
			myArray[1]="Doctor Status-3";
			mDataRow.ItemArray = myArray;
			mDataTable.Rows.Add(mDataRow);

			mDataTable.TableName = "DStatus";
			mDataView.Table = mDataTable;
			return mDataView;		
		}


	}
}
