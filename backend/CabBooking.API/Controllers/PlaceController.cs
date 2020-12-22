
using CabBooking.Core.Models.Request;
using CabBooking.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListInfo()
        {
            var items = await _placeService.GetAllPlaces();
            return items is null ? BadRequest(new { message = "No item found" }) : Ok(items);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddItem(PlaceRequestModel placeRequestModel)
        {
            var items = await _placeService.CreatePlace(placeRequestModel);
            return items is null ? BadRequest(new { message = "Adding Failed" }) : Ok(items);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var items = await _placeService.DeletePlace(id);
            return items is null ? BadRequest(new { message = "delete Failed" }) : Ok(items);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateItem(PlaceRequestModel placeRequestModel)
        {
            var items = await _placeService.UpdatePlace(placeRequestModel);
            return items is null ? BadRequest(new { message = "Update Failed" }) : Ok(items);
        }

    }
}
