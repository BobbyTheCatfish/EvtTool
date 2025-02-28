using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class ImDpCommandData : CommandData
    {
        public bool Show { get; set; }
        public bool PlayAnim { get; set; }
        public short PictId { get; set; }
        public short FrameId { get; set; }
        public int Static00 { get; set; } = 0;
        public short Static0A { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Show = reader.ReadBoolean();
            PlayAnim = reader.ReadBoolean();
            PictId = reader.ReadInt16();
            // is always 0 or 1.
            FrameId = reader.ReadInt16();

            Static0A = reader.ReadInt16();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write(Show);
            writer.Write(PlayAnim);
            writer.Write(PictId);
            writer.Write(FrameId);
            writer.Write(Static0A);
            writer.Write( Static0C );
        }
    }
}
