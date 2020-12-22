using CabBooking.Core.Entities;
using CabBooking.Core.Models.Request;
using CabBooking.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel requestModel);
        Task<BookingHistoryResponseModel> DeleteBookingHistory(int id);
        Task<IEnumerable<BookingHistory>> GetAllBookingHistories();
        Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel requestModel);
    }
}
