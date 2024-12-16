using EvtTool.IO;

namespace EvtTool
{
    public sealed class PRumCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public bool Field0C { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read(Command command, EndianBinaryReader reader )
        {
            // 0-2
            Field00 = reader.ReadInt32();
            // small. probably used for intensity
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32() == 1;
            // small. not sure of purpose
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();

            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
        }
    }
}
