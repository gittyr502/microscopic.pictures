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
            return examDL.GetByExamId(id);
        }
        public async Task<Examination> GetByPatientId(int PatientId)
        {
            return examDL.GetByPatientId(PatientId);
        }
    }
}
