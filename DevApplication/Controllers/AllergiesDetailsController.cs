using Microsoft.AspNetCore.Mvc;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public AllergiesDetailsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/AllergiesDetails
        [HttpGet]
        public IEnumerable<AllergiesDetail> GetAllergiesDetails(int? id)
        {
            if (id != null)
            {
                return _context.AllergyDetails.GetAll(x=>x.PatienId==id);
            }


            return _context.AllergyDetails.GetAll();
        }


        [HttpGet("AllergiesDetailName")]
        public IEnumerable<AllergiesDetailView>GetAllergies(int? id)
        {
         
                List<AllergiesDetailView> allergiesDetailViews = new List<AllergiesDetailView>();

                var data = _context.AllergyDetails.GetAll(x => x.PatienId == id);

                foreach (var a in data)
                {
                    var allergiesView = new AllergiesDetailView()
                    {
                        Id = a.Id,
                        Patient = _context.Patient.FirstOrDefault(x => x.Id == a.PatienId).Name,
                        Allergies = _context.Allergies.FirstOrDefault(x => x.Id == a.AllergiesId)?.Name,

                    };
                    allergiesDetailViews.Add(allergiesView);
                }
         

                return allergiesDetailViews;
        }


        [HttpGet("{id}")]
        public  ActionResult<AllergiesDetail> GetAllergiesDetail(int id)
        {
            var allergiesDetail =  _context.AllergyDetails.FirstOrDefault(x=>x.Id==id);
            return allergiesDetail;
        }

  
        [HttpPut("{id}")]
        public  IActionResult PutAllergiesDetail(int id, AllergiesDetail allergiesDetail)
        {
         
            _context.AllergyDetails.Update(allergiesDetail);
            _context.Save();
            return NoContent();
        }

    
        [HttpPost]
        public  ActionResult<AllergiesDetail> PostAllergiesDetail(AllergiesDetail allergiesDetail)
        {
            _context.AllergyDetails.Add(allergiesDetail);
             _context.Save();
            return CreatedAtAction("GetAllergiesDetail", new { id = allergiesDetail.Id }, allergiesDetail);
        }

 
        [HttpDelete("{id}")]
        public  IActionResult DeleteAllergiesDetail(int id)
        {
            var allergiesDetail =  _context.AllergyDetails.FirstOrDefault(x=>x.Id==id);
        

            _context.AllergyDetails.Remove(allergiesDetail);
            _context.Save();

            return NoContent();
        }

     
    }
}
