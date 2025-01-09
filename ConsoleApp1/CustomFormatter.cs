using System.Runtime.Intrinsics.Arm;

namespace ConsoleApp1;

internal sealed class CustomFormatter : IFormatProvider, ICustomFormatter
{
    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter)) return this;
        return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
    }

    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        string s;

        IFormattable formattable = arg as IFormattable;
        if (formattable == null)
        {
            s = arg.ToString();
            
        }
        else
        {
            s = formattable.ToString(format, formatProvider); 
        }

        if (arg.GetType() == typeof(Int32))
        {
            return "THIS IS INT" + s + " VALUE";
        }

        return s;
    }
}