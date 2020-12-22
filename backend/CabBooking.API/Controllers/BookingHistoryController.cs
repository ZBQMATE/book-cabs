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
    public class BookingHistoryController : ControllerBase
    {
        private readonly IBookingHistoryService _bookingService;

        public BookingHistoryController(IBookingHistoryService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListInfo()
        {
            var items = await _bookingService.GetAllBookingHistories();
            return items is null ? BadRequest(new { message = "No item found" }) : Ok(items);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddItem(BookingHistoryRequestModel bookingRequestModel)
        {
            var items = await _bookingService.CreateBookingHistory(bookingRequestModel);
            return items is null ? BadRequest(new { message = "Adding Failed" }) : Ok(items);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var items = await _bookingService.DeleteBookingHistory(id);
            return items is null ? BadRequest(new { message = "delete Failed" }) : Ok(items);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateItem(BookingHistoryRequestModel bookingRequestModel)
        {
            var items = await _bookingService.UpdateBookingHistory(bookingRequestModel);
            return items is null ? BadRequest(new { message = "Update Failed" }) : Ok(items);
        }

    }
}
