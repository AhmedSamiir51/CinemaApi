using Cinema.Models.Date;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryPatternWithUOW.Core;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                    RoleId=1
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

        [HttpPost("SendEmail")]
        public ActionResult  SendEmail(MailSender Email)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("FromMailAddress");
                message.To.Add(new MailAddress(Email.ToMailAddress));
                message.Subject = Email.Name;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = Email.Message;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                return Ok( );
            }
            catch (Exception e)
            {
                return Content($"{e.Message}");
            }


        }
    }
}
