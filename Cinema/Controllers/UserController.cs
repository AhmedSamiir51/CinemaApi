using Cinema.Models.Date;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var data = _unitOfWork.User.GetAll();
            return Ok(data);
        }


        [HttpPost("Login")]

        //POST : /api/Users/Login
        public  IActionResult  Login(AppLoginModel model)
        {
            var user = _unitOfWork.User.Login(model);

            if (user != null)
            {
                return Ok(user);
            }
            else
                return BadRequest();
        }


        [HttpPost("Register")]
        public ActionResult<User> Register(  RegisterModel model)
       {
            try
            {
                var data = new User
                {
                    FristName = model.FristName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    RoleId = 2
                };

              var user = _unitOfWork.User.Add(data);
                _unitOfWork.Complete();

                return Ok(user);
            }
            catch (Exception e)
            {
                return Content($"{e.Message}");
            }


        }



        [HttpPost("RegisterForAdmin")]
        public ActionResult<User> RegisterForAdmin(RegisterModel model)
        {
            try
            {
                var data = new User
                {
                    FristName = model.FristName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    RoleId=model.RolesId
                };

                var user = _unitOfWork.User.Add(data);
                _unitOfWork.Complete();

                return Ok(user);
            }
            catch (Exception e)
            {
                return Content($"{e.Message}");
            }


        }


    }
}
