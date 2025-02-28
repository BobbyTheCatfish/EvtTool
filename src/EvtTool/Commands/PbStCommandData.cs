using EvtTool.IO;

namespace EvtTool
{
    public sealed class PbStCommandData : CommandData
    {
        public int Field04 { get; set; }
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public int Field18 { get; set; }
        public float Field1C { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static08 { get; set; } = 4354;
        public int Static0C { get; set; } = 4354;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // small or large number
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            // 0-5ish
            Field10 = reader.ReadSingle();
            // small number
            Field14 = reader.ReadSingle();
            // 0-2
            Field18 = reader.ReadInt32();
            // very floaty float
            Field1C = reader.ReadSingle();
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
        }
    }
}
