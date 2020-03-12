using System;
using System.Linq;
using LiveCoding.Core;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveCoding.Persistence.Migrations
{
  public partial class AddSampleData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        ctx.Schools.Add(new School()
        {
          City = new City(4020, "Linz"),
          Name = "HTL Paul Hahn",
          Schooltype = Schooltype.Htl
        });

        ctx.SaveChanges();
      }
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        School paulHahn = ctx.Schools.FirstOrDefault();

        if (paulHahn != null)
        {
          ctx.Schools.Remove(paulHahn);
        }

        ctx.SaveChanges();
      }
    }
  }
}
