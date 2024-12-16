using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnHdCommandData : CommandData
    {
        public float BloomStrength { get; set; }
        public float Field18 { get; set; }
        public float BloomDampener { get; set; }
        public int GlareAngles { get; set; }
        public float GlareLength { get; set; }
        public float GlareStrength { get; set; }
        public float GlareSaturation { get; set; }
        public float GlareDirection { get; set; }
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public float Field10 { get; set; }
        public float Field34 { get; set; }
        public float Field38 { get; set; }
        public float Field3C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Field10 = reader.ReadSingle();
            BloomStrength = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            BloomDampener = reader.ReadSingle();
            GlareAngles = reader.ReadInt32();
            GlareLength = reader.ReadSingle();
            GlareStrength = reader.ReadSingle();
            GlareSaturation = reader.ReadSingle();
            GlareDirection = reader.ReadSingle();
            Field34 = reader.ReadSingle();
            Field38 = reader.ReadSingle();
            Field3C = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( BloomStrength );
            writer.Write( Field18 );
            writer.Write(BloomDampener);
            writer.Write( GlareAngles );
            writer.Write(GlareLength);
            writer.Write( GlareStrength );
            writer.Write( GlareSaturation );
            writer.Write(GlareDirection);
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
        }
    }
}
