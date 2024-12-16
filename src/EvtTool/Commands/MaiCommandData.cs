using EvtTool.IO;

namespace EvtTool
{
    public sealed class MaiCommandData : CommandData
    {
        public int Static00 { get; set; } = 0;
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public int Static10 { get; set; } = 0;
        public int Field14 { get; set; }
        public float Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public int Static24 { get; set; } = 0;
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public float Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Static3C { get; set; } = 0;
        public int Static40 { get; set; } = 0;
        public int Field44 { get; set; }
        public bool Field48 { get; set; }
        public int Field4C { get; set; }
        public int Field50 { get; set; }
        public int Static54 { get; set; } = 0;
        public int Static58 { get; set; } = 0;
        public int Field5C { get; set; }
        public float Static60 { get; set; } = 1;
        public int Field64 { get; set; }
        public int Field68 { get; set; }
        public int Static6C { get; set; } = 0;
        public int Static70 { get; set; } = 0;
        public int Field74 { get; set; }
        public float Static78 { get; set; } = 1;
        public int Field7C { get; set; }
        public int Field80 { get; set; }
        public int Static84 { get; set; } = 0;
        public int Static88 { get; set; } = 0;
        public int Field8C { get; set; }
        public float Static90 { get; set; } = 1;
        public int Field94 { get; set; }
        public int Field98 { get; set; }
        public int Static9C { get; set; } = 0;
        public int StaticA0 { get; set; } = 0;
        public int FieldA4 { get; set; }
        public float StaticA8 { get; set; } = 1;
        public int FieldAC { get; set; }
        public int FieldB0 { get; set; }
        public int StaticB4 { get; set; } = 0;
        public int StaticB8 { get; set; } = 0;
        public int FieldBC { get; set; }
        public float StaticC0 { get; set; } = 1;
        public int StaticC4 { get; set; } = 4;
        public int StaticC8 { get; set; } = 0;
        public int StaticCC { get; set; } = 0;
        public int StaticD0 { get; set; } = 0;
        public int StaticD4 { get; set; } = 0;
        public float StaticD8 { get; set; } = 1;
        public int StaticDC { get; set; } = 4;
        public int StaticE0 { get; set; } = 0;
        public int StaticE4 { get; set; } = 0;
        public int StaticE8 { get; set; } = 0;
        public int StaticEC { get; set; } = 0;
        public float StaticF0 { get; set; } = 1;
        public int StaticF4 { get; set; } = 0;
        public int StaticF8 { get; set; } = 0;
        public int StaticFC { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // 5 or 7
            Field04 = reader.ReadInt32();

            Field08 = reader.ReadInt32();
            // 0 or 45
            Field0C = reader.ReadInt32();

            Static10 = reader.ReadInt32();

            Field14 = reader.ReadInt32();
            Field18 = reader.ReadSingle();

            // 4-7
            Field1C = reader.ReadInt32();
            Field20 = reader.ReadInt32();

            Static24 = reader.ReadInt32();

            // 0, 45, 50
            Field28 = reader.ReadInt32();
            // 0-15
            Field2C = reader.ReadInt32();
            // 1 or .24999999...
            Field30 = reader.ReadSingle();
            // 4-7
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadInt32();

            Static3C = reader.ReadInt32();
            Static40 = reader.ReadInt32();
            
            // 0-15
            Field44 = reader.ReadInt32();
            Field48 = reader.ReadSingle() == 1;
            // 4 or 5
            Field4C = reader.ReadInt32();
            // 0-15
            Field50 = reader.ReadInt32();

            Static54 = reader.ReadInt32();
            Static58 = reader.ReadInt32();

            // 0-15
            Field5C = reader.ReadInt32();
            
            Static60 = reader.ReadSingle();

            // 4 or 5
            Field64 = reader.ReadInt32();
            // 0-55
            Field68 = reader.ReadInt32();
            
            Static6C = reader.ReadInt32();
            Static70 = reader.ReadInt32();

            // 0 or 10
            Field74 = reader.ReadInt32();

            Static78 = reader.ReadSingle();

            // 4 or 5
            Field7C = reader.ReadInt32();
            // 0-13
            Field80 = reader.ReadInt32();

            Static84 = reader.ReadInt32();
            Static88 = reader.ReadInt32();
            
            // 0 or 10
            Field8C = reader.ReadInt32();

            Static90 = reader.ReadSingle();

            // 0 or 10
            Field94 = reader.ReadInt32();
            // 0-13
            Field98 = reader.ReadInt32();

            Static9C = reader.ReadInt32();
            StaticA0 = reader.ReadInt32();
            
            // 0 or 10
            FieldA4 = reader.ReadInt32();

            StaticA8 = reader.ReadSingle();

            // 4 or 5
            FieldAC = reader.ReadInt32();
            // 0-13
            FieldB0 = reader.ReadInt32();

            StaticB4 = reader.ReadInt32();
            StaticB8 = reader.ReadInt32();
            
            // 0 or 10
            FieldBC = reader.ReadInt32();

            StaticC0 = reader.ReadSingle();
            StaticC4 = reader.ReadInt32();
            StaticC8 = reader.ReadInt32();
            StaticCC = reader.ReadInt32();
            StaticD0 = reader.ReadInt32();
            StaticD4 = reader.ReadInt32();
            StaticD8 = reader.ReadSingle();
            StaticDC = reader.ReadInt32();
            StaticE0 = reader.ReadInt32();
            StaticE4 = reader.ReadInt32();
            StaticE8 = reader.ReadInt32();
            StaticEC = reader.ReadInt32();
            StaticF0 = reader.ReadSingle();
            StaticF4 = reader.ReadInt32();
            StaticF8 = reader.ReadInt32();
            StaticFC = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Static10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Static24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Static3C );
            writer.Write( Static40 );
            writer.Write( Field44 );
            writer.Write( Field48 == true ? 1 : 0 );
            writer.Write( Field4C );
            writer.Write( Field50 );
            writer.Write( Static54 );
            writer.Write( Static58 );
            writer.Write( Field5C );
            writer.Write( Static60 );
            writer.Write( Field64 );
            writer.Write( Field68 );
            writer.Write( Static6C );
            writer.Write( Static70 );
            writer.Write( Field74 );
            writer.Write( Static78 );
            writer.Write( Field7C );
            writer.Write( Field80 );
            writer.Write( Static84 );
            writer.Write( Static88 );
            writer.Write( Field8C );
            writer.Write( Static90 );
            writer.Write( Field94 );
            writer.Write( Field98 );
            writer.Write( Static9C );
            writer.Write( StaticA0 );
            writer.Write( FieldA4 );
            writer.Write( StaticA8 );
            writer.Write( FieldAC );
            writer.Write( FieldB0 );
            writer.Write( StaticB4 );
            writer.Write( StaticB8 );
            writer.Write( FieldBC );
            writer.Write( StaticC0 );
            writer.Write( StaticC4 );
            writer.Write( StaticC8 );
            writer.Write( StaticCC );
            writer.Write( StaticD0 );
            writer.Write( StaticD4 );
            writer.Write( StaticD8 );
            writer.Write( StaticDC );
            writer.Write( StaticE0 );
            writer.Write( StaticE4 );
            writer.Write( StaticE8 );
            writer.Write( StaticEC );
            writer.Write( StaticF0 );
            writer.Write( StaticF4 );
            writer.Write( StaticF8 );
            writer.Write( StaticFC );
        }
    }
}
