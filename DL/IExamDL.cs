using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IExamDL
    {
        Task Post(Examination exam);
        Task<Examination> GetByExamId(int id);
        Examination GetByPatientId(int PatientId);
    }
}
