using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CarCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Unused04 { get; set; } = 0;
        public int Unused08 { get; set; } = 0;
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // might be the asset ID
            Field00 = reader.ReadInt32();
            // unused
            Unused04 = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Unused04 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
