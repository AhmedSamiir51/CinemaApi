using Cinema.Models.Date;
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
    public class HallsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HallsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/GetTimes 
        [HttpGet("GetAll")]
        public ActionResult<Hall> GetAll()
        {
            var Halls = _unitOfWork.Halls.GetAll();

            if (Halls == null)
            {
                return NotFound();
            }

            return Ok(Halls);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Hall> GetById(int id)
        {
            var Halls = _unitOfWork.Halls.GetById(id);

            if (Halls == null)
            {
                return NotFound();
            }

            return Halls;
        }
 
       



        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, Hall Halls)
        {
            if (id != Halls.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Halls.Update(Halls);
            _unitOfWork.Complete();

            return Ok("Updated");
        }

        // POST: api/Movies
        [HttpPost]
        public ActionResult<Hall> Post(Hall Halls)
        {
            _unitOfWork.Halls.Add(Halls);
            _unitOfWork.Complete();

            return Ok(Halls);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Halls = _unitOfWork.Halls.GetById(id);
            if (Halls == null)
            {
                return NotFound();
            }

            _unitOfWork.Halls.Delete(Halls);
            _unitOfWork.Complete();

            return Ok( Halls  );
        }
    }
}
