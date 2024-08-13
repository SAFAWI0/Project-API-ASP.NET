using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.DTOs;
using project.Models;


namespace project.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserControllers : Controller
{
    private readonly ApplicationDbContext _context;

    public UserControllers(ApplicationDbContext context) 
    {
        _context = context;
    }


    // GetTest
    [HttpGet]
    [Route ("gettest")]
    public IActionResult GetTest() 
    { 
        return Ok("Hi Safaa");
    }



    
    // Get
    [HttpGet]
    [Route("getalluser")]
    public IActionResult GetAllUser()
    {
        var  AllUsers = _context.Users.ToList();
        if (AllUsers == null)
        {
            return NotFound("No User Founded !");
        }
        return Ok(AllUsers);
    }


    // GetById
    [HttpGet]
    [Route("getuserbyid")]
    public IActionResult GetUserById([FromQuery] int id)
    {
        var  user = _context.Users.FirstOrDefault (el => el.Id == id);
        if (user == null)
        {
            return NotFound("User No Founded !");
        }
        return Ok(user);
    }



    // post
    [HttpPost]
    [Route("addusers")]
    public IActionResult AddUsers ([FromBody]UserDTO userDTO)
    {
        var user = new User
        {
            Name = userDTO.Name,
            Email = userDTO.Email,
            Password = userDTO.Password,
        };
        _context.Users.Add(user);   
        _context.SaveChanges();
        var result = new
        {
            Message= "User Created Succesfully !",
            Users = user,
        };
        return Ok(result);
    }




    // delete
    [HttpDelete]
    [Route("deleteusers")]
    public IActionResult DeleteUsers(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid user ID.");
        }
        var user = _context.Users.FirstOrDefault(el => el.Id == id);
        if (user == null)
        {
            return NotFound("User with the given ID does not exist.");
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        var result = new
        {
            Message = "User Deleted Succesfully",
            Users = user,
        };
        return Ok(result);
    }




    // put
    [HttpPut]
    [Route("upateusers")]
    public IActionResult UpateUsers(int id, UserDTO userDTO)
    {
        var user = _context.Users.FirstOrDefault(el => el.Id == id);

        user.Name = userDTO.Name;
        user.Email = userDTO.Email;
        user.Password = userDTO.Password;

        _context.Users.Update(user);
        _context.SaveChanges();
        var result = new
        {
            Message = "User Update Succesfully !",
            Users = user,
        };
        return Ok(result);
    }
}
