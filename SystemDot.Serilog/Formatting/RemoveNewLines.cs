using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace SystemDot.Serilog.Formatting;

public class RemoveNewLines : RemoveStringTextFormater
{
    public RemoveNewLines(ITextFormatter? textFormatter = null) : base(
        textFormatter ?? new MessageTemplateTextFormatter("[{Timestamp:u} {Level:u3}] {Message:lj} {Exception}", null),
        ("\n", "\\n"),
        ("\r", "\\r"))
    {
    }
}