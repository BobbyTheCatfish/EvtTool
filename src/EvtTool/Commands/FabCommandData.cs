using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class FabCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }
        public bool Field20 { get; set; }
        public float Field24 { get; set; }
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }
        public bool Field40 { get; set; }
        public float Field44 { get; set; }
        public int Static48 { get; set; } = 0;
        public int Static4C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
            Field20 = reader.ReadInt32() == 1;
            Field24 = reader.ReadSingle();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
            
            Field30 = reader.ReadInt32();
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadInt32();
            Field3C = reader.ReadInt32();
            Field40 = reader.ReadInt32() == 1;
            Field44 = reader.ReadSingle();

            Static48 = reader.ReadInt32();
            Static4C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 == true ? 1 : 0 );
            writer.Write( Field24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
            writer.Write( Field40 == true ? 1 : 0 );
            writer.Write( Field44 );
            writer.Write( Static48 );
            writer.Write( Static4C );
        }
    }
}
