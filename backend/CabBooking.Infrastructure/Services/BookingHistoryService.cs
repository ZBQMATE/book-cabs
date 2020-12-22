using CabBooking.Core.Entities;
using CabBooking.Core.Models.Request;
using CabBooking.Core.Models.Response;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IAsyncRepository<BookingHistory> _repository;

        public BookingHistoryService(IAsyncRepository<BookingHistory> repository)
        {
            _repository = repository;
        }

        public async Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel requestModel)
        {
            var booking = new BookingHistory
            {
                Email = requestModel.Email,
                FromPlaceId = requestModel.FromPlaceId,
                ToPlaceId = requestModel.ToPlaceId,
                PickupAddress = requestModel.PickupAddress,
                CabTypeId = requestModel.CabTypeId,
                ContactNo = requestModel.ContactNo,
                Charge = requestModel.Charge,
                Feedback = requestModel.Feedback,
            };
            var createdBooking = await _repository.AddAsync(booking);
            var response = new BookingHistoryResponseModel
            {
                Id = createdBooking.Id,
            };
            return response;
        }

        public async Task<BookingHistoryResponseModel> DeleteBookingHistory(int id)
        {
            var dbBooking = await _repository.GetByIdAsync(id);
            if (dbBooking != null)
            {
                await _repository.DeleteAsync(dbBooking);
                var responseSucc = new BookingHistoryResponseModel
                {
                    Id = dbBooking.Id,
                };
                return responseSucc;
            }
            var response = new BookingHistoryResponseModel
            {
                Id = id,
            };
            return response;
        }

        public async Task<IEnumerable<BookingHistory>> GetAllBookingHistories()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel requestModel)
        {
            var dbBooking = await _repository.GetByIdAsync(requestModel.Id);
            if (dbBooking != null)
            {
                dbBooking.Email = requestModel.Email;
                dbBooking.FromPlaceId = requestModel.FromPlaceId;
                dbBooking.ToPlaceId = requestModel.ToPlaceId;
                dbBooking.PickupAddress = requestModel.PickupAddress;
                dbBooking.CabTypeId = requestModel.CabTypeId;
                dbBooking.ContactNo = requestModel.ContactNo;
                dbBooking.Charge = requestModel.Charge;
                dbBooking.Feedback = requestModel.Feedback;
                var updatedBooking = await _repository.UpdateAsync(dbBooking);
                var responseSucc = new BookingHistoryResponseModel
                {
                    Id = updatedBooking.Id,
                };
                return responseSucc;
            }
            var response = new BookingHistoryResponseModel
            {
                Id = requestModel.Id,
            };
            return response;
        }
    }
}
