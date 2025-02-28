using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MmdCommandData : CommandData
    {
        public int Flags { get; set; }
        public bool InterpolationType { get; set; }
        public int ControlGroupCount { get; set; }
        public float MovementSpeed { get; set; }
        public byte StartSpeedType { get; set; }
        public byte EndSpeedType { get; set; }
        public Animation MovingAnimation { get; set; }
        public Animation WaitingAnimation { get; set; }
        public Vector3[] Positions { get; set; } = new Vector3[24];
        public int UNK { get; set; }
        public int Static14C { get; set; } = 0;
        public int Static150 { get; set; } = 0;
        public int Static154 { get; set; } = 0;
        public int Static16C { get; set; } = 0;
        public int Static170 { get; set; } = 0;
        public int Static174 { get; set; } = 0;
        public int Static178 { get; set; } = 0;
        public int Static17C { get; set; } = 0;
        public short Unused136 { get; set; }
        internal override void Read( Command command, EndianBinaryReader reader )
        {
            InterpolationType = reader.ReadInt32() == 1;
            ControlGroupCount = reader.ReadInt32();

            for ( int i = 0; i < Positions.Length; i++ )
                Positions[ i ] = reader.ReadVector3();

            Flags = reader.ReadInt32();
            // 0-10
            MovementSpeed = reader.ReadSingle();
            
            UNK = reader.ReadInt32();
            StartSpeedType = reader.ReadByte();
            EndSpeedType = reader.ReadByte();
            Unused136 = reader.ReadInt16();

            MovingAnimation = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32()
            };

            Static14C = reader.ReadInt32();
            Static150 = reader.ReadInt32();
            Static154 = reader.ReadInt32();

            WaitingAnimation = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32()
            };

            Static16C = reader.ReadInt32();
            Static170 = reader.ReadInt32();
            Static174 = reader.ReadInt32();
            Static178 = reader.ReadInt32();
            Static17C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( InterpolationType == true ? 1 : 0 );
            writer.Write( ControlGroupCount );
            writer.Write( Positions );
            writer.Write( Flags );
            writer.Write( MovementSpeed );
            writer.Write( UNK );
            writer.Write( StartSpeedType );
            writer.Write( EndSpeedType );
            writer.Write( Unused136 );
            writer.Write(MovingAnimation.ID);
            writer.Write(MovingAnimation.InterpolatedFrames);
            writer.Write(MovingAnimation.Loop == true ? 1 : 0);
            writer.Write(MovingAnimation.Speed);
            writer.Write(MovingAnimation.StartingFrame);
            writer.Write( Static14C );
            writer.Write( Static150 );
            writer.Write( Static154 );
            writer.Write(WaitingAnimation.ID);
            writer.Write(WaitingAnimation.InterpolatedFrames);
            writer.Write(WaitingAnimation.Loop == true ? 1 : 0);
            writer.Write(WaitingAnimation.Speed);
            writer.Write(WaitingAnimation.StartingFrame);
            writer.Write( Static16C );
            writer.Write( Static170 );
            writer.Write( Static174 );
            writer.Write( Static178 );
            writer.Write( Static17C );
        }
}
}