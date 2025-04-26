using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Arithmetic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RoleId { get; set; }
        public int? ClassId { get; set; }

        public Role Role { get; set; }
        public Class Class { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public DateTime SubmissionDate { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public int ParagraphId { get; set; }
        public string? ImagePath { get; set; }
        public bool HasAudio { get; set; }
    }

    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Paragraph
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChapterId { get; set; }
    }

    public class TestTask
    {
        public int TestId { get; set; }
        public int TaskId { get; set; }
        public int Order { get; set; }
        public int? TimeLimitPerTask { get; set; }
    }

    public class TaskResult
    {
        public int Id { get; set; }
        public int ResultId { get; set; }
        public int TaskId { get; set; }
        public string AnswerGiven { get; set; }
        public bool IsCorrect { get; set; }
        public int TimeSpent { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<TestTask> TestTasks { get; set; }
        public DbSet<TaskResult> TaskResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherClass>()
                .HasKey(tc => new { tc.TeacherId, tc.ClassId });

            modelBuilder.Entity<TestTask>()
                .HasKey(tt => new { tt.TestId, tt.TaskId });
        }
    }
}
