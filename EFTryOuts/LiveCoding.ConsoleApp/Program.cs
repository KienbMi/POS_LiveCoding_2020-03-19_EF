using System;
using System.Linq;
using System.Threading.Channels;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;
using LiveCoding.Persistence;
using LiveCoding.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiveCoding.ConsoleApp
{
  class Program
  {
    

    static void Main(string[] args)
    {
      InitData();


      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        //EntityFrameworkPupilRepository entityFrameworkPupilRepository = new EntityFrameworkPupilRepository(ctx);
        InMemoryPupilRepository inMemoryPupilRepository = new InMemoryPupilRepository();
        PrintAbendschule(inMemoryPupilRepository);
        PrintKolleg(inMemoryPupilRepository);
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
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        // Remove all the data from the db
        ctx.Pupils.RemoveRange(ctx.Pupils);
        ctx.Schools.RemoveRange(ctx.Schools);

        School htlLeonding = new School()
        {
          Principal = "Wolfgang Holzer",
          Name = "HTL Leonding",
          Schooltype = Schooltype.Htl,
          City = new City( 4060, "Leonding")
        };


        ctx.Pupils.AddRange(new[] {
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
        ctx.Schools.Add(htlLeonding);

        ctx.SaveChanges();
      }
    }
  }
}
