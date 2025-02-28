using System;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using EvtTool.IO;

namespace EvtTool
{
    internal class MsdCommandData : CommandData
    {
        public int Flags { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Animation WaitingAnimation { get; set; }
        public int Static30 { get; set; } = 0;
        public int Static34 { get; set; } = 0;
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            WaitingAnimation = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle()
            };


            // 0-10 or a huuuge number
            Flags = reader.ReadInt32();
            WaitingAnimation.StartingFrame = reader.ReadInt32();
            
            Static30 = reader.ReadInt32();
            Static34 = reader.ReadInt32();
            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Position );
            writer.Write( Rotation );
            writer.Write(WaitingAnimation.ID);
            writer.Write(WaitingAnimation.InterpolatedFrames);
            writer.Write(WaitingAnimation.Loop);
            writer.Write(WaitingAnimation.Speed);
            writer.Write( Flags );
            writer.Write(WaitingAnimation.StartingFrame);
            writer.Write( Static30 );
            writer.Write( Static34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
        }
    }
}