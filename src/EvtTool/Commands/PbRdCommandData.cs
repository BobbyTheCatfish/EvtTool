using EvtTool.IO;

namespace EvtTool
{
    public sealed class PbRdCommandData : CommandData
    {
        public int Static00 { get; set; } = 0;
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 4354;
        public int Static0C { get; set; } = 4354;
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // 0-60 or a very large number
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            // 0-1
            Field10 = reader.ReadSingle();
            // -1 - 1
            Field14 = reader.ReadSingle();
            // small number
            Field18 = reader.ReadSingle();
            // larger number.  these two might be a vector, but might not either.
            Field1C = reader.ReadSingle();
            // 0-2
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}
