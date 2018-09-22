using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public UsersController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Users/5
        [HttpGet("{UserId}")]
        public ActionResult<Users> Get(string UserId)
        {
            var users = _repoWrapper.Users.FindByID(UserId);
            if (users == null) return NotFound("Not found");
            return users;
        }

        [Route("[action]")]
        [HttpPost]
        public void RegisterUser([FromBody] Users user)
        {
            user.registred = 1;
            _repoWrapper.Users.Create(user);
        }

        // PUT: api/Users/5
        [Route("[action]/{OldUserid}")]
        [HttpPut("{OldUserid}")]
        public ActionResult<string> UpdateUser(string OldUserid, [FromBody] Users user)
        {
            if (OldUserid == user.UserId)
            {
                _repoWrapper.Users.Update(user);
                return Ok("Ok");
            }
            else
            {
                return Ok("Old UserId doesn't match UserId");
            }
        }

        [Route("[action]/{UserID}")]
        [HttpGet]
        public void UnRegisterUser(string UserId)
        {
            _repoWrapper.Users.UnRegisterUser(UserId);
        }

    }
}