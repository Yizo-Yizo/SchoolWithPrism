using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
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
    internal class StudentsDatabase : IDatabase
    {
        private SQLiteAsyncConnection database;

        public StudentsDatabase()
        {
            string dbPath = GetDbPath();
            database = new SQLiteAsyncConnection(dbPath);
            
        }

        private string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.db3");
        }

        public Task<List<StudentDetails>> GetStudents()
        {
            return database.Table<StudentDetails>().ToListAsync();
        }

        public async Task<int> SaveStudentDetails(StudentDetails studentDetails)
        {

            return await database.InsertAsync(studentDetails);

        }

        public async Task<int> UpdateStudentDetails(StudentDetails studentDetails)
        {

            return await database.UpdateAsync(studentDetails);

        }

        public async Task<int> DeleteStudentDetails(StudentDetails studentDetails)
        {

            return await database.DeleteAsync(studentDetails);

        }

        public int SaveChanges(IList<IUpdateEntry> entries)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(IList<IUpdateEntry> entries, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Func<QueryContext, TResult> CompileQuery<TResult>(Expression query, bool async)
        {
            throw new NotImplementedException();
        }
    }
}
