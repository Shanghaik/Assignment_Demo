using Data.DbContexts;
using Data.ModelsClass;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SanphamsController : ControllerBase
    {
        IRepositories<Sanpham> _repository;
        CuahangDbContext _dbContext;
        public SanphamsController(IRepositories<Sanpham> repositories, CuahangDbContext dbContext)
        {
            _repository = repositories;
            _dbContext = dbContext;
        }
        // GET: api/<SanphamsController>
        [HttpGet]
        [Route("get-all-sanpham")]
        public async Task<IActionResult> Get() // Get all không fake
        {
            var sanphamList = new List<Sanpham>();
            sanphamList = (List<Sanpham>)await _repository.GetAllAsync(); // Gọi từ DB
            return Ok(sanphamList); 
        }

        // GET api/<SanphamsController>/5
        [HttpGet("get-{id}")] // chưa động tới
        public Task<Sanpham> Get(Guid id)
        {
            return _repository.GetAsync(id);
        }

        // POST api/<SanphamsController>
        [HttpPost]
        [Route("create")] // Post để thêm
        public async Task<IActionResult> Post(Sanpham sp)
        {
            sp.Id = Guid.NewGuid();
            var result = await _repository.AddOneAsyn(sp);
            if (result.Id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }else
            return Ok("Added Successfully");
        }

        // PUT api/<SanphamsController>/5
        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateSanPham([FromBody] Sanpham sp)
        {
            var result = _dbContext.Sanphams.FirstOrDefault(x => x.Id == sp.Id);
            result.Ten = sp.Ten;
            result.Soluong = sp.Soluong;
            result.Gia = sp.Gia;
            result.Trangthai = sp.Trangthai;
            await _dbContext.SaveChangesAsync();
            return Ok("Updated Successfully");
        }
        // DELETE api/<SanphamsController>/5
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Sanpham sp = _dbContext.Sanphams.FirstOrDefault(x => x.Id == id);
            //_dbContext.Entry(sp).State = EntityState.Deleted; 

            _dbContext.Remove(sp);
            _dbContext.SaveChangesAsync();
            return Ok("Delete Successfully");
        }
    }
}
