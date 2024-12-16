using EvtTool.IO;

namespace EvtTool
{
    public sealed class PLfCommandData : CommandData
    {
        public int Field00 { get; set; }
        public float Field04 { get; set; }
        public float Field08 { get; set; }
        public float Field0C { get; set; }
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public bool Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public int Field30 { get; set; }
        public float Field34 { get; set; }
        public float Field38 { get; set; }
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0-2
            Field00 = reader.ReadInt32();
            // small to large
            Field04 = reader.ReadSingle();
            Field08 = reader.ReadSingle();
            Field0C = reader.ReadSingle();
            // has scientific notation
            Field10 = reader.ReadSingle();
            // 0-2
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadInt32() == 1;
            // small or large
            Field1C = reader.ReadInt32();
            // small
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();
            // large
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            // 0-5 or 272
            Field30 = reader.ReadInt32();
            // has scientific notation
            Field34 = reader.ReadSingle();
            Field38 = reader.ReadSingle();

            Static3C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 == true ? 1 : 0 );
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
