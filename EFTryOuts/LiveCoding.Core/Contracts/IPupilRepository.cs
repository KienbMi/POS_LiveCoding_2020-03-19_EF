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
    void Delete(int id);
    void Update(Pupil pupil);
  }
}
