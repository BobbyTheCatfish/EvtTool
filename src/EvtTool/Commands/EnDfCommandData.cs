using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnDfCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public int Field24 { get; set; }
        public int Static0C { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 3
            Field00 = reader.ReadInt32();
            // 0 or 4354
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            
            Static0C = reader.ReadInt32();
            // DOF values. not sure what does what yet though. might be Vector2, although there's 5... maybe a 2 and a 3?
            Field10 = reader.ReadSingle();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadSingle();

            Field24 = reader.ReadInt32();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32(); 
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
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
