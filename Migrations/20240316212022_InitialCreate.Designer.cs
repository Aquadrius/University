﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.DAL;

#nullable disable

namespace University.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20240316212022_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabworkStud", b =>
                {
                    b.Property<int>("LabworkId")
                        .HasColumnType("int");

                    b.Property<int>("StudId")
                        .HasColumnType("int");

                    b.HasKey("LabworkId", "StudId");

                    b.HasIndex("StudId");

                    b.ToTable("LabworkStud");
                });

            modelBuilder.Entity("LectureStud", b =>
                {
                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<int>("StudId")
                        .HasColumnType("int");

                    b.HasKey("LectureId", "StudId");

                    b.HasIndex("StudId");

                    b.ToTable("LectureStud");
                });

            modelBuilder.Entity("LectureTeacher", b =>
                {
                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("LectureId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LectureTeacher");
                });

            modelBuilder.Entity("University.Domain.Entity.Labwork", b =>
                {
                    b.Property<int>("LabworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabworkId"));

                    b.Property<string>("LabworkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("LabworkId");

                    b.HasIndex("LectureId");

                    b.ToTable("Labwork");
                });

            modelBuilder.Entity("University.Domain.Entity.Lecture", b =>
                {
                    b.Property<int>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectureId"));

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("University.Domain.Entity.Stud", b =>
                {
                    b.Property<int>("StudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudId"));

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kurs")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudId");

                    b.ToTable("Stud");
                });

            modelBuilder.Entity("University.Domain.Entity.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("University.Domain.Entity.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LabworkStud", b =>
                {
                    b.HasOne("University.Domain.Entity.Labwork", null)
                        .WithMany()
                        .HasForeignKey("LabworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Domain.Entity.Stud", null)
                        .WithMany()
                        .HasForeignKey("StudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureStud", b =>
                {
                    b.HasOne("University.Domain.Entity.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Domain.Entity.Stud", null)
                        .WithMany()
                        .HasForeignKey("StudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureTeacher", b =>
                {
                    b.HasOne("University.Domain.Entity.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University.Domain.Entity.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("University.Domain.Entity.Labwork", b =>
                {
                    b.HasOne("University.Domain.Entity.Lecture", "Lecture")
                        .WithMany("Labwork")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("University.Domain.Entity.Lecture", b =>
                {
                    b.Navigation("Labwork");
                });
#pragma warning restore 612, 618
        }
    }
}
