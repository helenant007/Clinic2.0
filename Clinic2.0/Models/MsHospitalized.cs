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
    
    public partial class MsHospitalized
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsHospitalized()
        {
            this.DetailHospitalizeds = new HashSet<DetailHospitalized>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailHospitalized> DetailHospitalizeds { get; set; }
    }
}
