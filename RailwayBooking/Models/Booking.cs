using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayBooking.Models
{
    public class Booking
    {
        public string Train_Name { get; set; }

        public int Coach_No { get; set; }

        [Range(1,72)]
        public int Seat_No { get; set; }
        public DateTime Trip_Date { get;set; }

        public string Trip_Start_Location { get; set; }

        public string Trip_End_Location { get; set; }

        public string Seat_Type { get; set; }


    }
}