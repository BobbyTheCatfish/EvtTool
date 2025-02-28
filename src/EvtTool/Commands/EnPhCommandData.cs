using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnPhCommandData : CommandData
    {
        public bool Enabled { get; set; }
        public int Static04 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Enabled = reader.ReadInt32() == 1; // idk if this is true

            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Enabled == true ? 1 : 0 );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}
