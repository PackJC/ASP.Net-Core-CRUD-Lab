using LabW06StudentGrades.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LabW06StudentGrades.Services
{
   public class StudentGradesDbContext : DbContext
   {
      public StudentGradesDbContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Student> Students { get; set; }
      public DbSet<Course> Courses { get; set; }
      public DbSet<StudentCourseGrade> StudentCourseGrades { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Course>()
                .HasKey(c => new { c.Code, c.Number });
         modelBuilder.Entity<StudentCourseGrade>()
                .HasKey(scg => new { scg.StudentENumber, scg.CourseCode, scg.CourseNumber });
      }

      public void Seed()
      {
         Database.EnsureCreated();

         // If there are any students then the database is already seeded.
         if (Students.Any()) return;

         var students = new List<Student>
         {
            new Student { ENumber = "E00000001", FirstName = "James", LastName = "Smith" },
            new Student { ENumber = "E00000002", FirstName = "Maria", LastName = "Garcia" },
            new Student { ENumber = "E00000003", FirstName = "Chen", LastName = "Li" },
            new Student { ENumber = "E00000004", FirstName = "Aban", LastName = "Hakim" }
         };

         Students.AddRange(students);
         SaveChanges();

         var courses = new List<Course>
         {
             new Course { Code = "CSCI", Number = "3110", CreditHours = 3 },
             new Course { Code = "CSCI", Number = "1250", CreditHours = 4 },
             new Course { Code = "CSCI", Number = "1260", CreditHours = 4 }
         };

         Courses.AddRange(courses);
         SaveChanges();

         Course csci3110 = Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "3110");
         Course csci1250 = Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1250");
         Course csci1260 = Courses
            .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1260");

         Student james = Students
            .FirstOrDefault(s => s.ENumber == "E00000001");
         Student maria = Students
            .FirstOrDefault(s => s.ENumber == "E00000002");
         Student li = Students
            .FirstOrDefault(s => s.ENumber == "E00000003");
         Student hakim = Students
            .FirstOrDefault(s => s.ENumber == "E00000004");

         james.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "B+",
               Course = csci3110
            }
         );
         james.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "C",
               Course = csci1250
            }
         );

         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci3110
            }
         );
         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "D",
               Course = csci1250
            }
         );
         maria.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "F",
               Course = csci1260
            }
         );

         li.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A-",
               Course = csci1250
            }
         );

         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "C+",
               Course = csci3110
            }
         );
         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci1250
            }
         );
         hakim.Grades.Add(
            new StudentCourseGrade
            {
               LetterGrade = "A",
               Course = csci1260
            }
         );
         SaveChanges();
      } // Seed()
   }
}
