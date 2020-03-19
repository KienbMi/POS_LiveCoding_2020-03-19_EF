using System.Diagnostics.Tracing;
using Serilog;

namespace LiveCoding.Util
{
  public class MyLogger
  {
    public static SqlCommandLogObserver SqlCommandLogObserver { get; set; }

    public static void InitializeLogger()
    {
      SqlCommandLogObserver = new SqlCommandLogObserver();

      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console()
        .WriteTo.File("SqlCommands.log")
        .WriteTo.Observers(events => events.Subscribe(SqlCommandLogObserver))
        .CreateLogger();
    }

    
  }
}
