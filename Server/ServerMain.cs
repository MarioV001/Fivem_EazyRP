using System;
using CitizenFX.Core;

namespace MyResource.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("");
            Debug.WriteLine("--------------------------");
            Debug.WriteLine(" MV001 C# Resource Loaded");
            Debug.WriteLine("--------------------------");
            Debug.WriteLine("");

            EventHandlers["SavePlayerPos"] += new Action<string, Vector3>(SavePosFunction);
            // In class constructor
            EventHandlers["playerConnecting"] += new Action<Player, string, dynamic, dynamic>(OnPlayerConnecting);
            EventHandlers["playerDropped"] += new Action<Player, string>(OnPlayerDisconnect);
            EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawned);
            //custom
            //EventHandlers["mvrS:cleanClothes"] += new Action<int>(CleanPlayerClothes);
        
        }

        private void CleanPlayerClothes(int PlayerID)
        {
            Player playerid = Players[PlayerID];

            //Player players = new Player().id;
        }

        private void OnPlayerSpawned(object spawned)
        {
            Console.WriteLine("player spawned");
        }

        private async void OnPlayerConnecting([FromSource] Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            deferrals.defer();
            // mandatory wait!
            await Delay(0);
            var licenseIdentifier = player.Identifiers["license"];

            Debug.WriteLine($"\t\tIncoming Connection: {playerName}");
            deferrals.update($"Hello {playerName}, your license [{licenseIdentifier}] is being checked");
            deferrals.done();
        }

        private void OnPlayerDisconnect([FromSource] Player player, string reason)
        {
            Debug.WriteLine($"\t\tPlayer {player.Name} Disconnect (Reason: {reason}).");
        }

        private void SavePosFunction(string PosName, Vector3 position)
        {

            System.IO.File.AppendAllText("D:\\FXServer\\cfx-server-data\\save\\locaitons.txt", PosName +" - "+position.ToString() + Environment.NewLine);
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");

           //API.RegisterCommand("valete", new Action(SummonValete), false);
        }
    }
}