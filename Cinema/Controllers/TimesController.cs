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
    public class TimesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/GetTimes 
        [HttpGet("GetAll")]
        public ActionResult<Times> GetAll()
        {
            var Times = _unitOfWork.Times.GetAll();

            if (Times == null)
            {
                return NotFound();
            }

            return Ok(Times);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Times> GetById(int id)
        {
            var Times = _unitOfWork.Times.GetById(id);

            if (Times == null)
            {
                return NotFound();
            }

            return Times;
        }





        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, Times Times)
        {
            if (id != Times.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Times.Update(Times);
            _unitOfWork.Complete();

            return Ok("Updated");
        }

        // POST: api/Movies
        [HttpPost]
        public ActionResult<Times> Post(Times Times)
        {
            _unitOfWork.Times.Add(Times);
            _unitOfWork.Complete();

            return Ok(Times);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Times = _unitOfWork.Times.GetById(id);
            if (Times == null)
            {
                return NotFound();
            }

            _unitOfWork.Times.Delete(Times);
            _unitOfWork.Complete();

            return Ok(Times);
        }
    }
}
 