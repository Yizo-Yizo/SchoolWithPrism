using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class StudentDetails
    {
        public int ID { get; set; }

        public string NameOfApplicant { get; set; }

        public string Surname { get; set; }

        public string NameOfParent { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        [MaxLength(10)]
        public int ParentsPhoneNO { get; set; }
    }
}
