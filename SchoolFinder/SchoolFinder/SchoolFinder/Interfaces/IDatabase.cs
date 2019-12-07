using SchoolFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinder.Interfaces
{
    class IDatabase
    {
        Task<StudentDetails> GetSavedStudentDetails();
    }
}
