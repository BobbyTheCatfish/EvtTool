using EvtTool.IO;

namespace EvtTool
{
    internal class MRotCommandData : CommandData
    {
        public int Field00 { get; set; }
        public float Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public bool Field28 { get; set; }
        public float Field2C { get; set; }
        public float Field30 { get; set; }
        public float Static34 { get; set; } = 0;
        public float Static38 { get; set; } = 0;
        public float Static3C { get; set; } = 0;
        public float Field40 { get; set; }
        public int Field44 { get; set; }
        public bool Field48 { get; set; }
        public float Field4C { get; set; }
        public float Field50 { get; set; }
        public float Static54 { get; set; } = 0;
        public float Static58 { get; set; } = 0;
        public float Static5C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadSingle();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            // 4k-8k range
            Field10 = reader.ReadInt32();

            Field14 = reader.ReadInt32();
            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();

            Field28 = reader.ReadInt32() == 1;

            Field2C = reader.ReadSingle();
            Field30 = reader.ReadSingle();
            Static34 = reader.ReadSingle();
            Static38 = reader.ReadSingle();
            Static3C = reader.ReadSingle();
            
            // 0-10
            Field40 = reader.ReadSingle();
            Field44 = reader.ReadInt32();
            Field48 = reader.ReadInt32() == 1;
            // 0-6
            Field4C = reader.ReadSingle();
            // 0-10
            Field50 = reader.ReadSingle();

            Static54 = reader.ReadSingle();
            Static58 = reader.ReadSingle();
            Static5C = reader.ReadSingle();
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
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 == true ? 1 : 0 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Static34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
            writer.Write( Field40 );
            writer.Write( Field44 );
            writer.Write( Field48 == true ? 1 : 0 );
            writer.Write( Field4C );
            writer.Write( Field50 );
            writer.Write( Static54 );
            writer.Write( Static58 );
            writer.Write( Static5C );
        }
    }
}