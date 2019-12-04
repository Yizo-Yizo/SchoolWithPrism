﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolFinder.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
