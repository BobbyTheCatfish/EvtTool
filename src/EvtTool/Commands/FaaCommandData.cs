using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class FaaCommandData : CommandData
    {
        public int Static00 { get; set; } = 174;
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;
        public bool Field20 { get; set; }
        public float Field24 { get; set; }
        public float Static28 { get; set; } = 1;
        public int Static2C { get; set; } = 0;
        public int Field30 { get; set; }
        public int Static34 { get; set; } = 0;
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;
        public int Static40 { get; set; } = 1;
        public float Static44 { get; set; } = 1;
        public float Static48 { get; set; } = 1;
        public int Static4C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // ranges from 31 to 62k
            Field04 = reader.ReadInt32();
            // 0-4
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            // 0-25
            Field10 = reader.ReadInt32();
            // 0, 43, or 170
            Field14 = reader.ReadInt32();

            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
            
            Field20 = reader.ReadInt32() == 1;
            // 0 or 6.9999999...
            Field24 = reader.ReadSingle();

            Static28 = reader.ReadSingle();
            Static2C = reader.ReadInt32();
            
            // 0 or 2
            Field30 = reader.ReadInt32();

            Static34 = reader.ReadInt32();
            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
            Static40 = reader.ReadInt32();
            Static44 = reader.ReadSingle();
            Static48 = reader.ReadSingle();
            Static4C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
            writer.Write( Field20 == true ? 1 : 0 );
            writer.Write( Field24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
            writer.Write( Field30 );
            writer.Write( Static34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
            writer.Write( Static40 );
            writer.Write( Static44 );
            writer.Write( Static48 );
            writer.Write( Static4C );
        }
    }
}
