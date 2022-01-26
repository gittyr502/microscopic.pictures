using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BL
{
    public class ExamBL:IExamBL
    {
        IExamDL examDL;
        public ExamBL(IExamDL _examDL)
        {
            examDL = _examDL;
        }
      public async Task Post(Examination exam)
        {
         await  examDL.Post(exam);
        }
        public async Task<Examination> GetByExamId(int id)
        {
            return await examDL.GetByExamId(id);
        }
        public async Task<List<Examination>> GetByPatientId(int PatientId)
        {
            return await examDL.GetByPatientId(PatientId);
        }
        public async Task<List<Examination>> GetByDoctorId(int DoctorId)
        {
            return await examDL.GetByDoctorId(DoctorId);
        }

        public async Task<List<Examination>> GetByDate(DateTime date)
        {
            return await examDL.GetByDate(date);
        }
    }
}
