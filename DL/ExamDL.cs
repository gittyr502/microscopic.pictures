using Microsoft.EntityFrameworkCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DL
{
    public class ExamDL : IExamDL
    {
        MicroscopicPicture1Context myDB;
        public ExamDL(MicroscopicPicture1Context _myDB)
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
            Examination e = await myDB.Examinations.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
            if (e != null)
            {
                return e;
            }
            return default(Examination);
        }
        public async Task<List<Examination>> GetByPatientIdNotChecked(int _PatientId)
        {
            List<Examination> examList = await myDB.Examinations.Where(e => e.PatientId.Equals(_PatientId) && e.ComputerDiagnosis == false).ToListAsync<Examination>();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }
        public async Task<List<Examination>> GetByPatientIdChecked(int _PatientId)
        {
            List<Examination> examList = await myDB.Examinations.Where(e => e.PatientId.Equals(_PatientId) && e.ComputerDiagnosis == true).ToListAsync<Examination>();
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

        public async Task<List<Examination>> GetByDate(DateTime date)
        {
            List<Examination> examList = await myDB.Examinations.Where(e => e.ExaminationDate.Equals(date.Date)).ToListAsync<Examination>();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }

        public async Task<string> getDoctorNameById(int Id)
        {
            string doctorName;


            using (SqlConnection sqlConnection1 = new SqlConnection("Server=DESKTOP-45L6QC9;Database=MicroscopicPicture1;Trusted_Connection=True;"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    var result = cmd.Parameters.Add("@doctorId", SqlDbType.VarChar).Value = Id;

                    cmd.CommandText = "get_docrtor_name";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    //await cmd.ExecuteNonQueryAsync();

                    string returnedValue = string.Empty;
                    returnedValue = (string)await cmd.ExecuteScalarAsync();

                    doctorName = returnedValue;
                    return doctorName;
                }



            }
        }
            public async Task<List<Examination>> GetAllExams()
        {
            List<Examination> examList = await myDB.Examinations.ToListAsync();
            if (examList != null)
            {
                return examList;
            }
            return null;
        }

        public async Task<bool> ImgExist( string linkToFile)
        {
            return await myDB.Examinations.AnyAsync(x => x.LinkToFile.Equals(linkToFile));
        }
    }
}
