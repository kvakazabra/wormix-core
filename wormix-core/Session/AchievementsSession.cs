using wormix_core.Controllers.Http.Account;
using wormix_core.Controllers.Http.Game;
using wormix_core.Controllers.Http.Info;
using wormix_core.Controllers.Static.Account;
using wormix_core.Controllers.Static.Service;
using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Info;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Server;

namespace wormix_core.Session;

public class AchievementsSession(TcpServer server) : TcpSession(server)
{

    protected override Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new()
        {

        };
    }

    protected override void OnMessage(Stream dataStream)
    {
        ProcessMessage(dataStream);
    }
}