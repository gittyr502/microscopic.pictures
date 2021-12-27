
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BL
{
    public interface IExamBL
    {
       Task Post(Examination exam);
        Task<Examination> GetByExamId(int id);
        List<Examination> GetByPatientID(int PatientId);
    }
}
