using System.Text;
using Serilog.Events;
using Serilog.Formatting;

namespace SystemDot.Serilog.Formatting;

public class RemoveStringTextFormater(
    ITextFormatter textFormatter,
    params (string OldValue, string NewValue)[] replaceStrings)
    : ITextFormatter
{
    protected int DefaultWriteBufferCapacity = 256;

    public void Format(LogEvent logEvent, TextWriter output)
    {
        var writerBuffer = new StringWriter(new StringBuilder(DefaultWriteBufferCapacity));

        textFormatter.Format(logEvent, writerBuffer);

        var logText = writerBuffer.ToString();
        foreach (var replaceString in replaceStrings)
        {
            logText = logText.Replace(replaceString.OldValue, replaceString.NewValue);
        }

        output.WriteLine(logText.Trim());
        output.Flush();
    }
}
