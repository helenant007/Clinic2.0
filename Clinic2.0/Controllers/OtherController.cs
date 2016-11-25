using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class OtherController : Controller
    {
        Models.KlinikModelContainer db = new Models.KlinikModelContainer();
        // GET: Other
        public ActionResult ChangePass()
        {
            return View();
        }

        public ActionResult ExportExcel() {
            return View();
        }
        public ActionResult Other(){
            return View();
        }

        public JsonResult GetAdminData(string Uname) {
            var data = db.Admins.Select(x => x.Username == Uname);
            return Json(data);
        }
    }
}