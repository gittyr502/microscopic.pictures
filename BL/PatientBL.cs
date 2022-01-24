using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PatientBL:IPatientBL
    {
        IPatientDL patientDL;

        public PatientBL(IPatientDL _patientDL)
        { 
            patientDL = _patientDL;
        }
        public async Task Post(Patient patient)
        {
             patientDL.Post(patient);
        }
        public async Task Put( Patient patient)
        {
            patientDL.Put(patient);
        }

        public async Task Delete(int id)
        {
            patientDL.Delete(id);
        }
    }
}
