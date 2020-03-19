using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCoding.Core.Contracts
{
  public interface IPupilRepository
  {
    Pupil[] GetAll();
    Pupil[] GetPupilsByRegistrationTypeWithSchool(Registrationtype registrationtype);

    void Add(Pupil pupil);
    void AddRange(IEnumerable<Pupil> pupils);
    
    void Delete(int id);
    void RemoveRange(IEnumerable<Pupil> pupils);

    void Update(Pupil pupil);
    
    
    
  }
}
