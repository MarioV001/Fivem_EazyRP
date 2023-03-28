using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using System;

namespace MyResource.Client.Interface.NUI
{
    public static class NUI 
    {
        public static void Send(string type, object data = null) => API.SendNuiMessage(JsonConvert.SerializeObject(new
        {
            type,
            data
        }));

        public static void RegisterCallback(string type, Action<dynamic, CallbackDelegate> callback)
        {
            API.RegisterNuiCallbackType(type);
            ClientMain.Instance.Handlers[$"__cfx_nui:{type}"] += callback; // TODO: Dispose
        }
        public static void RegisterCallbackEx(string type, Action<dynamic, CallbackDelegate> callback)
        {
            API.RegisterNuiCallbackType(type);
            Debug.WriteLine($"Type: {type} with: {callback}");
            
        }
    }
}
