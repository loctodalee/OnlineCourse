﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourse.Data;

#nullable disable

namespace OnlineCourse.Migrations
{
    [DbContext(typeof(OnlineCourseDbContext))]
    partial class OnlineCourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.ActEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_action");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.PermissionActionEntity", b =>
                {
                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CreateTimes");

                    b.HasIndex("ActionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("tbl_per_action");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.PermissionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Permission");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.RefreshTokens", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("VerifyToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.UserPermissionEntity", b =>
                {
                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CreateTimes");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_user_per");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.CourseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BeginLessonId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("tbl_Course");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.CourseUserEntity", b =>
                {
                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CreateTimes");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_user_course");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.LessonEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("NextLessonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("tbl_lesson");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.UserCourseLessonProgressEntity", b =>
                {
                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<string>("LessonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CreateTimes");

                    b.HasIndex("CourseId");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_user_course_lesson_progress");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Order.OrderEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Buy_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTimes")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTimes")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_order");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.PermissionActionEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Auth.ActEntity", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Auth.PermissionEntity", "Permission")
                        .WithMany("Actions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.RefreshTokens", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Auth.UserEntity", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.UserPermissionEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Auth.PermissionEntity", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Auth.UserEntity", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.CourseUserEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Course.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Auth.UserEntity", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.LessonEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Course.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.UserCourseLessonProgressEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Course.CourseEntity", "Course")
                        .WithMany("UserCourseLessonProgresses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Course.LessonEntity", "Lesson")
                        .WithMany("UserCourseLessonProgresses")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Auth.UserEntity", "User")
                        .WithMany("UserCourseLessonProgresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Order.OrderEntity", b =>
                {
                    b.HasOne("OnlineCourse.Data.Entity.Course.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCourse.Data.Entity.Auth.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.PermissionEntity", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Auth.UserEntity", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Orders");

                    b.Navigation("Permissions");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserCourseLessonProgresses");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.CourseEntity", b =>
                {
                    b.Navigation("UserCourseLessonProgresses");
                });

            modelBuilder.Entity("OnlineCourse.Data.Entity.Course.LessonEntity", b =>
                {
                    b.Navigation("UserCourseLessonProgresses");
                });
#pragma warning restore 612, 618
        }
    }
}
