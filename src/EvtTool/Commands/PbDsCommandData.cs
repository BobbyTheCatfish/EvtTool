using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class PbDsCommandData : CommandData
    {
        public Vector2 Shift1 { get; set; }
        public Vector2 Shift2 { get; set; }
        public int Static00 { get; set; } = 0;
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 4354;
        public int Static0C { get; set; } = 4354;
        public float Field10 { get; set; }
        public int Static1C { get; set; } = 0;
        public float Field20 { get; set; }
        public int Static2C { get; set; } = 0;
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Static38 { get; set; } = 0;
        public int Field3C { get; set; }
        public int Static40 { get; set; } = 4354;
        public int Static44 { get; set; } = 0;
        public int Static48 { get; set; } = 0;
        public int Static4C { get; set; } = 0;

        internal override void Read(Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // large number
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();

            // small number
            Field10 = reader.ReadSingle();
            // -1 - 1. probably controls
            Shift1 = reader.ReadVector2();

            Static1C = reader.ReadInt32();

            // small number
            Field20 = reader.ReadSingle();
            // -1 - 1. probably controls
            Shift2 = reader.ReadVector2();

            Static2C = reader.ReadInt32();

            // 0-5
            Field30 = reader.ReadInt32();
            // pos or neg (usually neg), large
            Field34 = reader.ReadInt32();

            Static38 = reader.ReadInt32();

            // small number
            Field3C = reader.ReadInt32();
            
            Static40 = reader.ReadInt32();
            Static44 = reader.ReadInt32();
            Static48 = reader.ReadInt32();
            Static4C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Shift1 );
            writer.Write( Static1C );
            writer.Write( Field20 );
            writer.Write( Shift2 );
            writer.Write( Static2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Static38 );
            writer.Write( Field3C );
            writer.Write( Static40 );
            writer.Write( Static44 );
            writer.Write( Static48 );
            writer.Write( Static4C );
        }
    }
}
