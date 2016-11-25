using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class MedicineController : Controller
    {
        Models.KlinikModelContainer db = new Models.KlinikModelContainer();
        // GET: Medicine
        public ActionResult Stock()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult StockViewModel()
        {

            return Json(new
            {
                Medicines = db.MsMedicines.Select(med => new
                {
                    Name = med.Name,
                    Qty = med.Qty,
                    Type = med.MsMedicineTypes.Value,
                    Id = med.Id
                })

            });
        }
        public JsonResult GetMedicineTypes()
        {
            return Json(db.MsMedicineTypes.Select(res => new
            {
                //Id = res.Id,
                Value = res.Value
            }));
        }

        [HttpPost]
        public JsonResult AddNewTypeMedicine()
        {

            return Json(true);
        }


        public class AddMedicForm
        {
            public string Name { get; set; }
            public int Qty { get; set; }
            public string Type { get; set; }
            public int Price { get; set; }
            public DateTime ExpDate { get; set; }
            public DateTime AddedDate { get; set; }
        }

        [HttpPost]
        public JsonResult AddMedicine(AddMedicForm fm)
        {

            var medic = db.MsMedicines.FirstOrDefault(x => x.Name == fm.Name && x.MsMedicineTypes.Value == fm.Type);
            int upsert = 0;



            if (medic == null)
            {
                var insert = new Models.MsMedicine()
                {
                    Name = fm.Name,
                    Qty = 0,
                    MsMedicineTypes = db.MsMedicineTypes.First(t => t.Value == fm.Type),
//refactor soon
                };

                upsert = 1;
                db.MsMedicines.Add(insert);
                db.SaveChanges();
                medic = insert;
            }
            else
            {
                medic.Qty += fm.Qty;
                db.Entry(medic).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new
            {
                Upsert = upsert,
                Name = medic.Name,
                Qty = medic.Qty,
                Type = medic.MsMedicineTypes.Value,
                Id = medic.Id
            });
            //intinya jalanin dlu deh gw aja blm ada bayangan 
        }
        [HttpPost]
        public JsonResult EditMedicine()
        {
            return Json(true);
        }
        [HttpPost]
        public JsonResult DeleteMedicine(int Id)
        {
            var delete = db.MsMedicines.Find(Id);

            db.MsMedicines.Remove(delete);

            db.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public JsonResult AddViewModel()
        {

            return Json(new
            {
                Medicines = db.MsMedicines
            });

        }
    }
}