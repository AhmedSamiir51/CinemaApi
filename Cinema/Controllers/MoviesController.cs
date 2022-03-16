using Cinema.Images;
using Cinema.Models.Date;
using Cinema.Models.ViewModel;
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
            var data = _unitOfWork.Movies.GetListOfMovies();

            return Ok(data ) ;
        }


        [HttpGet("AllGetListOfMovies")]
        public ActionResult<IEnumerable<Movies>> AllGetListOfMovies()
        {
            var data = _unitOfWork.Movies.AllGetListOfMovies();

            return Ok(data);
        }





        [HttpGet("GetHallIdFromMovies/{id}")]
        public ActionResult<IEnumerable<Hall>> GetHallIdFromMovies(int id)
        {
            var data = _unitOfWork.Movies.GetHallIdFromMovies(id);

            return Ok(data);
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

            return Ok(true);
        }

        // POST: api/Movies
        [HttpPost("SaveMovies")]
        public  ActionResult<Movies> SaveMovies([FromForm] MoviesModel model)
        {
            try
            {

                var movies = new Movies() {
                    Description=model.Description,
                    IdHalls=model.IdHalls,
                    Name=model.Name,
                    IsVisibale=model.IsVisibale,
                    PhotoData = model.PhotoData,
                    TraileUrl = model.TraileUrl,
                    ProfilePicture = model.ProfilePicture,
                };


              var mm=  _unitOfWork.Movies.Add(movies);
                _unitOfWork.Complete();

                if (model.ProfilePicture != null)
                {
                    string[] photoName = model.ProfilePicture.FileName.Split('.');
                    var imageName = $"{mm.Id}.{photoName[photoName.Length - 1]}";
                    string uploaded = Path.Combine("Images");
                    string filpath = Path.Combine(uploaded, imageName);

                    var filePath = $"~Images \\{imageName}";
                    var profilePic = ImageStuff.HandleImage(model.ProfilePicture);

                    using var imageMemory = new MemoryStream();
                    profilePic.Write(imageName);
                    System.IO.File.Move(imageName, filpath);
                    mm.PhotoData = filpath;
                }
                _unitOfWork.Complete();

                return Ok(true);

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
