using EvtTool.IO;

namespace EvtTool
{
    public sealed class MaiCommandData : CommandData
    {

        public class IdleAnimation : Animation
        {
            public int Bitfield { get; set; }
        }

        public IdleAnimation Animation1 { get; set; }
        public IdleAnimation Animation2 { get; set; }
        public int Static00 { get; set; } = 0;
        public int StaticF4 { get; set; } = 0;
        public int StaticF8 { get; set; } = 0;
        public int StaticFC { get; set; } = 0;

        internal override void Read(Command command, EndianBinaryReader reader)
        {
            Static00 = reader.ReadInt32();
            Animation1 = new IdleAnimation()
            {
                Bitfield = reader.ReadInt32(),
                ID = reader.ReadInt32(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Speed = reader.ReadSingle()
            };

            Animation2 = new IdleAnimation()
            {
                Bitfield = reader.ReadInt32(),
                ID = reader.ReadInt32(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Speed = reader.ReadSingle()
            };

            StaticF4 = reader.ReadInt32();
            StaticF8 = reader.ReadInt32();
            StaticFC = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );

            writer.Write(Animation1.Bitfield);
            writer.Write(Animation1.ID);
            writer.Write(Animation1.StartingFrame);
            writer.Write(Animation1.EndingFrame);
            writer.Write(Animation1.InterpolatedFrames);
            writer.Write(Animation1.Speed);

            writer.Write(Animation2.Bitfield);
            writer.Write(Animation2.ID);
            writer.Write(Animation2.StartingFrame);
            writer.Write(Animation2.EndingFrame);
            writer.Write(Animation2.InterpolatedFrames);
            writer.Write(Animation2.Speed);

            writer.Write(StaticF4);
            writer.Write(StaticF8);
            writer.Write(StaticFC);
        }
    }
}
