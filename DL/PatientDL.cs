﻿using Entity;
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
        public PatientDL(MicroscopicPicture1Context _myDB)
        {
            myDB = _myDB;
        }
        public async Task Post(Patient patient)
        {
            await myDB.Patients.AddAsync(patient);
            await myDB.SaveChangesAsync();
        }
    }
}
