using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using MyResource.Client.Interface.NUI;
using MyResource.Client.Services.Player;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client
{

    public class ClientMain : BaseScript
    {
        /// <summary>
		/// Gets or sets the global singleton instance reference.
		/// </summary>
		/// <value>
		/// The singleton <see cref="Client"/> instance.
		/// </value>
		public static ClientMain Instance { get; protected set; }

        /// <summary>
        /// Enable/Disable Debug messages for client.
        /// </summary>
        const bool EnableDebug = true;

        public static int gTimer;//game timer update ref

        /// <summary>
        /// Local player state maintained by the client script.
        /// </summary>
        protected PlayerState PlayerState = new PlayerState();


        public EventHandlerDictionary Handlers => this.EventHandlers;

        public ClientMain()
        {
            Debug.WriteLine("");
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine(" MV001 C# Client Resource Loaded");
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine("");

            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["playerSpawned"] += new Action(PlayerSpawnedCallback);
            EventHandlers["onClientGameTypeStart"] += new Action<string>(OnClientGameTypeStart);
        }
        protected void OnClientGameTypeStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName)
            {
                Debug.WriteLine($"resourceName is invalid: {resourceName} need to be: {GetCurrentResourceName()}");
                return;
            }

            // Enable autospawn.
            Exports["spawnmanager"].setAutoSpawnCallback(new Action(AutoSpawnCallback));
            Exports["spawnmanager"].setAutoSpawn(true);
            Exports["spawnmanager"].forceRespawn();

            Tick += UpdateLoop;
        }

        /// <summary>
        /// OnPlayer Spawn Callback
        /// </summary>
        protected void PlayerSpawnedCallback()
        {
            // Refresh player's death state.
            if(EnableDebug) Debug.WriteLine("PlayerSpawnedCallback");
                    
            //TriggerServerEvent("mvrS:cleanClothes", new { PlayerId = GetPlayerServerId(PlayerId()) });

            // Enable friendly fire.
            NetworkSetFriendlyFireOption(true);
            SetCanAttackFriendly(PlayerPedId(), true, true);

            if (GameState.Robbery.IsStarted || GameState.Robbery.IsEnding)
            {
                Debug.WriteLine($"GameState: Robbery.IsInProgress: {GameState.Robbery.IsInProgress}, Robbery.IsEnding: {GameState.Robbery.IsEnding}");
                //HuntUI.DisplayObjective(ref GameState, ref PlayerState, GameState.Hunt.IsEnding);
            }
            if (GameState.IsNewPlayer)
            {
                string pName = Player.Local.Name;
                
                NUI.Send("playerName", pName);
            }
        }
        protected async Task UpdateLoop()
        {

            Extensions.DisableTrafficAI();

            //1 second update delay
            if (API.GetGameTimer() - gTimer >= 1000)
            {
                //if (EnableDebug) Debug.WriteLine("Loop");
                gTimer = API.GetGameTimer();
                ClearPlayerWantedLevel(PlayerId());
                API.EnableDispatchService(5, false);

                Valete.UpdateLoop();

                if (Game.PlayerPed != null)
                {
                    ResetPlayerStamina(PlayerId());
                }


            }
            //PlayerState.UpdateWeapons(Game.PlayerPed);

            // Make sure the player can't get cops.
            

            // Check and report player death to the server if needed.
            if (Game.Player.IsDead && !PlayerState.DeathReported)
            {
                TriggerServerEvent("sth:playerDied", new { PlayerId = Game.Player.ServerId });
                //PlayerState.DeathReported = true;
            }


            //FixCarsInSpawn();
            Wait(0);
        }
        protected void AutoSpawnCallback()
        {
            if (EnableDebug) Debug.WriteLine("AutoSpawnCallback");
            Vector3 spawnLoc = Constants.AirportSpawn;

            Exports["spawnmanager"].spawnPlayer(new { x = spawnLoc.X, y = spawnLoc.Y, z = spawnLoc.Z, model = "a_m_m_skater_01" });
        }

        public void OnClientResourceStart(string resourceName)
            {
            if (GetCurrentResourceName() != resourceName) return;
            
            
            PlayerCommands.RegisterPlayerCommands(resourceName);
        }      
    }
}