using Microsoft.AspNetCore.Mvc;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NcddetailsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public NcddetailsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Ncddetails
        [HttpGet]
        public  IEnumerable<NcdDetail> GetNcdDetails(int? id)
        {
            if (id!=null)
            {
                return  _context.NcdDetails.GetAll(x=>x.PatientId==id);

            }
            return  _context.NcdDetails.GetAll();
        }



        [HttpGet("NcdDetailsName")]
        public IEnumerable<NcdDetailView> NcdDetailsName(int? id)
        {

            List<NcdDetailView> ncdDetailView = new List<NcdDetailView>();

            var data = _context.NcdDetails.GetAll(x => x.PatientId == id);

            foreach (var a in data)
            {
                var ncdView = new NcdDetailView()
                {
                    Id = a.Id,
                    Patient = _context.Patient.FirstOrDefault(x => x.Id == a.PatientId).Name,
                    Ncd = _context.Ncds.FirstOrDefault(x => x.Id == a.Ncdid)?.Name,

                };
                ncdDetailView.Add(ncdView);
            }


            return ncdDetailView;
        }




        [HttpGet("{id}")]
        public  NcdDetail GetNcddetail(int id)
        {
            var ncddetail =  _context.NcdDetails.FirstOrDefault(x=>x.Id==id);
            return ncddetail;
        }


       

        [HttpPut("{id}")]
        public  IActionResult PutNcddetail(int id, NcdDetail ncddetail)
        {


            _context.NcdDetails.Update(ncddetail); 
            _context.Save();
            return NoContent();
        }

        [HttpPost]
        public ActionResult<NcdDetail> PostNcddetail(NcdDetail ncddetail)
        {
            _context.NcdDetails.Add(ncddetail);
             _context.Save();

            return CreatedAtAction("GetNcddetail", new { id = ncddetail.Id }, ncddetail);
        }

     
        [HttpDelete("{id}")]
        public IActionResult DeleteNcddetail(int id)
        {
            var ncddetail =  _context.NcdDetails.FirstOrDefault(x=>x.Id==id);
            _context.NcdDetails.Remove(ncddetail);
             _context.Save();

            return NoContent();
        }

   
    }
}
