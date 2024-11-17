using Microsoft.AspNetCore.Mvc;
using service;
using System.Text.Json;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        //GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { " ", " " };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id) { 

        User foundUser = userService.GetUserById(id);
        if (foundUser == null)
            return  NoContent();
        else 

        return Ok(foundUser);

        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            User newUser = userService.AddUser(user);
    return newUser != null ? Ok(newUser) : Unauthorized();
        }

        [HttpPost("password")]
        public IActionResult CheckPassword([FromBody] string password)
        {

          int Score = userService.CheckPassword(password);
     
          return  (Score < 3)?
                 BadRequest(Score):
            Ok(Score);
        }


        [HttpPost("login")]
        public ActionResult<User> LogIn([FromQuery] string userName, string password)
        {
            User userLogin = userService.LogIn(userName, password);
            if (userLogin == null)
                return NoContent();
            else
            return Ok(userLogin);
         
           
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {
            return (userService.UpdateUser(id, userToUpdate) == 0) ?  Unauthorized() :NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
