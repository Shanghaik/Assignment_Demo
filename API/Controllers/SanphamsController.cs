using Data.ModelsClass;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            List<Sanpham> sanphamList = new List<Sanpham>()
            {
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = false },
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = true },
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = true },
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = true },
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = false },
                new Sanpham(){Id = Guid.NewGuid(), Ten = "ABC", Gia = 1000, Soluong = 100, Trangthai = false }
            };
            return Ok(sanphamList);
        }

        // GET api/<SanphamsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SanphamsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SanphamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SanphamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
