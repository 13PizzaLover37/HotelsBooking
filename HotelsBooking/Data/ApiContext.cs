using Microsoft.EntityFrameworkCore;
using HotelsBooking.Models;

namespace HotelsBooking.Data
{
    public class ApiContext :DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options) { }
    }
}
