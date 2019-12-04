﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolFinder.Models
{
    class StudentDetails
    {
        [PrimaryKey, AutoIncrement]

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
