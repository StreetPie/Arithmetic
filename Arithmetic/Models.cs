using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

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

    public class ArithmeticDbContext : DbContext
    {
        public ArithmeticDbContext() : base("DBConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
