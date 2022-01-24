﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;
//git

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_MicroscopicPicture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientBL patientBL;

        public PatientController(IPatientBL _patientBL)
        {
            patientBL = _patientBL;
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            patientBL.Post(patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] Patient patient)
        {
            patientBL.Put(patient);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            patientBL.Delete(id);
        }
    }
}
