using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Game;

public class GetArenaHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) :
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is GetArena)
        {
            ISerializable response = MessageController.ProcessMessage(requestMessage, Client);
            ICommandSerializer? serializer = null;

            if (response is ArenaResult)
            {
                serializer = new ArenaResultBinarySerializer();
            }

            if (response is ArenaLocked)
            {
                serializer = new ArenaLockedBinarySerializer();
            }

            if (serializer == null)
            {
                throw new Exception("Can't get serializer for GetArena message");
            }

            serializer.SerializeCommand(response, Client.GetStream());
        }
    }
}