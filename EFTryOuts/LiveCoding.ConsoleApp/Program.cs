using System;
using System.Linq;
using LiveCoding.Core;
using LiveCoding.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveCoding.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      InitData();
      PrintAbendschule();
    }

    private static void PrintAbendschule()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        var pupils = ctx
          .Pupils
          .Where(p => p.Registrationtype == Registrationtype.Abendschule)
          .Include(p => p.School)
          .ThenInclude(s => s.City);

        foreach (Pupil p in pupils)
        {
          Console.WriteLine(p);
        }
      }
    }

    private static void InitData()
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        // Remove all the data from the db
        ctx.Pupils.RemoveRange(ctx.Pupils);

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
