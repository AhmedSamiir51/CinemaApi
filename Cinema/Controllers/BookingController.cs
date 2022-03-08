using Cinema.Models.Date;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(_unitOfWork.Booking.GetAll());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Booking> GetById(int id)
        {
            var Booking = _unitOfWork.Booking.GetById(id);

            if (Booking == null)
            {
                return NotFound();
            }

            return Booking;
        }




        // GET: api/GetTimes 
        [HttpGet("GetTimes")]
        public ActionResult<Times> GetTimes()
        {
            var Times = _unitOfWork.Times.GetAll();

            if (Times == null)
            {
                return NotFound();
            }

            return Ok(Times);
        }




        // GET: api/GetTimes 
        [HttpGet("GetHalls")]
        public ActionResult<Hall> GetHalls()
        {
            var Halls = _unitOfWork.Halls.GetAll();

            if (Halls == null)
            {
                return NotFound();
            }

            return Ok(Halls);
        }



        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, Booking movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Booking.Update(movies);
            _unitOfWork.Complete();

            return Ok("Updated");
        }

        // POST: api/Movies
        [HttpPost]
        public ActionResult<Booking> Post(Booking movies)
        {
            _unitOfWork.Booking.Add(movies);
            _unitOfWork.Complete();

            return CreatedAtAction("GetMovies", new { id = movies.Id }, movies);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Booking = _unitOfWork.Booking.GetById(id);
            if (Booking == null)
            {
                return NotFound();
            }

            _unitOfWork.Booking.Delete(Booking);
            _unitOfWork.Complete();

            return Ok(new { data = "Deleted", Booking });
        }
    }
}
