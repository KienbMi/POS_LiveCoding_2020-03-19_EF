using System;

namespace LiveCoding.Core.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    IPupilRepository PupilRepository { get; }

    int SaveChanges();

    void DeleteDatabase();
    void MigrateDatabase();
  }
}
