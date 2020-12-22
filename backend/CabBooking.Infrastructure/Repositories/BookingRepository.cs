using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Repositories
{
    public class BookingRepository : EfRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CabBookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCabType(int CabTypeId)
        {
            var bookings = await _dbContext.Bookings.Where(c => c.CabTypeId == CabTypeId).ToListAsync();
            return bookings;
        }
    }
}
