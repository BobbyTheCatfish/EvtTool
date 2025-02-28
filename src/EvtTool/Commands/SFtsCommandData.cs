using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class SFtsCommandData : CommandData
    {
        public bool EnableFootsteps { get; set; }
        public int EvtObjectId { get; set; }
        public int Unused08 { get; set; }
        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            EnableFootsteps = reader.ReadInt32() == 1;
            EvtObjectId = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( EnableFootsteps == true ? 1 : 0 );
            writer.Write( EvtObjectId );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }

    }
}
