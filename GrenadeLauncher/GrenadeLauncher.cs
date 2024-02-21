
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;

namespace GrenadeLauncher
{
    [CustomItem(ItemType.GunLogicer)]
    public class GrenadeLauncher : CustomWeapon
    {
        public override float Damage { get; set; } = 0;
        public override uint Id { get; set; } = 20;
        public override string Name { get; set; } = "GrenadeLauncher";
        public override string Description { get; set; } = "GrenadeLauncher";
        public override float Weight { get; set; } = 10;
        public override byte ClipSize { get; set; } = 3;
        public override ItemType Type { get; set; } = ItemType.GunLogicer;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint()
                {
                    Chance = 20,
                    Location = SpawnLocationType.InsideHid,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 50,
                    Location = SpawnLocationType.Inside049Armory,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 15,
                    Location = SpawnLocationType.InsideHczArmory,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 5,
                    Location = SpawnLocationType.InsideLczArmory,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 5,
                    Location = SpawnLocationType.Inside914,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 30,
                    Location = SpawnLocationType.InsideSurfaceNuke,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 5,
                    Location = SpawnLocationType.Inside330,
                },
                new DynamicSpawnPoint()
                {
                    Chance = 40,
                    Location = SpawnLocationType.Inside173Connector,
                },
            },
        };

        protected override void OnReloading(ReloadingWeaponEventArgs ev)
        {
            ev.IsAllowed = false;
            if (ev.Firearm.Ammo >= ClipSize || ev.Player.IsReloading) return;

            foreach (Item itemInventory in ev.Player.Items)
            {
                if (itemInventory.Type == ItemType.GrenadeHE)
                {
                    itemInventory.Destroy();
                    ev.Player.ReloadWeapon();
                    ev.Firearm.MaxAmmo = ClipSize;
                    Timing.CallDelayed(4, () =>
                    {
                        ev.Firearm.Ammo++;
                    });
                    break;
                }
            }
            base.OnReloading(ev);
        }

        protected override void OnShooting(ShootingEventArgs ev)
        {
            ExplosiveGrenade explosiveGrenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, ev.Player);
            explosiveGrenade.FuseTime = 2;
            explosiveGrenade.Throw();
            base.OnShooting(ev);
        }
    }
}
