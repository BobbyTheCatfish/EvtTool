using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class TRgsCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RegisterStatus Action { get; set; }
        public int Static00 { get; set; } = 0;
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Action = (RegisterStatus)reader.ReadInt32();
            // 0-3
            Field08 = reader.ReadInt32();
            // 0-5
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( (int)Action );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
        public enum RegisterStatus
        {
            Unknown = 0,
            Spawn = 1,
            Despawn = 2
        }
    }
}
