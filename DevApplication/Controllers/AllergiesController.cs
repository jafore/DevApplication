using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public AllergiesController(IUnitOfWork context)
        {
            _context = context;
        }

      
        [HttpGet]
        public IEnumerable<Allergy> GetAllergies()
        {
            return  _context.Allergies.GetAll();
        }

     
        [HttpGet("{id}")]
        public Allergy GetAllergy(int id)
        {
            var allergy =  _context.Allergies.FirstOrDefault(x=>x.Id==id);
            return allergy;
        }

 
        [HttpPut("{id}")]
        public  IActionResult PutAllergy(int id, Allergy allergy)
        {

             _context.Allergies.Update(allergy);

          
            _context.Save();


            return NoContent();
        }

      
        [HttpPost]
        public  ActionResult<Allergy> PostAllergy(Allergy allergy)
        {
             _context.Allergies.Add(allergy);
             _context.Save();

            return CreatedAtAction("GetAllergy", new { id = allergy.Id }, allergy);
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteAllergy(int id)
        {
           var allergy = _context.Allergies.FirstOrDefault(x => x.Id == id);

            _context.Allergies.Remove(allergy);
            _context.Save();

            return NoContent();
        }

    }
}
