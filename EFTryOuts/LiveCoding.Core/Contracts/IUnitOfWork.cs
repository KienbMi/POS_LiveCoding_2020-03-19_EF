using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCoding.Core.Contracts
{
  public interface IUnitOfWork : IDisposable
  {
    // Repositories
    IPupilRepository PupilRepository { get; }
    ISchoolRepository SchoolRepository { get; }

    // UoW abzuschließen
    int SaveChanges();

    // Zusätzliche Hilfsmethoden
    void DeleteDatabase();

    void MigrateDatabase();
  }
}
