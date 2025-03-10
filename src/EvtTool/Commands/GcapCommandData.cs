using EvtTool.IO;

namespace EvtTool
{
    public class GcapCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0-10
            Field00 = reader.ReadInt32();
            //about 0-20
            Field04 = reader.ReadInt32();
            //0-3
            Field08 = reader.ReadInt32();
            // 0-10
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}