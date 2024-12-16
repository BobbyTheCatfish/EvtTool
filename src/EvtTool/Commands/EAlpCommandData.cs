using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EAlpCommandData : CommandData
    {
        public int Static00 { get; set; } = 0;
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // pos or neg int, high values
            Field04 = reader.ReadInt32();
            // 0, 1, or 4354
            Field08 = reader.ReadInt32();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Static0C );
        }
        public enum UnknownEAlp
        {
            Unknown = 0,
            Unknown1 = 1,
            Unknown2 = 4354,
        }
    }
}
