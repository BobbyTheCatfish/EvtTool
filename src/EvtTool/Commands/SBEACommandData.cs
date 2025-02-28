using EvtTool.IO;

namespace EvtTool
{
    public sealed class SBEACommandData : CommandData
    {
        public int Action { get; set; }
        public int Unused00 { get; set; }
        public int Unused08 { get; set; }
        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Action = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Action );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
