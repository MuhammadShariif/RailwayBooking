//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailwayBooking
{
    using System;
    using System.Collections.Generic;
    
    public partial class Station_Details
    {
        public int Train_ID { get; set; }
        public int Station_ID { get; set; }
        public Nullable<int> Sequence_No { get; set; }
        public Nullable<System.TimeSpan> Station_Arrival_Time { get; set; }
        public Nullable<System.TimeSpan> Station_Departure_Time { get; set; }
    
        public virtual Station Station { get; set; }
        public virtual Train Train { get; set; }
    }
}
