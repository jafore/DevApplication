using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevApplication.Connection;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;
using Microsoft.AspNetCore.Cors;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[DisableCors]
    public class DiseaseInformationController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public DiseaseInformationController(IUnitOfWork context)
        {
            _context = context;
        }

     
        [HttpGet]
        public  IEnumerable<DiseaseInformation> GetDiseaseInformation()
        {
            return  _context.DiseaseInformation.GetAll();
        }

        // GET: api/DiseaseInformation/5
        [HttpGet("{id}")]
        public ActionResult<DiseaseInformation> GetDiseaseInformation(int id)
        {
            var diseaseInformation = _context.DiseaseInformation.FirstOrDefault(x=>x.Id==id);

            if (diseaseInformation == null)
            {
                return NotFound();
            }

            return diseaseInformation;
        }

        // PUT: api/DiseaseInformation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutDiseaseInformation(int id, DiseaseInformation diseaseInformation)
        {
            if (id != diseaseInformation.Id)
            {
                return BadRequest();
            }

            _context.DiseaseInformation.Update(diseaseInformation);
            _context.Save();
            
            return NoContent();
        }

        [HttpPost]
        public ActionResult<DiseaseInformation> PostDiseaseInformation(DiseaseInformation diseaseInformation)
        {
            _context.DiseaseInformation.Add(diseaseInformation);
             _context.Save();

            return CreatedAtAction("GetDiseaseInformation", new { id = diseaseInformation.Id }, diseaseInformation);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiseaseInformation(int id)
        {
            var diseaseInformation =  _context.DiseaseInformation.FirstOrDefault(x=>x.Id==id);
            if (diseaseInformation == null)
            {
                return NotFound();
            }

            _context.DiseaseInformation.Remove(diseaseInformation); 
            _context.Save();

            return NoContent();
        }

    }
}
