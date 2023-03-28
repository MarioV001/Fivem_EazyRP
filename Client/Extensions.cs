using CitizenFX.Core.Native;
using CitizenFX.Core;
using System.Threading.Tasks;

namespace MyResource.Client
{
    internal class Extensions 
    {

        public static void DisplayMSG(string msg,int time)
        {
            API.ClearPrints();
            API.SetTextEntry_2("STRING");
            API.AddTextComponentString(msg);
            API.DrawSubtitleTimed(time, true);
        }
        public static async Task<bool> LoadModel(uint model)
        {
            if (!API.IsModelInCdimage(model))
            {
                Debug.WriteLine($"Invalid model {model} was suplied to LoadModel!");
                return false;
            }
            API.RequestModel(model);
            while (!API.HasModelLoaded(model))
            {
                Debug.WriteLine($"Waiting for model {model} to load");
                await BaseScript.Delay(100);
            }
            return true;
        }

        /// <summary>
        /// This hould be called every fram to clear memmory
        /// </summary>
        public static void DisableTrafficAI()
        {
            API.SetPedDensityMultiplierThisFrame(0.0F);
            API.SetScenarioPedDensityMultiplierThisFrame(0.0F, 0.0F);
            API.SetVehicleDensityMultiplierThisFrame(0.0F);
            API.SetRandomVehicleDensityMultiplierThisFrame(0.0F);
            API.SetParkedVehicleDensityMultiplierThisFrame(0.0F);
        }
    }
}
