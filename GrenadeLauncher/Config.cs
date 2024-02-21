
using Exiled.API.Interfaces;

namespace GrenadeLauncher
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        public GrenadeLauncher grenadeLauncher { get; set; } = new GrenadeLauncher();
    }
}
