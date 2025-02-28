using EvtTool.IO;

namespace EvtTool
{
    public sealed class McSdCommandData : CommandData
    {
        public int Flags { get; set; }
        public string InnerCircleColor { get; set; }
        public short InnerCircleDiameter { get; set; }
        public string OuterCircleColor { get; set; }
        public short OuterCircleDiameter { get; set; }
        public int Static0C { get; set; } = 0;
        public int Static14 { get; set; } = 0;
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 3
            Flags = reader.ReadInt32();
            // fairly large number
            InnerCircleColor = reader.ReadColor();
            OuterCircleColor = reader.ReadColor();

            Static0C = reader.ReadInt32();

            // fairly large number
            InnerCircleDiameter = reader.ReadInt16();
            OuterCircleDiameter = reader.ReadInt16();

            Static14 = reader.ReadInt32();
            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
            
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( InnerCircleColor );
            writer.Write( OuterCircleColor );
            writer.Write( Static0C );
            writer.Write( InnerCircleDiameter );
            writer.Write( Static14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
        }
    }
}
