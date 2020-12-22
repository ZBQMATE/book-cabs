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
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;

        public CabTypeController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListInfo()
        {
            var items = await _cabTypeService.GetAllCabTypes();
            return items is null ? BadRequest(new { message = "No item found" }) : Ok(items);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddItem(CabTypeRequestModel cabTypeRequestModel)
        {
            var items = await _cabTypeService.CreateCabType(cabTypeRequestModel);
            return items is null ? BadRequest(new { message = "Adding Failed" }) : Ok(items);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var items = await _cabTypeService.DeleteCabType(id);
            return items is null ? BadRequest(new { message = "delete Failed" }) : Ok(items);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateItem(CabTypeRequestModel cabTypeRequestModel)
        {
            var items = await _cabTypeService.UpdateCabType(cabTypeRequestModel);
            return items is null ? BadRequest(new { message = "Update Failed" }) : Ok(items);
        }

    }
}
