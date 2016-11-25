using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class SharedController : Controller
    {
        Models.KlinikModelContainer db = new Models.KlinikModelContainer();

        private class MonthsofYear
        {
            public int Value { get; set; }
            public string MonthName { get; set; }
        }
       
        
        List<MonthsofYear> months = new List<MonthsofYear> {
                new MonthsofYear{ Value = 1, MonthName = "January"},
                new MonthsofYear{ Value = 2, MonthName = "February"},
                new MonthsofYear{ Value = 3, MonthName = "March"},
                new MonthsofYear{ Value = 4, MonthName = "April"},
                new MonthsofYear{ Value = 5, MonthName = "May"},
                new MonthsofYear{ Value = 6, MonthName = "June"},
                new MonthsofYear{ Value = 7, MonthName = "July"},
                new MonthsofYear{ Value = 8, MonthName = "August"},
                new MonthsofYear{ Value = 9, MonthName = "September"},
                new MonthsofYear{ Value = 10, MonthName = "October"},
                new MonthsofYear{ Value = 11, MonthName = "November"},
                new MonthsofYear{ Value = 12, MonthName = "December"}
            };
        public JsonResult GetMonthsData()
        {
            return Json(months);
        }

        public JsonResult GetSectionList()
        {

            return Json( db.MsSections.OrderBy(s=>s.SectionName).Select(res => new {
                SectionName = res.SectionName,
                Abbr = res.Abbr
            }));
        }

        public JsonResult GetDiagnoses() {
            return Json(db.MsDiagnoses.OrderBy(d => d.DiagnoseName).Select(res => new {
                DiagnoseName = res.DiagnoseName
            }));
        }

        public JsonResult GetMedicineNames() {
            return Json(db.MsMedicines.OrderBy(m=>m.Name).Select(res=> new {
                Names = res.Name
            }));
        }


    }
}