using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabW06StudentGrades.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabW06StudentGrades.Services
{
   public class DbStudentRepository : IStudentRepository
   {
      private StudentGradesDbContext _db;

      public DbStudentRepository(StudentGradesDbContext db)
      {
         _db = db;
      }

      public void EnrollInCourse(string id, string courseCode, string courseNumber)
      {
         var student = Read(id);
         var course = _db.Courses
            .FirstOrDefault(c => c.Code == courseCode && c.Number == courseNumber);
         var studentCourseRecord = new StudentCourseGrade
         {
            Student = student,
            Course = course
         };
         student.Grades.Add(studentCourseRecord);
         _db.SaveChanges();
      }

      public Student Read(string id)
      {
         return _db.Students
            .Include(s => s.Grades)
            .ThenInclude(scg => scg.Course)
            .FirstOrDefault(s => s.ENumber == id);
      }

      public ICollection<Student> ReadAll()
      {
         return _db.Students
            .Include(s => s.Grades)
            .ThenInclude(scg => scg.Course)
            .ToList();
      }


    }
}
