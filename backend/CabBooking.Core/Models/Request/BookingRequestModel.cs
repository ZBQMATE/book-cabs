using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Models.Request
{
    public class BookingRequestModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public int FromPlaceId { get; set; }
        public int ToPlaceId { get; set; }
        public String PickupAddress { get; set; }
        public int CabTypeId { get; set; }
        public String ContactNo { get; set; }
    }
}
