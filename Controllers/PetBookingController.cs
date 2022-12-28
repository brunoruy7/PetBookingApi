using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetBookingApi.Models;
using PetBookingApi.Data;
using System.Security.Cryptography.X509Certificates;

namespace PetBookingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PetBookingController : ControllerBase
    {
        private readonly ApiContext _context;
        public PetBookingController(ApiContext context) 
        {
            _context = context;
        }
        // Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(PetBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.PetBooking.Add(booking);
            } else
            {
                var bookinginDb = _context.PetBooking.Find(booking.Id);

                if (bookinginDb == null) { return new JsonResult(NotFound()); }

                bookinginDb = booking;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        //Get
        [HttpGet]
        public JsonResult GetBooking(int id) 
        {
            var result = _context.PetBooking.Find(id);
            if (result == null) 
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete] 
        public JsonResult Delete(int id) 
        {
            var result = _context.PetBooking.Find(id);
            
            if(result == null)
            { return new JsonResult(NotFound()); }
            
            _context.PetBooking.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //GetAll
        [HttpGet]
        public JsonResult GetAll() 
        {
            var result = _context.PetBooking.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
