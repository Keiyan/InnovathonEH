using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerHermesInnovathon.Model.Client
{
    public enum ClientActionType
    {
        Sms,
        Email,
        Callback
    }

    public class ClientAction
    {
        public ClientActionType ActionType { get; set; }

        public string ActionData { get; set; }
    }
}
