using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClinicApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //new Seeder.Seeder().Seed();

        
        }

    }
}

namespace ClinicApp.Seeder
{
    using System.Data.Entity.Migrations;
    public class Seeder
    {

        public void Seed()
        {
            Random R = new Random(5); // Seed ny kasih 5 biar selalu konsistent randomnya

            var db = new Models.KlinikModelContainer();
            var sections = new Models.MsSection[] {
                new Models.MsSection(){SectionName = "Binus Center", Abbr = "BC",},
                new Models.MsSection(){SectionName = "Binus Online Learning", Abbr = "BOL",},
                new Models.MsSection(){SectionName = "Communication Marketing", Abbr = "CMC",},
                new Models.MsSection(){SectionName = "Finance (Procurement)", Abbr = "FINANCE",},
                new Models.MsSection(){SectionName = "General Affairs (BM, ME, Clinic)", Abbr = "GA",},
                new Models.MsSection(){SectionName = "Global Employability and Enterpreneurship Center", Abbr = "GEEC",},
                new Models.MsSection(){SectionName = "Human Capital", Abbr = "HC",},
                new Models.MsSection(){SectionName = "International Business Management",Abbr = "IBM",},
                new Models.MsSection(){SectionName = "Information Technology", Abbr = "IT",},
                new Models.MsSection(){SectionName = "Laboratory Center", Abbr = "LC",},
                new Models.MsSection(){SectionName = "Library and Knowledge Center", Abbr = "LKC",},
                new Models.MsSection(){SectionName = "Marketing (Admisi)", Abbr = "MARKETING",},
                new Models.MsSection(){SectionName = "Quality Management Control", Abbr = "QMC",},
                new Models.MsSection(){SectionName = "Rektorat",Abbr = "REKTORAT",},
                new Models.MsSection(){SectionName = "Student Service Center", Abbr = "SSC",},
                new Models.MsSection(){SectionName = "Corporate and Development Center", Abbr = "CDC",},
                new Models.MsSection(){SectionName = "Mahasiswa", Abbr = "MHS",},
                new Models.MsSection(){SectionName = "Jurusan", Abbr = "JUR",},
                new Models.MsSection(){SectionName = "Non Staff (ISS, Outsourcing, Security, etc)", Abbr = "NON BINUS",},
                new Models.MsSection(){SectionName = "Student Advisory and Development Center", Abbr = "SADC",},
                new Models.MsSection(){SectionName = "Teach For Indonesia", Abbr = "TFI",},
            };
            db.MsSections.AddOrUpdate(s => s.SectionName, sections);
            db.SaveChanges();

            var diagnoses = new Models.MsDiagnose[]
            {
                new Models.MsDiagnose() {DiagnoseName = "Febrile/Fever (Demam)" },
                new Models.MsDiagnose() {DiagnoseName = "Vertigo/Migrain (Pusing Berputar)" },
                new Models.MsDiagnose() {DiagnoseName = "Vommiting (Muntah)" },
                new Models.MsDiagnose() {DiagnoseName = "Gastro Enteritis (Radang Pencernaan)" },
                new Models.MsDiagnose() {DiagnoseName = "Myalgia (Nyeri Otot)" },
                new Models.MsDiagnose() {DiagnoseName = "Hypertension (Tekanan Darah Tinggi)" },
                new Models.MsDiagnose() {DiagnoseName = "Hypotension (Tekanan Darah Rendah)" },
                new Models.MsDiagnose() {DiagnoseName = "Fracture of Unspecified Bones (Patah/Retak Tulang)" }
            };
            db.MsDiagnoses.AddOrUpdate(diag => diag.DiagnoseName, diagnoses); 
            db.SaveChanges();

            var tablet = new Models.MsMedicineType() { Value = "Tablet" };
            var capsul = new Models.MsMedicineType() { Value = "Capsul" };
            var bottle = new Models.MsMedicineType() { Value = "Bottle" };
            var tube = new Models.MsMedicineType() { Value = "Tube" };
            var strip = new Models.MsMedicineType() { Value = "Strip" };
            var amp = new Models.MsMedicineType() { Value = "Amp" };

            db.MsMedicineTypes.AddOrUpdate(t => t.Value,
                tablet, capsul, bottle, tube, strip, amp
            );
            db.SaveChanges();

            var medicines = new Models.MsMedicine[]
            {
                new Models.MsMedicine() {Name ="Panadol", Qty = 0, MsMedicineTypes = tablet },
                new Models.MsMedicine() {Name ="Betadine", Qty = 0, MsMedicineTypes = tube },
                new Models.MsMedicine() {Name ="Decolsin Caplet", Qty = 0, MsMedicineTypes = capsul },
                new Models.MsMedicine() {Name ="Hansaplast", Qty = 0, MsMedicineTypes = strip },
                new Models.MsMedicine() {Name ="Feminax", Qty = 0, MsMedicineTypes = tablet }
            };
            db.MsMedicines.AddOrUpdate(med => med.Name, medicines);
            db.SaveChanges();

            var patients = new Models.MsPatient[]
            {
                new Models.MsPatient() { BinusianId="1801377654", Phone="085891846449", Name="Billy Darmawan", Gender="Male", BloodType="B", MsSection = db.MsSections.Find(R.Next(db.MsSections.Count()))},
                new Models.MsPatient() { BinusianId="1801380333", Phone="085891846447", Name="Proxima Prada", Gender="Female", BloodType = "O" , MsSection = db.MsSections.Find(R.Next(db.MsSections.Count()))},
                new Models.MsPatient() { BinusianId="1803103810", Phone="085891846444", Name="Arlette Wijaya", Gender="Female", BloodType="O", MsSection = db.MsSections.Find(R.Next(db.MsSections.Count()))},
                new Models.MsPatient() { BinusianId="1801401890", Phone="085891846445", Name="Christabella Danoko", Gender="Female", BloodType="A" , MsSection = db.MsSections.Find(R.Next(db.MsSections.Count()))},
                new Models.MsPatient() { BinusianId="1801413098", Phone="085891846446", Name="Nadia Sarah Pulungan", Gender="Female", BloodType="AB", MsSection = db.MsSections.Find(R.Next(db.MsSections.Count()))}

            };
            db.MsPatients.AddOrUpdate(person => person.Name, patients);
            db.SaveChanges();


            string[] conditions = new string[] { "Critical", "Slightly Injured", "Heavily Injured", "Healthy" };
            string[] treatments = new string[] { "nothing", "Use Medicine", "Bed Rest" };

            var GetDetailPatientVisit = new Func<List<Models.DetailPatientVisit>>(() =>
            {
                return new List<Models.DetailPatientVisit>()
                {
                    new Models.DetailPatientVisit() {  MsMedicines = medicines[R.Next(medicines.Length)], Qty = 5+ R.Next(5)},
                    new Models.DetailPatientVisit() {  MsMedicines = medicines[R.Next(medicines.Length)], Qty = 5+ R.Next(5)}
                };
            });
            
            var patientvisits = new Models.PatientVisit[]
            {
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() },
                new Models.PatientVisit() { Patient = patients[R.Next(patients.Length)], MsDiagnose = diagnoses[R.Next(diagnoses.Length)], Anamnesis= conditions[R.Next(conditions.Length)], Implementation=treatments[R.Next(treatments.Length)], Notes="", VisitDate=DateTime.Now.AddDays(R.Next(-365,0)), DetailPatientVisits = GetDetailPatientVisit() }
            };

            db.PatientVisits.AddOrUpdate(person => person.VisitDate,
                patientvisits
            );

            db.SaveChanges();

        }
    }
}