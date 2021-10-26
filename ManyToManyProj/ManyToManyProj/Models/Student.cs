﻿using System.Collections.Generic;

namespace ManyToManyProj.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual List<Course> Courses{ get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}