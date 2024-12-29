using System.Text;
using Serilog.Events;
using Serilog.Formatting;

namespace SystemDot.Serilog.Formatting;

public class RemoveStringTextFormater : ITextFormatter
{
    protected int DefaultWriteBufferCapacity = 256;
    private readonly ITextFormatter _textFormatter;
    private readonly (string OldValue, string NewValue)[] _replaceStrings;

    public RemoveStringTextFormater(ITextFormatter textFormatter,
        params (string OldValue, string NewValue)[] replaceStrings)
    {
        _textFormatter = textFormatter;
        _replaceStrings = replaceStrings;
    }

    public void Format(LogEvent logEvent, TextWriter output)
    {
        var writerBuffer = new StringWriter(new StringBuilder(DefaultWriteBufferCapacity));

        _textFormatter.Format(logEvent, writerBuffer);

        var logText = writerBuffer.ToString();
        foreach (var replaceString in _replaceStrings)
        {
            logText = logText.Replace(replaceString.OldValue, replaceString.NewValue);
        }

        output.WriteLine(logText.Trim());
        output.Flush();
    }
}
