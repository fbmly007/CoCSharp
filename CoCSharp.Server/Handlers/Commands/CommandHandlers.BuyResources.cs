﻿using CoCSharp.Network;
using CoCSharp.Network.Messages.Commands;
using CoCSharp.Server.Core;

namespace CoCSharp.Server.Handlers.Commands
{
    public static partial class CommandHandlers
    {
        private static void HandleBuyResourcesCommand(CoCServer server, CoCRemoteClient client, Command command)
        {
            var brCommand = (BuyResourcesCommand)command;
            var embeddedCommand = brCommand.Command;

            client.ResourcesAmount.GetSlot(brCommand.ResourceDataID).Amount += brCommand.ResourceAmount;
            FancyConsole.WriteLine("[&(darkgreen)Logic&(default)] Bought resource -> {1} for account &(darkcyan){0}&(default) \n\t\tAmount: {2}",
                  client.Token, brCommand.ResourceDataID, brCommand.ResourceAmount);

            if (embeddedCommand == null)
                return;

            server.HandleCommand(client, embeddedCommand);
        }
    }
}
