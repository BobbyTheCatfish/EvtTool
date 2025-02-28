using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class DateCommandData : CommandData
    {
        public bool Show { get; set; }
        public bool Field05 { get; set; }
        public int Static00 { get; set; } = 0;
        public short Unused06 { get; set; } = 0;
        public int Unused08 { get; set; } = 0;
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            // is always 1 or 2
            Show = reader.ReadBoolean();

            Field05 = reader.ReadBoolean();

            Unused06 = reader.ReadInt16();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Show );
            writer.Write( Field05 );
            writer.Write( Unused06 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
