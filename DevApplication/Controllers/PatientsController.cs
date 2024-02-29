using DevApplication.Connection;
using DevApplication.Models;
using DevApplication.Models.EntityModel;
using DevApplication.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DevApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public PatientsController(IUnitOfWork context)
        {
            _context = context;
        }




        [HttpPost("SaveDataForPatient")]
        public ActionResult<PatientSave> SaveData(PatientSave patientSave)
        {


            var pateint= new Patient();
            pateint.Name = patientSave.Name[0];
            pateint.DiseasesId = patientSave.Disease[0];
            bool epilepsy= patientSave.Epilepsy[0]!= 0;

            pateint.Epilepsy = epilepsy;
             _context.Patient.Add(pateint);
             _context.Save();

         

            if (patientSave.Allergies != null)
            {
               

                foreach (var allergydata in patientSave.Allergies)
                {
                    var allergy = new AllergiesDetail
                    {
                        PatienId = pateint.Id,
                        AllergiesId = allergydata
                    };
                    _context.AllergyDetails.Add(allergy);
                   
                }
                _context.Save();

            }


            if (patientSave.NCDs != null)
            {
               
                foreach (var ncDdata in patientSave.NCDs)
                {
                    var Ncd = new NcdDetail();
                    Ncd.PatientId = pateint.Id;
                    Ncd.Ncdid = ncDdata;
                    _context.NcdDetails.Add(Ncd);
                   
                }

                _context.Save();
            }
            
           
            return patientSave;
        }


        [HttpGet("GetPatients")]
        public IEnumerable<Patient> GetPatients()
        {
            var patients = _context.Patient.GetAll();

            return patients;
        }


        [HttpGet("GetPatients2")]
        public IEnumerable<PatientView> GetPatients2()
        {

            List<PatientView> patientViews = new List<PatientView>();

            var patients = _context.Patient.GetAll();

            foreach (var a in patients)
            {
                var patientView = new PatientView()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Diseases = _context.DiseaseInformation.FirstOrDefault(x => x.Id == a.DiseasesId)?.Name,
                    Epilepsy = a.Epilepsy
                };

                patientViews.Add(patientView);
            }





            return patientViews;
        }

      
        [HttpGet("{id}")]
        public PatientView GetPatient(int id)
        {
            var patientView = new PatientView();
            var patient = _context.Patient.FirstOrDefault(x=>x.Id==id);
            patientView.Id=patient.Id;
            patientView.Name=patient.Name;
            patientView.Diseases = _context.DiseaseInformation.FirstOrDefault(x => x.Id == patient.DiseasesId)?.Name;
            patientView.Epilepsy=patient.Epilepsy;

            return patientView;
        }

    
        [HttpPut("{id}")]
        public void PutPatient(int id, Patient patient)
        {
       

            _context.Patient.Update(patient);
            _context.Save();

        }

        [HttpPost]
        public ActionResult<Patient> PostPatient(Patient patient)
        {
            _context.Patient.Add(patient); 
            _context.Save();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient =  _context.Patient.FirstOrDefault(x=>x.Id==id);
          

            _context.Patient.Remove(patient);

            var ncdDetails = _context.NcdDetails.GetAll(z => z.PatientId == id);
            _context.NcdDetails.RemoveRange(ncdDetails);

            var allergyDetails = _context.AllergyDetails.GetAll(z => z.PatienId == id);
            _context.AllergyDetails.RemoveRange(allergyDetails);
            _context.Save();

            return new JsonResult(new { success= "Success"}); 
        }

       
    }
}
