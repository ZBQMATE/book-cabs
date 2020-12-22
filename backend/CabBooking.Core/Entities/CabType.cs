using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Entities
{
    public class CabType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BookingHistory> BookingHistorys { get; set; }

    }
}
