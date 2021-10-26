﻿using System.Collections.Generic;

namespace ManyToManyProj.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}