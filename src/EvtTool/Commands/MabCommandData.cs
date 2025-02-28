using System.Runtime.Remoting.Messaging;
using EvtTool.IO;

namespace EvtTool
{
    internal class MabCommandData : CommandData
    {
        public class UnkAnimation : Animation { 
            public short UnkFrames { get; set; }
        }
        
        public int Flags { get; set; }
        public int StartWaitingFrames { get; set; }
        public UnkAnimation Animation1 { get; set; }
        public UnkAnimation Animation2 { get; set; }
        public int Static38 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Animation1 = new UnkAnimation()
            {
                ID = reader.ReadInt32(),
                UnkFrames = reader.ReadInt16(),
                InterpolatedFrames = reader.ReadInt16(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle()
            };

            Animation2 = new UnkAnimation()
            {
                ID = reader.ReadInt32(),
                UnkFrames = reader.ReadInt16(),
                InterpolatedFrames = reader.ReadInt16(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle()
            };

            Flags = reader.ReadInt32();
            
            Animation1.StartingFrame = reader.ReadInt32();
            Animation1.EndingFrame = reader.ReadInt32();

            Animation2.StartingFrame = reader.ReadInt32();
            Animation2.EndingFrame = reader.ReadInt32();

            StartWaitingFrames = reader.ReadInt32();

            Static38 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(Animation1.ID);
            writer.Write(Animation1.UnkFrames);
            writer.Write(Animation1.InterpolatedFrames);
            writer.Write(Animation1.Loop == true ? 1 : 0);
            writer.Write(Animation1.Speed);

            writer.Write(Animation2.ID);
            writer.Write(Animation2.UnkFrames);
            writer.Write(Animation2.InterpolatedFrames);
            writer.Write(Animation2.Loop == true ? 1 : 0);
            writer.Write(Animation2.Speed);

            writer.Write(Flags);

            writer.Write(Animation1.StartingFrame);
            writer.Write(Animation1.EndingFrame);

            writer.Write(Animation2.StartingFrame);
            writer.Write(Animation2.EndingFrame);

            writer.Write(StartWaitingFrames);
            writer.Write(Static38);
            writer.Write(Static0C);
        }
    }
}