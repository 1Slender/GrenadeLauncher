
using CommandSystem;
using Exiled.API.Features;
using System;

namespace GrenadeLauncher
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Test : ICommand
    {
        public string Command { get; } = "GTest";

        public string[] Aliases { get; } = { "gtest" };

        public string Description { get; } = "GlunTEST";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!Exiled.Permissions.Extensions.Permissions.CheckPermission(sender, "test"))
            {
                response = "Не достаточно прав";
                return false;
            }
            
            response = "None!";
            return true;
        }
    }
}
