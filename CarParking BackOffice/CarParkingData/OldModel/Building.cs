//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarParkingData
{
    using Dapper.Contrib.Extensions;
    using System;
    using System.Collections.Generic;

    public partial class Building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
            this.Booking = new HashSet<Booking>();
            this.BuildingClass = new HashSet<BuildingClass>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Write(false)]
        public virtual ICollection<Booking> Booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Write(false)]
        public virtual ICollection<BuildingClass> BuildingClass { get; set; }
    }
}
