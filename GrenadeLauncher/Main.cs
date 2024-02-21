
using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using System;

namespace GrenadeLauncher
{
    public class Main : Plugin<Config>
    {
        public static Main Plugin { get; private set; }
        public override string Author { get; } = "Shoulate";
        public override string Name { get; } = "GrenadeLauncher";
        public override Version Version { get; } = new Version(1, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);

        public override void OnEnabled()
        {
            Plugin = this;
            
            Config.grenadeLauncher.Register();

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();

            base.OnDisabled();
        }
    }
}
