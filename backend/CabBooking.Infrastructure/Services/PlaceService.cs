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
    public class PlaceService : IPlaceService
    {
        private readonly IAsyncRepository<Place> _repository;

        public PlaceService(IAsyncRepository<Place> repository)
        {
            _repository = repository;
        }

        public async Task<PlaceResponseModel> CreatePlace(PlaceRequestModel requestModel)
        {
            var place = new Place
            {
                Name = requestModel.Name,
            };
            var createdPlace = await _repository.AddAsync(place);
            var response = new PlaceResponseModel
            {
                Id = createdPlace.Id,
                Name = createdPlace.Name,
            };
            return response;
        }

        public async Task<PlaceResponseModel> DeletePlace(int id)
        {
            var dbPlace = await _repository.GetByIdAsync(id);
            if (dbPlace != null) {
                await _repository.DeleteAsync(dbPlace);
                var responseSucc = new PlaceResponseModel
                {
                    Id = dbPlace.Id,
                    Name = dbPlace.Name,
                };
                return responseSucc;
            }
            var response = new PlaceResponseModel
            {
                Id = id,
                Name = "removed",
            };
            return response;
        }

        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<PlaceResponseModel> UpdatePlace(PlaceRequestModel requestModel)
        {
            var dbPlace = await _repository.GetByIdAsync(requestModel.Id);
            if (dbPlace != null)
            {
                dbPlace.Name = requestModel.Name;
                var updatedPlace = await _repository.UpdateAsync(dbPlace);
                var responseSucc = new PlaceResponseModel
                {
                    Id = updatedPlace.Id,
                    Name = updatedPlace.Name,
                };
                return responseSucc;
            }
            var response = new PlaceResponseModel
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
            };
            return response;

        }

        
    }
}
