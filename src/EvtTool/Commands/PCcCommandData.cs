using EvtTool.IO;

namespace EvtTool
{
    public sealed class PCcCommandData : CommandData
    {
        public int Field04 { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public float Field2C { get; set; }
        public int Field30 { get; set; }
        public float Field34 { get; set; }
        public int Field38 { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static08 { get; set; } = 4354;
        public int Static0C { get; set; } = 4354;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // small or large number
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();

            // 0 or a billion
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            
            // 0-1
            // probably dodge and burn
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            // probably CMY
            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadSingle();

            // 0-1
            Field2C = reader.ReadSingle();
            // 0 or a billion
            Field30 = reader.ReadInt32();
            // 0-1
            Field34 = reader.ReadSingle();

            Field38 = reader.ReadInt32();

            Static3C = reader.ReadInt32();
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
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Static3C );
        }
    }
}
