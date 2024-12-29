using Serilog.Formatting;

namespace SystemDot.Serilog.Formatting;

public class RemoveNewLines : RemoveStringTextFormater
{
    public RemoveNewLines(ITextFormatter textFormatter) : base(
        textFormatter,
        ("\n", "\\n"),
        ("\r", "\\r"))
    {
    }
}