﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_S2019_Lab_Data_Access_with_LINQ
{
    enum StudentField
    {
        ID,
        STUDENT_ID,
        FIRST_NAME,
        LAST_NAME,
        NUM_OF_FIELDS
    }

    public class Student
    {
        public int id { get; set; }
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
