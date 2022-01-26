using BL;
using Microsoft.AspNetCore.Mvc;

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
        
       public ExamController(IExamBL _examBL)
        {
            examBL = _examBL;
        }

        // GET api/<ExamController>/5
        [HttpGet("{id}")]
        public async Task<Examination> GetByExamId(int id)
        {
            return await examBL.GetByExamId(id);
        }
        [HttpGet("getByPatientId/{PatientId}")]
        public async Task<List<Examination>> GetByPatientId(int PatientId)
        {
            return await examBL.GetByPatientId(PatientId);
        }

        [HttpGet("getByDoctorId/{DoctorId}")]
        public async Task<List<Examination>> GetByDoctorId(int DoctorId)
        {
            return await examBL.GetByDoctorId(DoctorId);
        }

        [HttpGet("getByDate/{Date}")]

        public async Task<List<Examination>>GetByDate(DateTime date)
        {
            return await examBL.GetByDate(date);
        }
        // POST api/<ExamController>
        [HttpPost]
        public async void Post([FromBody] Examination _exam)
        {
            await examBL.Post(_exam);

        }

    }
}
