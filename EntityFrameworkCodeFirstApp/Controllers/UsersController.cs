using EntityFrameworkCodeFirstApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext userContext;

        public UsersController(UserContext userContext)
        {
            this.userContext = userContext;
            
        }


        [HttpGet]          // to get all users
        [Route("Getusers")]
        public List <Users> GetUsers()
        {
            return userContext.Users.ToList();
        }

        [HttpGet]              // to find a single user
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return userContext.Users.Where(x=> x.ID == id).FirstOrDefault();
        }
        [HttpPost]                        // to add new user
        [Route("AddUsers")]
        public string AddUser(Users users)
        {
            string response = string.Empty;
            userContext.Users.Add(users);
            userContext.SaveChanges();
            return "User added";
        }

        [HttpPut] // To update an existing record
        [Route("UpdateUser")]
        public string UpdateUser(Users user)
        {
            userContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified; // Mark the entity as modified
            userContext.SaveChanges(); // Save changes to persist the update
            return "User Updated";
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(int id)
        {
            Users user = userContext.Users.Where(x => x.ID == id).FirstOrDefault(); // Retrieve user by ID
            if (user != null) // Check the local variable 'user'
            {
                userContext.Users.Remove(user);
                userContext.SaveChanges(); // Persist the changes
                return "User Deleted";
            }
            else
            {
                return "No user found"; // Execute this if no user is found
            }
        }
    }
    }
