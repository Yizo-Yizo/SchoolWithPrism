using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SchoolFinderContext : DbContext
    {
        public SchoolFinderContext(DbContextOptions<SchoolFinderContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<StudentDetails> StudentsDetails { get; set; }
    }
}
