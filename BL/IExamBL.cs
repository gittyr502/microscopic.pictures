
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
        Task<List<Examination>> GetByPatientIdChecked(int PatientId);
        Task<List<Examination>> GetByPatientIdNotChecked(int PatientId);
        Task<List<Examination>> GetByDoctorId(int _DoctorId);

        Task<List<Examination>> GetByDate(DateTime date);
        Task<List<Examination>> GetAllExams();
        Task<string> getDoctorNameById(int id);

        Task Put(Examination _exam);
    }
}
