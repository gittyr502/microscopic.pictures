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
        Task<List<Examination>> GetByPatientIdNotChecked(int PatientId);
        Task<List<Examination>> GetByPatientIdChecked(int PatientId);
        Task<List<Examination>> GetByDoctorId(int _DoctorId);
        Task<List<Examination>> GetByDate(DateTime date);
        Task<List<Examination>> GetAllExams();

        Task<string> getDoctorNameById(int Id);

        Task<bool> ImgExist(string linkToFile);

        Task Put(Examination _exam);
    }
}
