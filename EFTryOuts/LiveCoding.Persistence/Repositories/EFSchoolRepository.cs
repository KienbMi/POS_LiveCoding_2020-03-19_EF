using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;

namespace LiveCoding.Persistence.Repositories
{
  class EFSchoolRepository : ISchoolRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public EFSchoolRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public (School School, int CntOfPupil)[] GetAllSchoolsWithPupilCountAsNamedTuple()
      => _dbContext
        .Schools
        .Select(s => new { School = s, CntOfPupil = s.Pupils.Count })
        .OrderByDescending(_ => _.CntOfPupil)
        .ToArray()
        .Select(_ => (_.School, _.CntOfPupil))
        .ToArray();


    public School[] GetAll() =>
      _dbContext
        .Schools
        .OrderBy(s => s.Name)
        .ToArray();

    public SchoolWithPupilCountDto[] GetAllSchoolsWithPupilCount()
      => _dbContext
          .Schools
          .Select(s => new SchoolWithPupilCountDto() { School = s, CntOfPupils = s.Pupils.Count })
          .OrderByDescending(_ => _.CntOfPupils)
          .ToArray();


    public void Add(School school) => _dbContext.Schools.Add(school);

    public void RemoveRange(IEnumerable<School> schools) => _dbContext.Schools.RemoveRange(schools);

  }
}
