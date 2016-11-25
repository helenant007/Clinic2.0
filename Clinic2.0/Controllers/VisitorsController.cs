using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicApp.Controllers
{
    public class VisitorsController : Controller
    {
        Models.KlinikModelContainer db = new Models.KlinikModelContainer();
        // GET: Visitors

        public ActionResult DailyVisitors()
        {
            return View();
        }


        public JsonResult GetDailyVisitors()
        {
            /*              <th>Date</th>
                            <th>Section</th>
                            <th>Binusian ID</th>
                            <th>Name</th>
                            <th>Phone</th>
                            <th>Diagnose</th>
                            <th>Anamnesis</th>
                            <th></th> */

            return Json(db.PatientVisits.Include(x => x.Patient).Include(x => x.Patient.MsSection).Include(x => x.MsDiagnose).ToList().Select(x => new
            {
                Id = x.Id,
                Date = x.VisitDate.ToString("ddd dd MM yyyy"),
                BinusianID = x.Patient.BinusianId,
                Name = x.Patient.Name,
                BloodType = x.Patient.BloodType,
                Gender = x.Patient.Gender,
                Phone = x.Patient.Phone,
                Diagnose = x.MsDiagnose.DiagnoseName,
                Anamnesis = x.Anamnesis,
                Notes = x.Notes,
                Section = x.Patient.MsSection.SectionName
            }));
        }

        /* Intinya di Web, kita punya 5 Method dasar
         * 1. GET
         * 2. POST
         * 3. PUT
         * 4. PATCH
         * 5. DELETE
         * 
         * GET itu kapan aja? paling basic, ketika lu input addressbar di browser terus hit ENTER
         * POST itu kapan? umumnya ya pas di angular ya, kita pake $http.post, otomatis metode post
         * PUT,PATCH,DELETE juga sama, umumnya di angular jg
         */
        public ActionResult SectionList()
        {
            return View();
        }


        public ActionResult Hospitalized()
        {
            return View();
        }


        public class A
        {
            public string MedName { get; set; }
            public int Qty { get; set; }
        }
        public class B
        {
            public string Anamnesis { get; set; }
            public string Implementation { get; set; }
            public string Diagnose { get; set; }
            public string Notes { get; set; }
            public string BinusianID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Section { get; set; }
            public string VisitDate { get; set; }
            public A[] Arr { get; set; }
            public string BloodType { get; set; }
            public string Gender { get; set; }
            public string UseMedicine { get; set; }
        }


        public JsonResult CreateVisitor(B fm)
        {
            var patient = db.MsPatients.FirstOrDefault(p => p.BinusianId == fm.BinusianID);
            if (patient == null)
            {
                var section = db.MsSections.First(s => s.SectionName == fm.Section);

                patient = new Models.MsPatient()
                {
                    BloodType = fm.BloodType,// nah ini, kenapa bloodtype sm gender nya gk ke add coba debug deh
                    BinusianId = fm.BinusianID,
                    Gender = fm.Gender,
                    MsSection = section,
                    Name = fm.Name,
                    Phone = fm.Phone
                };
                db.MsPatients.Add(patient);

                db.SaveChanges();
            }


            var diagnose = db.MsDiagnoses.First(d => d.DiagnoseName == fm.Diagnose);
            var pv = new Models.PatientVisit()
            {
                Anamnesis = fm.Anamnesis ?? "",
                Implementation = fm.Implementation ?? "",
                MsDiagnose = diagnose,
                Notes = fm.Notes ?? "",
                Patient = patient,
                VisitDate = DateTime.Now
            };
            db.PatientVisits.Add(pv);
            db.SaveChanges();

            if (fm.UseMedicine.Equals("yes"))
            {
                var detailpatientvisits = new List<Models.DetailPatientVisit>();
                if (fm.Arr != null && fm.Arr.Length > 0)
                {
                    foreach (var item in fm.Arr)
                    {
                        var med = db.MsMedicines.First(m => m.Name == item.MedName);

                        detailpatientvisits.Add(new Models.DetailPatientVisit()
                        {
                            MsMedicines = med,
                            Qty = item.Qty
                        });
                    }
                    pv.DetailPatientVisits = detailpatientvisits;
                    db.SaveChanges();
                }
            }

            var x = pv;
            return Json(new
            {
                Id = x.Id,
                Date = x.VisitDate.ToString("ddd dd MM yyyy"),
                BinusianID = x.Patient.BinusianId,
                Name = x.Patient.Name,
                Phone = x.Patient.Phone,
                Diagnose = x.MsDiagnose.DiagnoseName,
                Anamnesis = x.Anamnesis,
                Notes = x.Notes,
                Section = x.Patient.MsSection.SectionName
            });
        }

        public JsonResult DeleteVisitor(int id)
        {
            var delete = db.PatientVisits.Find(id);
            if (delete.DetailPatientVisits != null && delete.DetailPatientVisits.Count > 0)
                db.DetailPatientVisits.RemoveRange(delete.DetailPatientVisits);
            db.PatientVisits.Remove(delete);
            db.SaveChanges();
            return Json(true);
        }
    }
}