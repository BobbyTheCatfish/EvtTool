using EvtTool.IO;

namespace EvtTool
{
    public sealed class LbxCommandData : CommandData
    {
        public int Field00 { get; set; }
        public byte Field04 { get; set; }
        public bool Field05 { get; set; }
        public short Static06 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 2
            Field00 = reader.ReadInt32();
            // 1 or 2
            Field04 = reader.ReadByte();
            Field05 = reader.ReadBoolean();

            Static06 = reader.ReadInt16();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field05 );
            writer.Write( Static06 );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}
