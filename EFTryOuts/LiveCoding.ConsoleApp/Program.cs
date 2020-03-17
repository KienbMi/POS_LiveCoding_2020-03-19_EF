using System;
using LiveCoding.Core;
using LiveCoding.Core.Contracts;
using LiveCoding.Persistence;

namespace LiveCoding.ConsoleApp
{
  class Program
  {

    static void Main(string[] args)
    {
      InitData();


      PrintAbendschule();
      PrintKolleg();
    }

    private static void PrintKolleg()
    {
      Pupil[] pupils;
      using (IUnitOfWork uow = new UnitOfWork())
      {
         pupils = uow.PupilRepository.GetPupilsByRegistrationTypeWithSchool(Registrationtype.Kolleg);
      }

      Console.WriteLine("Kolleg:");
      foreach (var pupil in pupils)
      {
        //Console.WriteLine($"Pupil: ''{pupil}' School: {pupil.School.Name} City: {pupil.School.City.Name}");
        Console.WriteLine($"Pupil: ''{pupil}'");
      }
    }

    private static void PrintAbendschule()
    {
      Pupil[] pupils;
      using (IUnitOfWork uow = new UnitOfWork())
      {
        pupils = uow.PupilRepository.GetPupilsByRegistrationTypeWithSchool(Registrationtype.Abendschule);
      }

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
          City = new City(4060, "Leonding")
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
