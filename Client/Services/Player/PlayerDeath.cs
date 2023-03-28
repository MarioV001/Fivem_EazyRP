using CitizenFX.Core;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace MyResource.Client.Services.Player
{
    internal class PlayerDeath : ClientServices
    {

        public bool IsDowned { get; protected set; }
        public int? DownedAt { get; protected set; }
        public Entity LastKiller { get; protected set; }

        public PlayerDeath() 
        { 
        }

        public override async Task UpdateTick()
        {

            if (Game.Player.Character.IsAlive && !this.IsDowned) return;
            // Disable heath regeneration
            SetPlayerHealthRechargeMultiplier(Game.Player.Handle, 0);

            if (Game.Player.Character.IsDead && !this.IsDowned)
            {
                this.IsDowned = true;
                this.DownedAt = Game.GameTime;
                this.LastKiller = Game.Player.Character.GetKiller();
            }

        }
    }
}
