using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class MatOCommandData : CommandData
    {
        public int AttachObjectId { get; set; }
        public Vector3 PositionOffset {  get; set; }
        public Vector3 RotationOffset { get; set; }
        public int InterpolationType { get; set; } = 0;
        public int Static00 { get; set; } = 0;
        public int Static24 { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            AttachObjectId = reader.ReadInt32();
            PositionOffset = reader.ReadVector3();
            RotationOffset = reader.ReadVector3();
            InterpolationType = reader.ReadInt32();

            Static24 = reader.ReadInt32();
            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( AttachObjectId );
            writer.Write( PositionOffset );
            writer.Write( RotationOffset );
            writer.Write( InterpolationType );
            writer.Write( Static24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}
