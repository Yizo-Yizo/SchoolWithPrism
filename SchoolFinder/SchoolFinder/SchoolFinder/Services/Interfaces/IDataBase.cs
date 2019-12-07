using SchoolFinder.Models;
using System.Threading.Tasks;

namespace SchoolFinder.Service.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveStudentDetails(StudentDetails studentDetails);
    }
}
