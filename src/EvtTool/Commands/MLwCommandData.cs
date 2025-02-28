using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class MLwCommandData : CommandData
    {
        public float TopLimitAngle { get; set; }
        public float BottomLimitAngle { get; set; }
        public float LeftLimitAngle { get; set; }
        public float RightLimitAngle { get; set; }

        public int MinDelayFrames { get; set; }
        public int RandomDelayFrames { get; set; }
        public bool EnableUpperBodyRotation { get; set; }
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            EnableUpperBodyRotation = reader.ReadInt32() == 1;
            // i'd assume these would be xy rotation pairs
            TopLimitAngle = reader.ReadInt16();
            BottomLimitAngle = reader.ReadInt16();
            LeftLimitAngle = reader.ReadInt16();
            RightLimitAngle = reader.ReadInt16();
            // time until next look
            MinDelayFrames = reader.ReadInt32();
            RandomDelayFrames = reader.ReadInt32();

            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( EnableUpperBodyRotation );
            writer.Write( Direction1 );
            writer.Write( Direction2 );
            writer.Write( MinDelayFrames );
            writer.Write( RandomDelayFrames );
            writer.Write( Static1C );
        }
    }
}
