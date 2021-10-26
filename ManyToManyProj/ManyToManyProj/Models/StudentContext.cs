using System.Collections.Generic;
using System.Data.Entity;

namespace ManyToManyProj.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }

    public class CourseDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            Student s1 = new Student { Id = 1, Name = "Jorik", Surname = "Vartanov" };
            Student s2 = new Student { Id = 2, Name = "Lera", Surname = "Ivanova" };
            Student s3 = new Student { Id = 3, Name = "Dasha", Surname = "Ahmatova" };
            Student s4 = new Student { Id = 4, Name = "Eugene", Surname = "Kostilev" };

            context.Students.Add(s1);
            context.Students.Add(s2);
            context.Students.Add(s3);
            context.Students.Add(s4);

            Course c1 = new Course
            {
                Id = 1,
                Name = "Операционные системы",
                Students = new List<Student>
                {
                    s1, s2, s3
                }
            };
            Course c2 = new Course
            {
                Id = 1,
                Name = "Алгоритмы и структуры данных",
                Students = new List<Student>
                {
                    s2, s3
                }
            };
            Course c3 = new Course
            {
                Id = 1,
                Name = "Основы HTML и CSS",
                Students = new List<Student>
                {
                    s1, s4, s3
                }
            };

            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);

            context.SaveChanges();

        }
    }
}