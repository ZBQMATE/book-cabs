using CabBooking.Core.Entities;
using CabBooking.Core.Models.Request;
using CabBooking.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<BookingResponseModel> CreateBooking(BookingRequestModel requestModel);
        Task<BookingResponseModel> DeleteBooking(int id);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<BookingResponseModel> UpdateBooking(BookingRequestModel requestModel);

        Task<IEnumerable<CabTypeToBookingResponseModel>> CabTypeBooking(int CabTypeId);
    }
}
