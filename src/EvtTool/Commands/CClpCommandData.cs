using EvtTool.IO;

namespace EvtTool
{
    public sealed class CClpCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public float Field08 { get; set; }
        public float Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadSingle();
            Field0C = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}