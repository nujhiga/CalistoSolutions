namespace CalistoStandards.Definitions;
public static class ClConsts
{

    public static class Namespaces
    {
        public const string ClStandardsModels = "CalistoStandards.Definitions.Models.";

    }


    public static class ClJsonReader
    {
        public const string ResourcePath = "CalistoStandards.Resources.MessagesStructs.json";
        public const string Requests = nameof(Requests);
        public const string Responses = nameof(Responses);

        public static string[] Components => new[] { Sign, Pattern, Member, Members, Node, Nodes, Container, IsMassive };

        public const string Sign = nameof(Sign);
        public const string Pattern = nameof(Pattern);
        public const string Member = nameof(Member);
        public const string Members = nameof(Members);
        public const string Node = nameof(Node);
        public const string Nodes = nameof(Nodes);
        public const string Container = nameof(Container);
        public const string IsMassive = nameof(IsMassive);
    }

    public static class ClCampus
    {
        public const string ClCampusU3F = "Untref Virtual";
        public const string ClCampusULP = "Untref Virtual - La Punta";
        public const string ClCampusU3P = "Untref Virtual - Presenciales";
    }

    public static class ClResultTranslations
    {
        public const string Success = "Exitoso";
        public const string Warning = "Adevertencia";
        public const string Failed = "Fallido";
        public const string Error = "Error";
        public const string Exception = "Error no esperado";
        public const string Invalid = "Inválido";
        public const string Valid = "Válido";
    }

    public static class ClStatusTranslations
    {
        public const string Initializing = "Inicializando";
        public const string Working = "Trabajando";
        public const string Finished = "Finalizado";
        public const string Cancelled = "Cancelado";
        public const string Cancelling = "Cancelando";
        public const string Paused = "Pausado";
        public const string Pausing = "Pauseando";
    }

    public static class ClEnviroment
    {
        public const string SetHttpCredentials = "SetHttpClientCredentials";
        public const string GetClient = nameof(GetClient);
        public const string GetCurrentDbRequestCount = nameof(GetCurrentDbRequestCount);
        public const string SetCurrentDbRequestCount = nameof(SetCurrentDbRequestCount);
        
        public const string GetCampusTarget = nameof(GetCampusTarget);
    }



}
