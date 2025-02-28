using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EAlpCommandData : CommandData
    {
        public string Alpha { get; set; }
        public int Flags { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Alpha = reader.ReadColor();
            // 0, 1, or 4354
            Flags = reader.ReadInt32();
            
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.WriteColor( Alpha );
            writer.Write( Flags );
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
