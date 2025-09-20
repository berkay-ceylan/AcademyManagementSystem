using _51_entity_lab2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_entity_lab2.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CourseDetail> CourseDetails { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Student { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Kendi PC adınız;Initial Catalog=EntityDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");



        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One-To-Many: Course-Category

            modelBuilder.Entity<Course>()

                .HasOne(c => c.Category)

                .WithMany(c => c.Courses)

                .HasForeignKey(c => c.CategoryId)

                .OnDelete(DeleteBehavior.NoAction);

            //One-To-Many: Course-Instructor

            modelBuilder.Entity<Instructor>()

                .HasMany(i => i.courses)

                .WithOne(c => c.Instructor)

                .HasForeignKey(c => c.InstructorId)

                .OnDelete(DeleteBehavior.NoAction);

            //One-To-One: Course-CourseDetail

            modelBuilder.Entity<CourseDetail>()

                .HasKey(cd => cd.Id);

            modelBuilder.Entity<Course>()

                .HasOne(c => c.Coursedetails)

                .WithOne(cd => cd.Course)

                .HasForeignKey<CourseDetail>(cd => cd.Id)

                .OnDelete(DeleteBehavior.Cascade);

            //Many-to-Many: Student-Course

            modelBuilder.Entity<Enrollment>()

                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()

                .HasOne(e => e.Course)

                .WithMany(c => c.Enrollments)

                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()

                .HasOne(e => e.Student)

                .WithMany(s => s.Enrollments)

                .HasForeignKey(e => e.StudentId);

            //Others

            modelBuilder.Entity<Category>()

                .Property(c => c.Name)

                .HasColumnType("nvarchar(50)")

                .IsRequired();

            modelBuilder.Entity<Instructor>()

                .Property(c => c.Name)

                .HasColumnType("nvarchar(50)")

                .IsRequired();

            modelBuilder.Entity<Course>()

                .Property(c => c.Title)

                .HasColumnType("nvarchar(50)")

                .IsRequired();

            modelBuilder.Entity<CourseDetail>()

                .Property(cd => cd.Description)

                .HasMaxLength(250);

            modelBuilder.Entity<CourseDetail>()

                .Property(cd => cd.Duration)

                .IsRequired(false);

            modelBuilder.Entity<Enrollment>()

                .Property(e => e.Price)

                .HasPrecision(18, 2)

                .IsRequired(false);

            modelBuilder.Entity<Enrollment>()

                .Property(e => e.EnrolledOn)

                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Student>()

                .Property(c => c.Firstname)

                .HasColumnType("nvarchar(50)")

                .IsRequired();

            modelBuilder.Entity<Student>()

                .Property(c => c.Lastname)

                .HasColumnType("nvarchar(50)")

                .IsRequired();

            modelBuilder.Entity<Student>()

                .Ignore(s => s.Fullname);



        }


    }
}
