using System.ComponentModel;
using System.Numerics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CmdCommandData : CommandData
    {
        public int Flags { get; set; }
        public float Fov { get; set; }
        public Vector3 Position {  get; set; }
        public Vector3 Rotation { get; set; }
        public int Field24 { get; set; }
        public float Field28 { get; set; }
        public float Field2C { get; set; }
        public float Field30 { get; set; }

        public int Field34 { get; set; }
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 15 or 31
            Flags = reader.ReadInt32();
            
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            Fov = reader.ReadSingle();

            Field24 = reader.ReadInt32();

            Field28 = reader.ReadSingle();
            Field2C = reader.ReadSingle();
            Field30 = reader.ReadSingle();

            // 0-4
            Field34 = reader.ReadInt32();

            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( Position );
            writer.Write( Rotation );
            writer.Write( Fov );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
        }
    }
}
