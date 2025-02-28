using EvtTool.IO;

namespace EvtTool
{
    public sealed class ESclCommandData : CommandData
    {
        public int Flags { get; set; }
        public float Scale { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // 0 or 4354
            Flags = reader.ReadInt32();
            Scale = reader.ReadSingle();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Flags );
            writer.Write( Scale );
            writer.Write( Static0C );
        }
    }
}
