using Microsoft.EntityFrameworkCore;
using PetBookingApi.Models;

namespace PetBookingApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<PetBooking> PetBooking { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
