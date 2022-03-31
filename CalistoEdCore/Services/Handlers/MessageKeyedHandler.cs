using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalistoEdCore.Services.Handlers;
public sealed class MessageKeyedHandler : MessageHandler
{



    public MessageKeyedHandler(in HttpClient wClient) : base()
    {
    }
}
