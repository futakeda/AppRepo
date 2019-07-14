using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp.Utility
{
	public class DbMgr
	{
		/// <summary>
		/// DBコネクション
		/// </summary>
		private SqlConnection dbCon = null;

		/// <summary>
		/// SQLコマンド
		/// </summary>
		private SqlCommand dbCmd = null;

		/// <summary>
		/// DBキー
		/// </summary>
		private string dbKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

		/// <summary>
		/// SQLトランザクション
		/// </summary>
		public SqlTransaction DbTrn = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>

		/// <summary>
		/// DBコネクション生成
		/// </summary>
		public void CreateConn()
		{
			dbCon = new SqlConnection(dbKey);
			dbCon.Open();
		}

		/// <summary>
		/// DBトランザクション開始
		/// </summary>
		public void BeginTransaction()
		{
			DbTrn = dbCon.BeginTransaction();
		}

		/// <summary>
		/// DBトランザクションコミット
		/// </summary>
		public void CommitTransaction()
		{
			DbTrn.Commit();
		}

		/// <summary>
		/// DBトランザクションロールバック
		/// </summary>
		public void RollbackTransaction()
		{
			if (DbTrn != null)
			{
				DbTrn.Rollback();
			}
		}

		/// <summary>
		/// SqlCommand取得
		/// </summary>
		/// <returns>SqlCommand</returns>
		public SqlCommand GetCmd()
		{
			dbCmd = new SqlCommand();
			dbCmd.Connection = dbCon;
			dbCmd.Transaction = DbTrn;
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.CommandTimeout = 0;
			dbCmd.Parameters.Clear();
			dbCmd.Parameters.Add("@Ret", SqlDbType.Int, 4);
			dbCmd.Parameters["@Ret"].Direction = ParameterDirection.Output;
			dbCmd.Parameters.Add("@ErrInfo", SqlDbType.NVarChar, 400);
			dbCmd.Parameters["@ErrInfo"].Direction = ParameterDirection.Output;
			dbCmd.Parameters.Add("Return Value", SqlDbType.Int, 4);
			dbCmd.Parameters["Return Value"].Direction = System.Data.ParameterDirection.ReturnValue;

			return dbCmd;
		}

		/// <summary>
		/// DBコネクション解放
		/// </summary>
		public void RemoveConn()
		{
			if (dbCmd != null)
			{
				dbCmd.Dispose();
			}

			if (dbCon != null)
			{
				dbCon.Close();
				dbCon.Dispose();
			}
		}

		/// <summary>
		/// DBコマンドタイムアウト設定
		/// </summary>
		/// <param name="time">タイムアウト値(秒)</param>
		public void SetCommandTimeout(int time)
		{
		}
	}
}