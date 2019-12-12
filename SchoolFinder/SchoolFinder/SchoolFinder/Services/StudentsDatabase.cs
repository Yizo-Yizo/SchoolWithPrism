using SchoolFinder.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolFinder.Service.Interfaces;
using IDatabase = SchoolFinder.Service.Interfaces.IDatabase;

namespace SchoolFinder.Service
{
    public class StudentsDatabase : IDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public StudentsDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.db3");
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<StudentDetails>().Wait();
            database.CreateTableAsync<User>().Wait();
            
        }

    

        public Task<List<StudentDetails>> GetStudents()
        {
            return database.Table<StudentDetails>().ToListAsync();
        }

        public Task<int> SaveStudentDetailsAsync(StudentDetails studentDetails)
        {

            return database.InsertAsync(studentDetails);

        }

        public async Task<int> UpdateStudentDetails(StudentDetails studentDetails)
        {

            return await database.UpdateAsync(studentDetails);

        }

        public async Task<int> DeleteStudentDetails(StudentDetails studentDetails)
        {

            return await database.DeleteAsync(studentDetails);

        }

        public Task<int> SaveUserAsync(StudentDetails studentDetails)
        {
            return database.InsertAsync(studentDetails);
        }

        public Task<int> SaveUserAsync(User user)
        {
            return database.InsertAsync(user);
        }

        public Task SaveStudentDetailsAsync(int savedDetails)
        {
            throw new NotImplementedException();
        }

        /*   public Task SavedStudentDetails(StudentDetails studentInfo)
           {
               throw new NotImplementedException();
           }*/
    }
}
