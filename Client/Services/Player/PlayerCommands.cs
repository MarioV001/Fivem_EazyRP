using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client.Services.Player
{
    internal class PlayerCommands : BaseScript
    {
        public static void RegisterPlayerCommands(string resourceName)
        {
            RegisterCommand("veh", new Action<int, List<object>, string>(async (source, args, raw) =>
            {
                // account for the argument not being passed
                var model = "adder";
                if (args.Count > 0)
                {
                    model = args[0].ToString();
                }

                // check if the model actually exists
                // assumes the directive `using static CitizenFX.Core.Native.API;`
                var hash = (uint)GetHashKey(model);
                if (!IsModelInCdimage(hash) || !IsModelAVehicle(hash))
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[CarSpawner]", $"Vehicle {model}. is invalid!" }
                    });
                    return;
                }

                // create the vehicle
                var vehicle = await World.CreateVehicle(model, Game.PlayerPed.Position, Game.PlayerPed.Heading);

                // set the player ped into the vehicle and driver seat
                Game.PlayerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);

                // tell the player
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[CarSpawner]", $"Spawned ^*{model}!" }
                });
            }), false);

            //
            //
            //
            RegisterCommand("valete", new Action(Valete.Summon), false);

            RegisterCommand("SavePos", new Action<int, List<object>, string>((source, args, raw) =>
            {
                // account for the argument not being passed
                string PosName = "";
                if (args.Count > 0)
                {
                    PosName = args[0].ToString();
                }

                // check if the model actually exists
                // assumes the directive `using static CitizenFX.Core.Native.API;`
                if (PosName == null || PosName == "")
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[SavePos]", $"Please Give a name for the Save Position!" }
                    });
                    return;
                }

                // Save The Pos

                Vector3 PlayerPos;
                PlayerPos = new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);
                TriggerServerEvent("SavePlayerPos", PosName, PlayerPos);

                // tell the player
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[SavePos]", $"Position Saved *{PosName}*" }
                });
            }), false);
        }
    }
}
