using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BL
{
    public class ExamBL
    {
        IExamDL examDL;
      public async Task Post(Examination exam)
        {
           examDL.Post(exam);
        }
        public async Task<Examination> GetByExamId(int id)
        {
            return await examDL.GetByExamId(id);
        }
        public async Task<List<Examination>> GetByPatientId(int PatientId)
        {
            return await examDL.GetByPatientId(PatientId);
        }
    }
}
