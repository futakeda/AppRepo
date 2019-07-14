using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Utility;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
		public ActionResult Test()
		{
			return View();
		}
		// GET: Default
		public ActionResult KitBase()
        {
			#region Sampleだよ
			//// リストボックス Sample
			//ViewBag.SelectOptions = new SelectListItem[] {
			//new SelectListItem() { Value="jQuery Tips", Text="jQuery Tips" },
			//new SelectListItem() { Value="jQuery リファレンス ", Text="jQuery リファレンス " },
			//new SelectListItem() { Value="jQuery サンプル集 ", Text="jQuery サンプル集 " }
			//};

			//// Controller-View間のやり取り Sample
			//ViewData["Message"] = "Hello, MVC";
			//ViewData["Name"] = "Taro";
			#endregion

			// ユーザ情報取得
			GetUserInfo ObjUserInfo = new GetUserInfo();
			ObjUserInfo.Get_UserInfo();
			return View(ObjUserInfo);
        }
		public ActionResult KitList()
		{
			// KITリストデータ取得
			List<GetKitList> KitList = new List<GetKitList>();
			GetKitList ObjKitList = new GetKitList();
			ObjKitList.Get_KitList();

			DataTable dtKitList = new DataTable();
			dtKitList = Utilitys.GetUserTable(ObjKitList.DtKitList);

			return View(ObjKitList.DtKitList);
		}
	}
}