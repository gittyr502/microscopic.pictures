using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;
using DTO;
using AutoMapper;
//git

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_MicroscopicPicture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientBL patientBL;
        IMapper _mapper;
        public PatientController(IPatientBL _patientBL, IMapper mapper)
        {
            patientBL = _patientBL;
            _mapper = mapper;
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            await patientBL.Post(patient);
        }

        [HttpGet("{userId}")]
        public async Task<List<PatientDTO>> GetPatients(int userId)
        {
            List<Patient> listPatient = await patientBL.GetPatients(userId);
            return _mapper.Map<List<Patient>, List<PatientDTO>>(listPatient);
        }


        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] Patient patient)
        {
            await patientBL.Put(patient);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await patientBL.Delete(id);
        }

        [HttpGet("GetAllPatientsIds")]
        public async Task<List<string>> GetAllPatientsIds()
        {
            return await patientBL.GetAllPatientsIds();
        }
    }
}
