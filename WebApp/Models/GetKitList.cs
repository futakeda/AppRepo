using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Utility;

namespace WebApp.Models
{
	public class GetKitList : ModelBase
	{
		/// <summary>
		/// ストアド定義(ユーザ情報取得)
		/// </summary>
		private const string SP_GET_KIT_LIST = "GetKitList";

		/// <summary>
		/// 物流配膳No
		/// </summary>
		public string Butsuryu_no { get; set; }

		/// <summary>
		/// フダ
		/// </summary>
		public string Fuda { get; set; }

		/// <summary>
		/// BF
		/// </summary>
		public string Bf { get; set; }

		/// <summary>
		/// 取り扱い
		/// </summary>
		public string Toriatukai { get; set; }

		/// <summary>
		/// 位置
		/// </summary>
		public string Iti { get; set; }

		/// <summary>
		/// 部品番号
		/// </summary>
		public string Buhin_no { get; set; }

		/// <summary>
		/// 記述・型式
		/// </summary>
		public string Kijutu { get; set; }

		/// <summary>
		/// 丸め
		/// </summary>
		public string Marume { get; set; }

		/// <summary>
		/// 見積数量
		/// </summary>
		public string Suryo { get; set; }

		/// <summary>
		/// 摘要
		/// </summary>
		public string Tekiyo { get; set; }

		/// <summary>
		/// 欠品
		/// </summary>
		public string Keppin { get; set; }

		/// <summary>
		/// 進捗状況
		/// </summary>
		public string Sintyoku { get; set; }

		/// <summary>
		/// KitListDataTable
		/// </summary>
		public DataTable DtKitList { get; set; }
		
		/// <summary>
		/// KITリストデータ取得
		/// </summary>
		public void Get_KitList()
		{
			SqlCommand dbCmd = null;
			DtKitList = new DataTable();
			try
			{
				dbCmd = DbObj.GetCmd();
				dbCmd.CommandText = SP_GET_KIT_LIST;
				SqlDataAdapter dbAdapter = new SqlDataAdapter(dbCmd);
				dbAdapter.Fill(DtKitList);

				// 権限の取得
				if (DtKitList.Rows.Count == 0)
				{
					// エラーメッセージをセッションへ設定し、エラーページへ遷移
					// 権限が付与されていません。
					//Session[CommonConst.SESSON_KEY_ERROR] = this.GetMessage(CommonConst.ERRMSG_E0002);
					//Response.Redirect("~/C0000_ErrorPage.aspx", false);
					//return false;
				}

				//return dtKitList;
			}
			finally
			{
				if (dbCmd != null)
				{
					dbCmd.Dispose();
				}

				if (DbObj != null)
				{
					DbObj.RemoveConn();
				}
			}
		}
	}
}