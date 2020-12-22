using CabBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.RepositoryInterfaces
{
    public interface IBookingRepository: IAsyncRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByCabType(int CabTypeId);

    }
}
