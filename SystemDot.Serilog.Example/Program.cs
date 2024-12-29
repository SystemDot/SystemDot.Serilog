using Serilog;
using Serilog.Formatting.Display;
using SystemDot.Serilog.Formatting;

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console(new RemoveNewLines())
        .CreateLogger();
    
    Log.Logger.Information("Hello World");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}