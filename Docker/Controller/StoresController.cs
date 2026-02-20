using DockerDemo.Data;
using DockerDemo.Docker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Docker.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStudents()
        {
            return await _context.Stores.ToListAsync();
        }
    }
}

