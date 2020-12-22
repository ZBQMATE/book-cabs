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
    public class BookingService: IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IAsyncRepository<Place> _repositoryPlace;

        public BookingService(IBookingRepository repository, IAsyncRepository<Place> repositoryPlace)
        {
            _repository = repository;
            _repositoryPlace = repositoryPlace;
        }

        public async Task<IEnumerable<CabTypeToBookingResponseModel>> CabTypeBooking(int CabTypeId)
        {
            var bookings = await _repository.GetBookingsByCabType(CabTypeId);
            List <CabTypeToBookingResponseModel> tmp = new List<CabTypeToBookingResponseModel>();
            foreach (var booking in bookings) {
                var FromPlace = await _repositoryPlace.GetByIdAsync(booking.FromPlaceId);
                var ToPlace = await _repositoryPlace.GetByIdAsync(booking.ToPlaceId);
                var responseItem = new CabTypeToBookingResponseModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    PickupAddress = booking.PickupAddress,
                    ContactNo = booking.ContactNo,
                    FromPlaceName = FromPlace.Name,
                    ToPlaceName = ToPlace.Name,
                };
                tmp.Add(responseItem);
            }
            IEnumerable<CabTypeToBookingResponseModel> response = tmp;
            return response;
        }

        public async Task<BookingResponseModel> CreateBooking(BookingRequestModel requestModel)
        {
            var booking = new Booking
            {
                Email = requestModel.Email,
                FromPlaceId = requestModel.FromPlaceId,
                ToPlaceId = requestModel.ToPlaceId,
                PickupAddress = requestModel.PickupAddress,
                CabTypeId = requestModel.CabTypeId,
                ContactNo = requestModel.ContactNo,
            };
            var createdBooking = await _repository.AddAsync(booking);
            var response = new BookingResponseModel
            {
                Id = createdBooking.Id,
            };
            return response;
        }

        public async Task<BookingResponseModel> DeleteBooking(int id)
        {
            var dbBooking = await _repository.GetByIdAsync(id);
            if (dbBooking != null)
            {
                await _repository.DeleteAsync(dbBooking);
                var responseSucc = new BookingResponseModel
                {
                    Id = dbBooking.Id,
                };
                return responseSucc;
            }
            var response = new BookingResponseModel
            {
                Id = id,
            };
            return response;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<BookingResponseModel> UpdateBooking(BookingRequestModel requestModel)
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
                var updatedBooking = await _repository.UpdateAsync(dbBooking);
                var responseSucc = new BookingResponseModel
                {
                    Id = updatedBooking.Id,
                };
                return responseSucc;
            }
            var response = new BookingResponseModel
            {
                Id = requestModel.Id,
            };
            return response;
        }
    }
}
