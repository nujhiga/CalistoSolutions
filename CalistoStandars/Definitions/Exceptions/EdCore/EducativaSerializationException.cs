namespace CalistoStandards.Definitions.Exceptions;

public sealed class EducativaSerializationException : EducativaBuilderException
{
    public EducativaSerializationException(MessageSign messageSign, string methodName) :
        base("No se pudo serializar un metodo XML válido.")
    {
        
        HelpLink = $"On MessageSign: {messageSign}";
        Source = methodName;
    }
    public EducativaSerializationException(string methodName) :
        base("No se pudo serializar un metodo XML válido.") => Source = $"On method {methodName}";
}