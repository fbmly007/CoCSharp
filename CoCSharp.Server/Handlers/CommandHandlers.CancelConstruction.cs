﻿using CoCSharp.Logic;
using CoCSharp.Networking;
using CoCSharp.Networking.Messages.Commands;

namespace CoCSharp.Server.Handlers
{
    public static partial class CommandHandlers
    {
        private static void HandleCancelConstructionCommand(CoCServer server, CoCRemoteClient client, Command command)
        {
            var ccCommand = (CancelConsturctionCommand)command;
            var villageObject = client.Avatar.Home.GetVillageObject(ccCommand.VillageObjectID);
            if (villageObject is Buildable)
            {
                var buildable = villageObject as Buildable;
                buildable.CancelConstruction();
            }
            else if (villageObject is Obstacle)
            {
                var obstacle = villageObject as Obstacle;
                obstacle.CancelClearing();
            }
        }
    }
}
