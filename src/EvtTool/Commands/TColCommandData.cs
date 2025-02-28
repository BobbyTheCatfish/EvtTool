using EvtTool.IO;

namespace EvtTool
{
    public sealed class TColCommandData : CommandData
    {
        public string Color { get; set; }
        public int Field08 { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Color = Utils.ToHexString(reader.ReadBytes(4));
            // 0 or 4354
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Utils.ToBytes(Color) );
            writer.Write( Field08 );
            writer.Write( Static0C );
        }
    }
}
