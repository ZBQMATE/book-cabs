using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CabBooking.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public String BookingTime { get; set; }
        public int? FromPlaceId { get; set; }
        public int? ToPlaceId { get; set; }
        public String PickupAddress { get; set; }
        public String Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public String PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        public String ContactNo { get; set; }
        public String Status { get; set; }
        public CabType CabType { get; set; }
        public Place FromPlace { get; set; }
        public Place ToPlace { get; set; }
    }
}
