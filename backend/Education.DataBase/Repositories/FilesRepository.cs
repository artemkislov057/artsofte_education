﻿using Education.DataBase.Entities;
using Education.DataBase.Enums;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IFilesRepository
{
    Task<Guid> CreateFile(FileType fileType, string extension, string contentType);
    Task<Guid[]> CreateFiles(FileType filesType, int count, string extension, string contentType);
    Task<LoadedFile?> FindFile(Guid fileGuid);
    Task DeleteFile(LoadedFile file);
}

public class FilesRepository : IFilesRepository
{
    private readonly EducationDbContext dbContext;

    public FilesRepository(EducationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Guid> CreateFile(FileType fileType, string extension, string contentType)
    {
        var file = new LoadedFile { FileType = fileType, FileExtension = extension, ContentType = contentType };
        dbContext.LoadedFiles.Add(file);
        await dbContext.SaveChangesAsync();
        return file.FileGuid;
    }

    public async Task<Guid[]> CreateFiles(FileType filesType, int count, string extension, string contentType)
    {
        var files = Enumerable
            .Range(0, count)
            .Select(_ => new LoadedFile { FileType = filesType, FileExtension = extension, ContentType = contentType })
            .ToArray();
        dbContext.LoadedFiles.AddRange(files);
        await dbContext.SaveChangesAsync();
        return files.Select(f => f.FileGuid).ToArray();
    }

    public async Task<LoadedFile?> FindFile(Guid fileGuid) =>
        await dbContext.LoadedFiles.SingleOrDefaultAsync(f => f.FileGuid == fileGuid);

    public async Task DeleteFile(LoadedFile file)
    {
        dbContext.LoadedFiles.Remove(file);
        await dbContext.SaveChangesAsync();
    }
}