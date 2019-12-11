using SchoolFinder.Models;
using System.Threading.Tasks;

namespace SchoolFinder.Service.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveUserAsync(StudentDetails studentDetails);

        Task<int> SaveUserAsync(User user);

        Task<int> SaveStudentDetailsAsync(StudentDetails studentDetails);
        Task SaveStudentDetailsAsync(int savedDetails);
    }
}
