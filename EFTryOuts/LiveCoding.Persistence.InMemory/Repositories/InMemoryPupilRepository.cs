using System;
using System.Collections.Generic;
using System.Text;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;

namespace LiveCoding.Persistence.InMemory.Repositories
{
  class InMemoryPupilRepository : IPupilRepository
  {
    private Pupil[] _pupils = new Pupil[]
    {
      new Pupil() {LastName = "Kolev"}, 
      new Pupil() {LastName = "Gutenbrunner"}, 
    };


    public Pupil[] GetAll() => _pupils;

    public Pupil[] GetPupilsByRegistrationTypeWithSchool(Registrationtype registrationtype)
    {
      throw new NotImplementedException();
    }

    public void Add(Pupil pupil)
    {
      throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<Pupil> pupils)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<Pupil> pupils)
    {
      throw new NotImplementedException();
    }

    public void Update(Pupil pupil)
    {
      throw new NotImplementedException();
    }
  }
}
