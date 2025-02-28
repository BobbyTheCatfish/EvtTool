using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class ChtCommandData : CommandData
    {
        public int Field04 { get; set; }
        public int Unused00 { get; set; } = 0;
        public int Unused08 { get; set; } = 0;
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Field04 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
