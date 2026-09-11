using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SelectStuff() : ISerializable
{
    public List<SelectStuffStructure> SelectStuffs = new();

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
        {
            ushort size = br.ReadUInt16Be();
            SelectStuffStructure s = new();
            s.Deserialize(input);
            SelectStuffs.Add(s);
        }
    }
}
