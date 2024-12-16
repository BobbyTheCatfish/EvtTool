using EvtTool.IO;

namespace EvtTool
{
    public sealed class CsEcCommandData : CommandData
    {
        public int SomeBitfield { get; set; }
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // can we find a better name for this?
            SomeBitfield = reader.ReadInt32();
            // int in the 0-30ish range
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            // 2-5 are used
            Field10 = reader.ReadInt32();
            // decently high ints
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( SomeBitfield );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }
}
