using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class StudentDbContext : DbContext
    {
        public DbSet<StudentDbDto> studentDbDto { get; set; }
        public DbSet<StudentSubjectDbDto> studentSubjectDbDto { get; set; }
        public DbSet<SubjectDbDto> subjectDbDto { get; set; }
        public DbSet<MarksDbDto> markDbDto { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDbDto>().HasKey(e => e.Id);
            modelBuilder.Entity<SubjectDbDto>().HasKey(e => e.id);
            modelBuilder.Entity<MarksDbDto>().HasKey(m => m.Id);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .Property(ss => ss.Id);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(ss => ss.studentDbDto)
                .WithMany(s => s.studentSubjects)
                .HasForeignKey(ss => ss.SID);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(ss => ss.SubjectDbDto)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(ss => ss.marksDbDto)
                .WithOne(m => m.studentSubjectDbDto)
                .HasForeignKey<MarksDbDto>(m => new { m.SID, m.SubjectId })
                .HasPrincipalKey<StudentSubjectDbDto>(ss => new { ss.SID, ss.SubjectId });

            modelBuilder.Entity<MarksDbDto>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MarksDbDto>().HasIndex(m => new { m.SID, m.SubjectId }).IsUnique(false);
        }
    }
}
