using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CwHtCommandData : CommandData
    {
        public bool Field00 { get; set; }
        public int Field04 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            // usually 3-6
            Field04 = reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( Field04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}
