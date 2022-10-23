using Data.ModelsClass;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamsController : ControllerBase
    {
        IRepositories<Sanpham> _repository;
        public SanphamsController(IRepositories<Sanpham> repositories)
        {
            _repository = repositories;
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
        [HttpGet("{id}")] // chưa động tới
        public string Get(int id)
        {
            return "value";
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
        [HttpPut]
        [Route("update-sanpham")]
        public async Task<IActionResult> Put(Sanpham sp)
        {
            await _repository.UpdateOneAsyn(sp);
            return Ok("Updated Successfully");
        }
        // DELETE api/<SanphamsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Sanpham sp)
        {
            var result = await _repository.DeleteOneAsyn(sp);
            return null;
        }
    }
}
