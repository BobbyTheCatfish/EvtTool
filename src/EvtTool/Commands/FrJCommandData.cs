using EvtTool.IO;

namespace EvtTool
{
    public sealed class FrJCommandData : CommandData
    {
        public int JumpToFrame { get; set; }
        public int Static04 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            JumpToFrame = reader.ReadInt32();

            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( JumpToFrame );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}
