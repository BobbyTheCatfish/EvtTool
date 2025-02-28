using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class MDtCommandData : CommandData
    {
        public int Flags { get; set; }
        public int DetachObjectId { get; set; }
        public int HelperBoneId { get; set; }
        public Vector3 PlacementPosition { get; set; }
        public Vector3 PlacementRotation { get; set; }
        public int Static0C { get; set; } = 0;
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Flags = reader.ReadInt32(); // also might be attachment frame
            HelperBoneId = reader.ReadInt32();
            DetachObjectId = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            PlacementPosition = reader.ReadVector3();
            PlacementRotation = reader.ReadVector3();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( HelperBoneId );
            writer.Write( DetachObjectId );
            writer.Write( Static0C );
            writer.Write( PlacementPosition );
            writer.Write( PlacementRotation );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}
