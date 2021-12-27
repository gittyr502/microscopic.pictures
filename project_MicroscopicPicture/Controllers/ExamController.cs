using BL;
using Microsoft.AspNetCore.Mvc;
using project_MicroscopicPicture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_MicroscopicPicture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IExamBL examBL;
        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public async Task<Examination> GetByExamId(int id)
        {
            return examBL.GetByExamId(id);
        }
        [HttpGet("{PatientId}")]
        public async Task<List<Examination>> GetByPatientID(int PatientId)
        {
            return examBL.GetByPatientID(PatientId);
        }
        // POST api/<ExamController>
        [HttpPost]
        public async void Post([FromBody] Examination _exam)
        {
            examBL.Post(_exam);

        }

        // PUT api/<ExamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
