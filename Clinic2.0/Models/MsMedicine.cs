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
    
    public partial class MsMedicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsMedicine()
        {
            this.MedicineStocks = new HashSet<MedicineStock>();
            this.DetailPatientVisit = new HashSet<DetailPatientVisit>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineStock> MedicineStocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailPatientVisit> DetailPatientVisit { get; set; }
        public virtual MsMedicineType MsMedicineTypes { get; set; }
    }
}
