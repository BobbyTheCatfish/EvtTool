using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MRotCommandData : CommandData
    {
        public int Flags { get; set; }
        public int InterpolationType { get; set; }
        public int UNK { get; set; }
        public Vector3 Rotation { get; set; }
        public Animation RotatingAnimation { get; set; }
        public Animation WaitingAnimation { get; set; }
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;
        public float Static34 { get; set; } = 0;
        public float Static38 { get; set; } = 0;
        public float Static3C { get; set; } = 0;
        public float Static54 { get; set; } = 0;
        public float Static58 { get; set; } = 0;
        public float Static5C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Flags = reader.ReadInt32();
            Rotation = reader.ReadVector3();
            InterpolationType = reader.ReadInt32(); // 4k-8k range, not sure if accurate name
            UNK = reader.ReadInt32();

            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();

            RotatingAnimation = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32()
            };


            Static34 = reader.ReadSingle();
            Static38 = reader.ReadSingle();
            Static3C = reader.ReadSingle();

            // 0-10
            WaitingAnimation = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32()
            };

            Static54 = reader.ReadSingle();
            Static58 = reader.ReadSingle();
            Static5C = reader.ReadSingle();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( Rotation );
            writer.Write( InterpolationType );
            writer.Write( UNK );
            writer.Write( Static18 );
            writer.Write( Static1C );
            writer.Write(RotatingAnimation.ID);
            writer.Write(RotatingAnimation.InterpolatedFrames);
            writer.Write(RotatingAnimation.Loop == true ? 1 : 0 );
            writer.Write(RotatingAnimation.Speed );
            writer.Write(RotatingAnimation.StartingFrame);
            writer.Write( Static34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
            writer.Write(WaitingAnimation.ID);
            writer.Write(WaitingAnimation.InterpolatedFrames);
            writer.Write(WaitingAnimation.Loop == true ? 1 : 0);
            writer.Write(WaitingAnimation.Speed);
            writer.Write(WaitingAnimation.StartingFrame);
            writer.Write( Static54 );
            writer.Write( Static58 );
            writer.Write( Static5C );
        }
    }
}