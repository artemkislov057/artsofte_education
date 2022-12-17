﻿using Education.DataBase.Entities;
using Education.DataBase.Entities.Lessons;
using Education.DataBase.Entities.Lessons.LessonContent;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase;

public class EducationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public EducationDbContext(DbContextOptions<EducationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<VideoLesson> VideoLessons { get; set; }
    public DbSet<PresentationLesson> PresentationLessons { get; set; }
    public DbSet<LiteratureLesson> LiteratureLessons { get; set; }
    public DbSet<PresentationSlide> PresentationSlides { get; set; }
    public DbSet<LiteraturePurchaseLink> LiteraturePurchaseLinks { get; set; }
    public DbSet<LoadedFile> LoadedFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}