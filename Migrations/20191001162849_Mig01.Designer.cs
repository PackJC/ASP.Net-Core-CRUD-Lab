﻿// <auto-generated />
using LabW06StudentGrades.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabW06StudentGrades.Migrations
{
    [DbContext(typeof(StudentGradesDbContext))]
    [Migration("20191001162849_Mig01")]
    partial class Mig01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LabW06StudentGrades.Models.Entities.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(4);

                    b.Property<string>("Number")
                        .HasMaxLength(4);

                    b.Property<int>("CreditHours");

                    b.HasKey("Code", "Number");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LabW06StudentGrades.Models.Entities.Student", b =>
                {
                    b.Property<string>("ENumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(9);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ENumber");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LabW06StudentGrades.Models.Entities.StudentCourseGrade", b =>
                {
                    b.Property<string>("StudentENumber")
                        .HasMaxLength(9);

                    b.Property<string>("CourseCode")
                        .HasMaxLength(4);

                    b.Property<string>("CourseNumber")
                        .HasMaxLength(4);

                    b.Property<string>("LetterGrade")
                        .HasMaxLength(2);

                    b.HasKey("StudentENumber", "CourseCode", "CourseNumber");

                    b.HasIndex("CourseCode", "CourseNumber");

                    b.ToTable("StudentCourseGrades");
                });

            modelBuilder.Entity("LabW06StudentGrades.Models.Entities.StudentCourseGrade", b =>
                {
                    b.HasOne("LabW06StudentGrades.Models.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentENumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LabW06StudentGrades.Models.Entities.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseCode", "CourseNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
