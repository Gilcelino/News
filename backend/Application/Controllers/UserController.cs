using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Validators;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IBaseService<User> _baseUserService;

        public UserController(IBaseService<User> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            return Execute(() => _baseUserService.Insert<UserValidator>(user));
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            
            return Execute(() => _baseUserService.Update<UserValidator>(user)); 
        }

        [HttpDelete("{id}")]
        private IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Execute (() => {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult GetAll() => Execute(() => _baseUserService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            return Execute(() => _baseUserService.GetById(id));

        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}