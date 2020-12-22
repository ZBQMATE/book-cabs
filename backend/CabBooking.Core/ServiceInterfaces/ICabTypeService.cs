using CabBooking.Core.Entities;
using CabBooking.Core.Models.Request;
using CabBooking.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface ICabTypeService
    {
        Task<CabTypeResponseModel> CreateCabType(CabTypeRequestModel requestModel);
        Task<CabTypeResponseModel> DeleteCabType(int id);
        Task<IEnumerable<CabType>> GetAllCabTypes();
        Task<CabTypeResponseModel> UpdateCabType(CabTypeRequestModel requestModel);
    }
}
