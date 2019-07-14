using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApp.Utility;

namespace WebApp.Models
{
	public class GetUserInfo : ModelBase
	{
		/// <summary>
		/// ストアド定義(ユーザ情報取得)
		/// </summary>
		private const string SP_GET_USER_INFO = "GetUserInfo";

		/// <summary>
		/// ユーザ名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// メッセージ（Sampleなので後で消す）
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// タイトル（Sampleなので後で消す）
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// ユーザ情報取得処理
		/// </summary>
		public void Get_UserInfo()
		{
			SqlCommand dbCmd = null;
			try
			{
				// ストアド設定
				String userId = "takeda";
				String usrDomain = "INSTOK";

				dbCmd = DbObj.GetCmd();
				dbCmd.CommandText = SP_GET_USER_INFO;
				dbCmd.Parameters.Add("@UserNo", SqlDbType.NVarChar).Value = userId;
				dbCmd.Parameters.Add("@UserDomain", SqlDbType.NVarChar).Value = usrDomain;

				SqlDataAdapter dbAdapter = new SqlDataAdapter(dbCmd);
				DataSet ds = new DataSet();
				dbAdapter.Fill(ds);

				// 権限の取得
				if (ds.Tables[0].Rows.Count == 0)
				{
					// エラーメッセージをセッションへ設定し、エラーページへ遷移
					// 権限が付与されていません。
					//Session[CommonConst.SESSON_KEY_ERROR] = this.GetMessage(CommonConst.ERRMSG_E0002);
					//Response.Redirect("~/C0000_ErrorPage.aspx", false);
					//return false;
				}
				Name = ds.Tables[0].Rows[0].ItemArray[0].ToString();
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