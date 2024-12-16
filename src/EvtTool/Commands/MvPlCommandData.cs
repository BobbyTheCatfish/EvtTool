using EvtTool.IO;

namespace EvtTool
{
    public sealed class MvPlCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0-3
            Field00 = reader.ReadInt32();
            // 0-21
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();

            // 0 or 240
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Field0C );
        }
    }
}
