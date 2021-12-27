
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
        Task<List<Examination>> GetByPatientId(int PatientId);
        Task<List<Examination>> GetByDoctorId(int _DoctorId);
    }
}
