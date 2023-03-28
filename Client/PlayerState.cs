

namespace MyResource.Client
{
    public class PlayerState
    {
        /// <para>Does the player have weapons?</para>
        /// <para>This is refreshed on each respawn.</para>
        /// </summary>
        public bool WeaponsGiven { get; set; } = false;
        /// <summary>
        /// <para>Was the player's death reported to the server yet?</para>
        /// <para>This is refreshed on each respawn.</para>
        /// </summary>
        public bool DeathReported { get; set; } = false;
        /// <summary>
        /// Last weapon the player had equipped.
        /// </summary>
        public int LastWeaponEquipped { get; set; } = default;
    }
}
