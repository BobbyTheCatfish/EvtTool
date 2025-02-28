using EvtTool.IO;

namespace EvtTool
{
    internal class MaabCommandData : CommandData
    {
        public int Flags { get; set; }
        public int ChildObjectID { get; set; }
        public Animation Animation1;
        public Animation Animation2;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Flags = reader.ReadInt32();

            ChildObjectID = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            Animation1 = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                Static1 = reader.ReadInt32(),
                Static2 = reader.ReadInt32()
            };

            Animation2 = new Animation()
            {
                ID = reader.ReadInt32(),
                InterpolatedFrames = reader.ReadInt32(),
                Loop = reader.ReadInt32() == 1,
                Speed = reader.ReadSingle(),
                StartingFrame = reader.ReadInt32(),
                EndingFrame = reader.ReadInt32(),
                Static1 = reader.ReadInt32(),
                Static2 = reader.ReadInt32()
            };
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( ChildObjectID );
            writer.Write( Static08 );
            writer.Write( Static0C );

            writer.Write(Animation1.ID);
            writer.Write(Animation1.InterpolatedFrames);
            writer.Write(Animation1.Loop == true ? 1 : 0);
            writer.Write(Animation1.Speed);
            writer.Write(Animation1.StartingFrame);
            writer.Write(Animation1.EndingFrame);
            writer.Write(Animation1.Static1);
            writer.Write(Animation1.Static2);

            writer.Write(Animation2.ID);
            writer.Write(Animation2.InterpolatedFrames);
            writer.Write(Animation2.Loop == true ? 1 : 0);
            writer.Write(Animation2.Speed);
            writer.Write(Animation2.StartingFrame);
            writer.Write(Animation2.EndingFrame);
            writer.Write(Animation2.Static1);
            writer.Write(Animation2.Static2);
        }
    }
}