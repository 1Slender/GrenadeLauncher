using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenadeLauncher
{
    class CGrenade : CustomItem
    {
        public override uint Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override float Weight { get; set; }
        public override SpawnProperties SpawnProperties { get; set; }
    }
}
