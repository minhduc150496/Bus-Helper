//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusHelperDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusInfo()
        {
            this.BusInfo_BusStop = new HashSet<BusInfo_BusStop>();
            this.BusInfo_Vehicle = new HashSet<BusInfo_Vehicle>();
        }
    
        public int id { get; set; }
        public Nullable<int> number { get; set; }
        public Nullable<System.TimeSpan> start_time { get; set; }
        public Nullable<System.TimeSpan> end_time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusInfo_BusStop> BusInfo_BusStop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusInfo_Vehicle> BusInfo_Vehicle { get; set; }
    }
}
