using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Utility;

namespace WebApp.Models
{
	public class ModelBase
	{
		protected DbMgr DbObj { get; set; }

		public ModelBase()
		{
			DbObj = new DbMgr();
			DbObj.CreateConn();
		}
	}
}