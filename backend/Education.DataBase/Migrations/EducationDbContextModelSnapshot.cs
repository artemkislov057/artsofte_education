﻿// <auto-generated />
using System;
using Education.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Education.DataBase.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    partial class EducationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Education.DataBase.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Education.DataBase.Entities.EditorJsObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EditorJsObjects");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdditionalTextId")
                        .HasColumnType("int");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalTextId")
                        .IsUnique()
                        .HasFilter("[AdditionalTextId] IS NOT NULL");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.ListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TextBlockId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TextBlockId");

                    b.ToTable("ListItems");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.LiteratureElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoverSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LiteratureLessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LiteratureLessonId");

                    b.ToTable("LiteratureElement");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.LiteraturePurchaseLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LiteratureElementId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LiteratureElementId");

                    b.ToTable("LiteraturePurchaseLinks");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.PresentationSlide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PresentationId")
                        .HasColumnType("int");

                    b.Property<string>("VoiceSrc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PresentationId");

                    b.ToTable("PresentationSlides");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.QuestionAnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsCorrectAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswerOptions");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EditorJsId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EditorJsId")
                        .IsUnique();

                    b.HasIndex("TestId");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TextBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DataLevel")
                        .HasColumnType("int");

                    b.Property<string>("DataStyle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditorJsObjectId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EditorJsObjectId");

                    b.ToTable("TextBlocks");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LiteratureLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.ToTable("LiteratureLessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.PresentationLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.ToTable("PresentationLessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.TestLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.ToTable("TestLessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.TextLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("EditorJsObjectId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.HasIndex("EditorJsObjectId")
                        .IsUnique();

                    b.ToTable("TextLessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.VideoLesson", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoType")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.ToTable("VideoLessons");
                });

            modelBuilder.Entity("Education.DataBase.Entities.LoadedFile", b =>
                {
                    b.Property<Guid>("FileGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.HasKey("FileGuid");

                    b.ToTable("LoadedFiles");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.Lesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.EditorJsObject", "AdditionalText")
                        .WithOne("Lesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.Lesson", "AdditionalTextId");

                    b.HasOne("Education.DataBase.Entities.Module", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalText");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.ListItem", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.LessonContent.TextBlock", "TextBlock")
                        .WithMany("DataItems")
                        .HasForeignKey("TextBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TextBlock");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.LiteratureElement", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.LiteratureLesson", "LiteratureLesson")
                        .WithMany("LiteratureElements")
                        .HasForeignKey("LiteratureLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteratureLesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.LiteraturePurchaseLink", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.LessonContent.LiteratureElement", "LiteratureElement")
                        .WithMany("PurchaseLinks")
                        .HasForeignKey("LiteratureElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteratureElement");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.PresentationSlide", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.PresentationLesson", "PresentationLesson")
                        .WithMany("PresentationSlides")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PresentationLesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.QuestionAnswerOption", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.LessonContent.TestQuestion", "TestQuestion")
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestQuestion");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TestQuestion", b =>
                {
                    b.HasOne("Education.DataBase.Entities.EditorJsObject", "Question")
                        .WithOne()
                        .HasForeignKey("Education.DataBase.Entities.Lessons.LessonContent.TestQuestion", "EditorJsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Education.DataBase.Entities.Lessons.TestLesson", "TestLesson")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("TestLesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TextBlock", b =>
                {
                    b.HasOne("Education.DataBase.Entities.EditorJsObject", "EditorJsObject")
                        .WithMany("Blocks")
                        .HasForeignKey("EditorJsObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EditorJsObject");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LiteratureLesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.Lesson", "Lesson")
                        .WithOne("LiteratureLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.LiteratureLesson", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.PresentationLesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.Lesson", "Lesson")
                        .WithOne("PresentationLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.PresentationLesson", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.TestLesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.Lesson", "Lesson")
                        .WithOne("TestLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.TestLesson", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.TextLesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.EditorJsObject", "Value")
                        .WithOne("TextLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.TextLesson", "EditorJsObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Education.DataBase.Entities.Lessons.Lesson", "Lesson")
                        .WithOne("TextLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.TextLesson", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.VideoLesson", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Lessons.Lesson", "Lesson")
                        .WithOne("VideoLesson")
                        .HasForeignKey("Education.DataBase.Entities.Lessons.VideoLesson", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Module", b =>
                {
                    b.HasOne("Education.DataBase.Entities.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Education.DataBase.Entities.Course", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("Education.DataBase.Entities.EditorJsObject", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Lesson");

                    b.Navigation("TextLesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.Lesson", b =>
                {
                    b.Navigation("LiteratureLesson");

                    b.Navigation("PresentationLesson");

                    b.Navigation("TestLesson");

                    b.Navigation("TextLesson");

                    b.Navigation("VideoLesson");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.LiteratureElement", b =>
                {
                    b.Navigation("PurchaseLinks");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TestQuestion", b =>
                {
                    b.Navigation("AnswerOptions");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LessonContent.TextBlock", b =>
                {
                    b.Navigation("DataItems");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.LiteratureLesson", b =>
                {
                    b.Navigation("LiteratureElements");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.PresentationLesson", b =>
                {
                    b.Navigation("PresentationSlides");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Lessons.TestLesson", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Education.DataBase.Entities.Module", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
