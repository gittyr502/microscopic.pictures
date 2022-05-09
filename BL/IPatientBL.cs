using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IPatientBL
    {
        Task Post(Patient patient);
        Task Put(Patient patient);
        Task Delete(int id);
        Task<List<Patient>> GetPatients(int userId);

        Task<List<string>> GetAllPatientsIds();
    }
}
