using CabBooking.Core.Entities;
using CabBooking.Core.Models.Request;
using CabBooking.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<PlaceResponseModel> CreatePlace(PlaceRequestModel requestModel);
        Task<PlaceResponseModel> DeletePlace(int id);
        Task<IEnumerable<Place>> GetAllPlaces();
        Task<PlaceResponseModel> UpdatePlace(PlaceRequestModel requestModel);
    }
}
