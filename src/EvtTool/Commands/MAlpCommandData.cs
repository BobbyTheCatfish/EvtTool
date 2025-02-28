using EvtTool.IO;

namespace EvtTool
{
    public sealed class MAlpCommandData : CommandData
    {
        public string AlphaColor { get; set; }
        public int InterpolationParameters { get; set; }
        public byte TranslucentMode { get; set; }
        public int Static00 { get; set; } = 0;
        public byte Static11 { get; set; }
        public short Static12 { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            AlphaColor = reader.ReadColor();
            InterpolationParameters = reader.ReadInt32();
            TranslucentMode = reader.ReadByte();

            Static11 = reader.ReadByte();
            Static12 = reader.ReadInt16();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(Static00);
            writer.WriteColor(AlphaColor);
            writer.Write(InterpolationParameters);
            writer.Write(TranslucentMode);
            writer.Write(Static11);
            writer.Write(Static12);
        }
    }
}
