//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsPatient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsPatient()
        {
            this.PatientVisits = new HashSet<PatientVisit>();
            this.DetailHospitalizeds = new HashSet<DetailHospitalized>();
        }
    
        public int Id { get; set; }
        public string BinusianId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientVisit> PatientVisits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailHospitalized> DetailHospitalizeds { get; set; }
        public virtual MsSection MsSection { get; set; }
    }
}
