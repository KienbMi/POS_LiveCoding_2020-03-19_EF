using System;
using LiveCoding.Core.Contracts;
using LiveCoding.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
using Utils;

namespace LiveCoding.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _dbContext;

    public IPupilRepository PupilRepository { get; }

    public UnitOfWork()
    {
      _dbContext = new ApplicationDbContext();
      
      PupilRepository = new EFPupilRepository(_dbContext);

      MyLogger.InitializeLogger();

      var serviceProvider = _dbContext.GetInfrastructure();
      var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
      loggerFactory.AddSerilog();
    }


    public int SaveChanges()
    {
      try
      {
        return _dbContext.SaveChanges();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        throw;
      }
    }

    public void DeleteDatabase() => _dbContext.Database.EnsureDeleted();

    public void MigrateDatabase() => _dbContext.Database.Migrate();

    public void Dispose()
    {
      _dbContext?.Dispose();
    }
  }
}
