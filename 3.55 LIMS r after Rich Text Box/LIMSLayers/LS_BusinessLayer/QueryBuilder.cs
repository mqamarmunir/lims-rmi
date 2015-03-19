using System;
using System.Configuration;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for QueryBuilder.
	/// </summary>
	public class QueryBuilder
	{
		public QueryBuilder()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public string QBInsert(string[,] ar, string tableName)
		{
			string toReturn = "Insert into " + tableName + "(";
			int checker = 0;

			for(int counter = 0; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					toReturn += ar[counter, 0];

					checker++;
				}
			}

			toReturn += ") Values(";
			checker = 0;

			for(int counter = 0; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					switch(ar[counter,2])
					{
						case "string":
                            toReturn += "'" + ar[counter,1].Replace("'","''") + "'";
							break;

						case "int":
							toReturn += ar[counter,1];
							break;

						case "date":
                            string dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                            toReturn += "to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
							break;
                        case "datetime":
                            string dateTimeFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();
                            toReturn += "to_date('" + ar[counter, 1] + "','" + dateTimeFormat + "')";
                            break;

						default:
							toReturn += "'" + ar[counter,1] + "'";
							break;
					}

					checker++;
				}
			}

			toReturn += ")";

			return toReturn;
		}


		public string QBUpdate(string[,] ar, string tableName)
		{
			string toReturn = "Update " + tableName + " set ";
			int checker = 0;

			for(int counter = 1; counter <= ar.GetUpperBound(0); counter++)
			{
				if(ar[counter,0] != null)
				{
					if(checker != 0)
					{
						toReturn += ",";
					}

					switch(ar[counter,2])
					{
						case "string":
							toReturn += ar[counter, 0] + "='" + ar[counter,1].Replace("'","''") + "'";
							break;

						case "int":
							toReturn += ar[counter, 0] + "=" + ar[counter,1];
							break;

                        //case "date":
                        //    toReturn += ar[counter, 0] + "=to_date('" + ar[counter,1] + "','" + ar[counter,3] + "')";
                        //    break;
                        case "date":
                            string dateFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                            toReturn += ar[counter, 0] + "=to_date('" + ar[counter, 1] + "','" + dateFormat + "')";
                            break;
                        case "datetime":
                            string dateTimeFormat = ConfigurationSettings.AppSettings["DateTimeFormat"].ToString();
                            toReturn += "to_date('" + ar[counter, 1] + "','" + dateTimeFormat + "')";
                            break;
                        

						default:
							toReturn += ar[counter, 0] + "='" + ar[counter,1] + "'";
							break;
					}

					checker++;
				}
			}

			if(ar[0,2].Equals("string"))
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "='" + ar[0,1].ToUpper().Replace("'","''") +"'";
			}
			else
			{
				toReturn += " Where " + ar[0,0].ToUpper() + "=" + ar[0,1].ToUpper();
			}

			return toReturn;
		}


		public string QBGetSingle(string strColumnName, string strPKey, string strTableName)
		{
			return "Select * from " + strTableName + " Where Upper(" + strColumnName + ") = '" + strPKey.ToUpper() + "'";
		}

		
		public string QBGetMax(string columnName, string tableName, string strLength)
		{
			return "Select LPad(NVL(Max(" + columnName + "),0)+1, " + strLength + ", 0) As MAXID from " + tableName;
		}

		public string QBGetMaxWorkListNo(string SectionID)
		{
			return "Select NVL(Max(WorkListNo),0)+1 As MAXID from LS_TWorkList Where SectionID = " + SectionID;
		}

		public string QBGetMaxRSerialNo()
		{			
			return "Select NVL(Max(RSerialNo),0)+1 As MAXID from LS_TTestResultM";
		}
        public string QBGetMax(string columnName, string tableName)
        {
            return "Select NVL(Max(" + columnName + "),0)+1 As MAXID from " + tableName;
        }
	}
}