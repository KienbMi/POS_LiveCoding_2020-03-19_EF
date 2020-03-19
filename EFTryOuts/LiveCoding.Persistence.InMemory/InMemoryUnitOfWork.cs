using System;
using LiveCoding.Core.Contracts;
using LiveCoding.Persistence.InMemory.Repositories;

namespace LiveCoding.Persistence.InMemory
{
  public class InMemoryUnitOfWork : IUnitOfWork
  {
    public InMemoryUnitOfWork()
    {
      PupilRepository = new InMemoryPupilRepository();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IPupilRepository PupilRepository { get; }
    public ISchoolRepository SchoolRepository { get; }
    public int SaveChanges()
    {
      throw new NotImplementedException();
    }

    public void DeleteDatabase()
    {
      throw new NotImplementedException();
    }

    public void MigrateDatabase()
    {
      throw new NotImplementedException();
    }
  }
}
