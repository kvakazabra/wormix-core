using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("arena/get")]
public class GetArenaController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = PostRequest(gameSerializable, session).ToObject<JObject>()!;
        switch (result["type"]!.ToString())
        {
            case "ArenaResult":
                return result["data"]!.ToObject<ArenaResult>();
            case "ArenaLocked":
                return result["data"]!.ToObject<ArenaLocked>();
        }

        return new ArenaLocked
        {
            CurrentMission = 0,
            Delay = 0,
            ErrorCode = 500
        };
    }
}