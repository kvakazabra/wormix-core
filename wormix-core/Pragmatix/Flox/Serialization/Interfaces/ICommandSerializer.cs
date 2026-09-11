using wormix_core.Pragmatix.Flox.Secure;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Flox.Serialization.Interfaces;

public interface ICommandSerializer
{
    uint GetCommandId();
    void SerializeCommand(ISerializable command, Stream output);
    ISerializable DeserializeCommand(Stream input, ICommandHeader header);
}

public abstract class AbstractBinaryCommandSerializer<TCommand> : ICommandSerializer
    where TCommand : ISerializable
{
    protected abstract uint CommandId { get; }

    protected virtual bool IsSecure => false;

    public uint GetCommandId()
    {
        return CommandId;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is not TCommand)
        {
            return;
        }

        uint size = command.GetSize();

        BinaryCommandHeader header = new BinaryCommandHeader();
        header.SetCommandId(CommandId);
        header.SetLength(size + (IsSecure ? 16u : 0u));
        header.Write(output);

        if (size == 0)
        {
            return;
        }

        byte[] payload = new byte[size];
        using (MemoryStream ms = new MemoryStream(payload))
        {
            command.Serialize(ms);
        }

        output.Write(payload);

        if (IsSecure)
        {
            output.Write(SerializeSecurityUtils.Secure(payload));
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        if(header.GetCommandId() == CommandId)
        {
            throw new InvalidDataException(
                $"Serializer {GetType().Name} (commandId = {CommandId}) " +
                $"received command with id = {header.GetCommandId()}"
            );
        }

        TCommand? command = (TCommand?)Activator.CreateInstance(typeof(TCommand));
        if(command == null)
        {
            // todo resolve class name here
            throw new InvalidOperationException($"Failed to create an instance of TCommand");
        }

        command.Deserialize(input);
        return command;
    }
}