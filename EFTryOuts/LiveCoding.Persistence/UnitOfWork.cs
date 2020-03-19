using LiveCoding.Core.Contracts;
using LiveCoding.Persistence.Repositories;
using LiveCoding.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LiveCoding.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    public IPupilRepository PupilRepository { get; }
    public ISchoolRepository SchoolRepository { get; }

    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork()
    {
      MyLogger.InitializeLogger();

      Log.Information("ApplicationDbContext erzeugen ...");
      _dbContext = new ApplicationDbContext();
      Log.Information("[DONE]");

      Log.Information("Repositories erzeugen ...");
      PupilRepository = new EFPupilRepository(_dbContext);
      SchoolRepository = new EFSchoolRepository(_dbContext);
      //PupilRepository = new InMemoryPupilRepository();
      Log.Information("[DONE]");

      _dbContext
        .GetInfrastructure()
        .GetService<ILoggerFactory>()
        .AddSerilog();
    }

    public int SaveChanges() => _dbContext.SaveChanges();

    public void DeleteDatabase() => _dbContext.Database.EnsureDeleted();

    public void MigrateDatabase() => _dbContext.Database.Migrate();

    public void Dispose() => _dbContext?.Dispose();
  }
}
