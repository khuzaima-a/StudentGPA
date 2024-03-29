﻿// <auto-generated />
using DL.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DL.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DL.DbModels.MarksDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SID", "SubjectId");

                    b.ToTable("markDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("studentSubjectDbDto");
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditHour")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("subjectDbDto");
                });

            modelBuilder.Entity("DL.DbModels.MarksDbDto", b =>
                {
                    b.HasOne("DL.DbModels.StudentSubjectDbDto", "studentSubjectDbDto")
                        .WithOne("marksDbDto")
                        .HasForeignKey("DL.DbModels.MarksDbDto", "SID", "SubjectId")
                        .HasPrincipalKey("DL.DbModels.StudentSubjectDbDto", "SID", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("studentSubjectDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.HasOne("DL.DbModels.StudentDbDto", "studentDbDto")
                        .WithMany("studentSubjects")
                        .HasForeignKey("SID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.DbModels.SubjectDbDto", "SubjectDbDto")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectDbDto");

                    b.Navigation("studentDbDto");
                });

            modelBuilder.Entity("DL.DbModels.StudentDbDto", b =>
                {
                    b.Navigation("studentSubjects");
                });

            modelBuilder.Entity("DL.DbModels.StudentSubjectDbDto", b =>
                {
                    b.Navigation("marksDbDto")
                        .IsRequired();
                });

            modelBuilder.Entity("DL.DbModels.SubjectDbDto", b =>
                {
                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
