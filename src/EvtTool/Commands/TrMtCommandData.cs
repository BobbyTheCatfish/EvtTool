using EvtTool.IO;

namespace EvtTool
{
    public sealed class TrMtCommandData : CommandData
    {
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public bool Field24 { get; set; }
        public bool Field28 { get; set; }
        public bool Field2C { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }
        public int Field40 { get; set; }
        public int Field44 { get; set; }
        public int Field48 { get; set; }
        public int Field4C { get; set; }
        public int Static00 { get; set; } = 241;
        public int Static0C { get; set; } = 0;
        public int Static50 { get; set; } = 0;
        public int Static54 { get; set; } = 0;
        public int Static58 { get; set; } = 0;
        public int Static5C { get; set; } = 0;
        public int Static60 { get; set; } = 0;
        public int Static64 { get; set; } = 0;
        public int Static68 { get; set; } = 0;
        public int Static6C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // small
            Field04 = reader.ReadInt32();
            // 60 or 120
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            // small
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
            // 1 or 4
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32() == 1;
            Field28 = reader.ReadInt32() == 1;
            Field2C = reader.ReadInt32() == 1;
            // 0 or 40081
            Field30 = reader.ReadInt32();
            // 0 or 7
            Field34 = reader.ReadInt32();
            // 0 or 3473461
            Field38 = reader.ReadInt32();
            // 0 or 3866683
            Field3C = reader.ReadInt32();
            // 0 or 4081
            Field40 = reader.ReadInt32();
            // 0 or 8
            Field44 = reader.ReadInt32();
            // 0 or 3538998
            Field48 = reader.ReadInt32();
            // 0 or 3932220
            Field4C = reader.ReadInt32();

            Static50 = reader.ReadInt32();
            Static54 = reader.ReadInt32();
            Static58 = reader.ReadInt32();
            Static5C = reader.ReadInt32();
            Static60 = reader.ReadInt32();
            Static64 = reader.ReadInt32();
            Static68 = reader.ReadInt32();
            Static6C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
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
            writer.Write( Field3C );
            writer.Write( Field40 );
            writer.Write( Field44 );
            writer.Write( Field48 );
            writer.Write( Field4C );
            writer.Write( Static50 );
            writer.Write( Static54 );
            writer.Write( Static58 );
            writer.Write( Static5C );
            writer.Write( Static60 );
            writer.Write( Static64 );
            writer.Write( Static68 );
            writer.Write( Static6C );
        }
    }
}
