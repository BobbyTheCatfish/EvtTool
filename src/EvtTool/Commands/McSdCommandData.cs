using EvtTool.IO;

namespace EvtTool
{
    public sealed class McSdCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public int Static14 { get; set; } = 0;
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 3
            Field00 = reader.ReadInt32();
            // fairly large number
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            // fairly large number
            Field10 = reader.ReadInt32();

            Static14 = reader.ReadInt32();
            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
            
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Static14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
        }
    }
}
