using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class MlCommandData : CommandData
    {
        public string Diffuse { get; set; }
        public string Ambient { get; set; }
        public string Specular { get; set; }
        public string Emissive { get; set; }
        public int Enabled { get; set; } = 0;
        public Vector2 Direction { get; set; }
        public int Static04 { get; set; } = 4354;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Enabled = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Diffuse = reader.ReadColor();
            Ambient = reader.ReadColor();
            Specular = reader.ReadColor();
            Emissive = reader.ReadColor();

            Direction = reader.ReadVector2();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Enabled );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.WriteColor(Diffuse);
            writer.WriteColor(Ambient);
            writer.WriteColor(Specular);
            writer.WriteColor(Emissive);
            writer.Write( Direction );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}
