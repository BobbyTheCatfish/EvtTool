using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnShCommandData : CommandData
    {
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4354;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
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
