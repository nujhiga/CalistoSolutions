using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalistoEdCore.Services.Providers;
internal static class SerializerProvider
{
    private const string Encoding = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
    private const string EnvelopeOpen = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:aula=\"urn:Educativa/Aula/\">";
    private const string Header = "<soapenv:Header/>";
    private const string BodyOpen = "<soapenv:Body>";
    private const string BodyClose = "</soapenv:Body>";
    private const string EnvelopeClose = "</soapenv:Envelope>";

    private const string OpenStatament = "<aula:";
    private const string CloseStatament = "</aula:";
    private const char CloseOpenStatament = '>';

    private static string GetMessageHeader(ref StringBuilder _sbuilder)
    {
        if (_sbuilder.Length > 0)
            _sbuilder.Clear();

        _sbuilder.AppendLine(Encoding);
        _sbuilder.AppendLine(EnvelopeOpen);
        _sbuilder.AppendLine(Header);
        _sbuilder.AppendLine(BodyOpen);

        string messageHeader = _sbuilder.ToString();

        _sbuilder.Clear();
        _sbuilder = new StringBuilder();

        return messageHeader;
    }
    private static string GetMessageFooter(ref StringBuilder _sbuilder)
    {
        _sbuilder.AppendLine(BodyClose);
        _sbuilder.AppendLine(EnvelopeClose);

        string messageFooter = _sbuilder.ToString();

        _sbuilder.Clear();
        _sbuilder = new StringBuilder();

        return messageFooter;
    }
    public static (StringBuilder, string, string) GetHeaderFooter()
    {
        StringBuilder sb = new();
        return (sb, GetMessageHeader(ref sb), GetMessageFooter(ref sb));
    }

    public static string GetStatamen<TSing>(TSing Sign) => $"{OpenStatament}{Sign}{CloseOpenStatament}";
    public static string GetCloseStatamen<TSing>(TSing Sign) => $"{CloseStatament}{Sign}{CloseOpenStatament}";
    public static string GetStatamen<TSing>(TSing Sign, object? objValue)
    {
        if (objValue is not { } value)
            value = string.Empty;

        StringBuilder sb = new();

        string closeStatamentDef = $"{Sign}{CloseOpenStatament}";

        sb.Append($"{OpenStatament}{closeStatamentDef}");
        sb.Append($"{value}");
        sb.Append($"{CloseStatament}{closeStatamentDef}");

        return sb.ToString();
    }
}
