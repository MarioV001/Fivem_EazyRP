using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using System.Threading.Tasks;

namespace MyResource.Client
{
    internal class Valete
    {
        private static Vehicle ValetVeh;
        private static int ValetVehBlip;
        private static Ped ValetPed;
        private static bool ValleteSpawned;
        private static bool EventOnScene;

        private static Vector3 TargetLoc = new Vector3();
        public static async void Summon()
        {
            Ped player = Game.Player.Character;
            Screen.ShowNotification("The Valete is on his way to you now");

            //Get location
            Vector3 SpawnLocation = new Vector3();
            float spawnHeading = 0F;
            int UnUsed = 0;
            API.GetNthClosestVehicleNodeWithHeading(player.Position.X, player.Position.Y, player.Position.Z, 30,ref SpawnLocation,ref spawnHeading,ref UnUsed, 9, 3.0F, 2.5F);
            await Extensions.LoadModel((uint)VehicleHash.Infernus2);
            //Create Vehicle
            ValetVeh = await World.CreateVehicle(VehicleHash.Infernus2, SpawnLocation, spawnHeading);
            ValetVeh.Mods.PrimaryColor = VehicleColor.MetallicFrostWhite;
            ValetVeh.Mods.LicensePlate = $"{Game.Player.Name}";

            //Blip
            ValetVehBlip = API.AddBlipForEntity(ValetVeh.Handle);
            
            API.SetBlipColour(ValetVehBlip, 81);
            API.BeginTextCommandSetBlipName("STRING");
            API.AddTextComponentString("Valete");
            API.EndTextCommandSetBlipName(ValetVehBlip);

            //Driver
            await Extensions.LoadModel((uint)PedHash.Valet01SMY);
            ValetPed = await World.CreatePed(PedHash.Valet01SMY,SpawnLocation);
            ValetPed.SetIntoVehicle(ValetVeh, VehicleSeat.Driver);//set ped to vehicle
            ValetPed.CanFlyThroughWindscreen = false;
            ValetPed.CanSufferCriticalHits = false;

            //Config
            float TargetHeading = 0F;
            API.GetClosestVehicleNodeWithHeading(player.Position.X, player.Position.Y, player.Position.Z, ref TargetLoc, ref TargetHeading,1,3.0F,0);
            ValetPed.Task.DriveTo(ValetVeh, TargetLoc, 10F, 20F,262972);

            ValleteSpawned = true;
        }

        public async static void UpdateLoop()
        {
            if (ValleteSpawned)
            {
                if(!EventOnScene && API.GetDistanceBetweenCoords(ValetVeh.Position.X, ValetVeh.Position.X, ValetVeh.Position.X, TargetLoc.X, TargetLoc.X, TargetLoc.X,true) < 10F)
                {
                    EventOnScene = true;
                    ValetPed.Task.ClearAllImmediately();
                    API.SetVehicleForwardSpeed(ValetVeh.Handle, 0F);
                    //API.TaskLeaveVehicle(ValetPed.Handle, ValetVeh.Handle, 0);
                    ValetPed.Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
                    await BaseScript.Delay(1000);
                }
            }
        }

        
    }
}
