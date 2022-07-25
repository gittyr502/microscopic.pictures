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
        [HttpGet("GetByPatientIdNotChecked/{PatientId}")]
        public async Task<List<Examination>> GetByPatientIdNotChecked(int PatientId)
        {
            return await examBL.GetByPatientIdNotChecked(PatientId);
        }

        [HttpGet("GetByPatientIdChecked/{PatientId}")]
        public async Task<List<Examination>> GetByPatientIdChecked(int PatientId)
        {
            return await examBL.GetByPatientIdChecked(PatientId);
        }

        [HttpGet("GetAllExam")]
        public async Task<List<Examination>> GetAllExams()
        {
            return await examBL.GetAllExams();
        }

        [HttpGet("getByDoctorId/{DoctorId}")]
        public async Task<List<Examination>> GetByDoctorId(int DoctorId)
        {
            return await examBL.GetByDoctorId(DoctorId);
        }

        [HttpGet("getByDate/{Date}")]

        public async Task<List<Examination>> GetByDate(DateTime date)
        {
            return await examBL.GetByDate(date);
        }
        // POST api/<ExamController>
        [HttpPost]
        public async Task Post([FromBody] Examination _exam)
        {
            await examBL.Post(_exam);

        }

        [HttpPut]
        public async Task Put([FromBody] Examination _exam)
        {
            await examBL.Put(_exam);

        }

        [HttpGet("getDoctorNameById/{id}")]
        public async Task<string> getDoctorNameById(int id)
        {
            return await examBL.getDoctorNameById(id);
        }

    }
}
