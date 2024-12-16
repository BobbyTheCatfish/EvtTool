using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class ERgsCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RegisterStatus Action { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Action = (RegisterStatus)reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( (int)Action );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }

        public enum RegisterStatus
        {
            Other = 0,
            Spawn = 1,
            Despawn = 2,
        }
    }
}
