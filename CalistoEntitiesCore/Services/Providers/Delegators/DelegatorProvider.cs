//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using CalistoEdCore;

//using CalistoStandards.Definitions.Structures.Cls;
//using CalistoEnvironment.Services.Providers.Gateways;

//using System.Collections;

//namespace CalistoEnvironment.Services.Providers;
//internal static class DelegatorProvider
//{
//    internal static Action CretentialsDelegate => SetHttpClientCredentials;
//    internal static Action MessageCountDelegate(ClElementType mtype) => () => AddMessageCount(mtype);
//    internal static Func<int> GetMessageCountDelegate(ClElementType mtype) => () => GetMessageCount(mtype);
//    internal static Func<HttpClient> GetWsClientDelegate => () => ClEnvironment.WsClient;


//    private static void AddMessageCount(ClElementType mtype)
//    {
//        var instance = ClEnvironment.Instance;

//        if (mtype is ClElementType.Message)
//            instance.MessagesCount++;
//        else if (mtype is ClElementType.Request)
//            instance.RequestsCount++;
//        else if (mtype is ClElementType.Response)
//            instance.ResponsesCount++;
//    }
//    private static int GetMessageCount(ClElementType msgType)
//    {
//        var instance = ClEnvironment.Instance;

//        return msgType switch
//        {
//            ClElementType.Message => instance.MessagesCount,
//            ClElementType.Request => instance.RequestsCount,
//            ClElementType.Response => instance.ResponsesCount,
//            _ => 0
//        };
//    }

//    private static void SetHttpClientCredentials()
//    {
//        const string Basic = "Basic";

//        GatewayProvider gate = ClEnvironment.Instance.Gateway;
//        CampusTarget campus = gate.CurrentCampus;

//        string preAuthString = GetPreAuthString(in gate);
//        string authString = Convert.ToBase64String(Encoding.Default.GetBytes(preAuthString));

//        ClEnvironment.WsClient.DefaultRequestHeaders.Authorization =
//            new AuthenticationHeaderValue(Basic, authString);
//    }

//    private static string GetPreAuthString(in GatewayProvider gate)
//    {
//        CampusTarget campus = gate.CurrentCampus;

//        StringBuilder sb = new();
//        sb.Append(gate.GetUsAccess(campus.Source));
//        sb.Append(":");
//        sb.Append(gate.GetPwAccess(campus.Source));
//        string preAuthString = sb.ToString();
//        sb.Clear();
//        sb.Capacity = 0;
//        sb.Length = 0;

//        return preAuthString;
//    }
//}