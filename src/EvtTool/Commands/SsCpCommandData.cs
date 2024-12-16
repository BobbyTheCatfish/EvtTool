using EvtTool.IO;

namespace EvtTool
{
    public sealed class SsCpCommandData : CommandData
    {
        public int DisplayDuration { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            DisplayDuration = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( DisplayDuration );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}
