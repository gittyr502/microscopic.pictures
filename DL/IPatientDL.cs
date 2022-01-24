using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IPatientDL
    {
        Task Post(Patient patient);
        Task Put(Patient patient);
        Task Delete(int id);
    }
}
