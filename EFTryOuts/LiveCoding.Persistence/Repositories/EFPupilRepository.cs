using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LiveCoding.Persistence.Repositories
{
  class EFPupilRepository : IPupilRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public EFPupilRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Pupil[] GetAll() =>
        _dbContext.Pupils
          .Include(p => p.School)
          .ThenInclude(s => s.City)
          .ToArray();

    public Pupil[] GetPupilsByRegistrationTypeWithSchool(Registrationtype registrationtype) =>
        _dbContext.Pupils
          .Include(p => p.School)
          .ThenInclude(s => s.City)
          .Where(p => p.Registrationtype == registrationtype)
          .ToArray();

    public void Add(Pupil pupil) =>
      _dbContext.Pupils.Add(pupil);

    public void AddRange(IEnumerable<Pupil> pupils) => _dbContext.Pupils.AddRange(pupils);

    public void Delete(int id)
    {
      //var pupil = _dbContext.Pupils
      //  .Where(p => p.Id == id)
      //  .FirstOrDefault();

      var pupil = _dbContext.Pupils.Find(id);

      if (pupil != null)
      {
        _dbContext.Pupils.Remove(pupil);
      }
    }

    public void RemoveRange(IEnumerable<Pupil> pupils) => _dbContext.Pupils.RemoveRange(pupils);


    public void Update(Pupil pupil)
    {
      //_dbContext.Pupils.Attach(pupil);
      throw new NotImplementedException();
    }
  }
}
