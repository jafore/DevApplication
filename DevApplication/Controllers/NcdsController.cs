using Microsoft.AspNetCore.Mvc;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NcdsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public NcdsController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Ncd> GetNcds()
        {
            return  _context.Ncds.GetAll();
        }

   
        [HttpGet("{id}")]
        public async Task<ActionResult<Ncd>> GetNcd(int id)
        {
            var ncd =  _context.Ncds.FirstOrDefault(x=>x.Id==id);
            return ncd;
        }

        [HttpPut("{id}")]
        public  IActionResult PutNcd(int id, Ncd ncd)
        {
            if (id != ncd.Id)
            {
                return BadRequest();
            }

            _context.Ncds.Update(ncd);

                 _context.Save();
           

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Ncd> PostNcd(Ncd ncd)
        {
            _context.Ncds.Add(ncd);
            _context.Save();

            return CreatedAtAction("GetNcd", new { id = ncd.Id }, ncd);
        }

        // DELETE: api/Ncds/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteNcd(int id)
        {
            var ncd =  _context.Ncds.FirstOrDefault(x=>x.Id==id);
            _context.Ncds.Remove(ncd);
            _context.Save();

            return NoContent();
        }

       
    }
}
