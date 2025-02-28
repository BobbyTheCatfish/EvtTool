using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class FaaCommandData : CommandData
    {
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public Animation Animation1 { get; set; }
        public Animation Animation2 { get; set; }
        public int Static00 { get; set; } = 174;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // ranges from 31 to 62k
            Field04 = reader.ReadInt32();
            // 0-4
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            Animation1 = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                Static1 = reader.ReadInt32(),
                Static2 = reader.ReadInt32(),
            };

            Animation2 = new Animation()
            {
                ID = reader.ReadInt32(), // 0 or 2
                InterpolatedFrames = reader.ReadInt32(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1, // this one wasn't confirmed to be a boolean
                Speed = reader.ReadSingle(),
                Static1 = reader.ReadInt32(),
                Static2 = reader.ReadInt32(),
            };
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Static0C );
            writer.Write( Animation1.ID );
            writer.Write( Animation1.InterpolatedFrames );
            writer.Write( Animation1.StartingFrame );
            writer.Write( Animation1.EndingFrame );
            writer.Write( Animation1.Loop == true ? 1 : 0 );
            writer.Write( Animation1.Speed );
            writer.Write( Animation1.Static1 );
            writer.Write( Animation1.Static2 );
            writer.Write( Animation2.ID );
            writer.Write( Animation2.InterpolatedFrames );
            writer.Write( Animation2.StartingFrame );
            writer.Write( Animation2.EndingFrame );
            writer.Write( Animation2.Loop == true ? 1 : 0 );
            writer.Write( Animation2.Speed );
            writer.Write( Animation2.Static1 );
            writer.Write(Animation2.Static2);
        }
    }
}
