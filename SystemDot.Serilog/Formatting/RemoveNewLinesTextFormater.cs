﻿using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace SystemDot.Serilog.Formatting;

public class RemoveNewLinesTextFormater : RemoveStringTextFormater
{
    public RemoveNewLinesTextFormater(
        ITextFormatter? textFormatter = null) : base(
        textFormatter ?? new MessageTemplateTextFormatter("[{Timestamp:u} {Level:u3}] {Message:lj} {Exception}", null),
        ("\n", "\\n"),
        ("\r", "\\r"))
    {
    }

    public RemoveNewLinesTextFormater(
        string? outputTemplate = "[{Timestamp:u} {Level:u3}] {Message:lj} {Exception}") : base(
        new MessageTemplateTextFormatter(outputTemplate, null),
        ("\n", "\\n"),
        ("\r", "\\r"))
    {
    }
}