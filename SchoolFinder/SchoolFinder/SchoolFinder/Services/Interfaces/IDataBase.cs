using SchoolFinder.Models;
using System.Threading.Tasks;

namespace SchoolFinder.Service.Interfaces
{
    public interface IDataBase
    {
        Task<int> SaveStudentDetails(StudentDetails studentDetails);
        Task<string> SavedStudentDetails(StudentDetails studentDetails);
        Task SavedStudentDetails(string savedDetails);
    }
}
