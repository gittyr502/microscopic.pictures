using AutoMapper;
using DTO;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PatientDL:IPatientDL
    {
        MicroscopicPicture1Context myDB;
        IMapper mapper;
        public PatientDL(MicroscopicPicture1Context _myDB,IMapper _mapper)
        {
            myDB = _myDB;
            mapper = _mapper;
        }
        public async Task Post(Patient patient)
        {
            await myDB.Patients.AddAsync(patient);
            await myDB.SaveChangesAsync();
        }
        public async Task Put(Patient patient)
        {
             myDB.Patients.Update(patient);
            await myDB.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Patient p = await myDB.Patients.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            if (p!=null)
            {
                myDB.Patients.Remove(p);
                await myDB.SaveChangesAsync();
            }
            
        }

        public async Task<List<PatientDTO>> GetPatients(int userId)
        {

            List<PatientDTO> patientList = await myDB.Users.Where(u => u.Id == userId).Include(u => u.Patients).AllAsync();
                 
            if (patientList != null)
            {
                return patientList;
            }
            return null;
            
        }
    }
}
