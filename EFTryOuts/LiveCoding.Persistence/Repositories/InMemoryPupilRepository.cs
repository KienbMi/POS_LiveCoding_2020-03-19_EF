using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;

namespace LiveCoding.Persistence.Repositories
{
  public class InMemoryPupilRepository : IPupilRepository
  {
    public Pupil[] GetAll()
    {
      Pupil[] pupils = new[]
      {
          new Pupil() {FirstName = "Zvonko", LastName = "Kolev", Registrationtype = Registrationtype.Abendschule},
          new Pupil() {FirstName = "Oscar", LastName = "Yim", Registrationtype = Registrationtype.Kolleg}
      };

      return pupils;
    }

    public Pupil[] GetPupilsByRegistrationTypeWithSchool(Registrationtype registrationtype) =>
      GetAll()
        .Where(p => p.Registrationtype == registrationtype)
        .ToArray();

    public void Add(Pupil pupil)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public void Update(Pupil pupil)
    {
      throw new NotImplementedException();
    }
  }
}
