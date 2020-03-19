using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCoding.Core.Contracts
{
  public interface ISchoolRepository
  {
    School[] GetAll();
    SchoolWithPupilCountDto[] GetAllSchoolsWithPupilCount();
    (School School, int CntOfPupil)[] GetAllSchoolsWithPupilCountAsNamedTuple();

    void Add(School school);

    void RemoveRange(IEnumerable<School> schools);
  }

  public class SchoolWithPupilCountDto
  {
    public School School { get; set; }
    public int CntOfPupils { get; set; }
  }
}
