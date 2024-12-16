using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class FlbkCommandData : CommandData
    {
        public short ImageMajorId { get; set; }
        public short ImageMinorId { get; set; }
        public int Opacity { get; set; }
        public int ObjDrawOverImage { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 1;
        public float Static10 { get; set; } = 80;
        public float Static14 { get; set; } = 250;
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Static28 { get; set; } = 15;
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Static38 { get; set; }
        public int Static3C { get; set; }
        public int Static40 { get; set; }
        public int Static44 { get; set; }
        public int Static48 { get; set; }
        public int Static4C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            ImageMajorId = reader.ReadInt16();
            ImageMinorId = reader.ReadInt16();
            Opacity = reader.ReadInt32();

            Static0C = reader.ReadInt32();
            Static10 = reader.ReadSingle();
            Static14 = reader.ReadSingle();
            
            // 2/3 or 1
            Field18 = reader.ReadSingle();
            // 2/3 or 2 2/3
            Field1C = reader.ReadSingle();
            // 1 2/3 or 3 1/3
            Field20 = reader.ReadSingle();
            // 3 or 3 1/3
            Field24 = reader.ReadSingle();

            Static28 = reader.ReadSingle();
            // 3 or 4
            ObjDrawOverImage = reader.ReadInt32();
            // 0-5
            Field30 = reader.ReadInt32();
            //0-9
            Field34 = reader.ReadInt32();

            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
            Static40 = reader.ReadInt32();
            Static44 = reader.ReadInt32();
            Static48 = reader.ReadInt32();
            Static4C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write(ImageMajorId);
            writer.Write(ImageMinorId);
            writer.Write(Opacity);
            writer.Write( Static0C );
            writer.Write( Static10 );
            writer.Write( Static14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Static28 );
            writer.Write( ObjDrawOverImage );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
            writer.Write( Static40 );
            writer.Write( Static44 );
            writer.Write( Static48 );
            writer.Write( Static4C );
        }
    }
}
