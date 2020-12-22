using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<Booking> FromBookings { get; set; }
        public ICollection<Booking> ToBookings { get; set; }
        public ICollection<BookingHistory> FromBookingHistories { get; set; }
        public ICollection<BookingHistory> ToBookingHistories { get; set; }

    }
}
