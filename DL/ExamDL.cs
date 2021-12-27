using Microsoft.EntityFrameworkCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL
{
    public class ExamDL
    {
        MicroscopicPictureContext myDB;
        public async Task Post(Examination exam)
        {
            await myDB.Examinations.AddAsync(exam);
            await myDB.SaveChangesAsync();
        }
        public async Task<Examination> GetByExamID(int id)
        {
           Entity.Examination e = await myDB.Examinations.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            if (e != null)
            {
                return e;
            }
            return default(Examination);
        }
        public async Task<List<Examination>> GetByPatientId(int PatientId)
        {
           List<Examination> examList = await myDB.Examinations.Where(e =>e.PatientId.Equals(PatientId)).ToListAsync<Examination>();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }
    }
}
