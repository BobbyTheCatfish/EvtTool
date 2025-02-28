using System.ComponentModel;
using System.Numerics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnL0CommandData : CommandData
    {
        public string Diffuse { get; set; }
        public string Ambient { get; set; }
        public string Specular { get; set; }
        public string Emissive { get; set; }
        public Vector2 Distance { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4354;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Static24 { get; set; } = 0;
        public int Static28 { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {

            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();

            Diffuse = reader.ReadColor();
            Ambient = reader.ReadColor();
            Specular = reader.ReadColor();
            Emissive = reader.ReadColor();
            Distance = reader.ReadVector2();
            // wiki says Z? But it's an int? and it's static?
            Static24 = reader.ReadInt32();
            Static28 = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.WriteColor( Diffuse );
            writer.WriteColor( Ambient );
            writer.WriteColor( Specular );
            writer.WriteColor( Emissive );
            writer.Write( Distance );
            writer.Write( Static24 );
            writer.Write( Static28 );
        }
    }
}
