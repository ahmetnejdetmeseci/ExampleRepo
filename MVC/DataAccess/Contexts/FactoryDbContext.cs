using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class FactoryDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<FeedbackCategory> FeedbackCategories { get; set; }
        public DbSet<ImprovementFeedback> ImprovementFeedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=KayzenDb;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ImprovementFeedbacks)
                .WithOne(f => f.Employee)
                .HasForeignKey(f => f.EmployeeId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Machines)
                .WithOne(m => m.Department)
                .HasForeignKey(m => m.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Processes)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Jobs)
                .WithOne(j => j.Department)
                .HasForeignKey(j => j.DepartmentId);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.Job)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.ImprovementFeedbacks)
                .WithOne(f => f.Machine)
                .HasForeignKey(f => f.MachineId);

            modelBuilder.Entity<Process>()
                .HasMany(p => p.ImprovementFeedbacks)
                .WithOne(f => f.Process)
                .HasForeignKey(f => f.ProcessId);

            modelBuilder.Entity<FeedbackCategory>()
                .HasMany(fc => fc.ImprovementFeedbacks)
                .WithOne(f => f.FeedbackCategory)
                .HasForeignKey(f => f.FeedbackCategoryId);
        }
    }
}
