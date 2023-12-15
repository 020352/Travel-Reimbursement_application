using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apiapp.Models;

namespace Apiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly TodoContext _context;

        public RatingsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<IEnumerable<Ratings>> GetTodoItems()
        {
           var listofitems=_context.TodoItems.ToList();
           return listofitems;
        }

      [HttpPost]
      public async Task<bool> PutTodoItems(Ratings ratings)
      {
        // Console.WriteLine(ratings.feedback);
        // Console.WriteLine(ratings.scores);
        // Console.WriteLine(ratings.EmployeeID);
        _context.TodoItems.Add(ratings);
        _context.SaveChanges();
        return true;
      }

    }
}
