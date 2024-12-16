using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public class CShkCommandData : CommandData
    {
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        public int Static00 { get; set; } = 0;
        public bool Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static14 { get; set; } = 0;
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // probably a bool
            Field04 = reader.ReadInt32() == 1;
            Static08 = reader.ReadInt32();
            // most are around 0.5, but all are under 35
            SpeedX = reader.ReadSingle();
            SpeedY = reader.ReadSingle();
            Static14 = reader.ReadInt32();
            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();  
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 == true ? 1 : 0 );
            writer.Write( Static08 );
            writer.Write( SpeedX );
            writer.Write( SpeedY );
            writer.Write( Static14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
        }
    }
}