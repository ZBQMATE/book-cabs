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
    public class CabTypeService : ICabTypeService
    {
        private readonly IAsyncRepository<CabType> _repository;

        public CabTypeService(IAsyncRepository<CabType> repository)
        {
            _repository = repository;
        }

        public async Task<CabTypeResponseModel> CreateCabType(CabTypeRequestModel requestModel)
        {
            var cabType = new CabType
            {
                Name = requestModel.Name,
            };
            var createdCabType = await _repository.AddAsync(cabType);
            var response = new CabTypeResponseModel
            {
                Id = createdCabType.Id,
                Name = createdCabType.Name,
            };
            return response;
        }

        public async Task<CabTypeResponseModel> DeleteCabType(int id)
        {
            var dbCabType = await _repository.GetByIdAsync(id);
            if (dbCabType != null)
            {
                await _repository.DeleteAsync(dbCabType);
                var responseSucc = new CabTypeResponseModel
                {
                    Id = dbCabType.Id,
                    Name = dbCabType.Name,
                };
                return responseSucc;
            }
            var response = new CabTypeResponseModel
            {
                Id = id,
                Name = "remove",
            };
            return response;
        }

        public async Task<IEnumerable<CabType>> GetAllCabTypes()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<CabTypeResponseModel> UpdateCabType(CabTypeRequestModel requestModel)
        {
            var dbCabType = await _repository.GetByIdAsync(requestModel.Id);
            if (dbCabType != null)
            {
                dbCabType.Name = requestModel.Name;
                var updatedCabType = await _repository.UpdateAsync(dbCabType);
                var responseSucc = new CabTypeResponseModel
                {
                    Id = updatedCabType.Id,
                    Name = updatedCabType.Name,
                };
                return responseSucc;
            }
            var response = new CabTypeResponseModel
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
            };
            return response;
        }
    }
}
