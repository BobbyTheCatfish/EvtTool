using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MAtCommandData : CommandData
    {
        public int Flags { get; set; }
        public int AttachObjectId { get; set; }
        public int HelperBoneId { get; set; }
        public Vector3 PositionOffset { get; set; }
        public Vector3 RotationOffset { get; set; }
        public int Static0C { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 16
            Flags = reader.ReadInt32(); // likely attach frame, but also likely to be a bitfield
            HelperBoneId = reader.ReadInt32();
            AttachObjectId = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            PositionOffset = reader.ReadVector3();
            RotationOffset = reader.ReadVector3();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( HelperBoneId );
            writer.Write( AttachObjectId );
            writer.Write( Static0C );
            writer.Write( PositionOffset );
            writer.Write( RotationOffset );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}