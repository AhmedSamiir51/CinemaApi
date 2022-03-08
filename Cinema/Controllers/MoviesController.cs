using Cinema.Images;
using Cinema.Models.Date;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
 
namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> GetAll()
        {
            var data = _unitOfWork.Movies.GetAll();
            return Ok(data.Take(3)) ;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Movies> GetById(int id)
        {
            var movies =  _unitOfWork.Movies.GetById(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, Movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Movies.Update(movies);
            _unitOfWork.Complete();

            return Ok("Updated");
        }

        // POST: api/Movies
        [HttpPost("SaveMovies")]
        public  ActionResult<Movies> SaveMovies([FromForm]  Movies movies)
        {
            try
            {
                _unitOfWork.Movies.Add(movies);
                _unitOfWork.Complete();

                if (movies.ProfilePicture != null)
                {
                    string[] photoName = movies.ProfilePicture.FileName.Split('.');
                    var imageName = $"{movies.Id}.{photoName[photoName.Length - 1]}";
                    string uploaded = Path.Combine("Images");
                    string filpath = Path.Combine(uploaded, imageName);

                    var filePath = $"~Images \\{imageName}";
                    var profilePic = ImageStuff.HandleImage(movies.ProfilePicture);

                    using var imageMemory = new MemoryStream();
                    profilePic.Write(imageName);
                    System.IO.File.Move(imageName, filpath);
                    movies.PhotoData = filpath;
                }
                _unitOfWork.Complete();

                return Ok( movies);

            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movies = _unitOfWork.Movies.GetById(id);
            if (movies == null)
            {
                return NotFound();
            }

            _unitOfWork.Movies.Delete(movies);
            _unitOfWork.Complete();

            return Ok(new {data= "Deleted", movies });
        }

    }
}
