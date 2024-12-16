using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MsdCommandData : CommandData
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Field18 { get; set; }
        public float Field1C { get; set; }
        public int Field20 { get; set; }
        public float Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public int Static30 { get; set; } = 0;
        public int Static34 { get; set; } = 0;
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            // usually 0-50 but can be huge sometimes
            Field18 = reader.ReadInt32();
            // 1-10
            Field1C = reader.ReadSingle();
            // 0, 1, or negative a billion
            Field20 = reader.ReadInt32();
            // 0-10
            Field24 = reader.ReadSingle();
            // 0-10 or a huuuge number
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();

            Static30 = reader.ReadInt32();
            Static34 = reader.ReadInt32();
            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Position );
            writer.Write( Rotation );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Static30 );
            writer.Write( Static34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
        }
    }
}