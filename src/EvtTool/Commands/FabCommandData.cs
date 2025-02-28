using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class FabCommandData : CommandData
    {
        public Animation Animation1 { get; set; }
        public Animation Animation2 { get; set; }
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }
        public bool Field20 { get; set; }
        public float Field24 { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }
        public bool Field40 { get; set; }
        public float Field44 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
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
            }; // order isn't certain, but likely

            Animation2 = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                Static1 = reader.ReadInt32(),
                Static2 = reader.ReadInt32(),
            }; // order isn't certain, but is likely
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write(Animation1.ID);
            writer.Write(Animation1.InterpolatedFrames);
            writer.Write(Animation1.StartingFrame);
            writer.Write(Animation1.EndingFrame);
            writer.Write(Animation1.Loop == true ? 1 : 0);
            writer.Write(Animation1.Speed);
            writer.Write(Animation1.Static1);
            writer.Write(Animation1.Static2);
            writer.Write(Animation2.ID);
            writer.Write(Animation2.InterpolatedFrames);
            writer.Write(Animation2.StartingFrame);
            writer.Write(Animation2.EndingFrame);
            writer.Write(Animation2.Loop == true ? 1 : 0);
            writer.Write(Animation2.Speed);
            writer.Write(Animation2.Static1);
            writer.Write(Animation2.Static2);
        }
    }
}
