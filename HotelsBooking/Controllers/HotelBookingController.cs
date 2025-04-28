using HotelsBooking.Data;
using HotelsBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelsBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public JsonResult GetAll()
        {
            return new JsonResult(Ok(_context.Bookings.ToList()));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);

            return result == null
                ? new JsonResult(NotFound())
                : new JsonResult(Ok(result));
        }

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDB = _context.Bookings.Find(booking.Id);

                if (bookingInDB == null) return new JsonResult(NotFound());

                bookingInDB = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null) return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }
}
