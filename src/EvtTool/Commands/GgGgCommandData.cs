using EvtTool.IO;

namespace EvtTool
{
    public class GgGgCommandData : CommandData
    {
        public int Unused00 { get; set; } = 0;
        public int Field04 { get; set; }
        public short Static08 { get; set; } = 0;
        public short Field0A { get; set; }
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();

            // 1-3
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt16();

            // 0-2
            Field0A = reader.ReadInt16();

            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Field04 );
            writer.Write( Field0A );
            writer.Write( Unused0C );
        }
    }
}