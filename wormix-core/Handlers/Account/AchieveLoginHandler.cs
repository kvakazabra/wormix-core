using wormix_core.Controllers;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Serialization.Server;
using wormix_core.Session;

namespace wormix_core.Handlers.Account;

public class AchieveLoginHandler(ICommandSerializer requestSerializer, IGameController controller, TcpSession session) :
    GameMessageHandler(requestSerializer, controller, session)
{
    protected override void Process()
    {
        if (requestMessage is AchieveLogin achieveLoginRequest)
        {
            if (System.Int64.Parse(achieveLoginRequest.Id) == 0)
                throw new ArgumentException("Invalid achieve login struct");

            ISerializable result = MessageController.ProcessMessage(achieveLoginRequest, Client);
            if (result is AchieveLoginSuccess)
            {
                AchieveLoginSuccessBinarySerializer serializer = new AchieveLoginSuccessBinarySerializer();
                using MemoryStream stream = new MemoryStream();

                serializer.SerializeCommand(result, stream);
                Client.SendMessage(stream.ToArray());
            }
            else
            {
                if (result is AchieveLoginError)
                {
                    AchieveLoginErrorBinarySerializer serializer = new AchieveLoginErrorBinarySerializer();
                    using MemoryStream stream = new MemoryStream();

                    serializer.SerializeCommand(result, stream);
                    Client.SendMessage(stream.ToArray());
                }

                Thread.Sleep(1000);
                Client.CloseSession();
            }
        }
    }
}