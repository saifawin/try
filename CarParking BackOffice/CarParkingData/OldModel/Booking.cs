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

    public partial class Booking
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> BuildingParkId { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
        [Write(false)]
        public virtual Building Building { get; set; }
        [Write(false)]
        public virtual Users Users { get; set; }
        [Write(false)]
        public virtual BuildingPark BuildingPark { get; set; }
        [Write(false)]
        public string StatusCode { get; set; }
    }
}
