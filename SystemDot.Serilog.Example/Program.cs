using Serilog;
using Serilog.Formatting.Display;
using SystemDot.Serilog.Formatting;

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console(new RemoveNewLines(new MessageTemplateTextFormatter("[{Timestamp:u} {Level:u3}] {Message:lj} {Exception}")))
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