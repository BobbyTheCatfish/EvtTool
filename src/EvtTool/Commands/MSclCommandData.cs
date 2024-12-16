using EvtTool.IO;

namespace EvtTool
{
    public sealed class MSclCommandData : CommandData
    {
        public float Scale { get; set; } = 0;
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4354;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            
            Scale = reader.ReadSingle();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Scale );
            writer.Write( Static0C );
        }
    }
}
