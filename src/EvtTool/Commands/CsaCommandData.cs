using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CsaCommandData : CommandData
    {
        public int ParticlePakId { get; set; }
        public int CameraAnimation { get; set; }
        public float CameraSpeed { get; set; }
        public int SomeCameraBitfield { get; set; }
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public float Field30 { get; set; }
        public float Field34 { get; set; }
        public float Field38 { get; set; }
        public float Field3C { get; set; }
        public int Field40 { get; set; }
        public int Field44 { get; set; }
        public float Field48 { get; set; }
        public float Field4C { get; set; }
        public int Field50 { get; set; }
        public int Static2C { get; set; } = 0;
        public int Static54 { get; set; } = 0;
        public int Static58 { get; set; } = 0;
        public int Static5C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            SomeCameraBitfield = reader.ReadInt32();
            ParticlePakId = reader.ReadInt32();
            CameraAnimation = reader.ReadInt32();
            CameraSpeed = reader.ReadSingle();
            // int 0-60
            Field10 = reader.ReadInt32();
            // pos or neg int or float. vector?
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadSingle();
            // always 0
            Static2C = reader.ReadInt32();
            // pos or neg int or float. vector?
            Field30 = reader.ReadSingle();
            Field34 = reader.ReadSingle();
            Field38 = reader.ReadSingle();
            // float
            Field3C = reader.ReadSingle();
            // enum 0-4
            Field40 = reader.ReadInt32();
            // 4 or 5
            Field44 = reader.ReadInt32();
            // 375 or 565
            Field48 = reader.ReadSingle();
            // pos or neg int, usually very high or very very low
            Field4C = reader.ReadSingle();
            // large int
            Field50 = reader.ReadInt32();

            // always 0
            Static54 = reader.ReadInt32();
            Static58 = reader.ReadInt32();
            Static5C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( SomeCameraBitfield );
            writer.Write(ParticlePakId);
            writer.Write(CameraAnimation);
            writer.Write(CameraSpeed);
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Static2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
            writer.Write( Field40 );
            writer.Write( Field44 );
            writer.Write( Field48 );
            writer.Write( Field4C );
            writer.Write( Field50 );
            writer.Write( Static54 );
            writer.Write( Static58 );
            writer.Write( Static5C );
        }
    }
}
