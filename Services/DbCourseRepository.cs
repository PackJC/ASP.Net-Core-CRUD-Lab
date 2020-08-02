using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabW06StudentGrades.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabW06StudentGrades.Services
{
   public class DbCourseRepository : ICourseRepository
   {
      private StudentGradesDbContext _db;

      public DbCourseRepository(StudentGradesDbContext db)
      {
         _db = db;
      }

      public Course Read(string courseCode, string courseNumber)
      {
         return _db.Courses
            .Include(c => c.StudentGrades)
            .ThenInclude(scg => scg.Student)
            .FirstOrDefault(c => c.Code == courseCode && c.Number == courseNumber);
      }

      public ICollection<Course> ReadAll()
      {
         return _db.Courses
            .Include(c => c.StudentGrades)
            .ThenInclude(scg => scg.Student)
            .ToList();
      }
   }
}
