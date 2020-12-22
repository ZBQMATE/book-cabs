using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Models.Response
{
    public class CabTypeToBookingResponseModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String PickupAddress { get; set; }
        public String ContactNo { get; set; }
        public String FromPlaceName { get; set; }
        public String ToPlaceName { get; set; }

    }
}
