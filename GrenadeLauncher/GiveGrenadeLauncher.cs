
using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using System;

namespace GrenadeLauncher
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class GiveGrenadeLauncher : ICommand
    {
        public string Command { get; } = "GiveGrenadeLauncher";

        public string[] Aliases { get; } = { "givegrenadegauncher", "grenadelauncher", "grenl", "glaun" };

        public string Description { get; } = "Выдаёт себе GrenadeLauncher/nglaun *айди*";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!Exiled.Permissions.Extensions.Permissions.CheckPermission(sender, "glaun"))
            {
                response = "Не достаточно прав";
                return false;
            }

            string arg = "";
            foreach (string i in arguments)
            {
                arg += i + " ";
            }

            if (arguments.Count > 0)
            {
                player = Player.Get(Convert.ToInt32(arguments.Array[1]));
            }

            CustomItem.Get(typeof(GrenadeLauncher)).Give(player);

            response = "The command wat not a success!";
            return true;
        }
    }
}
