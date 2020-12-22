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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("CabBooking/{id}")]
        public async Task<IActionResult> GetBookingListInfo(int id)
        {
            var items = await _bookingService.CabTypeBooking(id);
            return items is null ? BadRequest(new { message = "No item found" }) : Ok(items);
        }


        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListInfo()
        {
            var items = await _bookingService.GetAllBookings();
            return items is null ? BadRequest(new { message = "No item found" }) : Ok(items);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddItem(BookingRequestModel bookingRequestModel)
        {
            var items = await _bookingService.CreateBooking(bookingRequestModel);
            return items is null ? BadRequest(new { message = "Adding Failed" }) : Ok(items);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var items = await _bookingService.DeleteBooking(id);
            return items is null ? BadRequest(new { message = "delete Failed" }) : Ok(items);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateItem(BookingRequestModel bookingRequestModel)
        {
            var items = await _bookingService.UpdateBooking(bookingRequestModel);
            return items is null ? BadRequest(new { message = "Update Failed" }) : Ok(items);
        }

    }
}
