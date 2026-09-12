using wormix_core.Controllers.Http.Attributes;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Session;

namespace wormix_core.Controllers.Http.Account;

[ApiPost("cookies/set")]
public class SetCookiesController : HttpGameController
{
    public override ISerializable ProcessMessage(ISerializable gameSerializable, TcpSession? session)
    {
        PostRequest(gameSerializable, session);
        return gameSerializable; // stub, todo set return type to ISerializable?
    }
}