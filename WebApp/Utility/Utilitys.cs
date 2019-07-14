using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApp.Utility
{
	public class Utilitys
	{
		/// <summary>
		/// ユーザ定義テーブル型データテーブル生成
		/// </summary>
		/// <param name="type">ユーザ定義テーブル型Datatable</param>
		/// <returns>cookie</returns>
		public static DataTable GetUserTable(DataTable type)
		{
			int i = 0;
			DataTable retDt = new DataTable();
			for (i = 0; i < type.Columns.Count; i++)
			{
				retDt.Columns.Add(type.Columns[i].ColumnName);
			}

			return retDt;
		}

	}
}