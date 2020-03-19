using System;
using System.Linq;
using System.Threading.Channels;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;
using LiveCoding.Persistence;
using LiveCoding.Persistence.InMemory;
using LiveCoding.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiveCoding.ConsoleApp
{
  class Program
  {
    

    static void Main(string[] args)
    {
      InitData();

      using (IUnitOfWork uow = new UnitOfWork())
      {
        //EntityFrameworkPupilRepository entityFrameworkPupilRepository = new EntityFrameworkPupilRepository(ctx);
        //InMemoryPupilRepository inMemoryPupilRepository = new InMemoryPupilRepository();
        
        PrintAbendschule(uow.PupilRepository);
        PrintKolleg(uow.PupilRepository);
        PrintSchoolOverview(uow.SchoolRepository);
        
      }
    }

    private static void PrintSchoolOverview(ISchoolRepository schoolRepository)
    {
      (School School, int CntOfPupils)[] result = schoolRepository.GetAllSchoolsWithPupilCountAsNamedTuple();
      foreach (var entry in result)
      {
        Console.WriteLine($"-> School: {entry.School.Name} [{entry.CntOfPupils}]");
      }
    }

    private static void PrintKolleg(IPupilRepository pupilRepository)
    {
      Pupil[] pupils = pupilRepository.GetPupilsByRegistrationTypeWithSchool(Registrationtype.Kolleg);

      Console.WriteLine("Kolleg:");
      foreach (var pupil in pupils)
      {
        //Console.WriteLine($"Pupil: ''{pupil}' School: {pupil.School.Name} City: {pupil.School.City.Name}");
        Console.WriteLine($"Pupil: ''{pupil}'");
      }
    }

    private static void PrintAbendschule(IPupilRepository pupilRepository)
    {
      Pupil[] pupils = pupilRepository.GetPupilsByRegistrationTypeWithSchool(Registrationtype.Abendschule);

      Console.WriteLine("Abendschule:");
      foreach (var pupil in pupils)
      {
        //Console.WriteLine($"Pupil: ''{pupil}' School: {pupil.School.Name} City: {pupil.School.City.Name}");
        Console.WriteLine($"Pupil: ''{pupil}'");
      }
    }

    private static void InitData()
    {
      using (IUnitOfWork uow = new UnitOfWork()) 
      {
        // Remove all the data from the db
        uow.PupilRepository.RemoveRange(uow.PupilRepository.GetAll());
        uow.SchoolRepository.RemoveRange(uow.SchoolRepository.GetAll());

        School htlLeonding = new School()
        {
          Principal = "Wolfgang Holzer",
          Name = "HTL Leonding",
          Schooltype = Schooltype.Htl,
          City = new City( 4060, "Leonding")
        };


        uow.PupilRepository.AddRange(new[] {
          new Pupil()
            {
              FirstName = "Oscar",
              LastName = "Yim",
              Birhtdate = new DateTime(1997, 06, 24),
              School = htlLeonding,
              Registrationtype = Registrationtype.Abendschule
            },
          new Pupil()
            {
              FirstName = "Pascal",
              LastName = "Königshofer",
              Birhtdate = new DateTime(1995, 02, 13),
              School = htlLeonding,
              Registrationtype = Registrationtype.Abendschule
            },
          new Pupil()
          {
            FirstName = "Michael",
            LastName = "Kienberger",
            Birhtdate = new DateTime(1977, 06, 17),
            School = htlLeonding,
            Registrationtype = Registrationtype.Kolleg
          },
          new Pupil()
          {
            FirstName = "Kolev",
            LastName = "Zvonko",
            Birhtdate = new DateTime(1975, 04, 13),
            School = htlLeonding,
            Registrationtype = Registrationtype.Kolleg
          }

        });
        
        uow.SchoolRepository.Add(htlLeonding);

        int cntOfChanges = uow.SaveChanges();
        Console.WriteLine($"changes: {cntOfChanges}");
        
      }
    }
  }
}
