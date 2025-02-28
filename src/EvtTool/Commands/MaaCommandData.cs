using EvtTool.IO;

namespace EvtTool
{
    public sealed class MaaCommandData : CommandData
    {
        public int Flags { get; set; }
        public int BlendAnimationID { get; set; }
        public float Weight { get; set; }
        public int TrackNumber { get; set; }
        public int InterpolatedFrames { get; set; }
        public bool Loop { get; set; }
        public float Speed { get; set; }
        public int StartingFrame { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0-7
            TrackNumber = reader.ReadInt32();
            BlendAnimationID = reader.ReadInt32();
            //0-100, most in the 10-30 range
            InterpolatedFrames = reader.ReadInt32();
            Weight = reader.ReadSingle();
            Loop = reader.ReadInt32() == 1;
            // 0-5
            Speed = reader.ReadSingle();
            //0-180, most around 10-30
            StartingFrame = reader.ReadInt32();
            //0 or negative 2 billion or something
            Flags = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(TrackNumber);
            writer.Write(BlendAnimationID);
            writer.Write(InterpolatedFrames);
            writer.Write(Weight);
            writer.Write(Loop == true ? 1 : 0 );
            writer.Write(Speed);
            writer.Write(StartingFrame);
            writer.Write(Flags);
        }
    }
}
