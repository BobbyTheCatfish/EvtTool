using EvtTool.IO;

namespace EvtTool
{
    public sealed class AlEfCommandData : CommandData
    {
        public byte EffectIndex { get; set; }
        public int Unused00 { get; set; } = 0;
        public byte Unused05 { get; set; } = 0;
        public short Unused06 { get; set; } = 0;
        public int Unused08 { get; set; } = 0;
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            EffectIndex = reader.ReadByte();
            Unused05 = reader.ReadByte();
            Unused06 = reader.ReadInt16();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer)
        {
            writer.Write( Unused00 );
            writer.Write( EffectIndex );
            writer.Write( Unused05 );
            writer.Write( Unused06 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
