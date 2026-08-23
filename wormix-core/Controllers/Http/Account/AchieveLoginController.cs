using wormix_core.Controllers.Http.Attributes;
using wormix_core.Facades;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("achievements/login")]
public class AchieveLoginController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        JObject result = PostRequest(gameSerializable, session).ToObject<JObject>()!;

        switch (result["type"]!.ToString())
        {
            case "AchieveLoginSuccess":
                return result["data"]!.ToObject<AchieveLoginSuccess>();
            case "AchieveLoginError":
                return result["data"]!.ToObject<AchieveLoginError>();
        }

        return new AchieveLoginError
        {
            Code = 500
        };
    }
}