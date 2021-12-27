using Microsoft.EntityFrameworkCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL
{
    public class ExamDL: IExamDL
    {
        MicroscopicPictureContext myDB;
        public ExamDL(MicroscopicPictureContext _myDB)
        {
            myDB = _myDB;
                
        }

        public async Task Post(Examination exam)
        {
            await myDB.Examinations.AddAsync(exam);
            await myDB.SaveChangesAsync();
        }
        public async Task<Examination> GetByExamId(int id)
        {
           Entity.Examination e = await myDB.Examinations.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            if (e != null)
            {
                return e;
            }
            return default(Examination);
        }
        public async Task<List<Examination>> GetByPatientId(int _PatientId)
        {
           List<Examination> examList = await myDB.Examinations.Where(e =>e.PatientId.Equals(_PatientId)).ToListAsync<Examination>();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }

        public async Task<List<Examination>> GetByDoctorId(int _DoctorId)
        {
            List<Examination> examList = await myDB.Examinations.Where(e => e.DoctorId.Equals(_DoctorId)).ToListAsync<Examination>();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }
    }
}
