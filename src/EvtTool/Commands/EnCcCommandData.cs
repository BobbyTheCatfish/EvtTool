using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnCcCommandData : CommandData
    {
        public float Cyan { get; set; }
        public float Magenta { get; set; }
        public float Yellow { get; set; }
        public float Dodge { get; set; }
        public float Burn { get; set; }
        public int Static00 { get; set; } = 1;
        public int Static04 { get; set; } = 4354;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Static24 { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();

            Cyan = reader.ReadSingle();
            Magenta = reader.ReadSingle();
            Yellow = reader.ReadSingle();
            Dodge = reader.ReadSingle();
            Burn = reader.ReadSingle();

            Static24 = reader.ReadInt32();
            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write(Cyan);
            writer.Write(Magenta);
            writer.Write(Yellow);
            writer.Write(Dodge);
            writer.Write(Burn);
            writer.Write( Static24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}
