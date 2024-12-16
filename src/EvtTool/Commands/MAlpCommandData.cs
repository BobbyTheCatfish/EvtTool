using EvtTool.IO;

namespace EvtTool
{
    public sealed class MAlpCommandData : CommandData
    {
        public int AlphaLevel { get; set; }
        public int Static00 { get; set; } = 0;
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // this is pretty weird chief... 0-255 but also huge values in + and -
            AlphaLevel = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            // 0-3 but also could be a very large number
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write(AlphaLevel);
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
